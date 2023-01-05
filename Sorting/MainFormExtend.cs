using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;


namespace Sorting
{

    public partial class MainForm
    {

        private Point root;
        public bool isRunning = false;
        private List<Node> nodeArr = new List<Node>();
        private List<Label> labelSTTArr = new List<Label>();   // dãy số thứ tự
        private Dictionary<string, Label> bienArr;
        private Label daySoChuaSapXepLabel;

        private void InitializeComponentExtend()
        {
            // root
            root.X = 30;
            root.Y = sortingPanel.Size.Height / 2 - 15;

            // Label dãy số chưa sắp xếp
            daySoChuaSapXepLabel = new Label();
            this.unsortedPanel.Controls.Add(daySoChuaSapXepLabel);
            daySoChuaSapXepLabel.TextAlign = ContentAlignment.MiddleCenter;
            daySoChuaSapXepLabel.ForeColor = Color.Cornsilk;
            daySoChuaSapXepLabel.Font = new Font("Consolas", ThamSo.KichCoNode / 5 * 2, FontStyle.Regular);
            daySoChuaSapXepLabel.Size = new Size(unsortedPanel.Size.Width, unsortedPanel.Size.Height);


            // Các label hiển thị các biến
            bienArr = new Dictionary<string, Label>();
            List<string> bienArrString = new List<string>() { "i", "j", "min", "right", "left", "k", "pos", "m", "vt_x", "gap", "a:", "b:", "c:" };
            foreach (string item in bienArrString)
            {
                bienArr.Add(item, new Label());
            }
            foreach (var item in bienArr)
            {

                this.sortingPanel.Controls.Add(item.Value);
                item.Value.TextAlign = ContentAlignment.MiddleCenter;
            }

            bienArr["i"].Size = bienArr["j"].Size = new Size(ThamSo.KichCoNode, 15);
            bienArr["i"].ForeColor = bienArr["j"].ForeColor = ThamSo.MauNodeDangXet;
            bienArr["i"].BackColor = bienArr["j"].BackColor = Color.Transparent;

            bienArr["min"].ForeColor = Color.LightGreen;
            bienArr["min"].Size = new Size(60, 20);
            bienArr["left"].ForeColor = Color.LightGreen;
            bienArr["left"].Size = new Size(60, 20);
            bienArr["right"].ForeColor = Color.IndianRed;
            bienArr["right"].Size = new Size(60, 20);
            bienArr["m"].ForeColor = bienArr["k"].ForeColor = Color.Coral;
            bienArr["m"].Size = bienArr["k"].Size = new Size(40, 15);
            bienArr["pos"].ForeColor = Color.Cornsilk;
            bienArr["pos"].Size = new Size(60, 20);
            bienArr["vt_x"].ForeColor = Color.Yellow;
            bienArr["vt_x"].Size = new Size(60, 20);
            bienArr["gap"].ForeColor = Color.LightGreen;
            bienArr["gap"].Size = new Size(60, 20);
            bienArr["a:"].ForeColor = bienArr["b:"].ForeColor = bienArr["c:"].ForeColor = Color.White;
            bienArr["a:"].Size = bienArr["b:"].Size = bienArr["c:"].Size = new Size(40, 15);
        }

        #region Tạo mảng ngẫu nhiên
        private void TaoMangNgauNhien(int soPhanTu)
        {
            XoaMang();
            ChinhKichCoNode();
            Random rd = new Random();
            for (int i = 0; i < soPhanTu; i++)
            {
                int giaTri = rd.Next(0, 99);
                Node temp = new Node(i, giaTri);
                this.sortingPanel.Controls.Add(temp);
                nodeArr.Add(temp);
                temp.Location = new Point(root.X + i * ThamSo.KhoanCachGiuaCacNode, root.Y - ThamSo.KichCoNode / 2);
                TaoLabelSoThuTuChoMang(i);
            }
            CapNhatDaySoChuaSapXep();
            destroyButton.Enabled = true;
        }
        #endregion

