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
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mydbDataSet.books". При необходимости она может быть перемещена или удалена.
            this.booksTableAdapter.Fill(this.mydbDataSet.books);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mydbDataSet.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.mydbDataSet.users);
            updateAll();   
        }
        private void updateAll()
        {
            this.historyTableAdapter.Fill(this.mydbDataSet.history);
            fixName();
        }


        //add
        private void button1_Click(object sender, EventArgs e)
        {
            if (isFill())
                try
                {
                    DataRowView row = (DataRowView)historyBindingSource.AddNew();

                    row[1] = comboBox1.SelectedValue;
                    row[2] = comboBox1.SelectedValue;
                    row[3] = dateTimePicker1.Value;
                    row[4] = checkBox1.Checked;
                    row[5] = dateTimePicker2.Value;
                    historyBindingSource.EndEdit();
                    this.historyTableAdapter.Update(mydbDataSet);
                    clearFields();

                    booksTableAdapter.UpdateCountById(-1, int.Parse(comboBox2.SelectedValue.ToString()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            this.historyTableAdapter.Fill(mydbDataSet.history);
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
                    int were = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                    dataGridView1.CurrentRow.Cells[1].Value = comboBox1.SelectedValue;
                    dataGridView1.CurrentRow.Cells[3].Value = comboBox2.SelectedValue;
                    dataGridView1.CurrentRow.Cells[5].Value = dateTimePicker1.Value;
                    dataGridView1.CurrentRow.Cells[6].Value = checkBox1.Checked;
                    dataGridView1.CurrentRow.Cells[7].Value = dateTimePicker2.Value;
                    historyBindingSource.EndEdit();
                    this.historyTableAdapter.Update(((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row);
                    this.historyTableAdapter.Fill(this.mydbDataSet.history);

                    clearFields();
                    booksTableAdapter.UpdateCountById(1, were);
                    booksTableAdapter.UpdateCountById(-1, int.Parse(comboBox2.SelectedValue.ToString()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            this.historyTableAdapter.Fill(this.mydbDataSet.history);
            fixName();
        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow != null)
            {
                try
                {
                    int were = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                    mydbDataSet.AcceptChanges();
                    historyBindingSource.RemoveAt(dataGridView1.CurrentRow.Index);
                    historyBindingSource.EndEdit();
                    historyTableAdapter.Update(mydbDataSet.history);
                    booksTableAdapter.UpdateCountById(1, were);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.historyTableAdapter.Fill(this.mydbDataSet.history);
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
                                            booksBindingSource.Find(
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

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            fixName();
        }
    }
}
