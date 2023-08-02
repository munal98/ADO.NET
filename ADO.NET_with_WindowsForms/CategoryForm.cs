using System;
using System.Collections;
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
using _028_ADO.NET_with_WindowsForms.Managers;

namespace _028_ADO.NET_with_WindowsForms
{
    public partial class CategoryForm : Form
    {
        FormManager formManager = new FormManager();
        CategoryDAL categoryDal = new CategoryDAL();

        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryListForm_Load(object sender, EventArgs e)
        {

        }

        public void FillGrid()
        {
            dgvCategories.Rows.Clear();
            dgvCategories.ColumnCount = 2;
            dgvCategories.Columns[0].Name = "Id";
            dgvCategories.Columns[1].Name = "Category Name";
            var categories = categoryDal.GetList();
            string[] columnValues;
            foreach (var category in categories)
            {
                columnValues = new string[2];
                columnValues[0] = category.Id.ToString();
                columnValues[1] = category.Name.ToString();
                dgvCategories.Rows.Add(columnValues);
            }
            dgvCategories.ClearSelection();
            SetColumnVisibilities();
        }

        void SetColumnVisibilities()
        {
            dgvCategories.Columns["Id"].Visible = false;
        }

        private void bSaveAll_Click(object sender, EventArgs e)
        {
            List<Category> categories = new List<Category>();
            Category category;
            int categoryId;
            string categoryName;
            object id;
            object name;
            bool error = false;
            for (int i = 0; i < dgvCategories.Rows.Count && !error; i++)
            {
                id = dgvCategories.Rows[i].Cells[0].Value; // category id
                name = dgvCategories.Rows[i].Cells[1].Value; // category name
                if (name != null)
                {
                    categoryName = name.ToString().Trim();
                    if (!String.IsNullOrWhiteSpace(categoryName))
                    {
                        if (id == null) // new category
                        {
                            categoryId = 0;
                        }
                        else
                        {
                            categoryId = Convert.ToInt32(id); // existing category
                        }

                        category = new Category(categoryId, categoryName);
                        categories.Add(category);
                    }
                    else
                    {
                        if (id != null)
                        {
                            error = true;
                        }
                    }
                }
                else
                {
                    if (id != null)
                    {
                        error = true;
                    }
                }
            }
            if (error)
            {
                MessageBox.Show("Empty category names not allowed!");
            }
            else
            {
                foreach (var c in categories)
                {
                    if (c.Id == 0) // new category
                    {
                        categoryDal.Add(c);
                    }
                    else // existing category
                    {
                        categoryDal.Update(c);
                    }
                }
                MessageBox.Show("Category changes saved to database.");
                formManager.ShowCategoryForm(this.MdiParent);
                formManager.RefreshProductForms();
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            ProductDAL productDal = new ProductDAL();
            List<int> categoryIds = new List<int>();
            int categoryId;
            object id;
            object name;
            bool error = false;
            int productCount;
            int selectedRowCount = 0;
            for (int i = 0; i < dgvCategories.Rows.Count && !error; i++)
            {
                if (dgvCategories.Rows[i].Selected)
                {
                    selectedRowCount++;
                    id = dgvCategories.Rows[i].Cells[0].Value; // category id
                    name = dgvCategories.Rows[i].Cells[1].Value; // category name
                    if (name != null && id != null) // existing category
                    {
                        categoryId = Convert.ToInt32(id);
                        productCount = productDal.GetCountByCategoryId(categoryId);
                        if (productCount > 0)
                        {
                            error = true;
                        }
                        else
                        {
                            categoryIds.Add(categoryId);
                        }
                    }
                }
            }
            if (selectedRowCount == 0)
            {
                MessageBox.Show("Select categories to delete.");
            }
            else
            {
                if (error)
                {
                    MessageBox.Show("Selected categories can't be deleted because they have products!");
                }
                else
                {
                    if (categoryIds.Count > 0)
                    {
                        foreach (var ci in categoryIds)
                        {
                            categoryDal.Delete(ci);
                        }
                        MessageBox.Show("Selected categories deleted from database.");
                        formManager.ShowCategoryForm(this.MdiParent);
                        formManager.RefreshProductForms();
                    }
                }
            }
        }
    }
}
