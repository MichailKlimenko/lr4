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
    public partial class Form1 : Form
    {
        LinkedList<int> linkedList;
        public Form1()
        {
            InitializeComponent();
            linkedList = new LinkedList<int>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count;
            if (!int.TryParse(textBox1.Text, out count))
            {
                MessageBox.Show("Введите корректное количество элементов.");
                return;
            }

            Random random = new Random();
            linkedList.Clear();
            for (int i = 0; i < count; i++)
            {
                linkedList.AddLast(random.Next(11)); // Добавляем случайные числа от 0 до 99 в список
            }

            UpdateListBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LinkedListNode<int> currentNode = linkedList.First;
            while (currentNode != null)
            {
                if (currentNode.Value == 10)
                {
                    linkedList.Remove(currentNode);
                    break; // Удаляем только первое вхождение числа 10
                }
                currentNode = currentNode.Next;
            }

            UpdateListBox();
        }
        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (var item in linkedList)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
