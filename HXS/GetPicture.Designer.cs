
namespace HXS
{
    partial class GetPicture
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Choose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Images = new System.Windows.Forms.DataGridViewImageColumn();
            this.CreateInfo = new System.Windows.Forms.Button();
            this.日期 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSCX = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.客户 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxHBZ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxWLMC = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxGGMS = new System.Windows.Forms.TextBox();
            this.textBoxYWBL = new System.Windows.Forms.TextBox();
            this.textBoxKYS = new System.Windows.Forms.TextBox();
            this.textBoxKCZ = new System.Windows.Forms.TextBox();
            this.textBoxLX = new System.Windows.Forms.TextBox();
            this.textBoxJC = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 653);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "获取金蝶数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GetInfo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Choose,
            this.Images});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 16);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 115);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 300;
            this.dataGridView1.Size = new System.Drawing.Size(1934, 532);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // No
            // 
            this.No.HeaderText = "序号";
            this.No.MinimumWidth = 6;
            this.No.Name = "No";
            this.No.Width = 125;
            // 
            // Choose
            // 
            this.Choose.HeaderText = "选择";
            this.Choose.MinimumWidth = 6;
            this.Choose.Name = "Choose";
            this.Choose.Width = 125;
            // 
            // Images
            // 
            this.Images.HeaderText = "Images";
            this.Images.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Images.MinimumWidth = 6;
            this.Images.Name = "Images";
            this.Images.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Images.Width = 125;
            // 
            // CreateInfo
            // 
            this.CreateInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreateInfo.Location = new System.Drawing.Point(253, 653);
            this.CreateInfo.Name = "CreateInfo";
            this.CreateInfo.Size = new System.Drawing.Size(244, 44);
            this.CreateInfo.TabIndex = 2;
            this.CreateInfo.Text = "生成数据";
            this.CreateInfo.UseVisualStyleBackColor = true;
            this.CreateInfo.Click += new System.EventHandler(this.CreateInfo_Click);
            // 
            // 日期
            // 
            this.日期.AutoSize = true;
            this.日期.Dock = System.Windows.Forms.DockStyle.Right;
            this.日期.Location = new System.Drawing.Point(172, 44);
            this.日期.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.日期.Name = "日期";
            this.日期.Size = new System.Drawing.Size(75, 28);
            this.日期.TabIndex = 5;
            this.日期.Text = "起始日期:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(253, 38);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 16;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxSCX, 11, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.客户, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxKH, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.CreateInfo, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 10, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCK, 9, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.日期, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerEnd, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 12, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxHBZ, 13, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 14, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxWLMC, 15, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 8, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 10, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 12, 2);
            this.tableLayoutPanel1.Controls.Add(this.label12, 14, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxGGMS, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxYWBL, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxKYS, 9, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxKCZ, 11, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxLX, 13, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxJC, 15, 2);
            this.tableLayoutPanel1.Controls.Add(this.button3, 5, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1924, 720);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(513, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "抓取状态:";
            // 
            // textBoxSCX
            // 
            this.textBoxSCX.Location = new System.Drawing.Point(1175, 35);
            this.textBoxSCX.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.textBoxSCX.Name = "textBoxSCX";
            this.textBoxSCX.Size = new System.Drawing.Size(100, 25);
            this.textBoxSCX.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "全部抓取状态",
            "已抓取",
            "未抓取"});
            this.comboBox1.Location = new System.Drawing.Point(594, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 23);
            this.comboBox1.TabIndex = 13;
            // 
            // 客户
            // 
            this.客户.AutoSize = true;
            this.客户.Location = new System.Drawing.Point(782, 41);
            this.客户.Margin = new System.Windows.Forms.Padding(35, 6, 0, 3);
            this.客户.Name = "客户";
            this.客户.Size = new System.Drawing.Size(45, 15);
            this.客户.TabIndex = 10;
            this.客户.Text = "客户:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 35);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.button2.Name = "button2";
            this.tableLayoutPanel1.SetRowSpan(this.button2, 2);
            this.button2.Size = new System.Drawing.Size(144, 35);
            this.button2.TabIndex = 8;
            this.button2.Text = "全选/全不选";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxKH
            // 
            this.textBoxKH.Location = new System.Drawing.Point(831, 35);
            this.textBoxKH.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.textBoxKH.Name = "textBoxKH";
            this.textBoxKH.Size = new System.Drawing.Size(100, 25);
            this.textBoxKH.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1109, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "生产线:";
            // 
            // textBoxCK
            // 
            this.textBoxCK.Location = new System.Drawing.Point(1003, 35);
            this.textBoxCK.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.textBoxCK.Name = "textBoxCK";
            this.textBoxCK.Size = new System.Drawing.Size(100, 25);
            this.textBoxCK.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(952, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(18, 6, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "仓库:";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerEnd.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(253, 78);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 25);
            this.dateTimePickerEnd.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(172, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 9, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 31);
            this.label3.TabIndex = 11;
            this.label3.Text = "结束日期:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1281, 41);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "行备注:";
            // 
            // textBoxHBZ
            // 
            this.textBoxHBZ.Location = new System.Drawing.Point(1347, 38);
            this.textBoxHBZ.Name = "textBoxHBZ";
            this.textBoxHBZ.Size = new System.Drawing.Size(100, 25);
            this.textBoxHBZ.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1453, 41);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "物料名称:";
            // 
            // textBoxWLMC
            // 
            this.textBoxWLMC.Location = new System.Drawing.Point(1534, 38);
            this.textBoxWLMC.Name = "textBoxWLMC";
            this.textBoxWLMC.Size = new System.Drawing.Size(100, 25);
            this.textBoxWLMC.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(513, 81);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "规格描述:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(750, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "有无玻璃:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(937, 81);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "框颜色:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1109, 81);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 21;
            this.label10.Text = "框材质:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1293, 81);
            this.label11.Margin = new System.Windows.Forms.Padding(15, 6, 0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "类型:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1480, 81);
            this.label12.Margin = new System.Windows.Forms.Padding(30, 6, 0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 15);
            this.label12.TabIndex = 23;
            this.label12.Text = "简称:";
            // 
            // textBoxGGMS
            // 
            this.textBoxGGMS.Location = new System.Drawing.Point(594, 78);
            this.textBoxGGMS.Name = "textBoxGGMS";
            this.textBoxGGMS.Size = new System.Drawing.Size(150, 25);
            this.textBoxGGMS.TabIndex = 24;
            // 
            // textBoxYWBL
            // 
            this.textBoxYWBL.Location = new System.Drawing.Point(831, 78);
            this.textBoxYWBL.Name = "textBoxYWBL";
            this.textBoxYWBL.Size = new System.Drawing.Size(100, 25);
            this.textBoxYWBL.TabIndex = 25;
            // 
            // textBoxKYS
            // 
            this.textBoxKYS.Location = new System.Drawing.Point(1003, 78);
            this.textBoxKYS.Name = "textBoxKYS";
            this.textBoxKYS.Size = new System.Drawing.Size(100, 25);
            this.textBoxKYS.TabIndex = 26;
            // 
            // textBoxKCZ
            // 
            this.textBoxKCZ.Location = new System.Drawing.Point(1175, 78);
            this.textBoxKCZ.Name = "textBoxKCZ";
            this.textBoxKCZ.Size = new System.Drawing.Size(100, 25);
            this.textBoxKCZ.TabIndex = 27;
            // 
            // textBoxLX
            // 
            this.textBoxLX.Location = new System.Drawing.Point(1347, 78);
            this.textBoxLX.Name = "textBoxLX";
            this.textBoxLX.Size = new System.Drawing.Size(100, 25);
            this.textBoxLX.TabIndex = 28;
            // 
            // textBoxJC
            // 
            this.textBoxJC.Location = new System.Drawing.Point(1534, 78);
            this.textBoxJC.Name = "textBoxJC";
            this.textBoxJC.Size = new System.Drawing.Size(100, 25);
            this.textBoxJC.TabIndex = 29;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(594, 653);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 44);
            this.button3.TabIndex = 30;
            this.button3.Text = "导出PDF";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // GetPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 720);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GetPicture";
            this.Text = "画先生";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GetPicture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button CreateInfo;
        private System.Windows.Forms.Label 日期;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxKH;
        private System.Windows.Forms.Label 客户;
        private System.Windows.Forms.TextBox textBoxCK;
        private System.Windows.Forms.TextBox textBoxSCX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Choose;
        private System.Windows.Forms.DataGridViewImageColumn Images;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxHBZ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxWLMC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxGGMS;
        private System.Windows.Forms.TextBox textBoxYWBL;
        private System.Windows.Forms.TextBox textBoxKYS;
        private System.Windows.Forms.TextBox textBoxKCZ;
        private System.Windows.Forms.TextBox textBoxLX;
        private System.Windows.Forms.TextBox textBoxJC;
        private System.Windows.Forms.Button button3;
    }
}

