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
            updateAll();   
        }
        private void updateAll()
        {
            this.bookTableAdapter.Fill(this.libraryMyDataSet.book);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryMyDataSet.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.libraryMyDataSet.users);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryMyDataSet.orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.libraryMyDataSet.orders);
            fixName();
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
            fixName();
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
                    dataGridView1.CurrentRow.Cells[3].Value = comboBox1.SelectedValue;
                    dataGridView1.CurrentRow.Cells[5].Value = dateTimePicker1.Value;
                    dataGridView1.CurrentRow.Cells[6].Value = checkBox1.Checked;

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
            fixName();
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
            fixName();
        }
        private void fixName() {
            for (int i = 0; i < dataGridView1.RowCount; i++) {
                comboBox1.SelectedItem = comboBox1.Items[
                                                           usersBindingSource.Find(
                                                                       "id",
                                                                       int.Parse(dataGridView1[1, i].Value.ToString())
                                                                       )
                                                           ];
                dataGridView1[2, i].Value = comboBox1.Text;

                comboBox2.SelectedItem = comboBox2.Items[
                                            bookBindingSource.Find(
                                                        "id",
                                                        int.Parse(dataGridView1[3, i].Value.ToString())
                                                        )
                                            ];
                dataGridView1[4, i].Value = comboBox2.Text;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            updateAll();
        }
    }
}
