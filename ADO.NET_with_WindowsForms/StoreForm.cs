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
using _028_ADO.NET_with_WindowsForms.Managers;

namespace _028_ADO.NET_with_WindowsForms
{
    public partial class StoreForm : Form
    {
        StoreDAL storeDal = new StoreDAL();
        Dictionary<string, int> locationDictionary; // string: Location (City), int: ComboBox Index
        FormManager formManager = new FormManager();

        public StoreForm()
        {
            InitializeComponent();
        }

        private void StoreForm_Load(object sender, EventArgs e)
        {
            FillLocations();
            pid.Visible = false;
            pStore.Visible = false;
        }

        void FillLocations()
        {
            locationDictionary = new Dictionary<string, int>();
            locationDictionary.Add("-- Select --", 0);
            locationDictionary.Add("Ankara", 1);
            locationDictionary.Add("Istanbul", 2);
            locationDictionary.Add("Izmir", 3);
            cbLocation.Items.Clear();
            foreach (var locationKey in locationDictionary.Keys)
            {
                cbLocation.Items.Add(locationKey);
            }
        }

        public void FillList()
        {
            lbStores.ValueMember = "Id";
            lbStores.DisplayMember = "NameAndLocation";
            var stores = storeDal.GetList();
            lbStores.DataSource = stores;
            lbStores.ClearSelected();
        }

        void ClearPanelStore()
        {
            tbName.Text = "";
            cbLocation.SelectedIndex = 0;
        }

        private void lbStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            lid.Text = "";
            if (lbStores.SelectedIndex != -1)
            {
                lid.Text = lbStores.SelectedValue.ToString();
                pStore.Visible = false;
            }
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            ClearPanelStore();
            lbStores.ClearSelected();
            lid.Text = "";
            pStore.Visible = true;
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            ClearPanelStore();
            int id;
            Store store;
            int selectedIndex = 0;
            if (Int32.TryParse(lid.Text, out id))
            {
                store = storeDal.GetById(id);
                if (store != null)
                {
                    tbName.Text = store.Name;
                    if (locationDictionary.TryGetValue(store.Location, out selectedIndex))
                        cbLocation.SelectedIndex = selectedIndex;
                    pStore.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Select a store from the list.");
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            ProductDAL productDal = new ProductDAL();
            pStore.Visible = false;
            if (lbStores.SelectedIndex == -1)
            {
                MessageBox.Show("Select a store from the list.");
            }
            else
            {
                string message = "Do you want to delete the selected store?";
                string title = "Delete Store";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(lid.Text);
                    int productCount = productDal.GetCountByStoreId(id);
                    if (productCount > 0)
                    {
                        MessageBox.Show("Selected store can't be deleted because it has products!");
                    }
                    else
                    {
                        storeDal.Delete(id);
                        FillList();
                        formManager.RefreshProductForms();
                    }
                }
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbName.Text) || cbLocation.SelectedIndex == 0)
            {
                MessageBox.Show("No empty fields allowed!");
                return;
            }
            string operation;
            Store store;
            if (lid.Text.Equals("")) // new store
            {
                store = new Store()
                {
                    Name = tbName.Text.Trim(),
                    Location = cbLocation.Text
                };
                storeDal.Add(store);
                operation = "added to";
            }
            else // existing store
            {
                store = new Store()
                {
                    Id = Convert.ToInt32(lid.Text),
                    Name = tbName.Text.Trim(),
                    Location = cbLocation.Text
                };
                storeDal.Update(store);
                operation = "updated in";
            }
            MessageBox.Show("Store " + operation + " database.");
            FillList();
            formManager.RefreshProductForms();
        }
    }
}
