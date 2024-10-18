namespace Buoi5_WinForms
{
    partial class FormStudentManagement
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblID = new Label();
            txtID = new TextBox();
            txtName = new TextBox();
            lblName = new Label();
            txtAdress = new TextBox();
            lblAdress = new Label();
            dtpBirthday = new DateTimePicker();
            lblBirthday = new Label();
            lblGender = new Label();
            grbGender = new GroupBox();
            rdoWomen = new RadioButton();
            rdoMen = new RadioButton();
            btnAdd = new Button();
            btnDelete = new Button();
            btnAlter = new Button();
            dgvList = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            btnWriteFile = new Button();
            btnWriteBinaryFile = new Button();
            btnExit = new Button();
            grbGender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(12, 4);
            lblID.Name = "lblID";
            lblID.Size = new Size(24, 20);
            lblID.TabIndex = 0;
            lblID.Text = "ID";
            // 
            // txtID
            // 
            txtID.Location = new Point(133, 2);
            txtID.Name = "txtID";
            txtID.Size = new Size(125, 27);
            txtID.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(133, 46);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 46);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 2;
            lblName.Text = "Name";
            // 
            // txtAdress
            // 
            txtAdress.Location = new Point(133, 88);
            txtAdress.Name = "txtAdress";
            txtAdress.Size = new Size(125, 27);
            txtAdress.TabIndex = 5;
            // 
            // lblAdress
            // 
            lblAdress.AutoSize = true;
            lblAdress.Location = new Point(12, 91);
            lblAdress.Name = "lblAdress";
            lblAdress.Size = new Size(53, 20);
            lblAdress.TabIndex = 4;
            lblAdress.Text = "Adress";
            // 
            // dtpBirthday
            // 
            dtpBirthday.Format = DateTimePickerFormat.Short;
            dtpBirthday.Location = new Point(133, 137);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(125, 27);
            dtpBirthday.TabIndex = 6;
            // 
            // lblBirthday
            // 
            lblBirthday.AutoSize = true;
            lblBirthday.Location = new Point(12, 137);
            lblBirthday.Name = "lblBirthday";
            lblBirthday.Size = new Size(64, 20);
            lblBirthday.TabIndex = 7;
            lblBirthday.Text = "Birthday";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(433, 53);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(0, 20);
            lblGender.TabIndex = 8;
            // 
            // grbGender
            // 
            grbGender.Controls.Add(rdoWomen);
            grbGender.Controls.Add(rdoMen);
            grbGender.Location = new Point(12, 189);
            grbGender.Name = "grbGender";
            grbGender.Size = new Size(123, 94);
            grbGender.TabIndex = 9;
            grbGender.TabStop = false;
            grbGender.Text = "Gender";
            // 
            // rdoWomen
            // 
            rdoWomen.AutoSize = true;
            rdoWomen.Location = new Point(6, 65);
            rdoWomen.Name = "rdoWomen";
            rdoWomen.Size = new Size(81, 24);
            rdoWomen.TabIndex = 1;
            rdoWomen.TabStop = true;
            rdoWomen.Text = "Women";
            rdoWomen.UseVisualStyleBackColor = true;
            // 
            // rdoMen
            // 
            rdoMen.AutoSize = true;
            rdoMen.Location = new Point(6, 35);
            rdoMen.Name = "rdoMen";
            rdoMen.Size = new Size(59, 24);
            rdoMen.TabIndex = 0;
            rdoMen.TabStop = true;
            rdoMen.Text = "Men";
            rdoMen.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(164, 189);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(164, 224);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAlter
            // 
            btnAlter.Location = new Point(164, 259);
            btnAlter.Name = "btnAlter";
            btnAlter.Size = new Size(94, 29);
            btnAlter.TabIndex = 12;
            btnAlter.Text = "Alter";
            btnAlter.UseVisualStyleBackColor = true;
            btnAlter.Click += btnAlter_Click;
            // 
            // dgvList
            // 
            dgvList.AllowUserToAddRows = false;
            dgvList.AllowUserToDeleteRows = false;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvList.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dgvList.Location = new Point(283, 2);
            dgvList.Name = "dgvList";
            dgvList.ReadOnly = true;
            dgvList.RowHeadersWidth = 51;
            dgvList.Size = new Size(687, 449);
            dgvList.TabIndex = 13;
            dgvList.SelectionChanged += dgvList_SelectionChanged;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "ID";
            Column1.HeaderText = "ID";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "Name";
            Column2.HeaderText = "Name";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "Birthday";
            Column3.HeaderText = "Birthday";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "Gender";
            Column4.HeaderText = "Gender";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.DataPropertyName = "Adress";
            Column5.HeaderText = "Adress";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 125;
            // 
            // btnWriteFile
            // 
            btnWriteFile.Location = new Point(18, 311);
            btnWriteFile.Name = "btnWriteFile";
            btnWriteFile.Size = new Size(240, 29);
            btnWriteFile.TabIndex = 14;
            btnWriteFile.Text = "Write File";
            btnWriteFile.UseVisualStyleBackColor = true;
            // 
            // btnWriteBinaryFile
            // 
            btnWriteBinaryFile.Location = new Point(18, 346);
            btnWriteBinaryFile.Name = "btnWriteBinaryFile";
            btnWriteBinaryFile.Size = new Size(240, 29);
            btnWriteBinaryFile.TabIndex = 15;
            btnWriteBinaryFile.Text = "Write Binary File";
            btnWriteBinaryFile.UseVisualStyleBackColor = true;
            btnWriteBinaryFile.Click += btnWriteBinaryFile_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Red;
            btnExit.ForeColor = SystemColors.ActiveCaptionText;
            btnExit.Location = new Point(18, 381);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(240, 29);
            btnExit.TabIndex = 16;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // FormStudentManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 453);
            Controls.Add(btnExit);
            Controls.Add(btnWriteBinaryFile);
            Controls.Add(btnWriteFile);
            Controls.Add(dgvList);
            Controls.Add(btnAlter);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(grbGender);
            Controls.Add(lblGender);
            Controls.Add(lblBirthday);
            Controls.Add(dtpBirthday);
            Controls.Add(txtAdress);
            Controls.Add(lblAdress);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(txtID);
            Controls.Add(lblID);
            Name = "FormStudentManagement";
            Text = "FormStudentManagement";
            Load += FormStudentManagement_Load;
            grbGender.ResumeLayout(false);
            grbGender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblID;
        private TextBox txtID;
        private TextBox txtName;
        private Label lblName;
        private TextBox txtAdress;
        private Label lblAdress;
        private DateTimePicker dtpBirthday;
        private Label lblBirthday;
        private Label lblGender;
        private GroupBox grbGender;
        private RadioButton rdoWomen;
        private RadioButton rdoMen;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnAlter;
        private DataGridView dgvList;
        private Button btnWriteFile;
        private Button btnWriteBinaryFile;
        private Button btnExit;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
    }
}
