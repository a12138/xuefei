namespace 登录界面
{
    partial class 学生缴费信息
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(学生缴费信息));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.snDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersDataSet5 = new 登录界面.UsersDataSet5();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.costTableAdapter = new 登录界面.UsersDataSet5TableAdapters.CostTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.snDataGridViewTextBoxColumn,
            this.cdateDataGridViewTextBoxColumn,
            this.cnumDataGridViewTextBoxColumn,
            this.kCDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.costBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(1, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(444, 293);
            this.dataGridView1.TabIndex = 0;
            // 
            // snDataGridViewTextBoxColumn
            // 
            this.snDataGridViewTextBoxColumn.DataPropertyName = "Sn";
            this.snDataGridViewTextBoxColumn.HeaderText = "姓名";
            this.snDataGridViewTextBoxColumn.Name = "snDataGridViewTextBoxColumn";
            this.snDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdateDataGridViewTextBoxColumn
            // 
            this.cdateDataGridViewTextBoxColumn.DataPropertyName = "C_date";
            this.cdateDataGridViewTextBoxColumn.HeaderText = "交费日期";
            this.cdateDataGridViewTextBoxColumn.Name = "cdateDataGridViewTextBoxColumn";
            this.cdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cnumDataGridViewTextBoxColumn
            // 
            this.cnumDataGridViewTextBoxColumn.DataPropertyName = "C_num";
            this.cnumDataGridViewTextBoxColumn.HeaderText = "交费金额";
            this.cnumDataGridViewTextBoxColumn.Name = "cnumDataGridViewTextBoxColumn";
            this.cnumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kCDataGridViewTextBoxColumn
            // 
            this.kCDataGridViewTextBoxColumn.DataPropertyName = "KC";
            this.kCDataGridViewTextBoxColumn.HeaderText = "课程";
            this.kCDataGridViewTextBoxColumn.Name = "kCDataGridViewTextBoxColumn";
            this.kCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costBindingSource
            // 
            this.costBindingSource.DataMember = "Cost";
            this.costBindingSource.DataSource = this.usersDataSet5;
            // 
            // usersDataSet5
            // 
            this.usersDataSet5.DataSetName = "UsersDataSet5";
            this.usersDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "查找";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(346, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // costTableAdapter
            // 
            this.costTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(445, 42);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // 学生缴费信息
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 332);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "学生缴费信息";
            this.Text = "学生缴费信息";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.学生缴费信息_FormClosed);
            this.Load += new System.EventHandler(this.学生缴费信息_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private UsersDataSet5 usersDataSet5;
        private System.Windows.Forms.BindingSource costBindingSource;
        private UsersDataSet5TableAdapters.CostTableAdapter costTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn snDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kCDataGridViewTextBoxColumn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}