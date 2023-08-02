namespace _028_ADO.NET_with_WindowsForms
{
    partial class StoreForm
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
            this.lbStores = new System.Windows.Forms.ListBox();
            this.pStore = new System.Windows.Forms.Panel();
            this.pid = new System.Windows.Forms.Panel();
            this.lid = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bNew = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.pStore.SuspendLayout();
            this.pid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbStores
            // 
            this.lbStores.FormattingEnabled = true;
            this.lbStores.Location = new System.Drawing.Point(12, 12);
            this.lbStores.Name = "lbStores";
            this.lbStores.Size = new System.Drawing.Size(660, 264);
            this.lbStores.TabIndex = 0;
            this.lbStores.SelectedIndexChanged += new System.EventHandler(this.lbStores_SelectedIndexChanged);
            // 
            // pStore
            // 
            this.pStore.Controls.Add(this.pid);
            this.pStore.Controls.Add(this.bSave);
            this.pStore.Controls.Add(this.cbLocation);
            this.pStore.Controls.Add(this.label2);
            this.pStore.Controls.Add(this.tbName);
            this.pStore.Controls.Add(this.label1);
            this.pStore.Location = new System.Drawing.Point(12, 311);
            this.pStore.Name = "pStore";
            this.pStore.Size = new System.Drawing.Size(660, 138);
            this.pStore.TabIndex = 1;
            // 
            // pid
            // 
            this.pid.Controls.Add(this.lid);
            this.pid.Controls.Add(this.label3);
            this.pid.Location = new System.Drawing.Point(3, 105);
            this.pid.Name = "pid";
            this.pid.Size = new System.Drawing.Size(654, 30);
            this.pid.TabIndex = 7;
            // 
            // lid
            // 
            this.lid.AutoSize = true;
            this.lid.Location = new System.Drawing.Point(63, 9);
            this.lid.Name = "lid";
            this.lid.Size = new System.Drawing.Size(17, 13);
            this.lid.TabIndex = 5;
            this.lid.Text = "lid";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Id:";
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(15, 67);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 6;
            this.bSave.Text = "Save Store";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // cbLocation
            // 
            this.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(69, 40);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(287, 21);
            this.cbLocation.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Location:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(69, 14);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(287, 20);
            this.tbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // bNew
            // 
            this.bNew.Location = new System.Drawing.Point(12, 282);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(75, 23);
            this.bNew.TabIndex = 2;
            this.bNew.Text = "New Store";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // bEdit
            // 
            this.bEdit.Location = new System.Drawing.Point(93, 282);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(75, 23);
            this.bEdit.TabIndex = 3;
            this.bEdit.Text = "Edit Store";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(174, 282);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(75, 23);
            this.bDelete.TabIndex = 4;
            this.bDelete.Text = "Delete Store";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // StoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bNew);
            this.Controls.Add(this.pStore);
            this.Controls.Add(this.lbStores);
            this.Name = "StoreForm";
            this.Text = "Stores";
            this.Load += new System.EventHandler(this.StoreForm_Load);
            this.pStore.ResumeLayout(false);
            this.pStore.PerformLayout();
            this.pid.ResumeLayout(false);
            this.pid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbStores;
        private System.Windows.Forms.Panel pStore;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bNew;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Panel pid;
        private System.Windows.Forms.Label lid;
        private System.Windows.Forms.Label label3;
    }
}