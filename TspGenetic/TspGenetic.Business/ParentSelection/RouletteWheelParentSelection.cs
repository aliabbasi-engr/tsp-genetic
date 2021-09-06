using System;
using System.Collections.Generic;
using System.Linq;
using TspGenetic.Business.Model;
using TspGenetic.Business.Service;

namespace TspGenetic.Business.ParentSelection
{
    public class RouletteWheelParentSelection
    {
        private readonly static int floatPrecision = 15;
        private readonly static double delta = Math.Pow(10, -1 * floatPrecision);

        protected static List<Triple> GetTriples(List<WeightedIndividual> weightedIndividuals)
        {
            var sum = weightedIndividuals.Sum(x => x.Weight);
            var individualShares = weightedIndividuals.Select(weightedIndividual => (weightedIndividual.Individual, Math.Round(weightedIndividual.Weight / sum, floatPrecision))).OrderBy(x => x.Item2);
            var triples = new List<Triple>();
            var lowerBound = 0.0;

            foreach (var individualShare in individualShares)
            {
                var upperBound = Math.Round(lowerBound + individualShare.Item2 - delta, floatPrecision);

                var triple = new Triple
                {
                    Individual = individualShare.Individual,
                    LowerBound = lowerBound,
                    UpperBound = upperBound
                };
                triples.Add(triple);

                lowerBound = Math.Round(upperBound + delta, floatPrecision);
            }
            triples.Last().UpperBound = 1;

            return triples;
        }

        protected static List<WeightedIndividual> GetFitnessBasedWeightedIndividuals(Population population)
        {
            return population.Individuals.Select(individual => new WeightedIndividual
            {
                Individual = individual,
                Weight = (double)1 / individual.GetFitness()
            }).ToList();
        }

        protected static List<WeightedIndividual> GetRankBasedWeightedIndividuals(Population population)
        {
            var weight = 1;
            var sortedIndividuals = population.Individuals.OrderByDescending(x => x.GetFitness());

            var weightedIndividuals = new List<WeightedIndividual>();
            foreach (var individual in sortedIndividuals)
            {
                var weightedIndividual = new WeightedIndividual
                {
                    Individual = individual,
                    Weight = weight
                };

                weightedIndividuals.Add(weightedIndividual);
                weight++;
            }

            return weightedIndividuals;
        }

        protected static Individual SelectParent(List<Triple> triples, double randomNumber)
        {
            return triples.First(x => randomNumber <= x.UpperBound).Individual;
        }

        protected class WeightedIndividual
        {
            public Individual Individual { get; set; }
            public double Weight { get; set; }
        }

        protected class Triple
        {
            public Individual Individual { get; set; }
            public double LowerBound { get; set; }
            public double UpperBound { get; set; }
        }
    }
}
