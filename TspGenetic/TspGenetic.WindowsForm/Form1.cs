using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TspGenetic.Business;
using TspGenetic.Business.Crossover;
using TspGenetic.Business.Model;
using TspGenetic.Business.Mutation;
using TspGenetic.Business.ParentSelection;
using TspGenetic.Business.Service;
using TspGenetic.Business.SurvivorSelection;
using TspGenetic.WindowsForm.Enums;

namespace TspGenetic.WindowsForm
{
    public partial class Form1 : Form
    {
        private readonly static string kValidText = "10";
        private readonly static string kInvalidText = "Only for Tournament";

        public Form1()
        {
            InitializeComponent();
            Variables.startCity = City.Zahedan;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupTabIndexes();
            SetupComboBoxes();
            ResetToDefault();
            SetupLiveCharts();
        }

        private void SetupToolTip()
        {
            pbToolTip.Image = Image.FromFile(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\icon.png");
            pbToolTip.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void SetupTabIndexes()
        {
            cbStartCity.TabIndex = 0;
            tbPopulation.TabIndex = 1;
            tbMaximumIteration.TabIndex = 2;
            cbParentSelection.TabIndex = 3;
            tbKValue.TabIndex = 4;
            cbCrossover.TabIndex = 5;
            tbCrossoverProbability.TabIndex = 6;
            tbPcDecreaseRate.TabIndex = 7;
            cbMutation.TabIndex = 8;
            tbMutationProbability.TabIndex = 9;
            tbPmIncreaseRate.TabIndex = 10;
            cbSurvivorSelection.TabIndex = 11;
            btnRun.TabIndex = 12;
        }

        private void ResetToDefault()
        {
            cbStartCity.SelectedIndex = 0;
            tbPopulation.Text = "100";
            tbMaximumIteration.Text = "1000";
            cbParentSelection.SelectedIndex = 3;
            tbKValue.Text = kValidText;
            cbCrossover.SelectedIndex = 0;
            tbCrossoverProbability.Text = "0.7";
            tbPcDecreaseRate.Text = "0.99";
            cbMutation.SelectedIndex = 0;
            tbMutationProbability.Text = "0.005";
            tbPmIncreaseRate.Text = "1.01";
            cbSurvivorSelection.SelectedIndex = 0;
        }

        private void SetupComboBoxes()
        {
            SetupComboBox<City>(cbStartCity);

            SetupComboBox<ParentSelection>(cbParentSelection);

            SetupComboBox<Crossover>(cbCrossover);

            SetupComboBox<Mutation>(cbMutation);

            SetupComboBox<SurvivorSelection>(cbSurvivorSelection);
        }

        private void SetupLiveCharts()
        {
            cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;
        }

        private static void SetupComboBox<T>(ComboBox comboBox) where T : Enum
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox.Items.Clear();
            foreach (var item in Enum.GetValues(typeof(T)))
                comboBox.Items.Add(GetEnumDescription((T)item));
        }

        private static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        private void cbParentSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = cbParentSelection.SelectedIndex;

            if ((ParentSelection)selectedIndex == ParentSelection.Tournament)
            {
                tbKValue.Enabled = true;
                tbKValue.Text = kValidText;
            }
            else
            {
                tbKValue.Enabled = false;
                tbKValue.Text = kInvalidText;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                btnRun.Enabled = false;

                if (!int.TryParse(tbPopulation.Text, out int populationSize))
                    throw new Exception("Please enter a valid number for Population");

                if (!int.TryParse(tbMaximumIteration.Text, out int maxIteration))
                    throw new Exception("Please enter a valid number for Maximum Iteration");

                if (!double.TryParse(tbCrossoverProbability.Text, out double pc))
                    throw new Exception("Please enter a valid number for Crossover Probability");

                if (!double.TryParse(tbPcDecreaseRate.Text, out double pcDecreaseRate))
                    throw new Exception("Please enter a valid number for Pc Decrease Rate");

                if (!double.TryParse(tbMutationProbability.Text, out double pm))
                    throw new Exception("Please enter a valid number for Mutation Probability");

                if (!double.TryParse(tbPmIncreaseRate.Text, out double pmIncreaseRate))
                    throw new Exception("Please enter a valid number for Pm Increase Rate");

                var parentSelection = GetParentSelection((ParentSelection)cbParentSelection.SelectedIndex);
                var crossover = GetCrossover((Crossover)cbCrossover.SelectedIndex);
                var mutation = GetMutation((Mutation)cbMutation.SelectedIndex);
                var survivorSelection = GetSurvivorSelection((SurvivorSelection)cbSurvivorSelection.SelectedIndex);

                var (populations, population) = Helper.FindSolution2(populationSize, maxIteration, pc, pcDecreaseRate, pm, pmIncreaseRate, parentSelection, crossover, mutation, survivorSelection);

                Plot(populations);

                var cities = Helper.Decode(population.GetFittestIndividual());
                lblSolution.Text = $"Solution: {Helper.GetSolutionString(cities)}";

                lblCost.Text = $"Cost: {population.GetFittestIndividual().GetFitness()}";
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                btnRun.Enabled = true;
            }
        }

