using System;
using TspGenetic.Business.Service;

namespace TspGenetic.Business.Model
{
    public class Individual
    {
        public int[] Chromosome { get; set; }

        public int Generation { get; set; }

        public Individual()
        {
            Chromosome = new int[Constants.CHROMOSE_LENGHT];
            Array.Fill(Chromosome, -1);
        }

        public Individual(int[] chromosome)
        {
            Chromosome = chromosome;
        }

        public Individual Clone()
        {
            var chromosome = new int[Constants.CHROMOSE_LENGHT];
            Array.Copy(Chromosome, chromosome, Constants.CHROMOSE_LENGHT);
            return new Individual(chromosome);
        }

        public int GetFitness()
        {
            if (Chromosome[0] != (int)Variables.startCity)
                return 25000;

            var distanceSum = 0;

            for (int i = 0; i < Chromosome.Length - 1; i++)
            {
                var distance = Map.GetDistance(Helper.GetCity(Chromosome[i]), Helper.GetCity(Chromosome[i + 1]));
                if (distance == 0)
                    return 25000;

                distanceSum += distance;
            }

            var returnDistance = Map.GetDistance(Helper.GetCity(Chromosome[Chromosome.Length - 1]), Helper.GetCity(0));
            return distanceSum + returnDistance;
        }
    }
}