        // Chỉnh kích cỡ Node khi tạo mảng
        private void ChinhKichCoNode()
        {
            int soPhanTu = int.Parse(soPhanTuTextBox.Text);
            //Điều chỉnh khích cỡ node phù hợp với số phần tử
            if (soPhanTu > 14 && soPhanTu <= ThamSo.SoLuongPhanTuMax)
            {
                ThamSo.KichCoNode = 30 + (18 - soPhanTu) * 2;
                ThamSo.KhoanCachGiuaCacNode = ThamSo.KichCoNode * 2;
            }
            else if ((Properties.Settings.Default.KichCoNode > 40 || Properties.Settings.Default.KhoanCachGiuaCacNode > 80) && soPhanTu > 11)
            {
                ThamSo.KichCoNode = 45;
                ThamSo.KhoanCachGiuaCacNode = 85;
            }
            else if (soPhanTu <= 14)
            {
                ThamSo.KichCoNode = Properties.Settings.Default.KichCoNode;
                ThamSo.KhoanCachGiuaCacNode = Properties.Settings.Default.KhoanCachGiuaCacNode;
            }
        }

        // dãy số thứ tự bên dưới mảng
        private void TaoLabelSoThuTuChoMang(int i)
        {
            Label temp = new Label();
            temp.Location = new Point(root.X + i * ThamSo.KhoanCachGiuaCacNode, sortingPanel.Size.Height - 30);
            temp.Font = new Font("Consolas", ThamSo.KichCoNode / 3.3f, FontStyle.Regular);
            temp.BackColor = Color.Transparent;
            temp.ForeColor = Color.White;
            temp.Size = new Size(ThamSo.KichCoNode, ThamSo.KichCoNode / 2);
            temp.TextAlign = ContentAlignment.MiddleCenter;
            temp.Text = i.ToString();
            this.sortingPanel.Controls.Add(temp);
            labelSTTArr.Add(temp);
        }


        #region Xóa mảng hiện tại
        private void XoaMang()
        {
            // Xóa các node
            foreach (Control node in nodeArr)
            {
                node.Dispose();
            }
            nodeArr.Clear();

            // Xóa các label
            foreach (Control label in labelSTTArr)
            {
                label.Dispose();
            }
            labelSTTArr.Clear();

            // Tắt chế độ tạm dừng nếu đang Tạm dừng
            if (Node.IsPause == true)
            {
                TamDung();
            }
            // Cancel các thread đang hoạt động
            if (sortingThread != null)
            {
                sortingThread.Abort();
            }
            foreach (Label item in bienArr.Values)
            {
                item.Visible = false;
            }
            SortRunOrStop(false);

            // Xóa label daySoChuaSapXep
            daySoChuaSapXepLabel.Text = "";

            // đặt lại yTuongTextBox và codeTextbox
            CapNhatYTuongVaCode();

            destroyButton.Enabled = false;
        }
        #endregion

        #region Bắt đầu sắp xếp
        // Các việc cần làm khi sắp xếp bắt đầu - kết thúc
        public void SortRunOrStop(bool IsRun)
        {
            // Nếu dừng mà mảng rỗng thì tắt batDauButton
            if (nodeArr != null)
                batDauButton.Enabled = !IsRun;

            cancelSortingButton.Enabled = IsRun;
            isRunning = IsRun;
           
            taoNgauNghienButton.Enabled = !IsRun;

            // Nếu debug đang bật thì tamdungButton tắt
            if (!debugCheckBox.Checked)
                tamDungButton.Enabled = IsRun;

            foreach (Node node in nodeArr)
            {
                // Chuyển về màu mặc định khi bắt đầu sắp xếp
                if (IsRun)
                {
                    node.BackColor = ThamSo.MauNenNode;
                }
            }
            // tắt các biến label đang hiện thị
            foreach (Label label in bienArr.Values)
            {
                label.Visible = false;
            }

        }

        // Hàm chính để Gọi phần xắp xếp
        Thread sortingThread;
        Action hamSapXep;
            public void BatDauSapXep()
            {
                SortRunOrStop(true);

                if (sortingThread != null)   // Hủy thread nếu vẫn đang chạy
                {
                    sortingThread.Abort();
                }


                sortingThread = new Thread(new ThreadStart(hamSapXep));
                sortingThread.Start();

                // Dùng thread vì : có thể abort khi nào cần, task k làm đc
                // cả task và thread đều k thể tạo control và add vào trong thread khác --> dùng Invoke để giải quyết
            }

