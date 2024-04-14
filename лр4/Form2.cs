using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лр4
{
    public partial class Form2 : Form
    {
        private List<Train> trains = new List<Train>();
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string destination = textBox4 .Text;
            int trainNumber = Convert.ToInt32(textBox3 .Text);
            DateTime departureTime = dateTimePicker2.Value;

            if (string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            Train newTrain = new Train(destination, trainNumber, departureTime);
            trains.Add(newTrain);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = trains;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchDestination = textBox1.Text;

            List<Train> searchResults = new List<Train>();

            foreach (Train train in trains)
            {
                if (train.Destination.Contains(searchDestination))
                {
                    searchResults.Add(train);
                }
            }

            dataGridView1.DataSource = searchResults;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1 .Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3 .Text = "";
            textBox4 .Text = "";
            dateTimePicker2 .Value = DateTime.Now;
        }
        public class Train
        {
            public string Destination { get; }
            public int TrainNumber { get; }
            public DateTime DepartureTime { get; }

            public Train(string destination, int trainNumber, DateTime departureTime)
            {
                Destination = destination;
                TrainNumber = trainNumber;
                DepartureTime = departureTime;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = trains;
        }
    }
}
