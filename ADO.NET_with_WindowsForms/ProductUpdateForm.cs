using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _028_ADO.NET_with_WindowsForms.DAL;
using _028_ADO.NET_with_WindowsForms.Data;
using _028_ADO.NET_with_WindowsForms.Managers;

namespace _028_ADO.NET_with_WindowsForms
{
    public partial class ProductUpdateForm : Form
    {
        FormManager formManager = new FormManager();
        ProductDAL productDal = new ProductDAL();
        CategoryDAL categoryDal = new CategoryDAL();

        public ProductUpdateForm()
        {
            InitializeComponent();
        }

        private void ETradeUpdateForm_Load(object sender, EventArgs e)
        {

        }

        public void FillGrid()
        {
            dgvProducts.DataSource = productDal.GetListWithReader();
            dgvProducts.ClearSelection();
            SetColumnVisibilities();
        }

        void SetColumnVisibilities()
        {
            dgvProducts.Columns["Id"].Visible = false;
            dgvProducts.Columns["CategoryId"].Visible = false;
            dgvProducts.Columns["CategoryName"].Visible = false;
            dgvProducts.Columns["StoreId"].Visible = false;
            dgvProducts.Columns["StoreName"].Visible = false;
            dgvProducts.Columns["StoreLocation"].Visible = false;
            dgvProducts.Columns["StoreNameAndLocation"].Visible = false;
        }

        public void FillStores()
        {
            StoreDAL storeDal = new StoreDAL();
            clbStores.DataSource = storeDal.GetStoreDataTable();
            clbStores.ValueMember = "Id";
            clbStores.DisplayMember = "NameAndLocation";
            ClearStoreCheckBoxes();
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            ClearForm();
            int? id = GetIdFromDataGridView();
            //if (id.HasValue)
            if (id != null)
            {
                Product product = productDal.GetById(id.Value);
                if (product != null)
                {
                    tbName.Text = product.Name;
                    //tbUnitPrice.Text = product.UnitPrice.ToString(CultureInfo.InvariantCulture).Replace(".", ",");
                    tbUnitPrice.Text = product.UnitPrice.ToString(new CultureInfo("tr"));
                    tbStockAmount.Text = product.StockAmount.ToString();
                    cbCategory.SelectedValue = product.CategoryId;
                    SetStoreCheckBoxes(product.StoreIds);
                }
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

        public void ClearForm()
        {
            tbName.Text = "";
            tbStockAmount.Text = "";
            tbUnitPrice.Text = "";
            if (cbCategory.Items.Count > 0)
                cbCategory.SelectedIndex = 0;
            ClearStoreCheckBoxes();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            dgvProducts.ClearSelection();
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbName.Text) || String.IsNullOrWhiteSpace(tbStockAmount.Text) ||
                String.IsNullOrWhiteSpace(tbUnitPrice.Text) || cbCategory.SelectedIndex == 0 || clbStores.CheckedItems.Count == 0)
            {
                MessageBox.Show("No empty fields allowed!");
                return;
            }
            int? id = GetIdFromDataGridView();
            if (id.HasValue)
            {
                Product product = new Product()
                {
                    Id = id.Value,
                    Name = tbName.Text.Trim(),
                    //UnitPrice = Convert.ToDecimal(tbUnitPrice.Text.Trim().Replace(",", "."), CultureInfo.InvariantCulture),
                    UnitPrice = Convert.ToDecimal(tbUnitPrice.Text.Trim(), new CultureInfo("tr")),
                    StockAmount = Convert.ToInt32(tbStockAmount.Text.Trim()),
                    CategoryId = Convert.ToInt32(cbCategory.SelectedValue)
                };
                product.StoreIds = new List<int>();
                DataRowView dataRowView;
                int i = 0;
                foreach (var item in clbStores.CheckedItems)
                {
                    dataRowView = clbStores.CheckedItems[i] as DataRowView;
                    product.StoreIds.Add(dataRowView.Row.Field<int>("Id"));
                    i++;
                }
                productDal.Update(product);
                MessageBox.Show("Product updated in database.");
                formManager.RefreshProductForms();
            }
            else
            {
                MessageBox.Show("Select a product from the list.");
            }
        }

        public void FillCategories()
        {
            cbCategory.ValueMember = "Id";
            cbCategory.DisplayMember = "Name";
            List<Category> categories = categoryDal.GetList();
            categories.Insert(0, new Category() { Id = 0, Name = "-- Select --" });
            cbCategory.DataSource = categories;
        }

        void ClearStoreCheckBoxes()
        {
            clbStores.ClearSelected();
            foreach (int i in clbStores.CheckedIndices)
            {
                clbStores.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        void SetStoreCheckBoxes(List<int> storeIds)
        {
            ClearStoreCheckBoxes();
            DataRowView dataRowView;
            int storeId;
            bool found;
            foreach (var _storeId in storeIds)
            {
                found = false;
                for (int i = 0; i < clbStores.Items.Count && !found; i++)
                {
                    dataRowView = clbStores.Items[i] as DataRowView;
                    storeId = dataRowView.Row.Field<int>("Id");
                    if (storeId == _storeId)
                    {
                        clbStores.SetItemCheckState(i, CheckState.Checked);
                        found = true;
                    }
                }
            }
        }
    }
}
