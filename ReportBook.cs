using Microsoft.Reporting.WinForms;
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
    public partial class ReportBook : Form
    {
        public ReportBook()
        {
            InitializeComponent();
        }

        private void ReportBook_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mydbDataSet.books". При необходимости она может быть перемещена или удалена.
            this.booksTableAdapter.Fill(this.mydbDataSet.books);
            reportViewer1.LocalReport.SetParameters(new ReportParameter("name", Main.fio));

            this.reportViewer1.RefreshReport();
        }
    }
}
