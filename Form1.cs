using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryAndUserCards
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryMyDataSet.book". При необходимости она может быть перемещена или удалена.
            this.bookTableAdapter.Fill(this.libraryMyDataSet.book);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryMyDataSet.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.libraryMyDataSet.users);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryMyDataSet.orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.libraryMyDataSet.orders);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Users().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Autor().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Book().Show();
        }

        //add
        private void button1_Click(object sender, EventArgs e)
        {
            if (isFill())
                try
                {
                    DataRowView row = (DataRowView)ordersBindingSource.AddNew();

                    row[1] = comboBox1.SelectedValue;
                    row[2] = comboBox1.SelectedValue;
                    row[3] = dateTimePicker1.Value;
                    row[4] = checkBox1.Checked;
                    ordersBindingSource.EndEdit();
                    this.ordersTableAdapter.Update(libraryMyDataSet);
                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            this.ordersTableAdapter.Fill(libraryMyDataSet.orders);

        }
        private bool isFill()
        {
           
            return true;
        }
        private void clearFields()
        {
           
        }
        //edit
        private void button2_Click(object sender, EventArgs e)
        {
            if (isFill())
                try
                {
                    
                    dataGridView1.CurrentRow.Cells[1].Value = comboBox1.SelectedValue;
                    dataGridView1.CurrentRow.Cells[2].Value = comboBox1.SelectedValue;
                    dataGridView1.CurrentRow.Cells[3].Value = dateTimePicker1.Value;
                    dataGridView1.CurrentRow.Cells[4].Value = checkBox1.Checked;

                    ordersBindingSource.EndEdit();
                    this.ordersTableAdapter.Update(((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row);
                    this.ordersTableAdapter.Fill(this.libraryMyDataSet.orders);

                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            this.ordersTableAdapter.Fill(this.libraryMyDataSet.orders);

        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow != null)
            {
                try
                {
                    libraryMyDataSet.AcceptChanges();
                    ordersBindingSource.RemoveAt(dataGridView1.CurrentRow.Index);
                    ordersBindingSource.EndEdit();
                    ordersTableAdapter.Update(libraryMyDataSet.orders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.ordersTableAdapter.Fill(this.libraryMyDataSet.orders);
            }
        }
    }
}
