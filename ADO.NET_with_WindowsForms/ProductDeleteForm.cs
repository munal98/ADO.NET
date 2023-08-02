using _028_ADO.NET_with_WindowsForms.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _028_ADO.NET_with_WindowsForms.Managers;

namespace _028_ADO.NET_with_WindowsForms
{
    public partial class ProductDeleteForm : Form
    {
        FormManager formManager = new FormManager();
        ProductDAL productDal = new ProductDAL();

        public ProductDeleteForm()
        {
            InitializeComponent();
        }

        private void ETradeDeleteForm_Load(object sender, EventArgs e)
        {

        }

        public void FillGrid()
        {
            dgvProducts.DataSource = productDal.GetProductList(0, null, ""); // hepsini getirsin
            dgvProducts.ClearSelection();
            SetColumnVisibilities();
        }

        void SetColumnVisibilities()
        {
            dgvProducts.Columns["Id"].Visible = false;
            dgvProducts.Columns["CategoryId"].Visible = false;
            dgvProducts.Columns["StoreId"].Visible = false;
            dgvProducts.Columns["StoreName"].Visible = false;
            dgvProducts.Columns["StoreLocation"].Visible = false;
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            string message;
            string title;
            MessageBoxButtons buttons;
            DialogResult result;
            int? id = GetIdFromDataGridView();
            if (id.HasValue)
            {
                message = "Do you want to delete the selected product?";
                title = "Delete Product";
                buttons = MessageBoxButtons.OKCancel;
                result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.OK)
                {
                    productDal.Delete(id.Value);
                    MessageBox.Show("Product deleted from database.");
                    formManager.RefreshProductForms();
                }
            }
            else
            {
                MessageBox.Show("Select a product from the list.");
            }
        }

        int? GetIdFromDataGridView()
        {
            int? result = null;
            if (dgvProducts.SelectedRows.Count == 1)
            {
                result = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells[0].Value);
            }
            return result;
        }
    }
}
