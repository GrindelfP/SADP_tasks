namespace taskFour
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.movieName = new System.Windows.Forms.TextBox();
            this.movieDuration = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.movieHasOscars = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateMovie = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.movieDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // movieName
            // 
            this.movieName.Location = new System.Drawing.Point(22, 24);
            this.movieName.Name = "movieName";
            this.movieName.Size = new System.Drawing.Size(210, 22);
            this.movieName.TabIndex = 0;
            this.movieName.Text = "Название фильма";
            this.movieName.Click += new System.EventHandler(this.movieName_Click);
            // 
            // movieDuration
            // 
            this.movieDuration.Location = new System.Drawing.Point(112, 51);
            this.movieDuration.Maximum = new decimal(new int[] {
            51420,
            0,
            0,
            0});
            this.movieDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.movieDuration.Name = "movieDuration";
            this.movieDuration.Size = new System.Drawing.Size(120, 22);
            this.movieDuration.TabIndex = 1;
            this.movieDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Время (мин)";
            // 
            // movieHasOscars
            // 
            this.movieHasOscars.FormattingEnabled = true;
            this.movieHasOscars.Items.AddRange(new object[] {
            "ДА",
            "НЕТ"});
            this.movieHasOscars.Location = new System.Drawing.Point(112, 80);
            this.movieHasOscars.Name = "movieHasOscars";
            this.movieHasOscars.Size = new System.Drawing.Size(121, 24);
            this.movieHasOscars.TabIndex = 3;
            this.movieHasOscars.Text = "Выберите:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "\"Оскары\"?";
            // 
            // CreateMovie
            // 
            this.CreateMovie.Location = new System.Drawing.Point(25, 116);
            this.CreateMovie.Name = "CreateMovie";
            this.CreateMovie.Size = new System.Drawing.Size(208, 23);
            this.CreateMovie.TabIndex = 5;
            this.CreateMovie.Text = "Создать объект";
            this.CreateMovie.UseVisualStyleBackColor = true;
            this.CreateMovie.Click += new System.EventHandler(this.CreateMovie_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CreateMovie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.movieHasOscars);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.movieDuration);
            this.Controls.Add(this.movieName);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.movieDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox movieName;
        private System.Windows.Forms.NumericUpDown movieDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox movieHasOscars;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CreateMovie;
    }
}

