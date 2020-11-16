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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryMyDataSet.autor". При необходимости она может быть перемещена или удалена.
            this.autorTableAdapter.Fill(this.libraryMyDataSet.autor);

        }

        //add
        private void button1_Click(object sender, EventArgs e)
        {
            if (isFill())
                try
                {
                    DataRowView row = (DataRowView)autorBindingSource.AddNew();

                    row[0] = textBox1.Text;

                    autorBindingSource.EndEdit();
                    this.autorTableAdapter.Update(libraryMyDataSet);
                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            this.autorTableAdapter.Fill(libraryMyDataSet.autor);

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
                    dataGridView1.CurrentRow.Cells[0].Value = textBox1.Text;

                    autorBindingSource.EndEdit();
                    this.autorTableAdapter.Update(((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row);
                    this.autorTableAdapter.Fill(this.libraryMyDataSet.autor);

                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            this.autorTableAdapter.Fill(this.libraryMyDataSet.autor);

        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow != null)
            {
                try
                {
                    libraryMyDataSet.AcceptChanges();
                    autorBindingSource.RemoveAt(dataGridView1.CurrentRow.Index);
                    autorBindingSource.EndEdit();
                    autorTableAdapter.Update(libraryMyDataSet.autor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.autorTableAdapter.Fill(this.libraryMyDataSet.autor);
            }
        }
    }
}
