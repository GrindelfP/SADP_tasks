using System;
using System.Windows.Forms;

namespace taskSix
{
    public partial class TreePresentation : Form
    {
        private readonly Tree _tree;
        private Movie movie;

        public TreePresentation()
        {
            InitializeComponent();
            _tree = new Tree();
        }

        private void CreateMovie_Click(object sender, EventArgs e)
        {
            movie = new Movie(movieName.Text, 
                (int)movieDuration.Value, 
                (string)movieHasOscars.SelectedItem == "ДА");
        }

        private void Add_Click(object sender, EventArgs e)
        {
            bool added = _tree.Add(movie);
            if (!added) MessageBox.Show("Не добавлен!");
            VisualizeList();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            Movie foundMovie = _tree.Find((int)movieDurationKey.Value); // stopped here
            string isFound = foundMovie != null ? foundMovie.ToString() : "Не найдено";
            MessageBox.Show(isFound);
            
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            bool removed = _tree.Remove((int)movieDurationKey.Value);
            if (!removed) MessageBox.Show("Не найден!");
            VisualizeList();
        }

        private void VisualizeList()
        {
            _tree.Visualize(listPresentation);
        }
    }
}