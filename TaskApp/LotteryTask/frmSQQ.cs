using frmSSQ.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotteryTask
{
    public partial class frmSQQ : Form
    {
        public frmSQQ()
        {
            InitializeComponent();
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
        }
        #region Data 
        /// <summary>
        /// 红球集合  其实可以写入配置文件
        /// </summary>
        private string[] RedNums =
        {
            "01","02","03","04","05","06","07","08","09","10",
            "11","12","13","14","15","16","17","18","19","20",
            "21","22","23","24","25","26","27","28","29","30",
            "31","32","33"
        };

        /// <summary>
        /// 蓝球集合
        /// </summary>
        private string[] BlueNums =
        {
            "01","02","03","04","05","06","07","08","09","10",
            "11","12","13","14","15","16"
        };
        #endregion
        private void btnStart_Click(object sender, EventArgs e)
        {
            #region 初始化动作
            this.btnStart.Text = "运行ing";
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = false;
            this.IsGoOn = true;
            // this.taskList = new List<Task>();
            this.lblBlue.Text = "00";
            this.lblRed1.Text = "00";
            this.lblRed2.Text = "00";
            this.lblRed3.Text = "00";
            this.lblRed4.Text = "00";
            this.lblRed5.Text = "00";
            this.lblRed6.Text = "00";
            #endregion

            foreach (var controls in gboSSQ.Controls)
            {
                if (controls is Label)
                {
                    Label label = (Label)controls;
                    if (label.Name.Contains("Blue"))
                    {
                        tasks.Add(Task.Run(() =>
                            {
                                try
                                {
                                    while (IsGoOn)
                                    {

                                  //1.获得随机等待的随机数
                                RandomHelper randomHelper = new RandomHelper();
                                int index = randomHelper.GetRandomNumberDelay(1, 16);
                                    string snumber = this.BlueNums[index];

                                   // 2.更新界面
                                   // this.lblBlue.Text = snumber; //不动，理由是这里是子线程，但是lalBlue是主线程的元素

                                    //换种方法
                                    this.Invoke(new Action(() =>
                                    {
                                        this.lblBlue.Text = snumber;
                                    }));

                                        //3.循环

                                    }
                                }
                                catch (Exception ex)
                                {

                                    Console.WriteLine("线程异常 "+ex);
                                }
                            }));
                    }
                    else if (label.Name.Contains("Red"))
                    {
                        //1.怎么让他有6个进程同时进来---因为线程是无序的，等待时间随机的，就可以造成6个都在跑
                        //2. 33个数据怎么保证每次6个人让他不重复-----
                        tasks.Add(Task.Run(() =>
                        {
                            try
                            {
                                while (IsGoOn)
                                {
                                    RandomHelper randomHelper = new RandomHelper();
                                    int index = randomHelper.GetRandomNumberDelay(0, 33);
                                    string snumber = this.RedNums[index];

                                   lock (obj_lock)
                                    {
                                    List<string> usedRedNumber = this.GetUsedRedNumber();
                                    if (!usedRedNumber.Contains(snumber))
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            label.Text = snumber;
                                        }));//  this.Invoke 是同步方法
                                    }
                                    }
                                }
                               
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine("线程异常 " + ex);
                            }
                        }));
                    }
                }
            }
            Task.Factory.ContinueWhenAll(tasks.ToArray(), tArray => {
                this.ShowResult();
                this.Invoke(new Action(() =>
                {
                    this.btnStart.Enabled = true;
                    this.btnStop.Enabled = false;
                }));
 
            });

            Task.Delay(10*1000).ContinueWith(t=> {
                this.Invoke(new Action(() =>
                {
                    this.btnStop.Enabled = true;
                }));
            });
        }
        List<Task> tasks = new List<Task>();
        private bool IsGoOn;
        private static readonly object obj_lock = new object();
        private List<string> GetUsedRedNumber()
        {
            List<string> usedNumber = new List<string>();
            //得到界面上的数字
            foreach (var control in gboSSQ.Controls)
            {
                if (control is Label)
                {
                    if (((Label)control).Name.Contains("Red"))
                    {
                        usedNumber.Add(((Label)control).Text);
                    }
                }
            }
            //if (usedNumber.Distinct<string>().Count() < 6)
            //{
            //    Console.WriteLine("出现重复数据");
            //}
            return usedNumber;
                    
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.IsGoOn = false;
          

            //这样写，还是有点问题。。。。---没问题，控件按钮名字写错了
            //Task.Run(() =>
            //{
            //    Task.WaitAll(tasks.ToArray());//这样会死锁，再包一层
            //    this.ShowResult();
            //});
        }
        private void ShowResult()
        {
            MessageBox.Show($"双色球结果为:  {this.lblRed2.Text}  {this.lblRed3.Text}  {this.lblRed4.Text}  {this.lblRed5.Text} {this.lblRed6.Text}   {this.lblBlue.Text}");
        }
    }
}
