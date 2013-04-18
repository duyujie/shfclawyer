using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System.Net;
using System.Text;
using System.Web;
using System.IO;
using com.hujun64.logic;
using com.hujun64.util;
using com.hujun64.po;
using com.hujun64.type;
using System.IO.Compression;

namespace com.hujun64
{
    /// <summary>
    /// Global ��ժҪ˵����
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private log4net.ILog log = log4net.LogManager.GetLogger("Global");
        private bool hasTaskInstanceRunnig = false;


        private static DateTime lastLogPurgeDate;
        private DateTime lastSiteUpdateDate;
        private List<int> refreshSiteHoursList = new List<int>(Total.RefreshSiteHoursArray.Length);


        public Global()
        {
            InitializeComponent();
        }

        protected void Application_Start(Object sender, EventArgs e)
        {
            try
            {

                if (Total.EnableCGW)
                    Total.CGWFileapth = Server.MapPath(Total.CGWFileapth);

                log4net.Config.XmlConfigurator.Configure();


                Total.SiteId = ServiceFactory.GetCommonService().GetSiteIdByName(Total.SiteName);

                foreach (string h in Total.RefreshSiteHoursArray)
                {
                    refreshSiteHoursList.Add(Convert.ToInt32(h));
                }


                log.Info("Application Start!");


                log.Debug("����������" + HardwareInfo.GetHostName());

                StringBuilder sb = new StringBuilder();
                foreach (string serverIp in Total.ServerIpList)
                {
                    sb.Append(serverIp);
                    sb.Append("\n");
                }
                log.Info("������IP��ַ��\n" + sb.ToString());

                //���嶨ʱ�� 
                log.Debug("������ʱ��...");
                System.Timers.Timer myTimer = new System.Timers.Timer(Total.TimerInterval);
                myTimer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
                myTimer.Enabled = true;
                myTimer.AutoReset = true;
                log.Info("�ɹ�������ʱ����");


                ServiceFactory.GetCommonService().SetGlobalConfigValue(Total.CONVERTING_CONFIG, Boolean.FalseString);




                ServiceFactory.GetCommonService().CheckSiteStatus(Total.MonitorUrl);


                //������վ���º�����
                //ServiceFactory.GetBackupService().BackupArticleGuestbook();



            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }
        private void Timer_Elapsed(object source, ElapsedEventArgs e)
        {

            try
            {
                log.Info("��ʱ�����������У�");
                if (!hasTaskInstanceRunnig)
                {

                    hasTaskInstanceRunnig = true;


                    Log_Purge();

                    Site_Update();

                    ServiceFactory.GetCommonService().CheckSiteStatus(Total.MonitorUrl);

                    ServiceFactory.GetBackupService().BackupArticleGuestbook();


                    hasTaskInstanceRunnig = false;

                }
                else
                {
                    log.Debug("�Ѿ���һ����ʱ����ʵ�������У�������");
                }
            }
            catch (Exception ex)
            {
                hasTaskInstanceRunnig = false;
                log.Error("��ʱ���������쳣��", ex);
            }
        }
        //�������ö����ʱ��������վ����ҳ�����
        private void Site_Update()
        {
            string LAST_UPDATE_SITE_DATE = "LAST_SITE_UPDATE_DATE";


            try
            {
                ICommonService commonService = ServiceFactory.GetCommonService();


                string lastDateString = commonService.GetGlobalConfigValue(LAST_UPDATE_SITE_DATE);
                if (string.IsNullOrEmpty(lastDateString))
                {
                    lastSiteUpdateDate = DateTime.MinValue;
                }
                else
                {
                    lastSiteUpdateDate = Convert.ToDateTime(lastDateString);
                }
                if (lastSiteUpdateDate < (DateTime.Now.AddHours(-1)) && refreshSiteHoursList.Contains(DateTime.Now.Hour))
                {

                    log.Info("��ʼ��ʱ������վ...");

                    GlobalConfig globalConfig = new GlobalConfig();
                    globalConfig.config_name = LAST_UPDATE_SITE_DATE;
                    globalConfig.config_value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    //ά��GlobalConfig     
                    commonService.MaintainGlobalConfig(globalConfig);






                    //�첽��ȡIP������
                    AsyncTaskService.GetIpProvinceAsync();

                    //�첽��ȡ�ͻ��ֻ�������
                    AsyncTaskService.GetClientMobileProvinceAsync();


                    //�첽������վ
                    //AsyncTaskService.UpdateSiteAsync(RefreshType.ALL_FRAME_HTML);
                    //Thread.Sleep(5 * 1000);
                    //AsyncTaskService.UpdateSiteAsync(RefreshType.ALL_MODULE_LIST);


                    //�ؽ�����
                    List<ArticleBase> articleList = ServiceFactory.GetArticleService().GetAllArticlesIndex();
                    LuceneSearcher.WriteIndex(articleList, true);

                }
            }
            catch (Exception ex)
            {
                log.Error("��ʱ������վ����", ex);
            }

        }




        //ɾ��������־
        private void Log_Purge()
        {
            if (lastLogPurgeDate < (DateTime.Now.AddDays(-1)))
            {
                lastLogPurgeDate = DateTime.Now;

                log.Debug("��ʼɾ��������־...");


                int logPurged = ServiceFactory.GetCommonService().PurgeLog(Total.ExpiresLog);
                log.Debug("�ɹ�ɾ��" + logPurged + "����־��");
            }
        }



        protected void Session_Start(Object sender, EventArgs e)
        {
            if (Total.CurrentSiteUrl == null || !Total.CurrentSiteUrl.Contains(Total.SiteUrl))
            {

                foreach (string serverIp in Total.ServerIpList)
                {
                    foreach (string definedIp in Total.SiteIpArray)
                    {
                        if (serverIp.Trim().Equals(definedIp.Trim()))
                        {
                            Total.IsDefinedServer = true;
                            break;
                        }
                    }
                    if (Total.IsDefinedServer)
                        break;
                }

                Total.CurrentSiteUrl = "http://" + Request.Url.Authority;

                if (Total.IsDefinedServer)
                {
                    //Total.CurrentSiteUrl = Total.SiteUrl;
                    //Total.CurrentSiteRootUrl = Total.CurrentSiteUrl + "/";

                    Total.CurrentSiteRootUrl = Total.CurrentSiteUrl + "/";
                }
                else
                {
                    Total.CurrentSiteRootUrl = Total.CurrentSiteUrl + Request.ApplicationPath;
                }

                if (!Total.CurrentSiteRootUrl.EndsWith("/"))
                    Total.CurrentSiteRootUrl += "/";

            }
            if (string.IsNullOrEmpty(Total.ApplicationPath))
            {
                Total.ApplicationPath = Request.ApplicationPath;
            }
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            UtilHttp.CheckSqlHacker(Request, Response);
        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {

            //if (Request.CurrentExecutionFilePath.EndsWith("html"))
            //{
            //    FileGlobal.UpdateExecutingStatus(Request.CurrentExecutionFilePath, false);
            //}

        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_Error(Object sender, EventArgs e)
        {

        }

        protected void Session_End(Object sender, EventArgs e)
        {


        }

        protected void Application_End(Object sender, EventArgs e)
        {
            log.Info("Application End!");




            //ͬ�����ݿ�������
            //int i = PageGlobal.SyncClickToDB();
            //log.Info("ͬ�����ݿ������ݣ�" + i.ToString() + "�����ݱ����£�");

            //FileGlobal.ResetAllExecutingStatus();


            //����Ĵ����ǹؼ����ɽ��IISӦ�ó�����Զ����յ�����
            Thread.Sleep(1000);
            //�����������web��ַ���������ָ���������һ��aspxҳ�����������ڵ�ҳ�棬Ŀ����Ҫ����Application_Start


            UtilHttp.ExecHttpWebRequestUrlGet(Total.SiteUrl, Total.EncodingDefault);


        }

        #region Web ������������ɵĴ���
        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
        }
        #endregion
    }
}

