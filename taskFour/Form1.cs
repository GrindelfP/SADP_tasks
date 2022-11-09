using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taskFour
{
    public partial class ListPresentationForm : Form
    {
        private readonly LinkedList linkedList = new LinkedList();
        private Movie movie;

        public ListPresentationForm()
        {
            InitializeComponent();
        }

        private void movieName_Click(object sender, EventArgs e)
        {
            movieName.Text = "";
        }

        private void CreateMovie_Click(object sender, EventArgs e)
        {
            movie = new Movie(movieName.Text, 
                (int)movieDuration.Value, 
                (string)movieHasOscars.SelectedItem == "ДА");
        }

        private void Visualize_Click(object sender, EventArgs e)
        {
            listPresentation.Items.Clear();
            foreach (var item in linkedList.Show())
            {
                listPresentation.Items.Add(item);
            } 
            
        }

        private void AddToBeginning_Click(object sender, EventArgs e)
        {
            linkedList.AddToBeggining(movie);
        }

        private void Append_Click(object sender, EventArgs e)
        {
            linkedList.Add(movie);
        }

        private void SortedAdd_Click(object sender, EventArgs e)
        {
            linkedList.AddToSorted(movie);
        }

        private void Find_Click(object sender, EventArgs e)
        {
            MessageBox.Show(linkedList.Find(searchRemoveKey.Text).ToString());
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            linkedList.Remove(searchRemoveKey.Text);
        }
    }
}
