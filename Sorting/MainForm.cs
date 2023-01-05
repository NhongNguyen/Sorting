using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Sorting
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            InitializeComponentExtend();

            // Tắt các Button cần tắt khi khởi động
            destroyButton.Enabled = batDauButton.Enabled = tamDungButton.Enabled = cancelSortingButton.Enabled = false;

            // track bar
            speedTrackBar.Maximum = ThamSo.TocDo;
            speedTrackBar.Minimum = 0;
            speedTrackBar.Value = ThamSo.TocDo / 2;
            speedTrackBar.LargeChange = 1;

            // radiobutton check
            tangRadioButton.Checked = true;
           


            // Load các thông tin cài đặt của người dùng 
      
            ThamSo.KichCoNode = Properties.Settings.Default.KichCoNode;
            ThamSo.KhoanCachGiuaCacNode = Properties.Settings.Default.KhoanCachGiuaCacNode;
           

           

            // Tắt phần check lỗi Cross-thread : lỗi xảy ra do thread con điều khiển những tài nguyên vốn dĩ k do nó tạo ra
            Control.CheckForIllegalCrossThreadCalls = false;

        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                CapNhatYTuongVaCode();
            }

        }
        private void CapNhatYTuongVaCode()
        {
            bool tang = tangRadioButton.Checked;
            if (quickSortRadioButton.Checked)
            {
                
                hamSapXep = QuickSort;
            }
            else if (mergeSortRadioButton.Checked)
            {
                hamSapXep = MergeSort;
            }
        }




        private void TaoNgauNghienButton_Click(object sender, EventArgs e)
        {
            TaoMangNgauNhien(int.Parse(soPhanTuTextBox.Text));

        }

        private void TamDungButton_Click(object sender, EventArgs e)
        {
            TamDung();
        }

        private void BatDauButton_Click(object sender, EventArgs e)
        {
            BatDauSapXep();
        }
         private void DestroyButton_Click(object sender, EventArgs e)
        {
            XoaMang();
            batDauButton.Enabled = false;
        }
        private void SoPhanTuTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')    // nếu là nút BackSpace thì bỏ qua bước check này --> cho phép nút Backspace hoạt động
            {
                e.Handled = !char.IsNumber(e.KeyChar);
                // Handled == true thì event bị hủy
                // isNumber(True) + not = false --> cho phép nhập
            }
        }
        private void SoPhanTuTextBox_TextChanged(object sender, EventArgs e)
        {
            if (soPhanTuTextBox.Text != "")
            {
                int soPhanTu = int.Parse(soPhanTuTextBox.Text);
                if (mergeSortRadioButton.Checked == true && soPhanTu > 10)
                {
                    soPhanTuTextBox.Text = "10";
                }
                if (soPhanTu > ThamSo.SoLuongPhanTuMax)
                {
                    soPhanTuTextBox.Text = ThamSo.SoLuongPhanTuMax.ToString();
                }
            }
        }
        private void SoPhanTuTextBox_LostFocus(object sender, EventArgs e)
        {
            if (soPhanTuTextBox.Text == "" || soPhanTuTextBox.Text == "0")
            {
                soPhanTuTextBox.Text = "1";
            }
        }
        private void Panel_MouseClick(object sender, MouseEventArgs e)
        {
            batDauButton.Focus();
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            soPhanTuTextBox.Focus();
        }
       
        private void speedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            ThamSo.TocDo = speedTrackBar.Maximum - speedTrackBar.Value;

        }
        private void cancelSortingButton_Click(object sender, EventArgs e)
        {
            HuyQuaTrinh(nodeArr.Count);

        }
        private void nhapMotDayButton_Click(object sender, EventArgs e)
        {
            ReadFile();
        }

  

        public void ReadFile()
        {
            try
            {
                FileStream fs = new FileStream(".\\..\\..\\FILE.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string str = sr.ReadLine();
                var numbers = str.Split(' ');
                List<int> arr = new List<int>();
                int number = 0;

                foreach (var num in numbers)
                {
                    if (int.TryParse(num, out number))
                        Console.WriteLine("{0}", number);
                    arr.Add(number);
                }

                Console.WriteLine("Array Length: ", arr.Count);

                arr.ForEach(Console.WriteLine);

                if (arr.Count > 20)
                {
                    MessageBox.Show("Số lượng phần tử max là 20", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    XoaMang();
                    ThamSo.KichCoNode = 30 + (18 - arr.Count) * 2;
                    ThamSo.KhoanCachGiuaCacNode = ThamSo.KichCoNode * 2;
                    for (int i = 0; i < arr.Count; i++)
                    {
                        int giaTri = arr[i];
                        Node temp = new Node(i, giaTri);
                        this.sortingPanel.Controls.Add(temp);
                        nodeArr.Add(temp);
                        temp.Location = new Point(root.X + i * ThamSo.KhoanCachGiuaCacNode, root.Y - ThamSo.KichCoNode / 2);
                        TaoLabelSoThuTuChoMang(i);
                    }
                    nodeArr[0].Focus();
                    destroyButton.Enabled = true;
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }

        }
        
    }

    public class MySR : ToolStripSystemRenderer
    {
        public MySR() { }
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
        }
    }
}
