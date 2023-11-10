using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V110.Accessibility;
using DocumentFormat.OpenXml.Bibliography;

namespace MSHB.TsetmcReader.Service.Impl
{
    public class TsetmcDriver
    {
        private ChromeDriver chromeDriver;
        private INetwork interceptor;
        private static TsetmcDriver instance = null;
        private TsetmcDataAnalyzer _dataAnalyzer;
        public delegate void UpdateStatus(string status);
        public event UpdateStatus UpdateStatusEvent;
        public void OnUpdateStatus(string status)
        {
            if (UpdateStatusEvent != null)
                UpdateStatusEvent(status);
        }
        public static TsetmcDriver Instance
        {
            get { 
            if(instance == null)
                instance = new TsetmcDriver();
            return instance;
            }
        }
        private TsetmcDriver()
        {
            try
            {
                _dataAnalyzer = TsetmcDataAnalyzer.Instance;
            }
            catch(Exception ex) 
            { 
            }
        }
        public async Task Navegate(string url)
        {
            try
            {                
                var options = new ChromeOptions();
                chromeDriver = new ChromeDriver(ChromeDriverService.CreateDefaultService(),
                    options, TimeSpan.FromMinutes(1));

                interceptor = chromeDriver.Manage().Network;
                
                //interceptor.NetworkRequestSent += OnNetworkRequestSent;
                //pegah
                interceptor.NetworkResponseReceived += NetworkManager_NetworkResponseReceived;
                chromeDriver.Navigate().GoToUrl(url);
                await interceptor.StartMonitoring();
                Trace.WriteLine("*************monitoring was started.***************");
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        private void OnNetworkRequestSent(object sender, NetworkRequestSentEventArgs e)
        {
            Trace.WriteLine($"R s ReqId={e.RequestId}  ResponseUrl= {e.RequestUrl} ");
        }

        private void NetworkManager_NetworkResponseReceived(object sender, NetworkResponseReceivedEventArgs e)
        {
            try
            {                
                Trace.WriteLine($"R R ReqId={e.RequestId}  ResponseUrl= {e.ResponseUrl} status={e.ResponseStatusCode} ");
                if(e.ResponseStatusCode==200)
                    Listener(e);
            }
            catch(Exception ex)
            {

            }
        }
        public async Task StopInterceptorAsync()
        {
            try
            {
                await interceptor.StopMonitoring();
            }
            catch { }
        }
        void Listener(NetworkResponseReceivedEventArgs e)
        {
            try {
                string url = e.ResponseUrl;
                string status = string.Empty;
                string recievedData = e.ResponseBody;
                Task.Run(() =>
                {
                    try
                    {
                        _dataAnalyzer.Add2MessageBag(recievedData);
                    }
                    catch { }

                    /*try
                    {
                        int counter = 0;
                        string recievedData = string.Empty;
                        while (counter <= 3)
                        {
                            try {
                                recievedData = e.ResponseBody;
                                _dataAnalyzer.ProcessMessage(recievedData);
                            }
                            catch { 
                            }
                            counter++;
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }*/
                });
            }
            catch(Exception ex)
            {
                OnUpdateStatus(ex.Message);
            }
        }
    }
}
