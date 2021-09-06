
namespace TspGenetic.WindowsForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbParentSelection = new System.Windows.Forms.ComboBox();
            this.cbCrossover = new System.Windows.Forms.ComboBox();
            this.cbMutation = new System.Windows.Forms.ComboBox();
            this.cbSurvivorSelection = new System.Windows.Forms.ComboBox();
            this.tbPopulation = new System.Windows.Forms.TextBox();
            this.tbMaximumIteration = new System.Windows.Forms.TextBox();
            this.tbCrossoverProbability = new System.Windows.Forms.TextBox();
            this.tbPcDecreaseRate = new System.Windows.Forms.TextBox();
            this.tbMutationProbability = new System.Windows.Forms.TextBox();
            this.tbPmIncreaseRate = new System.Windows.Forms.TextBox();
            this.tbKValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.lblSolution = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbStartCity = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.pbToolTip = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToolTip)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mutation Probability (0 ~ 1):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Crossover Probability (0 ~ 1):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Population:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Maximum Iteration:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "K Value:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Pc Decrease Rate:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 452);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Pm Increase Rate:";
            // 
            // cbParentSelection
            // 
            this.cbParentSelection.FormattingEnabled = true;
            this.cbParentSelection.Location = new System.Drawing.Point(243, 147);
            this.cbParentSelection.Name = "cbParentSelection";
            this.cbParentSelection.Size = new System.Drawing.Size(151, 28);
            this.cbParentSelection.TabIndex = 11;
            this.cbParentSelection.SelectedIndexChanged += new System.EventHandler(this.cbParentSelection_SelectedIndexChanged);
            // 
            // cbCrossover
            // 
            this.cbCrossover.FormattingEnabled = true;
            this.cbCrossover.Location = new System.Drawing.Point(243, 228);
            this.cbCrossover.Name = "cbCrossover";
            this.cbCrossover.Size = new System.Drawing.Size(151, 28);
            this.cbCrossover.TabIndex = 12;
            // 
            // cbMutation
            // 
            this.cbMutation.FormattingEnabled = true;
            this.cbMutation.Location = new System.Drawing.Point(243, 359);
            this.cbMutation.Name = "cbMutation";
            this.cbMutation.Size = new System.Drawing.Size(151, 28);
            this.cbMutation.TabIndex = 13;
            // 
            // cbSurvivorSelection
            // 
            this.cbSurvivorSelection.FormattingEnabled = true;
            this.cbSurvivorSelection.Location = new System.Drawing.Point(243, 490);
            this.cbSurvivorSelection.Name = "cbSurvivorSelection";
            this.cbSurvivorSelection.Size = new System.Drawing.Size(151, 28);
            this.cbSurvivorSelection.TabIndex = 14;
            // 
            // tbPopulation
            // 
            this.tbPopulation.Location = new System.Drawing.Point(243, 66);
            this.tbPopulation.Name = "tbPopulation";
            this.tbPopulation.Size = new System.Drawing.Size(151, 27);
            this.tbPopulation.TabIndex = 15;
            // 
            // tbMaximumIteration
            // 
            this.tbMaximumIteration.Location = new System.Drawing.Point(243, 107);
            this.tbMaximumIteration.Name = "tbMaximumIteration";
            this.tbMaximumIteration.Size = new System.Drawing.Size(151, 27);
            this.tbMaximumIteration.TabIndex = 16;
            // 
            // tbCrossoverProbability
            // 
            this.tbCrossoverProbability.Location = new System.Drawing.Point(243, 272);
            this.tbCrossoverProbability.Name = "tbCrossoverProbability";
            this.tbCrossoverProbability.Size = new System.Drawing.Size(151, 27);
            this.tbCrossoverProbability.TabIndex = 17;
            // 
            // tbPcDecreaseRate
            // 
            this.tbPcDecreaseRate.Location = new System.Drawing.Point(243, 316);
            this.tbPcDecreaseRate.Name = "tbPcDecreaseRate";
            this.tbPcDecreaseRate.Size = new System.Drawing.Size(151, 27);
            this.tbPcDecreaseRate.TabIndex = 18;
            // 
            // tbMutationProbability
            // 
            this.tbMutationProbability.Location = new System.Drawing.Point(243, 404);
            this.tbMutationProbability.Name = "tbMutationProbability";
            this.tbMutationProbability.Size = new System.Drawing.Size(151, 27);
            this.tbMutationProbability.TabIndex = 19;
            // 
            // tbPmIncreaseRate
            // 
            this.tbPmIncreaseRate.Location = new System.Drawing.Point(243, 449);
            this.tbPmIncreaseRate.Name = "tbPmIncreaseRate";
            this.tbPmIncreaseRate.Size = new System.Drawing.Size(151, 27);
            this.tbPmIncreaseRate.TabIndex = 20;
            // 
            // tbKValue
            // 
            this.tbKValue.Location = new System.Drawing.Point(243, 188);
            this.tbKValue.Name = "tbKValue";
            this.tbKValue.Size = new System.Drawing.Size(151, 27);
            this.tbKValue.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Parent Selection Mode:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Crossover Mode:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 362);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "Mutation Mode:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 493);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(173, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "Survivor Selection Mode:";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(300, 550);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(94, 29);
            this.btnRun.TabIndex = 26;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 603);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(696, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Computational Inteligence (2014335), Project 1, Ordibehesht 1400, Dr M Rezai, Ali" +
    " Abbasi, Dorsa Sayadi.";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(409, 33);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(858, 453);
            this.cartesianChart1.TabIndex = 29;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // lblSolution
            // 
            this.lblSolution.AutoSize = true;
            this.lblSolution.Location = new System.Drawing.Point(414, 516);
            this.lblSolution.Name = "lblSolution";
            this.lblSolution.Size = new System.Drawing.Size(67, 20);
            this.lblSolution.TabIndex = 30;
            this.lblSolution.Text = "Solution:";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(414, 553);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(41, 20);
            this.lblCost.TabIndex = 31;
            this.lblCost.Text = "Cost:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 20);
            this.label15.TabIndex = 33;
            this.label15.Text = "Start City:";
            // 
            // cbStartCity
            // 
            this.cbStartCity.FormattingEnabled = true;
            this.cbStartCity.Location = new System.Drawing.Point(243, 23);
            this.cbStartCity.Name = "cbStartCity";
            this.cbStartCity.Size = new System.Drawing.Size(151, 28);
            this.cbStartCity.TabIndex = 34;
            this.cbStartCity.SelectedIndexChanged += new System.EventHandler(this.cbStartCity_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(409, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(858, 485);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(200, 550);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 29);
            this.btnReset.TabIndex = 36;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pbToolTip
            // 
            this.pbToolTip.Image = global::TspGenetic.WindowsForm.Properties.Resources.icon;
            this.pbToolTip.Location = new System.Drawing.Point(165, 110);
            this.pbToolTip.Name = "pbToolTip";
            this.pbToolTip.Size = new System.Drawing.Size(20, 20);
            this.pbToolTip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbToolTip.TabIndex = 38;
            this.pbToolTip.TabStop = false;
            this.pbToolTip.MouseHover += new System.EventHandler(this.pbToolTip_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 644);
            this.Controls.Add(this.pbToolTip);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbStartCity);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblSolution);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbKValue);
            this.Controls.Add(this.tbPmIncreaseRate);
            this.Controls.Add(this.tbMutationProbability);
            this.Controls.Add(this.tbPcDecreaseRate);
            this.Controls.Add(this.tbCrossoverProbability);
            this.Controls.Add(this.tbMaximumIteration);
            this.Controls.Add(this.tbPopulation);
            this.Controls.Add(this.cbSurvivorSelection);
            this.Controls.Add(this.cbMutation);
            this.Controls.Add(this.cbCrossover);
            this.Controls.Add(this.cbParentSelection);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "TSP Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToolTip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbParentSelection;
        private System.Windows.Forms.ComboBox cbCrossover;
        private System.Windows.Forms.ComboBox cbMutation;
        private System.Windows.Forms.ComboBox cbSurvivorSelection;
        private System.Windows.Forms.TextBox tbPopulation;
        private System.Windows.Forms.TextBox tbMaximumIteration;
        private System.Windows.Forms.TextBox tbCrossoverProbability;
        private System.Windows.Forms.TextBox tbPcDecreaseRate;
        private System.Windows.Forms.TextBox tbMutationProbability;
        private System.Windows.Forms.TextBox tbPmIncreaseRate;
        private System.Windows.Forms.TextBox tbKValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label12;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Label lblSolution;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbStartCity;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.PictureBox pbToolTip;
    }
}

