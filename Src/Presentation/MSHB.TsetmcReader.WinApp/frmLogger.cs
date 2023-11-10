using MSHB.TsetmcReader.DTO.DataModel;
using MSHB.TsetmcReader.Service.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSHB.TsetmcReader.WinApp
{
    public partial class frmLogger : Form
    {
        public frmLogger()
        {
            tseAnalyzer = TsetmcDataAnalyzer.Instance;
            tseAnalyzer.OnResultReady += TseAnalyzer_OnResultReady;
            InitializeComponent();
        }

        private void TseAnalyzer_OnResultReady(Dictionary<decimal, TsetmcDto> results)
        {
            string tempData="";
            foreach (var item in results)
            {
                tempData = item.Key.ToString() + "=>" + item.Value.ToString();
            }
            if (tempData.Length < 1)
                tempData = "System is working correctly, but there is no data.";
            this.Invoke((MethodInvoker)(() =>
            {
                if(listBox1.Items.Count>100)
                    listBox1.Items.Clear();
                listBox1.Items.Add(tempData);
            }));
        }

        private TsetmcDataAnalyzer tseAnalyzer;
        private void frmLogger_Load(object sender, EventArgs e)
        {

        }
    }
}
