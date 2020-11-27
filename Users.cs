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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mydbDataSet.users". При необходимости она может быть перемещена или удалена.
            update();
        }

        //add
        private void button1_Click(object sender, EventArgs e)
        {
            if (isFill())
                try
                {
                    DataRowView row = (DataRowView)usersBindingSource.AddNew();

                    row[1] = textBox1.Text;
                    row[2] = int.Parse(textBox2.Text);
                    row[3] = int.Parse(textBox3.Text);
                    row[4] = textBox4.Text;

                    usersBindingSource.EndEdit();
                    this.usersTableAdapter.Update(mydbDataSet);
                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            this.usersTableAdapter.Fill(mydbDataSet.users);

        }
        private bool isFill() {
            if (textBox1.Text.Length < 10) { MessageBox.Show("Не введено ФИО пользователя (минимум 10 символов)"); return false; }
            if (textBox2.Text.Length != 4) { MessageBox.Show("Год введен некорректно"); return false; }
            if (textBox3.Text.Length < 7) { MessageBox.Show("У номера телефона не может быть менее 7 цифр"); return false; }
            if (textBox4.Text.Length < 1) { MessageBox.Show("Не введен класс"); return false; }
            return true;
        }
        private void clearFields() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
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
                    dataGridView1.CurrentRow.Cells[4].Value = textBox4.Text;

                    usersBindingSource.EndEdit();
                    this.usersTableAdapter.Update(((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row);
                    this.usersTableAdapter.Fill(this.mydbDataSet.users);

                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            this.usersTableAdapter.Fill(this.mydbDataSet.users);

        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow != null)
            {
                try
                {
                    mydbDataSet.AcceptChanges();
                    usersBindingSource.RemoveAt(dataGridView1.CurrentRow.Index);
                    usersBindingSource.EndEdit();
                    usersTableAdapter.Update(mydbDataSet.users);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.usersTableAdapter.Fill(this.mydbDataSet.users);
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked && textBox1.Text.Length > 0)
                this.usersTableAdapter.FillByFIO(this.mydbDataSet.users, "%" + textBox1.Text + "%");
            if (radioButton2.Checked && textBox2.Text.Length > 0)
                this.usersTableAdapter.FillByDate(this.mydbDataSet.users, int.Parse(textBox2.Text));
            if (radioButton3.Checked && textBox3.Text.Length > 0)
                this.usersTableAdapter.FillByPhone(this.mydbDataSet.users, int.Parse(textBox3.Text));
            if (radioButton4.Checked && textBox4.Text.Length > 0)
                this.usersTableAdapter.FillByClass(this.mydbDataSet.users, "%" + textBox4.Text + "%");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            update();
        }
        private void update() {
            clearFields();
            this.usersTableAdapter.Fill(this.mydbDataSet.users);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Report().Show();
        }
    }
}
