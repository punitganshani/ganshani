namespace NestedGrid
{
    partial class Form1
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
            this.dataGridView1 = new NestedGrid.NestedDataGrid();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTest2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListNested = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colColor,
            this.colTestValue,
            this.colTest2,
            this.colListNested});
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(588, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            // 
            // colColor
            // 
            this.colColor.DataPropertyName = "Color";
            this.colColor.HeaderText = "Color";
            this.colColor.Name = "colColor";
            // 
            // colTestValue
            // 
            this.colTestValue.DataPropertyName = "Types.FruitType";
            this.colTestValue.HeaderText = "Fruit Type";
            this.colTestValue.Name = "colTestValue";
            // 
            // colTest2
            // 
            this.colTest2.DataPropertyName = "Types.Quantity";
            this.colTest2.HeaderText = "Quantity";
            this.colTest2.Name = "colTest2";
            // 
            // colListNested
            // 
            this.colListNested.DataPropertyName = "ListTypes[0].Quantity";
            this.colListNested.HeaderText = "FruitTypes";
            this.colListNested.Name = "colListNested";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 262);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NestedDataGrid dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTest2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListNested;
    }
}

