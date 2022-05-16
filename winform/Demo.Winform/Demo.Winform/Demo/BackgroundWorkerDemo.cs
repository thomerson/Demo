using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Demo.Winform.Demo
{
    public partial class BackgroundWorkerDemo : Form
    {
        public BackgroundWorkerDemo()
        {
            InitializeComponent();
            Init();
        }

        private BackgroundWorker bgWorker;

        private void Init()
        {
            #region button
            this.btn_start.Click += Btn_start_Click;

            this.btn_stop.Enabled = false;
            this.btn_stop.Click += Btn_stop_Click;
            #endregion

            #region BackgroundWorker
            bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = true; //可以报告进度更新
            bgWorker.WorkerSupportsCancellation = true;//支持异步取消操作
            bgWorker.DoWork += Do_Work;
            bgWorker.ProgressChanged += BgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            #endregion

        }

        private void Btn_stop_Click(object sender, EventArgs e)
        {
            this.btn_start.Enabled = true;
            this.btn_stop.Enabled = false;
            bgWorker.CancelAsync();
        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            if (bgWorker.IsBusy)
            {
                //避免多次调用
                return;
            }

            this.progressBar1.Maximum = 100;
            this.btn_start.Enabled = false;
            this.btn_stop.Enabled = true;

            this.bgWorker.RunWorkerAsync();
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }

            if (e.Cancelled)
            {
                this.label_message.Text = "任务取消";
                return;
            }

            this.label_message.Text = "任务完成";
        }

        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var userState = e.UserState.ToString();

            this.progressBar1.Value = e.ProgressPercentage;
            this.label_message.Text = $"{e.ProgressPercentage}%";
        }

        private void Do_Work(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                if (bgWorker.CancellationPending)
                {
                    // 取消操作
                    e.Cancel = true;
                    return;
                }

                // 模拟后台执行操作
                Thread.Sleep(1000);

                bgWorker.ReportProgress(i, "success");
            }
        }


    }
}
