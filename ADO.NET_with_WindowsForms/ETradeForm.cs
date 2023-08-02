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
using _028_ADO.NET_with_WindowsForms.Managers;

namespace _028_ADO.NET_with_WindowsForms
{
    public partial class ETradeForm : Form
    {
        FormManager formManager = new FormManager();
        DateTime now;
        string nowText;
        string formText = "E-Trade";

        public ETradeForm()
        {
            InitializeComponent();
        }

        private void ETradeForm_Load(object sender, EventArgs e) // event
        {
            SetNowText();
            StartTimer();
        }

        void SetNowText()
        {
            now = DateTime.Now;
            nowText = now.ToShortDateString() + " " + now.ToLongTimeString();
            if (this.Text.Length > formText.Length)
                this.Text = this.Text.Remove(formText.Length);
            this.Text = formText + " - " + nowText;
        }

        void StartTimer()
        {
            timer.Start();
        }

        private void listProductsToolStripMenuItem_Click(object sender, EventArgs e) // event
        {
            formManager.ShowProductListForm(this);
        }

        private void addNewProductToolStripMenuItem_Click_1(object sender, EventArgs e) // event
        {
            formManager.ShowProductAddForm(this);
        }

        private void updateExistingProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowProductUpdateForm(this);
        }

        private void deleteExistingProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowProductDeleteForm(this);
        }

        private void sQLdbServiceTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowTestForm(this);
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowCategoryForm(this);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            SetNowText();
        }

        private void ETradeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTimer();
        }

        void StopTimer()
        {
            timer.Stop();
        }

        private void storesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.ShowStoreForm(this);
        }
    }
}
