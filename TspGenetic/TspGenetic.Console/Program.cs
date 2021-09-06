using System.Collections.Generic;
using TspGenetic.Business;
using TspGenetic.Business.Crossover;
using TspGenetic.Business.Model;
using TspGenetic.Business.Mutation;
using TspGenetic.Business.ParentSelection;
using TspGenetic.Business.Service;
using TspGenetic.Business.SurvivorSelection;

namespace TspGenetic.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int populationSize = 100;
            int maxIteration = 500;
            int kValue = 10;
            double pc = 0.7;
            double pcDecreaseRate = 0.99;
            double pm = 0.005;
            double pmIncreaseRate = 1.01;
            (var solution, var cost) = FindSolution(populationSize, maxIteration, kValue, pc, pcDecreaseRate, pm, pmIncreaseRate);
            var solutionString = Helper.GetSolutionString(solution);
            System.Console.WriteLine($"Solution: {solutionString}\nCost: {cost}");
        }

        public static (City[], int) FindSolution(int populationSize, int maxIteration, int kValue, double pc, double pcDecreaseRate, double pm, double pmIncreaseRate)
        {
            IParentSelection parentSelection = new TournamentParentSelection(kValue);
            //IParentSelection parentSelection = new FpsParentSelection();
            //IParentSelection parentSelection = new SusParentSelection();
            //IParentSelection parentSelection = new RankBasedParentSelection();
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> TESTING PARENT SELECTION
            //var p1 = new Individual(new int[] { 5, 0, 9, 3, 6, 2, 7, 8, 4, 1 });
            //var p2 = new Individual(new int[] { 0, 5, 9, 3, 6, 2, 7, 8, 4, 1 });
            //var p3 = new Individual(new int[] { 5, 0, 6, 2, 7, 9, 3, 8, 4, 1 });

            //var p = new Population(new List<Individual> { p1, p2, p3 });
            //parentSelection.SelectParents(p);

            // Fitness:
            // [0]: 9518
            // [1]: 10986
            // [2]: 10120

            // 1 / Fitness:
            // [0]: 0.00010506408909434755
            // [1]: 0.00009102494083378846
            // [2]: 0.00009881422924901186

            // Sum = 0.0002949031

            // [1] 0.3086603701351393
            // [2] 0.335073452940983
            // [0] 0.3562661769238777
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            //ICrossover crossover = new OrderOneCrossover();
            ICrossover crossover = new RotationBasedCrossover();

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> TESTING CROSSOVER
            //var p1 = new Individual(new int[] { 5, 0, 9, 3, 6, 2, 7, 8, 4, 1 });
            //var p2 = new Individual(new int[] { 5, 0, 9, 3, 6, 2, 7, 8, 4, 1 });

            //(var c1, var c2) = crossover.Crossover(p1, p2);
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            //IMutation mutation = new SwapMutation();
            //IMutation mutation = new InsertionMutation();
            //IMutation mutation = new InversionMutation();
            IMutation mutation = new ScrambleMutation();

            ISurvivorSelection survivorSelection = new AgeBasedSurvivorSelection();

            return Helper.FindSolution(populationSize, maxIteration, pc, pcDecreaseRate, pm, pmIncreaseRate, parentSelection, crossover, mutation, survivorSelection);
        }
    }
}
