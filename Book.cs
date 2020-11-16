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
    public partial class Book : Form
    {
        public Book()
        {
            InitializeComponent();
        }

        private void Book_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryMyDataSet1.autor". При необходимости она может быть перемещена или удалена.
            this.autorTableAdapter.Fill(this.libraryMyDataSet1.autor);

            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryMyDataSet.book". При необходимости она может быть перемещена или удалена.
            this.bookTableAdapter.Fill(this.libraryMyDataSet.book);

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
        //add
        private void button1_Click(object sender, EventArgs e)
        {
            if (isFill())
                try
                {
                    DataRowView row = (DataRowView)bookBindingSource.AddNew();

                    row[1] = comboBox1.Text;
                    row[2] = textBox1.Text;
                    row[3] = textBox2.Text;
                    row[4] = textBox3.Text;

                    bookBindingSource.EndEdit();
                    this.bookTableAdapter.Update(libraryMyDataSet);
                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            this.bookTableAdapter.Fill(libraryMyDataSet.book);

        }
        private bool isFill()
        {
            if (textBox1.Text.Length < 1 || textBox1.Text.Length < 2 || textBox1.Text.Length < 3)
                return false;
            return true;
        }
        private void clearFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        //edit
        private void button2_Click(object sender, EventArgs e)
        {
            if (isFill())
                try
                {
                    dataGridView1.CurrentRow.Cells[1].Value = comboBox1.Text;
                    dataGridView1.CurrentRow.Cells[2].Value = textBox1.Text;
                    dataGridView1.CurrentRow.Cells[3].Value = textBox2.Text;
                    dataGridView1.CurrentRow.Cells[4].Value = textBox3.Text;

                    bookBindingSource.EndEdit();
                    this.bookTableAdapter.Update(((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row);
                    this.bookTableAdapter.Fill(this.libraryMyDataSet.book);

                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            this.bookTableAdapter.Fill(this.libraryMyDataSet.book);

        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow != null)
            {
                try
                {
                    libraryMyDataSet.AcceptChanges();
                    bookBindingSource.RemoveAt(dataGridView1.CurrentRow.Index);
                    bookBindingSource.EndEdit();
                    bookTableAdapter.Update(libraryMyDataSet.book);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.bookTableAdapter.Fill(this.libraryMyDataSet.book);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