        #endregion

        #region Hủy quá trình sắp xếp
        private void HuyQuaTrinh(int soPhanTu)
        {
            string[] mangCu = daySoChuaSapXepLabel.Text.Split();
            XoaMang();

            for (int i = 0; i < soPhanTu; i++)
            {
                int giaTri = int.Parse(mangCu[i]);
                Node temp = new Node(i, giaTri);
                this.sortingPanel.Controls.Add(temp);
                nodeArr.Add(temp);
                temp.Location = new Point(root.X + i * ThamSo.KhoanCachGiuaCacNode, root.Y - ThamSo.KichCoNode / 2);
                TaoLabelSoThuTuChoMang(i);
            }
            CapNhatDaySoChuaSapXep();
            destroyButton.Enabled = true;
        }
        #endregion

        #region Di chuyển và hoán vị Node

        // Hàm di chuyển node đến 1 vị trí
        public void DiChuyenNodeDen(object oNode, object oVitriMoi)  // public delegate void ParameterizedThreadStart(object obj);
        {
            int vitriMoi = (int)oVitriMoi;
            Node node = (Node)oNode;
            if (vitriMoi > node.vitriHienTai)
            {
                node.ChuyenLen();
                node.ChuyenQua(vitriMoi);
                node.ChuyenXuong();
            }
            else if (vitriMoi < node.vitriHienTai)
            {
                node.ChuyenXuong();
                node.ChuyenQua(vitriMoi);
                node.ChuyenLen();
            }

            // Gán lại giá trị vị trí hiện tại
            node.vitriHienTai = vitriMoi;

            // Khi dùng thread thì dùng delegate Callback lại 
            //this.BeginInvoke(moveIsStopped);          // define: public Action moveIsStopped = null;

        }

        // Hoán vị chổ của 2 node
        Task hoanVi1Task;
        Task hoanVi2Task;
        private void HoanVi2Node(int vitriNodeA, int vitriNodeB)
        {
            // Cách dùng task
            hoanVi1Task = Task.Factory.StartNew(() => { DiChuyenNodeDen(nodeArr[vitriNodeA], vitriNodeB); });
            hoanVi2Task = Task.Factory.StartNew(() => { DiChuyenNodeDen(nodeArr[vitriNodeB], vitriNodeA); });
            // note: Task.Factory.StartNew = THÊM task vào cuối hàng đợi và CHẠY ngay khi có thể

            Task.WaitAll(hoanVi1Task, hoanVi1Task);

            // Thay đổi vị trí của node trong mảng nodeArray
            if (nodeArr.Count != 0)                   //check xem nếu mảng còn tồn tại --> trong trường hợp mảng đã bị hủy
            {
                // Đổi màu 2 node sau khi sắp xếp
                Color tempColor = nodeArr[vitriNodeA].BackColor;
                nodeArr[vitriNodeA].BackColor = nodeArr[vitriNodeB].BackColor;//nodeArr[vitriNodeB].BackColor;
                nodeArr[vitriNodeB].BackColor = tempColor;

                Node t = nodeArr[vitriNodeA];
                nodeArr[vitriNodeA] = nodeArr[vitriNodeB];
                nodeArr[vitriNodeB] = t;
            }

            #region Cách dùng thread  -- không dùng vì code dài
            //// inject hàm cần callback vào delegate
            //listNode[vitriNodeA].moveIsStopped = NodeDungDiChuyen;

            //thread1 = new Thread(listNode[vitriNodeA].DiChuyenNodeDen);
            //thread1.Start(vitriNodeB);
            //thread2 = new Thread(listNode[vitriNodeB].DiChuyenNodeDen);
            //thread2.Start(vitriNodeA);

            ///*  Nếu dùng cách này sẽ bị lỗi:

            //    threadControl[0].Join();
            //    hoanViButton.Enabled = true;

            //       -- Loi : Khi dùng Join() current thread sẽ bị block -->  GUI thread/main thread sẽ bị block
            //                Thay vào dùng delegate
            //          Node : Tại sao GUI thread bị block mà event click vẫn đc đưa vào Message Queue ?
            //*/
            #endregion

        }
        #endregion

