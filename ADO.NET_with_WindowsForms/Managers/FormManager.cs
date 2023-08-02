using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _028_ADO.NET_with_WindowsForms.Extras;

namespace _028_ADO.NET_with_WindowsForms.Managers
{
    class FormManager
    {
        public static ProductListForm productListForm = null;
        public static ProductAddForm productAddForm = null;
        public static ProductUpdateForm productUpdateForm = null;
        public static ProductDeleteForm productDeleteForm = null;
        public static SQLdbServiceTestForm testForm = null;
        public static CategoryForm categoryForm = null;
        public static StoreForm storeForm = null;

        public void ShowProductListForm(Form mdiParentForm)
        {
            if (productListForm == null || productListForm.IsDisposed)
            {
                productListForm = new ProductListForm();
                productListForm.MdiParent = mdiParentForm;
            }
            productListForm.WindowState = FormWindowState.Maximized;
            productListForm.Show();
            productListForm.Focus();
            productListForm.FillCategories();
            productListForm.FillStores();
            productListForm.FillGrid();
        }

        public void ShowProductAddForm(Form mdiParentForm)
        {
            if (productAddForm == null || productAddForm.IsDisposed)
            {
                productAddForm = new ProductAddForm();
                productAddForm.MdiParent = mdiParentForm;
            }
            productAddForm.WindowState = FormWindowState.Maximized;
            productAddForm.Show();
            productAddForm.Focus();
            productAddForm.FillCategories();
            productAddForm.FillStores();
            productAddForm.ClearForm();
        }

        public void ShowProductUpdateForm(Form mdiParentForm)
        {
            if (productUpdateForm == null || productUpdateForm.IsDisposed)
            {
                productUpdateForm = new ProductUpdateForm();
                productUpdateForm.MdiParent = mdiParentForm;
            }
            productUpdateForm.WindowState = FormWindowState.Maximized;
            productUpdateForm.Show();
            productUpdateForm.Focus();
            productUpdateForm.FillGrid();
            productUpdateForm.FillCategories();
            productUpdateForm.FillStores();
        }

        public void ShowProductDeleteForm(Form mdiParentForm)
        {
            if (productDeleteForm == null || productDeleteForm.IsDisposed)
            {
                productDeleteForm = new ProductDeleteForm();
                productDeleteForm.MdiParent = mdiParentForm;
            }
            productDeleteForm.WindowState = FormWindowState.Maximized;
            productDeleteForm.Show();
            productDeleteForm.Focus();
            productDeleteForm.FillGrid();
        }

        public void ShowTestForm(Form mdiParentForm)
        {
            if (testForm == null || testForm.IsDisposed)
            {
                testForm = new SQLdbServiceTestForm();
                testForm.MdiParent = mdiParentForm;
            }
            testForm.WindowState = FormWindowState.Maximized;
            testForm.Show();
            testForm.Focus();
            testForm.FillGrid();
        }

        public void ShowCategoryForm(Form mdiParentForm)
        {
            if (categoryForm == null || categoryForm.IsDisposed)
            {
                categoryForm = new CategoryForm();
                categoryForm.MdiParent = mdiParentForm;
            }
            categoryForm.WindowState = FormWindowState.Maximized;
            categoryForm.Show();
            categoryForm.Focus();
            categoryForm.FillGrid();
        }

        public void ShowStoreForm(Form mdiParentForm)
        {
            if (storeForm == null || storeForm.IsDisposed)
            {
                storeForm = new StoreForm();
                storeForm.MdiParent = mdiParentForm;
            }
            storeForm.WindowState = FormWindowState.Maximized;
            storeForm.Show();
            storeForm.Focus();
            storeForm.FillList();
        }

        public void RefreshProductListForm()
        {
            if (productListForm != null && !productListForm.IsDisposed)
                productListForm.FillGrid();
        }

        public void RefreshProductUpdateForm()
        {
            if (productUpdateForm != null && !productUpdateForm.IsDisposed)
                productUpdateForm.FillGrid();
        }

        public void RefreshProductDeleteForm()
        {
            if (productDeleteForm != null && !productDeleteForm.IsDisposed)
                productDeleteForm.FillGrid();
        }

        public void RefreshProductForms()
        {
            RefreshProductListForm();
            RefreshProductDeleteForm();
            RefreshProductUpdateForm();
        }
    }
}
