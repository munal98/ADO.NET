using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _028_ADO.NET_with_WindowsForms.Extras
{
    public partial class SQLdbServiceTestForm : Form
    {
        public SQLdbServiceTestForm()
        {
            InitializeComponent();
        }

        private void SQLdbServiceTestForm_Load(object sender, EventArgs e)
        {
            
        }

        public void FillGrid()
        {
            //SQLdbService db = new SQLdbService(@"Server=(localdb)\MSSQLLocalDB; Initial Catalog=ETrade; Integrated Security=true;");
            SQLdbService db = new SQLdbService(@"Server=.\SQLEXPRESS; Initial Catalog=ETrade; Integrated Security=true;");
            int result;
            DataSet ds = db.SQL_SelectAdapter("select * from Products", out result);
            dgvProducts.DataSource = ds.Tables[0];
            dgvProducts.ClearSelection();
        }
    }
}
