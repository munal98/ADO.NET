using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _028_ADO.NET_with_WindowsForms.DAL;
using _028_ADO.NET_with_WindowsForms.Data;

namespace _028_ADO.NET_with_WindowsForms
{
    public partial class ProductListForm : Form
    {
        public ProductListForm()
        {
            InitializeComponent();
        }

        private void ETradeListForm_Load(object sender, EventArgs e)
        {
            
        }

        public void FillGrid(int categoryId = 0, List<int> storeIds = null, string name = "")
        {
            ProductDAL productDal = new ProductDAL();
            dgvProducts.DataSource = productDal.GetProductList(categoryId, storeIds, name);
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

        public void FillCategories()
        {
            CategoryDAL categoryDal = new CategoryDAL();
            cbCategories.ValueMember = "Id";
            cbCategories.DisplayMember = "Name";
            List<Category> categories = categoryDal.GetList();
            categories.Insert(0,new Category(){ Id = 0, Name = "-- All --" });
            cbCategories.DataSource = categories;
        }

        public void FillStores()
        {
            StoreDAL storeDal = new StoreDAL();
            clbStores.DataSource = storeDal.GetStoreDataTable();
            clbStores.ValueMember = "Id";
            clbStores.DisplayMember = "NameAndLocation";
            ClearStoreCheckBoxes();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            int categoryId = 0;
            List<int> storeIds = null;
            DataRowView dataRowView;
            if (cbCategories.SelectedIndex != 0)
            {
                categoryId = Convert.ToInt32(cbCategories.SelectedValue);
            }
            if (clbStores.CheckedItems.Count > 0)
            {
                storeIds = new List<int>();
                for (int i = 0; i < clbStores.CheckedItems.Count; i++)
                {
                    dataRowView = clbStores.CheckedItems[i] as DataRowView;
                    storeIds.Add(dataRowView.Row.Field<int>("Id"));
                }
            }
            FillGrid(categoryId, storeIds, tbName.Text);
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        void ClearForm()
        {
            cbCategories.SelectedIndex = 0;
            ClearStoreCheckBoxes();
            tbName.Text = "";
            FillGrid();
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
