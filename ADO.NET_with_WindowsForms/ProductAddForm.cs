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
    public partial class ProductAddForm : Form
    {
        FormManager formManager = new FormManager();

        public ProductAddForm()
        {
            InitializeComponent();
        }

        private void ETradeAddForm_Load(object sender, EventArgs e)
        {
            
        }

        public void FillStores()
        {
            StoreDAL storeDal = new StoreDAL();
            clbStores.DataSource = storeDal.GetStoreDataTable();
            clbStores.ValueMember = "Id";
            clbStores.DisplayMember = "NameAndLocation";
            ClearStoreCheckBoxes();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        public void ClearForm()
        {
            tbName.Text = "";
            tbStockAmount.Text = "";
            tbUnitPrice.Text = "";
            cbCategory.SelectedIndex = 0;
            ClearStoreCheckBoxes();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbName.Text) || String.IsNullOrWhiteSpace(tbStockAmount.Text) ||
                String.IsNullOrWhiteSpace(tbUnitPrice.Text) || cbCategory.SelectedIndex == 0 || clbStores.CheckedItems.Count == 0)
            {
                MessageBox.Show("No empty fields allowed!");
                return;
            }
            ProductDAL productDal = new ProductDAL();
            Product product = new Product()
            {
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
            productDal.Add(product);
            MessageBox.Show("Product added to database.");
            formManager.ShowProductListForm(this.MdiParent);
        }

        public void FillCategories()
        {
            CategoryDAL categoryDal = new CategoryDAL();
            cbCategory.ValueMember = "Id";
            cbCategory.DisplayMember = "Name";
            List<Category> categories = categoryDal.GetList();
            categories.Insert(0, new Category() {Id = 0, Name = "-- Select --"});
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
    }
}
