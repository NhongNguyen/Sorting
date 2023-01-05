using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Sorting
{
    class Node : Button
    {

        public int giaTri;
        public int vitriHienTai;
        public TextBox nhapTayTexbox;
        public Node(int vitrihientai, int giatri)
        {
            // Node : property + event
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = ThamSo.MauNenNode;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Size = new Size(ThamSo.KichCoNode, ThamSo.KichCoNode);
            this.Padding = new Padding(0);
            this.Font = new Font("Consolas", ThamSo.KichCoNode / 3.2f, FontStyle.Bold);
            this.UseCompatibleTextRendering = true;

            this.Text = giatri.ToString();
            giaTri = giatri;
            vitriHienTai = vitrihientai;

            // NhapTay TextBox : property + event
            nhapTayTexbox = new TextBox();
            nhapTayTexbox.MaxLength = 2;
            nhapTayTexbox.TextAlign = HorizontalAlignment.Center;
            nhapTayTexbox.BorderStyle = BorderStyle.Fixed3D;
            nhapTayTexbox.Visible = false;
            nhapTayTexbox.Size = new Size(ThamSo.KichCoNode, ThamSo.KichCoNode);
            nhapTayTexbox.Font = new Font("Consolas", ThamSo.KichCoNode / 2, FontStyle.Bold);
        }


        



        #region Các hàm Chuyển động lên xuống, qua, lại
        // Property dùng để Pause  -  dùng ManualResetEvent
        public static ManualResetEvent pauseStatus = new ManualResetEvent(true);
        public static bool IsPause = false;

        public void ChuyenXuong()
        {
            int y_ViTriMoi = this.Location.Y + ThamSo.KhoanCachTrenDuoiNode;
            while (this.Location.Y < y_ViTriMoi)
            {
                pauseStatus.WaitOne(Timeout.Infinite);
                Thread.Sleep(ThamSo.TocDo);
                this.Location = new Point(this.Location.X, this.Location.Y + 2);
            }
        }
        public void ChuyenLen()
        {
            int y_ViTriMoi = this.Location.Y - ThamSo.KhoanCachTrenDuoiNode;
            while (this.Location.Y > y_ViTriMoi)
            {
                pauseStatus.WaitOne(Timeout.Infinite);
                Thread.Sleep(ThamSo.TocDo);
                //Task.Delay(ThamSo.TocDo);
                this.Location = new Point(this.Location.X, this.Location.Y - 2);
            }
        }
        public void ChuyenQua(int vitriMoi)
        {
            int x_vitririMoi;
            if (vitriMoi > this.vitriHienTai)
            {
                x_vitririMoi = this.Location.X + ((vitriMoi - vitriHienTai) * ThamSo.KhoanCachGiuaCacNode);
                while (this.Location.X < x_vitririMoi)
                {
                    pauseStatus.WaitOne(Timeout.Infinite);
                    Thread.Sleep(ThamSo.TocDo);
                    this.Location = new Point(this.Location.X + 2, this.Location.Y);
                }
            }
            else
            {
                x_vitririMoi = this.Location.X - ((vitriHienTai - vitriMoi) * ThamSo.KhoanCachGiuaCacNode);
                while (this.Location.X > x_vitririMoi)
                {
                    pauseStatus.WaitOne(Timeout.Infinite);
                    Thread.Sleep(ThamSo.TocDo);
                    this.Location = new Point(this.Location.X - 2, this.Location.Y);
                }
            }
        }
        #endregion
    }
}
