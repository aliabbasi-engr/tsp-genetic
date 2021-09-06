using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Drawing.Imaging;
using TspGenetic.Business.Model;
using TspGenetic.Business.Service;
using TspGenetic.Business.ParentSelection;
using TspGenetic.Business.Crossover;
using TspGenetic.Business.Mutation;
using TspGenetic.Business.SurvivorSelection;

namespace TspGenetic.Business
{
    public static class Helper
    {
        public static int GetRandomNumber(int lowerBound, int upperBound)
        {
            var r = new Random();
            return r.Next(lowerBound, upperBound);
        }

        public static (int, int) GetTwoRandomNumbers(int lowerBound, int upperBound, bool distinct)
        {
            var firstNumber = GetRandomNumber(lowerBound, upperBound);
            var secondNumber = GetRandomNumber(lowerBound, upperBound);
            
            if (distinct)
                while (secondNumber == firstNumber)
                    secondNumber = GetRandomNumber(lowerBound, upperBound);

            var min = Math.Min(firstNumber, secondNumber);
            var max = Math.Max(firstNumber, secondNumber);

            return (min, max);
        }

        public static double GetRandomNumber()
        {
            var r = new Random();
            return r.NextDouble();
        }

        public static bool IsConverging(List<Population> populations)
        {
            if (populations.Count < Constants.MIN_CONVERGENCE_COUNT)
                return false;

            var standardDeviation = GetStandardDeviation(populations.Select(x => x.GetFitnessAverage()).Skip(populations.Count - Constants.MIN_CONVERGENCE_COUNT).ToList());
            if (standardDeviation < Constants.CONVERGENCE_THRESHOLD)
                return true;

            return false;
        }

        private static double GetStandardDeviation(List<double> values)
        {
            var mean = values.Average();
            var a = values.Select(x => Math.Pow(x - mean, 2)).Sum();
            return Math.Sqrt(a / values.Count);
        }

        public static double DecreasePc(double pc, double decreaseRate)
        {
            return pc * decreaseRate;
        }

        public static double IncreasePm(double pm, double increaseRate)
        {
            return pm * increaseRate;
        }

        public static void SavePlot(List<Population> populations)
        {
            var pane = new ZedGraph.GraphPane();

            var curve1 = pane.AddCurve(
                label: "Fitness Average",
                x: Enumerable.Range(0, populations.Count).Select(x => (double)x).ToArray(),
                y: populations.Select(x => x.GetFitnessAverage()).ToArray(),
                color: Color.Blue);
            curve1.Line.IsAntiAlias = true;

            var curve2 = pane.AddCurve(
                label: "Fittest Chromosome",
                x: Enumerable.Range(0, populations.Count).Select(x => (double)x).ToArray(),
                y: populations.Select(x => (double)x.GetFittestIndividual().GetFitness()).ToArray(),
                color: Color.Green);
            curve2.Line.IsAntiAlias = true;

            pane.AxisChange();
            pane.Title.Text = "Fitness Function Graph";
            pane.XAxis.Title.Text = "Iteration";
            pane.YAxis.Title.Text = "Fitness";
            pane.Legend.Border.Width = 0;
            pane.Legend.Border.IsVisible = false;
            pane.Border.Width = 0;
            pane.Chart.Border.Width = 0;

            Bitmap bmp = pane.GetImage(1600, 1200, dpi: 100, isAntiAlias: true);
            bmp.Save("graph.png", ImageFormat.Png);
        }

        public static City[] Decode(Individual individual)
        {
            var solution = new City[10];
            
            for (int i = 0; i < individual.Chromosome.Length; i++)
                solution[i] = GetCity(individual.Chromosome[i]);

            return solution;
        }

        public static string GetSolutionString(City[] cities)
        {
            var temp = cities.ToList();
            temp.Add(cities[0]);

            return String.Join(" » ", temp);
        }

        public static City GetCity(int cityNumber)
        {
            return (City)cityNumber;
        }

        public static (City[], int) FindSolution(int populationSize, int maxIteration, double pc, double pcDecreaseRate, double pm, double pmIncreaseRate,
                       IParentSelection parentSelection, ICrossover crossover, IMutation mutation, ISurvivorSelection survivorSelection)
        {
            var populations = new List<Population>();
            var population = new Population();
            population.Initialize(populationSize);

            var iteration = 0;
            while (true)
            {
                populations.Add(population);

                if (Helper.IsConverging(populations) || iteration == maxIteration)
                    break;

                var randomNumber = Helper.GetRandomNumber();
                if (randomNumber < pc)
                {
                    (var parent1, var parent2) = parentSelection.SelectParents(population);

                    (var child1, var child2) = crossover.Crossover(parent1, parent2);
                    child1.Generation = iteration + 1;
                    child2.Generation = iteration + 1;

                    randomNumber = Helper.GetRandomNumber();
                    if (randomNumber < pm)
                        child1 = mutation.Mutate(child1);
                    population.Individuals.Add(child1);

                    randomNumber = Helper.GetRandomNumber();
                    if (randomNumber < pm)
                        child2 = mutation.Mutate(child2);
                    population.Individuals.Add(child2);

                    population = survivorSelection.SelectSuvivors(population, populationSize);

                    pc = Helper.DecreasePc(pc, pcDecreaseRate);
                    pm = Helper.IncreasePm(pm, pmIncreaseRate);
                }
                iteration++;
            }
            Helper.SavePlot(populations);
            return (Helper.Decode(population.GetFittestIndividual()), population.GetFittestIndividual().GetFitness());
        }

        public static (List<Population>, Population) FindSolution2(int populationSize, int maxIteration, double pc, double pcDecreaseRate, double pm, double pmIncreaseRate,
                       IParentSelection parentSelection, ICrossover crossover, IMutation mutation, ISurvivorSelection survivorSelection)
        {
            var populations = new List<Population>();
            var population = new Population();
            population.Initialize(populationSize);

            var iteration = 0;
            while (true)
            {
                populations.Add(population);

                if (Helper.IsConverging(populations) || iteration == maxIteration)
                    break;

                var randomNumber = Helper.GetRandomNumber();
                if (randomNumber < pc)
                {
                    (var parent1, var parent2) = parentSelection.SelectParents(population);

                    (var child1, var child2) = crossover.Crossover(parent1, parent2);
                    child1.Generation = iteration + 1;
                    child2.Generation = iteration + 1;

                    randomNumber = Helper.GetRandomNumber();
                    if (randomNumber < pm)
                        child1 = mutation.Mutate(child1);
                    population.Individuals.Add(child1);

                    randomNumber = Helper.GetRandomNumber();
                    if (randomNumber < pm)
                        child2 = mutation.Mutate(child2);
                    population.Individuals.Add(child2);

                    population = survivorSelection.SelectSuvivors(population, populationSize);

                    pc = Helper.DecreasePc(pc, pcDecreaseRate);
                    pm = Helper.IncreasePm(pm, pmIncreaseRate);
                }
                iteration++;
            }
            
            return (populations, population);
        }
    }
}