        private IParentSelection GetParentSelection(ParentSelection parentSelection)
        {
            switch (parentSelection)
            {
                case ParentSelection.RouletteWheel:
                    return new FpsParentSelection();
                case ParentSelection.RankBased:
                    return new RankBasedParentSelection();
                case ParentSelection.Stochastic:
                    return new SusParentSelection();
                case ParentSelection.Tournament:
                    if (!int.TryParse(tbKValue.Text, out int kValue))
                        throw new Exception("Please enter a valid number for K Value");
                    return new TournamentParentSelection(kValue);
                default:
                    throw new NotSupportedException("Invalid Parent Selection");
            }
        }

        private ICrossover GetCrossover(Crossover crossover)
        {
            switch (crossover)
            {
                case Crossover.OrderOne:
                    return new OrderOneCrossover();
                case Crossover.RotationBased:
                    return new RotationBasedCrossover();
                default:
                    throw new NotSupportedException("Invalid Crossover");
            }
        }

        private IMutation GetMutation(Mutation mutation)
        {
            switch (mutation)
            {
                case Mutation.Insersion:
                    return new InsertionMutation();
                case Mutation.Inversion:
                    return new InversionMutation();
                case Mutation.Scramble:
                    return new ScrambleMutation();
                case Mutation.Swap:
                    return new SwapMutation();
                default:
                    throw new NotSupportedException("Invalid Mutation");
            }
        }

        private ISurvivorSelection GetSurvivorSelection(SurvivorSelection survivorSelection)
        {
            switch (survivorSelection)
            {
                case SurvivorSelection.AgeBased:
                    return new AgeBasedSurvivorSelection();
                case SurvivorSelection.FitnessBased:
                    return new FitnessBasedSurvivorSelection();
                default:
                    throw new Exception("Invalid Survivor Selection");
            }
        }

        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Plot(List<Population> populations)
        {
            #region OxyPlot
            // create lines and fill them with data points
            // var line1 = new OxyPlot.Series.LineSeries()
            // {
            //     Title = $"Fitness Average",
            //     Color = OxyPlot.OxyColors.SeaGreen,
            //     StrokeThickness = 3,
            // };

            // var line2 = new OxyPlot.Series.LineSeries()
            // {
            //     Title = $"Fittest Chromosome",
            //     Color = OxyPlot.OxyColors.SkyBlue,
            //     StrokeThickness = 3,
            // };

            // for (var i = 0; i < populations.Count; i++)
            // {
            //     line1.Points.Add(new OxyPlot.DataPoint(i, populations[i].GetFitnessAverage()));
            //     line2.Points.Add(new OxyPlot.DataPoint(i, populations[i].GetFittestIndividual().GetFitness()));
            // }

            // create the model and add the lines to it
            //var model = new OxyPlot.PlotModel
            //{
            //    Title = "Fitness Function Graph"
            //};

            // model.Series.Add(line1);
            // model.Series.Add(line2);

            // load the model into the user control
            // plotView1.Model = model;
            #endregion

            #region LiveCharts
            //create series and populate them with data
            var series1 = new LiveCharts.Wpf.LineSeries()
            {
                Title = "Fitness Average",
                Values = new LiveCharts.ChartValues<double>(populations.Select(x => x.GetFitnessAverage()))
            };

            var series2 = new LiveCharts.Wpf.LineSeries()
            {
                Title = "Fittest Chromosome",
                Values = new LiveCharts.ChartValues<int>(populations.Select(x => x.GetFittestIndividual().GetFitness()))
            };

            var axisX = new LiveCharts.Wpf.Axis
            {
                Title = "Iteration"
            };
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(axisX);

            var axisY = new LiveCharts.Wpf.Axis
            {
                Title = "Fitness"
            };
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(axisY);

            //display the series in the chart control
            cartesianChart1.Series.Clear();
            cartesianChart1.Series.Add(series1);
            cartesianChart1.Series.Add(series2);

            pictureBox1.Visible = false;
            #endregion
        }

        private void cbStartCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Variables.startCity = (City)cbStartCity.SelectedIndex;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetToDefault();
        }

        private void pbToolTip_MouseHover(object sender, EventArgs e)
        {
            var toolTip = new ToolTip();
            toolTip.SetToolTip(this.pbToolTip, "Convergence stopping criteria will be applied automaticaly.");
        }
    }
}
