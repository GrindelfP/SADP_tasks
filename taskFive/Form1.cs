using System;
using System.Windows.Forms;

namespace taskFive
{
    public partial class ListPresentationForm : Form
    {
        private VectorList vectorList;
        private Movie movie;

        public ListPresentationForm()
        {
            InitializeComponent();
        }

        private void CreateList_Click(object sender, EventArgs e)
        {
            vectorList = new VectorList((int)ArraySize.Value);
        }

        private void CreateMovie_Click(object sender, EventArgs e)
        {
            movie = new Movie(movieName.Text, 
                (int)movieDuration.Value, 
                (string)movieHasOscars.SelectedItem == "ДА");
        }

        private void AddToBeginning_Click(object sender, EventArgs e)
        {
            bool added = vectorList.AddToBeggining(movie);
            if (!added) MessageBox.Show("Не добавлен!");
            VisualizeList();
        }

        private void Append_Click(object sender, EventArgs e)
        {
            bool added = vectorList.Append(movie);
            if (!added) MessageBox.Show("Не добавлен!");
            VisualizeList();
        }

        private void SortedAdd_Click(object sender, EventArgs e)
        {
            bool added = vectorList.SortedAdd(movie);
            if (!added) MessageBox.Show("Не добавлен!");
            VisualizeList();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            Movie foundMovie = vectorList.Find(searchRemoveKey.Text);
            string isFound = foundMovie != null ? foundMovie.ToString() : "Не найдено";
            MessageBox.Show(isFound);
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            bool removed = vectorList.Remove(searchRemoveKey.Text);
            if (!removed) MessageBox.Show("Не найден!");
            VisualizeList();
        }

        private void VisualizeList()
        {
            vectorList.Show(listPresentation);
        }
    }
}
