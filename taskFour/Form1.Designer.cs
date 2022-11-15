namespace taskFour
{
    partial class ListPresentationForm
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
            this.listPresentation = new System.Windows.Forms.ListBox();
            this.AddToBeginning = new System.Windows.Forms.Button();
            this.Append = new System.Windows.Forms.Button();
            this.SortedAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Find = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.searchRemoveKey = new System.Windows.Forms.TextBox();
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
            this.movieHasOscars.Text = "НЕТ";
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
            // listPresentation
            // 
            this.listPresentation.FormattingEnabled = true;
            this.listPresentation.ItemHeight = 16;
            this.listPresentation.Location = new System.Drawing.Point(272, 24);
            this.listPresentation.Name = "listPresentation";
            this.listPresentation.Size = new System.Drawing.Size(502, 292);
            this.listPresentation.TabIndex = 6;
            // 
            // AddToBeginning
            // 
            this.AddToBeginning.Location = new System.Drawing.Point(25, 145);
            this.AddToBeginning.Name = "AddToBeginning";
            this.AddToBeginning.Size = new System.Drawing.Size(208, 23);
            this.AddToBeginning.TabIndex = 8;
            this.AddToBeginning.Text = "Добавить объект в начало";
            this.AddToBeginning.UseVisualStyleBackColor = true;
            this.AddToBeginning.Click += new System.EventHandler(this.AddToBeginning_Click);
            // 
            // Append
            // 
            this.Append.Location = new System.Drawing.Point(25, 174);
            this.Append.Name = "Append";
            this.Append.Size = new System.Drawing.Size(208, 23);
            this.Append.TabIndex = 9;
            this.Append.Text = "Добавить объект в конец";
            this.Append.UseVisualStyleBackColor = true;
            this.Append.Click += new System.EventHandler(this.Append_Click);
            // 
            // SortedAdd
            // 
            this.SortedAdd.Location = new System.Drawing.Point(25, 203);
            this.SortedAdd.Name = "SortedAdd";
            this.SortedAdd.Size = new System.Drawing.Size(208, 23);
            this.SortedAdd.TabIndex = 10;
            this.SortedAdd.Text = "Добавить упорядоченно";
            this.SortedAdd.UseVisualStyleBackColor = true;
            this.SortedAdd.Click += new System.EventHandler(this.SortedAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ключ поиска/удаления";
            // 
            // Find
            // 
            this.Find.Location = new System.Drawing.Point(15, 349);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(208, 23);
            this.Find.TabIndex = 13;
            this.Find.Text = "Найти";
            this.Find.UseVisualStyleBackColor = true;
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(15, 378);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(208, 23);
            this.Remove.TabIndex = 14;
            this.Remove.Text = "Удалить";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // searchRemoveKey
            // 
            this.searchRemoveKey.Location = new System.Drawing.Point(15, 323);
            this.searchRemoveKey.Name = "searchRemoveKey";
            this.searchRemoveKey.Size = new System.Drawing.Size(210, 22);
            this.searchRemoveKey.TabIndex = 15;
            this.searchRemoveKey.Text = "Название фильма";
            // 
            // ListPresentationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchRemoveKey);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.Find);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SortedAdd);
            this.Controls.Add(this.Append);
            this.Controls.Add(this.AddToBeginning);
            this.Controls.Add(this.listPresentation);
            this.Controls.Add(this.CreateMovie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.movieHasOscars);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.movieDuration);
            this.Controls.Add(this.movieName);
            this.Name = "ListPresentationForm";
            this.Text = "ListPresentationForm";
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
        private System.Windows.Forms.ListBox listPresentation;
        private System.Windows.Forms.Button AddToBeginning;
        private System.Windows.Forms.Button Append;
        private System.Windows.Forms.Button SortedAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Find;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.TextBox searchRemoveKey;
    }
}

