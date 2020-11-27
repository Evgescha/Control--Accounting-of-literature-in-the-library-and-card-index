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
    public partial class Autor : Form
    {
        public Autor()
        {
            InitializeComponent();
        }

        private void Autor_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mydbDataSet.autor". При необходимости она может быть перемещена или удалена.
            this.autorTableAdapter.Fill(this.mydbDataSet.autor);

        }

        //add
        private void button1_Click(object sender, EventArgs e)
        {
            if (isFill())
                try
                {
                    //DataRowView r = autorBindingSource1.add
                    DataRowView row = (DataRowView)autorBindingSource1.AddNew();

                    row[1] = textBox1.Text;
                    row[2] = dateTimePicker1.Value;

                    autorBindingSource1.EndEdit();
                    this.autorTableAdapter.Update(mydbDataSet);
                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            this.autorTableAdapter.Fill(mydbDataSet.autor);

        }
        private bool isFill()
        {
            if (textBox1.Text.Length < 1 )
                return false;
            return true;
        }
        private void clearFields()
        {
            textBox1.Text = "";
        }
        //edit
        private void button2_Click(object sender, EventArgs e)
        {
            if (isFill())
                try
                {
                    dataGridView1.CurrentRow.Cells[1].Value = textBox1.Text;
                    dataGridView1.CurrentRow.Cells[2].Value = dateTimePicker1.Text;
                    autorBindingSource1.EndEdit();
                    this.autorTableAdapter.Update(((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row);
                    this.autorTableAdapter.Fill(this.mydbDataSet.autor);

                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            this.autorTableAdapter.Fill(this.mydbDataSet.autor);

        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow != null)
            {
                try
                {
                    mydbDataSet.AcceptChanges();
                    autorBindingSource1.RemoveAt(dataGridView1.CurrentRow.Index);
                    autorBindingSource1.EndEdit();
                    autorTableAdapter.Update(mydbDataSet.autor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.autorTableAdapter.Fill(this.mydbDataSet.autor);
            }
        }
    }
}
