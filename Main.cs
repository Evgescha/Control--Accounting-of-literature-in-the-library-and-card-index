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
    public partial class Main : Form
    {
        public static string fio;
        public Main(string fio)
        {
            Main.fio = fio;
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mydbDataSet.books". При необходимости она может быть перемещена или удалена.
            
            update();
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
                    DataRowView row = (DataRowView)booksBindingSource.AddNew();

                    row[1] = textBox1.Text;
                    row[2] = comboBox1.SelectedValue;
                    row[3] = dateTimePicker1.Value;
                    row[4] = checkBox1.Checked;
                    row[5] = textBox2.Text;

                    booksBindingSource.EndEdit();
                    this.booksTableAdapter.Update(mydbDataSet);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                    update();

        }
        private bool isFill()
        {
            if (textBox2.Text.Length < 1) { MessageBox.Show("Не введено количество");return false; }
            if( textBox1.Text.Length < 1){ MessageBox.Show("Не введено название"); return false; }
            return true;
        }
      
        //edit
        private void button2_Click(object sender, EventArgs e)
        {
            if (isFill())
                try
                {
                    dataGridView1.CurrentRow.Cells[1].Value = textBox1.Text;
                    dataGridView1.CurrentRow.Cells[2].Value = comboBox1.SelectedValue;
                    dataGridView1.CurrentRow.Cells[4].Value = dateTimePicker1.Value;
                    dataGridView1.CurrentRow.Cells[5].Value = checkBox1.Checked;
                    dataGridView1.CurrentRow.Cells[6].Value = textBox2.Text;

                    booksBindingSource.EndEdit();
                    this.booksTableAdapter.Update(((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row);
                    this.booksTableAdapter.Fill(this.mydbDataSet.books);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                    update();

        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow != null)
            {
                try
                {
                    mydbDataSet.AcceptChanges();
                    booksBindingSource.RemoveAt(dataGridView1.CurrentRow.Index);
                    booksBindingSource.EndEdit();
                    booksTableAdapter.Update(mydbDataSet.books);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.booksTableAdapter.Fill(this.mydbDataSet.books);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Autor().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Users().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new History().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            update();
        }
        private void update() {
            textBox2.Text = "";
            textBox1.Text = "";
            this.autorTableAdapter.Fill(this.mydbDataSet.autor);
            this.booksTableAdapter.Fill(this.mydbDataSet.books);
            booksBindingSource.RemoveFilter();
            fixName();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.booksTableAdapter.FillByAutor(this.mydbDataSet.books,int.Parse(comboBox1.SelectedValue.ToString()));

        }

        private void fixName()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                comboBox1.SelectedItem = comboBox1.Items[
                                                           autorBindingSource.Find(
                                                                       "id",
                                                                       int.Parse(dataGridView1[2, i].Value.ToString())
                                                                       )
                                                           ];
                dataGridView1[3, i].Value = comboBox1.Text;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if(comboBox1.Items.Count>0 && radioButton1.Checked)
                this.booksTableAdapter.FillByAvtor(this.mydbDataSet.books,int.Parse(comboBox1.SelectedValue.ToString()));
            if(radioButton2.Checked && textBox1.Text.Length>0)
                this.booksTableAdapter.FillByName(this.mydbDataSet.books, $"%{textBox1.Text}%");
            fixName();
        }
        //filter
        private void button9_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
                 booksBindingSource.Filter =
                    String.Format("autor = '{0}'", comboBox1.SelectedValue);
            else
                booksBindingSource.Filter=
                //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
           String.Format("name like '%{0}%'", textBox1.Text);
            fixName();
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            fixName();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new ReportBook().Show();
        }
    }
}