        #region Tạm dừng
        // Tạm dừng
        public static ManualResetEvent codeListBoxPauseStatus = new ManualResetEvent(true);
        public static bool CodeListBoxIsPause = false;
        void TamDung()
        {
            if (Node.IsPause)
            {
                Node.pauseStatus.Set();     // hàm để resume
                Node.IsPause = false;
                tamDungButton.Text = "Tạm dừng";
            }
            else
            {
                Node.pauseStatus.Reset();    // hàm để pause
                Node.IsPause = true;
                tamDungButton.Text = "Tiếp tục";
            }
            if (CodeListBoxIsPause)
            {
                tamDungButton.Text = "Tạm dừng";
            }
            else
            {
                tamDungButton.Text = "Tiếp tục";
            }
        }
        #endregion


        #region Cập nhật dãy số chưa sắp xếp 
        private void CapNhatDaySoChuaSapXep()
        {
            daySoChuaSapXepLabel.Text = "";
            foreach (Node node in nodeArr)
            {
                node.BackColor = ThamSo.MauNenNode;
                daySoChuaSapXepLabel.Text += node.Text + " ";
            }
        }
        #endregion

        #region Thuật toán

       
        public void QuickSort()
        {
          
            ThucHienQuickSort(0, nodeArr.Count - 1);
            SortRunOrStop(false);
            foreach (Node node in nodeArr)
            {
                node.BackColor = ThamSo.MauNodeDaXetQua;
            }
            if (nodeArr.Count != 0)
            {
                MessageBox.Show("Sắp xếp hoàn tất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ThucHienQuickSort(int left, int right)
        {
           
            int i, j, x, vt_x;
            bienArr["left"].Text = "left = " + left;
            bienArr["left"].Location = new Point(root.X + ThamSo.KhoanCachGiuaCacNode * left - 10, 32);
            bienArr["left"].BackColor = Color.Yellow;
            bienArr["left"].ForeColor = Color.DarkBlue;
            bienArr["left"].Visible = true;
            bienArr["left"].SendToBack();

            bienArr["right"].Text = "right = " + right;
            bienArr["right"].Location = new Point(root.X + ThamSo.KhoanCachGiuaCacNode * right - 10, 12);
            bienArr["right"].BackColor = Color.Yellow;
            bienArr["right"].ForeColor = Color.DarkBlue;
            bienArr["right"].Visible = true;
            bienArr["right"].SendToBack();
            x = nodeArr[(left + right) / 2].giaTri;
           
            vt_x = (left + right) / 2;
            i = left; j = right;
            do
            {
                int z_vt_x = vt_x;
                if (tangRadioButton.Checked == true)
                {
                
                    bienArr["vt_x"].Location = new Point(root.X + ThamSo.KhoanCachGiuaCacNode * vt_x - 10, 188);
                    bienArr["vt_x"].Text = "x = a[" + vt_x + "]";
                    nodeArr[vt_x].BackColor = Color.Yellow;
                    nodeArr[vt_x].ForeColor = Color.Blue;
                    bienArr["vt_x"].Visible = true;
                    bienArr["vt_x"].SendToBack();

                    bienArr["i"].Text = "i = " + i;
                    bienArr["i"].Location = new Point(root.X + ThamSo.KhoanCachGiuaCacNode * i, 208);
                    nodeArr[i].BackColor = ThamSo.MauNodeDangXet;
                    nodeArr[i].ForeColor = Color.Red;
                    bienArr["i"].Visible = true;
                    bienArr["i"].SendToBack();

                    bienArr["j"].Text = "j = " + j;
                    bienArr["j"].Location = new Point(root.X + ThamSo.KhoanCachGiuaCacNode * j, 208);
                    nodeArr[j].BackColor = ThamSo.MauNodeDangXet;
                    nodeArr[j].ForeColor = Color.Red;
                    bienArr["j"].Visible = true;
                    bienArr["j"].SendToBack();
                    while (nodeArr[i].giaTri < x)
                    {
                       
                        int f_i = i;
                        i++;
                        bienArr["i"].Text = "i = " + i;
                        bienArr["i"].Location = new Point(root.X + ThamSo.KhoanCachGiuaCacNode * i, 208);
                        nodeArr[i].BackColor = ThamSo.MauNodeDangXet;
                        nodeArr[i].ForeColor = Color.Red;
                        nodeArr[f_i].BackColor = Color.White;
                        nodeArr[f_i].ForeColor = Color.Purple;
                        bienArr["i"].Visible = true;
                        bienArr["i"].SendToBack();
                    }
                   
                    while (nodeArr[j].giaTri > x)
                    {
                        
                        int f_j = j;
                        j--;
                        bienArr["j"].Text = "j = " + j;
                        bienArr["j"].Location = new Point(root.X + ThamSo.KhoanCachGiuaCacNode * j, 208);
                        nodeArr[j].BackColor = ThamSo.MauNodeDangXet;
                        nodeArr[j].ForeColor = Color.Red;
                        nodeArr[f_j].BackColor = Color.White;
                        nodeArr[f_j].ForeColor = Color.Purple;
                        bienArr["j"].Visible = true;
                        bienArr["j"].SendToBack();
                    }
                }
                else
                {
                    
                    bienArr["vt_x"].Location = new Point(root.X + ThamSo.KhoanCachGiuaCacNode * vt_x - 10, 188);
                    bienArr["vt_x"].Text = "x = a[" + vt_x + "]";
                    nodeArr[vt_x].BackColor = Color.Yellow;
                    nodeArr[vt_x].ForeColor = Color.Blue;
                    bienArr["vt_x"].Visible = true;
                    bienArr["vt_x"].SendToBack();

                    bienArr["i"].Text = "i = " + i;
                    bienArr["i"].Location = new Point(root.X + ThamSo.KhoanCachGiuaCacNode * i, 208);
                    nodeArr[i].BackColor = ThamSo.MauNodeDangXet;
                    nodeArr[i].ForeColor = Color.Red;
                    bienArr["i"].Visible = true;
                    bienArr["i"].SendToBack();

                    bienArr["j"].Text = "j = " + j;
                    bienArr["j"].Location = new Point(root.X + ThamSo.KhoanCachGiuaCacNode * j, 208);
                    nodeArr[j].BackColor = ThamSo.MauNodeDangXet;
                    nodeArr[j].ForeColor = Color.Red;
                    bienArr["j"].Visible = true;
                    bienArr["j"].SendToBack();
                    while (nodeArr[i].giaTri > x)
                    {
                       
                        int f_i = i;
                        i++;
                        bienArr["i"].Text = "i = " + i;
                        bienArr["i"].Location = new Point(root.X + ThamSo.KhoanCachGiuaCacNode * i, 208);
                        nodeArr[i].BackColor = ThamSo.MauNodeDangXet;
                        nodeArr[i].ForeColor = Color.Red;
                        nodeArr[f_i].BackColor = Color.White;
                        nodeArr[f_i].ForeColor = Color.Purple;
                        bienArr["i"].Visible = true;
                        bienArr["i"].SendToBack();
                    }
                   
                    while (nodeArr[j].giaTri < x)
                    {
                      
                        int f_j = j;
                        j--;
                        bienArr["j"].Text = "j = " + j;
                        bienArr["j"].Location = new Point(root.X + ThamSo.KhoanCachGiuaCacNode * j, 208);
                        nodeArr[j].BackColor = ThamSo.MauNodeDangXet;
                        nodeArr[j].ForeColor = Color.Red;
                        nodeArr[f_j].BackColor = Color.White;
                        nodeArr[f_j].ForeColor = Color.Purple;
                        bienArr["j"].Visible = true;
                        bienArr["j"].SendToBack();
                    }
                }
             
                if (i <= j)
                {
                    int f_vt_x = vt_x;
                    if (i == vt_x)
                    {
                        vt_x = j;
                    }
                    else if (j == vt_x)
                    {
                        vt_x = i;
                    }
                
                    HoanVi2Node(i, j);
                    nodeArr[i].BackColor = Color.White;
                    nodeArr[i].ForeColor = Color.Purple;
                    nodeArr[j].BackColor = Color.White;
                    nodeArr[j].ForeColor = Color.Purple;
                    bienArr["vt_x"].Location = new Point(root.X + ThamSo.KhoanCachGiuaCacNode * vt_x - 10, 188);
                    bienArr["vt_x"].Text = "x = a[" + vt_x + "]";
                    nodeArr[vt_x].BackColor = Color.Yellow;
                    nodeArr[vt_x].ForeColor = Color.Blue;
                    nodeArr[f_vt_x].BackColor = Color.White;
                    nodeArr[f_vt_x].ForeColor = Color.Purple;
                    bienArr["vt_x"].Visible = true;
                    bienArr["vt_x"].SendToBack();
                    i++; j--;
                }
                nodeArr[z_vt_x].BackColor = Color.White;
                nodeArr[z_vt_x].ForeColor = Color.Purple;
                nodeArr[i].BackColor = Color.White;
                nodeArr[i].ForeColor = Color.Purple;
                if (j != -1)
                {
                    nodeArr[j].BackColor = Color.White;
                    nodeArr[j].ForeColor = Color.Purple;
                }
               
               
            } while (i <= j);
           
            if (left < j)
            {
               
                ThucHienQuickSort(left, j);
            }
          
            if (i < right)
            {
                ThucHienQuickSort(i, right);
            }
        }




        List<Node> b = new List<Node>();
        List<Node> c = new List<Node>();
        int nb, nc;
        int Min(int a, int b)
        {
            if (a > b) return b;
            else return a;
        }
        void Distribute(List<Node> a, int N, ref int nb, ref int nc, int k)
        {
            int i, pa, pb, pc;
            pa = pb = pc = 0;
         
            while (pa < N)
            {
       
                for (i = 0; (pa < N) && (i < k); i++, pa++, pb++)
                {
                
                    
                    a[pa].BackColor = ThamSo.MauNodeDangXet;
                    a[pa].ChuyenLen();
                    a[pa].ChuyenQua(pb);
                    a[pa].vitriHienTai = pb;

                    b[pb] = a[pa];

                  
                }
         
             
                for (i = 0; (pa < N) && (i < k); i++, pa++, pc++)
                {
                  
                    //c[pc] = a[pa];
                    a[pa].BackColor = Color.LightYellow;
                    a[pa].ChuyenXuong();
                    a[pa].ChuyenQua(pc);
                    a[pa].vitriHienTai = pc;

                    c[pc] = a[pa];

                  
                }
              
            }
          
            nb = pb; nc = pc;
        }
        void Merge(List<Node> a, int nb, int nc, int k)
        {
            int p, pb, pc, ib, ic, kb, kc;
            p = pb = pc = 0; ib = ic = 0;

           
            while ((nb > 0) && (nc > 0))
            {
                kb = Min(k, nb);
                kc = Min(k, nc);

               

                bool thucHien = false; // dùng để xét tăng/giảm , nếu bằng true thì code sẽ chạy
                if (tangRadioButton.Checked == true)
                {
                    if (c[pc + ic].giaTri >= b[pb + ib].giaTri)
                        thucHien = true;
                }
                else
                {
                    if (c[pc + ic].giaTri <= b[pb + ib].giaTri)
                        thucHien = true;
                }
                if (thucHien)
                {
            
                    //a[p++] = b[pb + ib];
                    b[pb + ib].BackColor = ThamSo.MauNenNode;
                    b[pb + ib].ChuyenXuong();
                    b[pb + ib].ChuyenQua(p);
                    b[pb + ib].vitriHienTai = p;

                    a[p] = b[pb + ib];
                    p = p + 1;

                    ib++;

                
                    if (ib == kb)
                    {
              
                        for (; ic < kc; ic++)
                        {

                            //a[p++] = c[pc + ic];
                            c[pc + ic].BackColor = ThamSo.MauNenNode;
                            c[pc + ic].ChuyenLen();
                            c[pc + ic].ChuyenQua(p);
                            c[pc + ic].vitriHienTai = p;

                            a[p] = c[pc + ic];
                            p = p + 1;

                        }

                        pb += kb; pc += kc; ib = ic = 0;
                        nb -= kb; nc -= kc;
                    }
                }
                else
                {
                    //a[p++] = c[pc + ic];
                    c[pc + ic].BackColor = ThamSo.MauNenNode;
                    c[pc + ic].ChuyenLen();
                    c[pc + ic].ChuyenQua(p);
                    c[pc + ic].vitriHienTai = p;

                    a[p] = c[pc + ic];
                    p = p + 1;

                    ic++;

                    if (ic == kc)
                    {
                        for (; ib < kb; ib++)
                        {
                            //a[p++] = b[pb + ib];
                            b[pb + ib].BackColor = ThamSo.MauNenNode;
                            b[pb + ib].ChuyenXuong();
                            b[pb + ib].ChuyenQua(p);
                            b[pb + ib].vitriHienTai = p;


                            a[p] = b[pb + ib];
                            p = p + 1;

                        }

                        pb += kb; pc += kc; ib = ic = 0;
                        nb -= kb; nc -= kc;
                    }
                }

            }  // while

            if (a.Count % 2 == 1 && (k != (a.Count - 1)))
            {
                if (nb > nc)
                {
                    b[pb].BackColor = ThamSo.MauNenNode;
                    b[pb].ChuyenXuong();
                    b[pb].ChuyenQua(a.Count - 1);
                    b[pb].vitriHienTai = a.Count - 1;

                }

            }
            if (a.Count % 2 == 0 && Math.Abs(nb - nc) == 2)
            {

                b[pb].BackColor = ThamSo.MauNenNode;
                b[pb].ChuyenXuong();
                b[pb].ChuyenQua(a.Count - 2);
                b[pb].vitriHienTai = a.Count - 2;

                b[pb + 1].BackColor = ThamSo.MauNenNode;
                b[pb + 1].ChuyenXuong();
                b[pb + 1].ChuyenQua(a.Count - 1);
                b[pb + 1].vitriHienTai = a.Count - 1;


            }

            ;
        }
        void ThucHienMergeSort(List<Node> a, int N)
        {
            for (int i = 0; i < int.Parse(soPhanTuTextBox.Text); i++)
            {
                b.Add(new Node(i, 0));
                c.Add(new Node(i, 0));
            }
            int k;

            for (k = 1; k < N; k *= 2)
            {
                bienArr["k"].Location = new Point(root.X + 420, 11);
                bienArr["k"].Text = "k = " + k;
                bienArr["k"].Visible = true;
                Distribute(a, N, ref nb, ref nc, k);

                Merge(a, nb, nc, k);

            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        void MergeSort()
        {


            bienArr["a:"].Location = new Point(0, root.Y - 5);
            bienArr["b:"].Location = new Point(0, root.Y - ThamSo.KhoanCachTrenDuoiNode - 5);
            bienArr["c:"].Location = new Point(0, root.Y + ThamSo.KhoanCachTrenDuoiNode - 5);
            bienArr["a:"].Text = "a:";
            bienArr["b:"].Text = "b:";
            bienArr["c:"].Text = "c:";
            bienArr["a:"].SendToBack();
            bienArr["b:"].SendToBack();
            bienArr["c:"].SendToBack();
            bienArr["a:"].Visible = bienArr["b:"].Visible = bienArr["c:"].Visible = true;


            
            ThucHienMergeSort(nodeArr, nodeArr.Count);

            foreach (Node node in nodeArr)
            {
                node.BackColor = ThamSo.MauNodeDaXetQua;
            }

            SortRunOrStop(false);
            if (nodeArr.Count != 0)               // Nếu mảng bị huy trong lúc chạy thì k cần in ra kết quả
                MessageBox.Show("Sắp xếp hoàn tất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
