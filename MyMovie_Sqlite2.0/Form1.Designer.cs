namespace MyMovie_Sqlite2._0
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.操作 = new System.Windows.Forms.GroupBox();
            this.cbSelectQuery = new System.Windows.Forms.ComboBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.btnUpdateNum = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnDelFolder = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnCheckDiff = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblImageName = new System.Windows.Forms.Label();
            this.btnEditTime = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.gbNfoEdit = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnAddActor = new System.Windows.Forms.Button();
            this.txtActor = new System.Windows.Forms.TextBox();
            this.BtnAddGenre = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGenre = new System.Windows.Forms.ComboBox();
            this.gbNfo = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.番号类 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnFindSame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.操作.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbNfoEdit.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.番号类.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(874, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "扫描并导入数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1011, 586);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // 操作
            // 
            this.操作.Controls.Add(this.btnFindSame);
            this.操作.Controls.Add(this.cbSelectQuery);
            this.操作.Controls.Add(this.lblPercent);
            this.操作.Controls.Add(this.btnUpdateNum);
            this.操作.Controls.Add(this.progressBar1);
            this.操作.Controls.Add(this.btnDelFolder);
            this.操作.Controls.Add(this.btnPlay);
            this.操作.Controls.Add(this.btnCheckDiff);
            this.操作.Controls.Add(this.btnReset);
            this.操作.Controls.Add(this.label1);
            this.操作.Controls.Add(this.txtQuery);
            this.操作.Controls.Add(this.button1);
            this.操作.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.操作.Location = new System.Drawing.Point(23, 7);
            this.操作.Name = "操作";
            this.操作.Size = new System.Drawing.Size(1467, 42);
            this.操作.TabIndex = 2;
            this.操作.TabStop = false;
            this.操作.Text = "操作";
            // 
            // cbSelectQuery
            // 
            this.cbSelectQuery.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbSelectQuery.FormattingEnabled = true;
            this.cbSelectQuery.Items.AddRange(new object[] {
            "文件名",
            "演员名",
            "字幕",
            "影片质量"});
            this.cbSelectQuery.Location = new System.Drawing.Point(65, 14);
            this.cbSelectQuery.Margin = new System.Windows.Forms.Padding(2);
            this.cbSelectQuery.Name = "cbSelectQuery";
            this.cbSelectQuery.Size = new System.Drawing.Size(74, 24);
            this.cbSelectQuery.TabIndex = 10;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.ForeColor = System.Drawing.Color.Green;
            this.lblPercent.Location = new System.Drawing.Point(830, 17);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(19, 17);
            this.lblPercent.TabIndex = 9;
            this.lblPercent.Text = "%";
            // 
            // btnUpdateNum
            // 
            this.btnUpdateNum.Location = new System.Drawing.Point(1291, 12);
            this.btnUpdateNum.Name = "btnUpdateNum";
            this.btnUpdateNum.Size = new System.Drawing.Size(94, 23);
            this.btnUpdateNum.TabIndex = 8;
            this.btnUpdateNum.Text = "更新Num表";
            this.btnUpdateNum.UseVisualStyleBackColor = true;
            this.btnUpdateNum.Click += new System.EventHandler(this.BtnUpdateNum_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar1.Location = new System.Drawing.Point(461, 14);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(365, 18);
            this.progressBar1.TabIndex = 7;
            // 
            // btnDelFolder
            // 
            this.btnDelFolder.Location = new System.Drawing.Point(1073, 13);
            this.btnDelFolder.Name = "btnDelFolder";
            this.btnDelFolder.Size = new System.Drawing.Size(107, 23);
            this.btnDelFolder.TabIndex = 6;
            this.btnDelFolder.Text = "删除当前文件夹";
            this.btnDelFolder.UseVisualStyleBackColor = true;
            this.btnDelFolder.Click += new System.EventHandler(this.btnDelFolder_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnPlay.Location = new System.Drawing.Point(982, 13);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(82, 23);
            this.btnPlay.TabIndex = 5;
            this.btnPlay.Text = "播放视频";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnCheckDiff
            // 
            this.btnCheckDiff.Location = new System.Drawing.Point(1191, 13);
            this.btnCheckDiff.Name = "btnCheckDiff";
            this.btnCheckDiff.Size = new System.Drawing.Size(94, 23);
            this.btnCheckDiff.TabIndex = 4;
            this.btnCheckDiff.Text = "更改文件夹名";
            this.btnCheckDiff.UseVisualStyleBackColor = true;
            this.btnCheckDiff.Click += new System.EventHandler(this.btnCheckDiff_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(352, 13);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(42, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "查询按";
            // 
            // txtQuery
            // 
            this.txtQuery.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtQuery.Location = new System.Drawing.Point(144, 14);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(202, 23);
            this.txtQuery.TabIndex = 0;
            this.txtQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuery_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(1047, 131);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(444, 318);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1283, 455);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(83, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "下一张";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(1165, 455);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(76, 23);
            this.btnPre.TabIndex = 5;
            this.btnPre.Text = "上一张";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFileName.ForeColor = System.Drawing.Color.OliveDrab;
            this.lblFileName.Location = new System.Drawing.Point(6, 4);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(434, 60);
            this.lblFileName.TabIndex = 6;
            this.lblFileName.Text = "lblFileName";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFileName);
            this.panel1.Location = new System.Drawing.Point(1046, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 74);
            this.panel1.TabIndex = 7;
            // 
            // lblImageName
            // 
            this.lblImageName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImageName.ForeColor = System.Drawing.Color.Blue;
            this.lblImageName.Location = new System.Drawing.Point(1043, 482);
            this.lblImageName.Name = "lblImageName";
            this.lblImageName.Size = new System.Drawing.Size(208, 29);
            this.lblImageName.TabIndex = 7;
            this.lblImageName.Text = "lblImageName";
            this.lblImageName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnEditTime
            // 
            this.btnEditTime.Location = new System.Drawing.Point(1396, 487);
            this.btnEditTime.Name = "btnEditTime";
            this.btnEditTime.Size = new System.Drawing.Size(80, 23);
            this.btnEditTime.TabIndex = 8;
            this.btnEditTime.Text = "修改图片时间";
            this.btnEditTime.UseVisualStyleBackColor = true;
            this.btnEditTime.Click += new System.EventHandler(this.btnEditTime_Click);
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("微软雅黑 Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDate.Location = new System.Drawing.Point(1258, 490);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(133, 21);
            this.txtDate.TabIndex = 9;
            // 
            // gbNfoEdit
            // 
            this.gbNfoEdit.Controls.Add(this.label3);
            this.gbNfoEdit.Controls.Add(this.BtnAddActor);
            this.gbNfoEdit.Controls.Add(this.txtActor);
            this.gbNfoEdit.Controls.Add(this.BtnAddGenre);
            this.gbNfoEdit.Controls.Add(this.label2);
            this.gbNfoEdit.Controls.Add(this.cbGenre);
            this.gbNfoEdit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbNfoEdit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbNfoEdit.Location = new System.Drawing.Point(1048, 619);
            this.gbNfoEdit.Margin = new System.Windows.Forms.Padding(2);
            this.gbNfoEdit.Name = "gbNfoEdit";
            this.gbNfoEdit.Padding = new System.Windows.Forms.Padding(2);
            this.gbNfoEdit.Size = new System.Drawing.Size(442, 54);
            this.gbNfoEdit.TabIndex = 10;
            this.gbNfoEdit.TabStop = false;
            this.gbNfoEdit.Text = "NFO操作";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(233, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Actor";
            // 
            // BtnAddActor
            // 
            this.BtnAddActor.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAddActor.Location = new System.Drawing.Point(382, 21);
            this.BtnAddActor.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAddActor.Name = "BtnAddActor";
            this.BtnAddActor.Size = new System.Drawing.Size(56, 22);
            this.BtnAddActor.TabIndex = 4;
            this.BtnAddActor.Text = "添加";
            this.BtnAddActor.UseVisualStyleBackColor = true;
            // 
            // txtActor
            // 
            this.txtActor.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtActor.Location = new System.Drawing.Point(275, 21);
            this.txtActor.Margin = new System.Windows.Forms.Padding(2);
            this.txtActor.Name = "txtActor";
            this.txtActor.Size = new System.Drawing.Size(103, 23);
            this.txtActor.TabIndex = 3;
            // 
            // BtnAddGenre
            // 
            this.BtnAddGenre.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAddGenre.Location = new System.Drawing.Point(160, 19);
            this.BtnAddGenre.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAddGenre.Name = "BtnAddGenre";
            this.BtnAddGenre.Size = new System.Drawing.Size(56, 22);
            this.BtnAddGenre.TabIndex = 2;
            this.BtnAddGenre.Text = "添加";
            this.BtnAddGenre.UseVisualStyleBackColor = true;
            this.BtnAddGenre.Click += new System.EventHandler(this.BtnAddGenre_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Genre";
            // 
            // cbGenre
            // 
            this.cbGenre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGenre.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbGenre.FormattingEnabled = true;
            this.cbGenre.Items.AddRange(new object[] {
            "中文字幕",
            "高清",
            "清晰"});
            this.cbGenre.Location = new System.Drawing.Point(48, 20);
            this.cbGenre.Margin = new System.Windows.Forms.Padding(2);
            this.cbGenre.Name = "cbGenre";
            this.cbGenre.Size = new System.Drawing.Size(108, 25);
            this.cbGenre.TabIndex = 0;
            // 
            // gbNfo
            // 
            this.gbNfo.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbNfo.Location = new System.Drawing.Point(1048, 516);
            this.gbNfo.Margin = new System.Windows.Forms.Padding(2);
            this.gbNfo.Name = "gbNfo";
            this.gbNfo.Padding = new System.Windows.Forms.Padding(2);
            this.gbNfo.Size = new System.Drawing.Size(442, 106);
            this.gbNfo.TabIndex = 12;
            this.gbNfo.TabStop = false;
            this.gbNfo.Text = "Genre与Actor";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.番号类);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(12, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1025, 618);
            this.tabControl1.TabIndex = 13;
            // 
            // 番号类
            // 
            this.番号类.Controls.Add(this.dataGridView1);
            this.番号类.Location = new System.Drawing.Point(4, 22);
            this.番号类.Name = "番号类";
            this.番号类.Padding = new System.Windows.Forms.Padding(3);
            this.番号类.Size = new System.Drawing.Size(1017, 592);
            this.番号类.TabIndex = 0;
            this.番号类.Text = "番号类";
            this.番号类.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1017, 592);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "综艺类";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1017, 592);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "青色类";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1017, 592);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "话匣子";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnFindSame
            // 
            this.btnFindSame.Location = new System.Drawing.Point(400, 13);
            this.btnFindSame.Name = "btnFindSame";
            this.btnFindSame.Size = new System.Drawing.Size(42, 23);
            this.btnFindSame.TabIndex = 11;
            this.btnFindSame.Text = "查重";
            this.btnFindSame.UseVisualStyleBackColor = true;
            this.btnFindSame.Click += new System.EventHandler(this.btnFindSame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1493, 678);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gbNfo);
            this.Controls.Add(this.gbNfoEdit);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.btnEditTime);
            this.Controls.Add(this.lblImageName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.操作);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Movie文件夹管理";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.操作.ResumeLayout(false);
            this.操作.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gbNfoEdit.ResumeLayout(false);
            this.gbNfoEdit.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.番号类.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox 操作;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCheckDiff;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblImageName;
        private System.Windows.Forms.Button btnEditTime;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnDelFolder;
        private System.Windows.Forms.GroupBox gbNfoEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGenre;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnAddActor;
        private System.Windows.Forms.TextBox txtActor;
        private System.Windows.Forms.Button BtnAddGenre;
        private System.Windows.Forms.GroupBox gbNfo;
        private System.Windows.Forms.Button btnUpdateNum;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.ComboBox cbSelectQuery;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage 番号类;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnFindSame;
    }
}