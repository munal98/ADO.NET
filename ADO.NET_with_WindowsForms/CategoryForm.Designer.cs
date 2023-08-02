namespace _028_ADO.NET_with_WindowsForms
{
    partial class CategoryForm
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
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.bDelete = new System.Windows.Forms.Button();
            this.bSaveAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToOrderColumns = true;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Location = new System.Drawing.Point(12, 12);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(660, 405);
            this.dgvCategories.TabIndex = 2;
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(13, 424);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(120, 23);
            this.bDelete.TabIndex = 3;
            this.bDelete.Text = "Delete Selected";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bSaveAll
            // 
            this.bSaveAll.Location = new System.Drawing.Point(552, 423);
            this.bSaveAll.Name = "bSaveAll";
            this.bSaveAll.Size = new System.Drawing.Size(120, 23);
            this.bSaveAll.TabIndex = 4;
            this.bSaveAll.Text = "Save All";
            this.bSaveAll.UseVisualStyleBackColor = true;
            this.bSaveAll.Click += new System.EventHandler(this.bSaveAll_Click);
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.bSaveAll);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.dgvCategories);
            this.Name = "CategoryForm";
            this.Text = "Categories";
            this.Load += new System.EventHandler(this.CategoryListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bSaveAll;
    }
}