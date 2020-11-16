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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryMyDataSet.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.libraryMyDataSet.users);
          

        }

        //add
        private void button1_Click(object sender, EventArgs e)
        {
            if (isFill())
                try
                {
                    DataRowView row = (DataRowView)usersBindingSource.AddNew();

                    row[1] = textBox1.Text;
                    row[2] = textBox2.Text;
                    row[3] = textBox3.Text;

                    usersBindingSource.EndEdit();
                    this.usersTableAdapter.Update(libraryMyDataSet);
                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                    this.usersTableAdapter.Fill(libraryMyDataSet.users);

        }
        private bool isFill() {
            if (textBox1.Text.Length < 1 || textBox1.Text.Length < 2 || textBox1.Text.Length < 3)
                return false;
            return true;
        }
        private void clearFields(){
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
                dataGridView1.CurrentRow.Cells[1].Value = textBox1.Text;
                dataGridView1.CurrentRow.Cells[2].Value = textBox2.Text;
                dataGridView1.CurrentRow.Cells[3].Value = textBox3.Text;

                usersBindingSource.EndEdit();
                this.usersTableAdapter.Update(((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row);
                this.usersTableAdapter.Fill(this.libraryMyDataSet.users);

                clearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.usersTableAdapter.Fill(this.libraryMyDataSet.users);

        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow != null)
            {
                try
                {
                    libraryMyDataSet.AcceptChanges();
                    usersBindingSource.RemoveAt(dataGridView1.CurrentRow.Index);
                    usersBindingSource.EndEdit();
                    usersTableAdapter.Update(libraryMyDataSet.users);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                    this.usersTableAdapter.Fill(this.libraryMyDataSet.users);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}
