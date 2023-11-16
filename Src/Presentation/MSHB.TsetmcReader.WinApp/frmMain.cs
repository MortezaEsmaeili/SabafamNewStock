using MSHB.TsetmcReader.DTO.DataModel;
using MSHB.TsetmcReader.Service.Contract;
using MSHB.TsetmcReader.Service.Impl;
using MSHB.TsetmcReader.Service.Repository;
using MSHB.TsetmcReader.WinApp.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Zu.AsyncWebDriver.Remote;
//using Zu.Chrome;
//using Zu.ChromeDevTools.Network;

//removed packages packages= "AsyncChromeDriver" version = "0.5.8" 
//< package id = "Zu.ChromeDevToolsClient" version = "0.5.6" targetFramework = "net461" requireReinstallation = "true" /> 

namespace MSHB.TsetmcReader.WinApp
{
    public partial class frmMain : Form
    {
        private List<Form> OpenWindows = new List<Form>();
        TsetmcDriver _testmcDriver = null;
        

        private IInstrumentRepository _instrumentRepo;
        private IType1StockRepository _Type1StockRepo;
  //      private DBWorkerService _dbWorkerService;
        public frmMain()
        {
            //---------------------------------------------------
       //     _instrumentRepo =  InstrumentRepository.Instance;
        //    _Type1StockRepo = Type1StockRepository.Instance;
   //         _dbWorkerService = DBWorkerService.Instance;
            InitializeComponent();
        }

        private void tmClock_Tick(object sender, EventArgs e)
        {
            tsmTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private async void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the program?", "Exit!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            if (_testmcDriver != null)
                await _testmcDriver.StopInterceptorAsync();


        }

        private  void tsmOpenBrowser_Click(object sender, EventArgs e)
        {
           frmLogger frmLogger = new frmLogger();
            frmLogger.MdiParent = this;
            frmLogger.Show();
            try
            {
                if (_testmcDriver == null)
                {
                    string url = ConfigReaderHelper.GetWebsiteUrl();
                    _testmcDriver = TsetmcDriver.Instance;
                    Task.Run(async ()=> await _testmcDriver.Navegate(url));

                //    _testmcDriver.UpdateStatusEvent += UpdateStatus;
                }
                else
                    MessageBox.Show("مرورگر مشابه ای در حال اجراست");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void tsmMinimize_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {/*
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIconManage.Visible = true;
                notifyIconManage.BalloonTipTitle = "مشاهده گر بورس";
                notifyIconManage.BalloonTipText = "مشاهده گر اطلاعات آنلاین بورس";
                notifyIconManage.BalloonTipIcon = ToolTipIcon.Info;
                notifyIconManage.ShowBalloonTip(2000);
            }*/
        }
        private void notifyIconManage_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            notifyIconManage.Visible = false;
            this.ShowInTaskbar = true;
        }

       // public Dictionary<decimal, TargetPrice> InstrumentPriceDic;


        private void cascateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var form in OpenWindows)
                form.Close();
        }

        private async void removeDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This will clear Type1Stock table in database. Are you sure?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                //Todo: Remove Excel Type 1 From Database
                await _Type1StockRepo.ClearDataAsync();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in clearing Type1Stock; " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void loadExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadExcelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmType1Excel frmType1 = new frmType1Excel(true);
            frmType1.MdiParent = this;
            OpenWindows.Add(frmType1);
            frmType1.Show();
        }

        private void loadFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmType1Excel frmType1 = new frmType1Excel(false);
            frmType1.MdiParent = this;
            OpenWindows.Add(frmType1);
            frmType1.Show();
        }

        private void historyFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPriceHistory frmPriceHistory = new frmPriceHistory();
            frmPriceHistory.MdiParent = this;
            OpenWindows.Add(frmPriceHistory);
            frmPriceHistory.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmType1Excel frmType1 = new frmType1Excel(true);
            frmType1.MdiParent = this;
            OpenWindows.Add(frmType1);
            frmType1.Show();
        }
    }
}
