using System.Windows.Forms;


namespace Sorting
{
    partial class MainForm
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
            DialogResult rs = MessageBox.Show("Bạn thực sự muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                return;
            }
            if (sortingThread != null)  // Hủy thread nếu lúc tắt vẫn đang chạy
                sortingThread.Abort();
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
            this.sortPanel = new System.Windows.Forms.Panel();
            this.quickSortRadioButton = new System.Windows.Forms.RadioButton();
            this.sortLabel = new System.Windows.Forms.Label();
            this.mergeSortRadioButton = new System.Windows.Forms.RadioButton();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.cancelSortingButton = new System.Windows.Forms.Button();
            this.destroyButton = new System.Windows.Forms.Button();
            this.batDauButton = new System.Windows.Forms.Button();
            this.tamDungButton = new System.Windows.Forms.Button();
            this.controlLabel = new System.Windows.Forms.Label();
            this.debugPanel = new System.Windows.Forms.Panel();
            this.debugCheckBox = new System.Windows.Forms.CheckBox();
            this.debugLabel = new System.Windows.Forms.Label();
            this.directionPanel = new System.Windows.Forms.Panel();
            this.giamRadioButton = new System.Windows.Forms.RadioButton();
            this.directionLabel = new System.Windows.Forms.Label();
            this.tangRadioButton = new System.Windows.Forms.RadioButton();
            this.originalLabel = new System.Windows.Forms.Label();
            this.unsortedPanel = new System.Windows.Forms.Panel();
            this.sortingPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.initializationPanel = new System.Windows.Forms.Panel();
            this.nhapMotDayButton = new System.Windows.Forms.Button();
            this.soPhanTuLabel = new System.Windows.Forms.Label();
            this.soPhanTuTextBox = new System.Windows.Forms.TextBox();
            this.taoNgauNghienButton = new System.Windows.Forms.Button();
            this.initializationLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sortPanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.directionPanel.SuspendLayout();
            this.unsortedPanel.SuspendLayout();
            this.sortingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            this.initializationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sortPanel
            // 
            this.sortPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.sortPanel.Controls.Add(this.quickSortRadioButton);
            this.sortPanel.Controls.Add(this.sortLabel);
            this.sortPanel.Controls.Add(this.mergeSortRadioButton);
            this.sortPanel.Location = new System.Drawing.Point(13, 13);
            this.sortPanel.Margin = new System.Windows.Forms.Padding(4);
            this.sortPanel.Name = "sortPanel";
            this.sortPanel.Size = new System.Drawing.Size(390, 166);
            this.sortPanel.TabIndex = 3;
            // 
            // quickSortRadioButton
            // 
            this.quickSortRadioButton.AutoSize = true;
            this.quickSortRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.quickSortRadioButton.Font = new System.Drawing.Font("Corbel", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quickSortRadioButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.quickSortRadioButton.Location = new System.Drawing.Point(223, 78);
            this.quickSortRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.quickSortRadioButton.Name = "quickSortRadioButton";
            this.quickSortRadioButton.Size = new System.Drawing.Size(126, 31);
            this.quickSortRadioButton.TabIndex = 12;
            this.quickSortRadioButton.TabStop = true;
            this.quickSortRadioButton.Text = "Quick sort";
            this.quickSortRadioButton.UseVisualStyleBackColor = false;
            this.quickSortRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // sortLabel
            // 
            this.sortLabel.AutoSize = true;
            this.sortLabel.BackColor = System.Drawing.Color.Transparent;
            this.sortLabel.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.sortLabel.Location = new System.Drawing.Point(92, 14);
            this.sortLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sortLabel.Name = "sortLabel";
            this.sortLabel.Size = new System.Drawing.Size(168, 23);
            this.sortLabel.TabIndex = 99;
            this.sortLabel.Text = "Thuật toán sắp xếp";
            // 
            // mergeSortRadioButton
            // 
            this.mergeSortRadioButton.AutoSize = true;
            this.mergeSortRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.mergeSortRadioButton.Font = new System.Drawing.Font("Corbel", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mergeSortRadioButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.mergeSortRadioButton.Location = new System.Drawing.Point(37, 78);
            this.mergeSortRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.mergeSortRadioButton.Name = "mergeSortRadioButton";
            this.mergeSortRadioButton.Size = new System.Drawing.Size(132, 31);
            this.mergeSortRadioButton.TabIndex = 7;
            this.mergeSortRadioButton.TabStop = true;
            this.mergeSortRadioButton.Text = "Merge sort";
            this.mergeSortRadioButton.UseVisualStyleBackColor = false;
            this.mergeSortRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.controlPanel.Controls.Add(this.cancelSortingButton);
            this.controlPanel.Controls.Add(this.destroyButton);
            this.controlPanel.Controls.Add(this.batDauButton);
            this.controlPanel.Controls.Add(this.tamDungButton);
            this.controlPanel.Controls.Add(this.controlLabel);
            this.controlPanel.Location = new System.Drawing.Point(412, 15);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(4);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(408, 285);
            this.controlPanel.TabIndex = 15;
            this.controlPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseClick);
            // 
            // cancelSortingButton
            // 
            this.cancelSortingButton.BackColor = System.Drawing.Color.Red;
            this.cancelSortingButton.Enabled = false;
            this.cancelSortingButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cancelSortingButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.cancelSortingButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.cancelSortingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelSortingButton.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelSortingButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.cancelSortingButton.Location = new System.Drawing.Point(196, 182);
            this.cancelSortingButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelSortingButton.Name = "cancelSortingButton";
            this.cancelSortingButton.Size = new System.Drawing.Size(177, 60);
            this.cancelSortingButton.TabIndex = 100;
            this.cancelSortingButton.Text = "HỦY BỎ";
            this.cancelSortingButton.UseVisualStyleBackColor = false;
            this.cancelSortingButton.Click += new System.EventHandler(this.cancelSortingButton_Click);
            // 
            // destroyButton
            // 
            this.destroyButton.BackColor = System.Drawing.Color.DimGray;
            this.destroyButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.destroyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.destroyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.destroyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.destroyButton.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destroyButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.destroyButton.Location = new System.Drawing.Point(45, 92);
            this.destroyButton.Margin = new System.Windows.Forms.Padding(4);
            this.destroyButton.Name = "destroyButton";
            this.destroyButton.Size = new System.Drawing.Size(125, 44);
            this.destroyButton.TabIndex = 4;
            this.destroyButton.Text = "Xóa mảng";
            this.destroyButton.UseVisualStyleBackColor = false;
            this.destroyButton.Click += new System.EventHandler(this.DestroyButton_Click);
            // 
            // batDauButton
            // 
            this.batDauButton.BackColor = System.Drawing.Color.DarkGreen;
            this.batDauButton.Enabled = false;
            this.batDauButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.batDauButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.batDauButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.batDauButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.batDauButton.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.batDauButton.ForeColor = System.Drawing.Color.Snow;
            this.batDauButton.Location = new System.Drawing.Point(23, 182);
            this.batDauButton.Margin = new System.Windows.Forms.Padding(4);
            this.batDauButton.Name = "batDauButton";
            this.batDauButton.Size = new System.Drawing.Size(165, 60);
            this.batDauButton.TabIndex = 33;
            this.batDauButton.Text = "BẮT ĐẦU";
            this.batDauButton.UseVisualStyleBackColor = false;
            this.batDauButton.Click += new System.EventHandler(this.BatDauButton_Click);
            // 
            // tamDungButton
            // 
            this.tamDungButton.BackColor = System.Drawing.Color.DimGray;
            this.tamDungButton.Enabled = false;
            this.tamDungButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.tamDungButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tamDungButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.tamDungButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tamDungButton.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tamDungButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.tamDungButton.Location = new System.Drawing.Point(222, 92);
            this.tamDungButton.Margin = new System.Windows.Forms.Padding(4);
            this.tamDungButton.Name = "tamDungButton";
            this.tamDungButton.Size = new System.Drawing.Size(113, 44);
            this.tamDungButton.TabIndex = 32;
            this.tamDungButton.Text = "Tạm Dừng";
            this.tamDungButton.UseVisualStyleBackColor = false;
            this.tamDungButton.Click += new System.EventHandler(this.TamDungButton_Click);
            // 
            // controlLabel
            // 
            this.controlLabel.AutoSize = true;
            this.controlLabel.BackColor = System.Drawing.Color.Transparent;
            this.controlLabel.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.controlLabel.Location = new System.Drawing.Point(147, 12);
            this.controlLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.controlLabel.Name = "controlLabel";
            this.controlLabel.Size = new System.Drawing.Size(82, 23);
            this.controlLabel.TabIndex = 99;
            this.controlLabel.Text = "Thao tác";
            // 
            // debugPanel
            // 
            this.debugPanel.Location = new System.Drawing.Point(0, 0);
            this.debugPanel.Name = "debugPanel";
            this.debugPanel.Size = new System.Drawing.Size(200, 100);
            this.debugPanel.TabIndex = 101;
            // 
            // debugCheckBox
            // 
            this.debugCheckBox.Location = new System.Drawing.Point(0, 0);
            this.debugCheckBox.Name = "debugCheckBox";
            this.debugCheckBox.Size = new System.Drawing.Size(104, 24);
            this.debugCheckBox.TabIndex = 0;
            // 
            // debugLabel
            // 
            this.debugLabel.Location = new System.Drawing.Point(0, 0);
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(100, 23);
            this.debugLabel.TabIndex = 0;
            // 
            // directionPanel
            // 
            this.directionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.directionPanel.Controls.Add(this.giamRadioButton);
            this.directionPanel.Controls.Add(this.directionLabel);
            this.directionPanel.Controls.Add(this.tangRadioButton);
            this.directionPanel.Location = new System.Drawing.Point(12, 187);
            this.directionPanel.Margin = new System.Windows.Forms.Padding(4);
            this.directionPanel.Name = "directionPanel";
            this.directionPanel.Size = new System.Drawing.Size(391, 113);
            this.directionPanel.TabIndex = 17;
            // 
            // giamRadioButton
            // 
            this.giamRadioButton.AutoSize = true;
            this.giamRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.giamRadioButton.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giamRadioButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.giamRadioButton.Location = new System.Drawing.Point(235, 52);
            this.giamRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.giamRadioButton.Name = "giamRadioButton";
            this.giamRadioButton.Size = new System.Drawing.Size(88, 33);
            this.giamRadioButton.TabIndex = 15;
            this.giamRadioButton.Text = "Giảm";
            this.giamRadioButton.UseVisualStyleBackColor = false;
            this.giamRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // directionLabel
            // 
            this.directionLabel.AutoSize = true;
            this.directionLabel.BackColor = System.Drawing.Color.Transparent;
            this.directionLabel.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directionLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.directionLabel.Location = new System.Drawing.Point(120, 10);
            this.directionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.directionLabel.Name = "directionLabel";
            this.directionLabel.Size = new System.Drawing.Size(120, 23);
            this.directionLabel.TabIndex = 99;
            this.directionLabel.Text = "Cách sắp xếp ";
            // 
            // tangRadioButton
            // 
            this.tangRadioButton.AutoSize = true;
            this.tangRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.tangRadioButton.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tangRadioButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.tangRadioButton.Location = new System.Drawing.Point(57, 52);
            this.tangRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.tangRadioButton.Name = "tangRadioButton";
            this.tangRadioButton.Size = new System.Drawing.Size(83, 33);
            this.tangRadioButton.TabIndex = 14;
            this.tangRadioButton.Text = "Tăng";
            this.tangRadioButton.UseVisualStyleBackColor = false;
            this.tangRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // originalLabel
            // 
            this.originalLabel.AutoSize = true;
            this.originalLabel.BackColor = System.Drawing.Color.Transparent;
            this.originalLabel.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originalLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.originalLabel.Location = new System.Drawing.Point(566, 9);
            this.originalLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.originalLabel.Name = "originalLabel";
            this.originalLabel.Size = new System.Drawing.Size(169, 23);
            this.originalLabel.TabIndex = 99;
            this.originalLabel.Text = "mảng chưa sắp xếp";
            // 
            // unsortedPanel
            // 
            this.unsortedPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.unsortedPanel.Controls.Add(this.originalLabel);
            this.unsortedPanel.Location = new System.Drawing.Point(12, 308);
            this.unsortedPanel.Margin = new System.Windows.Forms.Padding(4);
            this.unsortedPanel.Name = "unsortedPanel";
            this.unsortedPanel.Size = new System.Drawing.Size(1342, 103);
            this.unsortedPanel.TabIndex = 19;
            this.unsortedPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseClick);
            // 
            // sortingPanel
            // 
            this.sortingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.sortingPanel.Controls.Add(this.label2);
            this.sortingPanel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.sortingPanel.Location = new System.Drawing.Point(12, 418);
            this.sortingPanel.Name = "sortingPanel";
            this.sortingPanel.Size = new System.Drawing.Size(1342, 337);
            this.sortingPanel.TabIndex = 21;
            this.sortingPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(1489, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 101;
            this.label2.Text = "Tốc Độ";
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.speedTrackBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.speedTrackBar.LargeChange = 1;
            this.speedTrackBar.Location = new System.Drawing.Point(1305, 68);
            this.speedTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.speedTrackBar.Maximum = 0;
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.speedTrackBar.Size = new System.Drawing.Size(56, 232);
            this.speedTrackBar.TabIndex = 22;
            this.speedTrackBar.TickFrequency = 10;
            this.speedTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.speedTrackBar.ValueChanged += new System.EventHandler(this.speedTrackBar_ValueChanged);
            // 
            // initializationPanel
            // 
            this.initializationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.initializationPanel.Controls.Add(this.nhapMotDayButton);
            this.initializationPanel.Controls.Add(this.soPhanTuLabel);
            this.initializationPanel.Controls.Add(this.soPhanTuTextBox);
            this.initializationPanel.Controls.Add(this.taoNgauNghienButton);
            this.initializationPanel.Controls.Add(this.initializationLabel);
            this.initializationPanel.Location = new System.Drawing.Point(834, 18);
            this.initializationPanel.Margin = new System.Windows.Forms.Padding(4);
            this.initializationPanel.Name = "initializationPanel";
            this.initializationPanel.Size = new System.Drawing.Size(456, 282);
            this.initializationPanel.TabIndex = 14;
            // 
            // nhapMotDayButton
            // 
            this.nhapMotDayButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.nhapMotDayButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.nhapMotDayButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.nhapMotDayButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.nhapMotDayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nhapMotDayButton.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhapMotDayButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.nhapMotDayButton.Location = new System.Drawing.Point(293, 151);
            this.nhapMotDayButton.Margin = new System.Windows.Forms.Padding(4);
            this.nhapMotDayButton.Name = "nhapMotDayButton";
            this.nhapMotDayButton.Size = new System.Drawing.Size(112, 52);
            this.nhapMotDayButton.TabIndex = 100;
            this.nhapMotDayButton.Text = "Nhập FILE";
            this.nhapMotDayButton.UseVisualStyleBackColor = false;
            this.nhapMotDayButton.Click += new System.EventHandler(this.nhapMotDayButton_Click);
            // 
            // soPhanTuLabel
            // 
            this.soPhanTuLabel.AutoSize = true;
            this.soPhanTuLabel.BackColor = System.Drawing.Color.Transparent;
            this.soPhanTuLabel.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soPhanTuLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.soPhanTuLabel.Location = new System.Drawing.Point(110, 73);
            this.soPhanTuLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.soPhanTuLabel.Name = "soPhanTuLabel";
            this.soPhanTuLabel.Size = new System.Drawing.Size(107, 24);
            this.soPhanTuLabel.TabIndex = 99;
            this.soPhanTuLabel.Text = "Số phần tử:";
            // 
            // soPhanTuTextBox
            // 
            this.soPhanTuTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.soPhanTuTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.soPhanTuTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soPhanTuTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.soPhanTuTextBox.Location = new System.Drawing.Point(234, 70);
            this.soPhanTuTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.soPhanTuTextBox.MaxLength = 2;
            this.soPhanTuTextBox.Name = "soPhanTuTextBox";
            this.soPhanTuTextBox.Size = new System.Drawing.Size(65, 30);
            this.soPhanTuTextBox.TabIndex = 0;
            this.soPhanTuTextBox.Text = "10";
            this.soPhanTuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soPhanTuTextBox.TextChanged += new System.EventHandler(this.SoPhanTuTextBox_TextChanged);
            this.soPhanTuTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoPhanTuTextBox_KeyPress);
            this.soPhanTuTextBox.LostFocus += new System.EventHandler(this.SoPhanTuTextBox_LostFocus);
            // 
            // taoNgauNghienButton
            // 
            this.taoNgauNghienButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.taoNgauNghienButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.taoNgauNghienButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.taoNgauNghienButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.taoNgauNghienButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taoNgauNghienButton.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taoNgauNghienButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.taoNgauNghienButton.Location = new System.Drawing.Point(82, 151);
            this.taoNgauNghienButton.Margin = new System.Windows.Forms.Padding(4);
            this.taoNgauNghienButton.Name = "taoNgauNghienButton";
            this.taoNgauNghienButton.Size = new System.Drawing.Size(113, 52);
            this.taoNgauNghienButton.TabIndex = 30;
            this.taoNgauNghienButton.Text = "Tạo ngẫu nhiên";
            this.taoNgauNghienButton.UseVisualStyleBackColor = false;
            this.taoNgauNghienButton.Click += new System.EventHandler(this.TaoNgauNghienButton_Click);
            // 
            // initializationLabel
            // 
            this.initializationLabel.AutoSize = true;
            this.initializationLabel.BackColor = System.Drawing.Color.Transparent;
            this.initializationLabel.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initializationLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.initializationLabel.Location = new System.Drawing.Point(162, 9);
            this.initializationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.initializationLabel.Name = "initializationLabel";
            this.initializationLabel.Size = new System.Drawing.Size(111, 23);
            this.initializationLabel.TabIndex = 99;
            this.initializationLabel.Text = "Tạo phần tử";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(1298, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 23);
            this.label3.TabIndex = 100;
            this.label3.Text = "Tốc độ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1374, 767);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sortingPanel);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.initializationPanel);
            this.Controls.Add(this.speedTrackBar);
            this.Controls.Add(this.sortPanel);
            this.Controls.Add(this.unsortedPanel);
            this.Controls.Add(this.debugPanel);
            this.Controls.Add(this.directionPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thuật toán sắp xếp";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.sortPanel.ResumeLayout(false);
            this.sortPanel.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.directionPanel.ResumeLayout(false);
            this.directionPanel.PerformLayout();
            this.unsortedPanel.ResumeLayout(false);
            this.unsortedPanel.PerformLayout();
            this.sortingPanel.ResumeLayout(false);
            this.sortingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            this.initializationPanel.ResumeLayout(false);
            this.initializationPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel sortPanel;
        private System.Windows.Forms.Label sortLabel;
        private System.Windows.Forms.RadioButton mergeSortRadioButton;
        private System.Windows.Forms.RadioButton quickSortRadioButton;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Label controlLabel;
        private System.Windows.Forms.Panel debugPanel;
        private System.Windows.Forms.Label debugLabel;
        private System.Windows.Forms.Panel directionPanel;
        private System.Windows.Forms.Label originalLabel;
        private System.Windows.Forms.Panel unsortedPanel;
        private System.Windows.Forms.CheckBox debugCheckBox;
        private System.Windows.Forms.RadioButton giamRadioButton;
        private System.Windows.Forms.RadioButton tangRadioButton;
        private System.Windows.Forms.Panel sortingPanel;
        public System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.Button tamDungButton;
        private System.Windows.Forms.Button batDauButton;
        private System.Windows.Forms.Button cancelSortingButton;
        private System.Windows.Forms.Button destroyButton;
        private System.Windows.Forms.Panel initializationPanel;
        private System.Windows.Forms.Label soPhanTuLabel;
        private System.Windows.Forms.TextBox soPhanTuTextBox;
        private System.Windows.Forms.Button taoNgauNghienButton;
        private System.Windows.Forms.Label initializationLabel;
 
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label directionLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button nhapMotDayButton;
    }
}

