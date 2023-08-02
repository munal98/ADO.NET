namespace _028_ADO.NET_with_WindowsForms
{
    partial class ETradeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateExistingProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteExistingProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sQLdbServiceTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.storesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsToolStripMenuItem,
            this.categoriesToolStripMenuItem,
            this.storesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listProductsToolStripMenuItem,
            this.addNewProductToolStripMenuItem,
            this.updateExistingProductToolStripMenuItem,
            this.deleteExistingProductToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sQLdbServiceTestToolStripMenuItem});
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.productsToolStripMenuItem.Text = "Products";
            // 
            // listProductsToolStripMenuItem
            // 
            this.listProductsToolStripMenuItem.Name = "listProductsToolStripMenuItem";
            this.listProductsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.listProductsToolStripMenuItem.Text = "List Products";
            this.listProductsToolStripMenuItem.Click += new System.EventHandler(this.listProductsToolStripMenuItem_Click);
            // 
            // addNewProductToolStripMenuItem
            // 
            this.addNewProductToolStripMenuItem.Name = "addNewProductToolStripMenuItem";
            this.addNewProductToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.addNewProductToolStripMenuItem.Text = "Add New Product";
            this.addNewProductToolStripMenuItem.Click += new System.EventHandler(this.addNewProductToolStripMenuItem_Click_1);
            // 
            // updateExistingProductToolStripMenuItem
            // 
            this.updateExistingProductToolStripMenuItem.Name = "updateExistingProductToolStripMenuItem";
            this.updateExistingProductToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.updateExistingProductToolStripMenuItem.Text = "Update Existing Product";
            this.updateExistingProductToolStripMenuItem.Click += new System.EventHandler(this.updateExistingProductToolStripMenuItem_Click);
            // 
            // deleteExistingProductToolStripMenuItem
            // 
            this.deleteExistingProductToolStripMenuItem.Name = "deleteExistingProductToolStripMenuItem";
            this.deleteExistingProductToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.deleteExistingProductToolStripMenuItem.Text = "Delete Existing Product";
            this.deleteExistingProductToolStripMenuItem.Click += new System.EventHandler(this.deleteExistingProductToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(198, 6);
            // 
            // sQLdbServiceTestToolStripMenuItem
            // 
            this.sQLdbServiceTestToolStripMenuItem.Name = "sQLdbServiceTestToolStripMenuItem";
            this.sQLdbServiceTestToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.sQLdbServiceTestToolStripMenuItem.Text = "SQLdbService Test";
            this.sQLdbServiceTestToolStripMenuItem.Click += new System.EventHandler(this.sQLdbServiceTestToolStripMenuItem_Click);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.categoriesToolStripMenuItem.Text = "Categories";
            this.categoriesToolStripMenuItem.Click += new System.EventHandler(this.categoriesToolStripMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // storesToolStripMenuItem
            // 
            this.storesToolStripMenuItem.Name = "storesToolStripMenuItem";
            this.storesToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.storesToolStripMenuItem.Text = "Stores";
            this.storesToolStripMenuItem.Click += new System.EventHandler(this.storesToolStripMenuItem_Click);
            // 
            // ETradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "ETradeForm";
            this.Text = "E-Trade";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ETradeForm_FormClosing);
            this.Load += new System.EventHandler(this.ETradeForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateExistingProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteExistingProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sQLdbServiceTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem storesToolStripMenuItem;
    }
}

