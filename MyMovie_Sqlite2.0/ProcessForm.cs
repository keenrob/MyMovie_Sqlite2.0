using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMovie_Sqlite2._0
{
    public partial class ProcessForm : Form
    {

        public ProcessForm()
        {



            InitializeComponent();
        }

         private void ProcessForm_Load(object sender, EventArgs e)
        {
            this.progressBarSum.Maximum = 100;
            
            _demoBGWorker.DoWork += BGWorker_DoWork;
            _demoBGWorker.RunWorkerAsync(100);
            _demoBGWorker.WorkerReportsProgress = true;
            _demoBGWorker.ProgressChanged += BGWorker_ProgressChanged;

        }

        private void BGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // 修改进度条的显示。
             this.progressBarSum.Value = e.ProgressPercentage;

            //如果有更多的信息需要传递，可以使用 e.UserState 传递一个自定义的类型。
            //这是一个 object 类型的对象，您可以通过它传递任何类型。
            //我们仅把当前 sum 的值通过 e.UserState 传回，并通过显示在窗口上。
            string message = e.UserState.ToString();
            this.labelSum.Text = message;
        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgWorker = sender as BackgroundWorker;
            int endNumber = 0;
            if (e.Argument != null)
            {
                endNumber = (int)e.Argument;
            }

            int sum = 0;
            for (int i = 0; i <= endNumber; i++)
            {
                sum += i;

                string message = "Current sum is: " + sum.ToString();
                //ReportProgress 方法把信息传递给 ProcessChanged 事件处理函数。
                //第一个参数类型为 int，表示执行进度。
                //如果有更多的信息需要传递，可以使用 ReportProgress 的第二个参数。
                //这里我们给第二个参数传进去一条消息。
                bgWorker.ReportProgress(i, message);
                Thread.Sleep(600);
            }
        }

    

    }
}
