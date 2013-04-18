using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using com.hujun64.logic;
using com.hujun64.type;
using com.hujun64.util;
using com.hujun64.po;

namespace com.hujun64.admin
{
    /// <summary>
    /// add_art ��ժҪ˵����
    /// </summary>
    public partial class site_update : AdminPageBase
    {


        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("SiteUpdate");

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DropDownlistUpdateSite.Items.Add(RefreshType.ONLY_CHANGED);
                DropDownlistUpdateSite.Items.Add(RefreshType.ONLY_GUESTASK);
                DropDownlistUpdateSite.Items.Add(RefreshType.ALL_FRAME_HTML);
                DropDownlistUpdateSite.Items.Add(RefreshType.ALL_MODULE_LIST);
                DropDownlistUpdateSite.Items.Add(RefreshType.ALL_ARTICLE);
                DropDownlistUpdateSite.Items.Add(RefreshType.ALL_GUESTBOOK);
                DropDownlistUpdateSite.Items.Add(RefreshType.ALL_SITE);





                DropDownlistUpdateSite.SelectedValue = RefreshType.ONLY_CHANGED;
            }
        }
        protected void refreshCache_Click(object sender, System.EventArgs e)
        {
            ServiceFactory.RefreshAllCache();
            MSG.Text = "<font color=red>�����Ѿ��ɹ����£�</font>";
            Response.Write("<script>javascript:alert('�����Ѿ��ɹ����£�');</script>");

        }
        protected void ButtonTest_Click(object sender, System.EventArgs e)
        {
            //ServiceFactory.GetBackupService().BackupArticleGuestbook();
        }
        protected void ButtonSyncMirror_Click(object sender, System.EventArgs e)
        {
            DateTime beginTime = System.DateTime.Now;

            ServiceFactory.GetBackupService().BackupArticleGuestbook();

            DateTime endTime = System.DateTime.Now;
            TimeSpan span = endTime - beginTime;

            int spanSeconds = span.Minutes * 60 + span.Seconds;
            MSG.Text = "<font color=red>������վͬ���Ѿ��ɹ���ɣ� ��ʱ:" + spanSeconds.ToString() + "��</font>";
        }
        protected void refreshSite_Click(object sender, System.EventArgs e)
        {
            //�첽��ȡIP������
            AsyncTaskService.GetIpProvinceAsync();

            //�첽��ȡ�ͻ��ֻ�������
            AsyncTaskService.GetClientMobileProvinceAsync();

            //������վ���º�����
            //ServiceFactory.GetBackupService().BackupArticleGuestbook();


            UtilStatic aspx2Html = UtilStatic.GetInstance();

            DateTime beginTime = System.DateTime.Now;
            int pageConverted = 0;
            try
            {
                pageConverted = aspx2Html.ConvertAll(DropDownlistUpdateSite.SelectedValue);


                DateTime endTime = System.DateTime.Now;
                TimeSpan span = endTime - beginTime;

                int spanSeconds = span.Minutes * 60 + span.Seconds;


                MSG.Text = pageConverted + "����̬ҳ���Ѿ��ɹ����£� ��ʱ:" + spanSeconds.ToString() + "��";

            }
            catch (Exception ex)
            {
                log.Error("���³���", ex);
                MSG.Text = ex.ToString();

            }
            Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");
            ButtonRefreshSite.Enabled = true;




        }
        protected void updateIndex_Click(object sender, System.EventArgs e)
        {


            DateTime beginTime = System.DateTime.Now;

            int indexCount = 0;

            List<ArticleBase> articleList = ServiceFactory.GetArticleService().GetAllArticlesIndex();
            LuceneSearcher.WriteIndex(articleList, true);
            indexCount = articleList.Count;


            DateTime endTime = System.DateTime.Now;
            TimeSpan span = endTime - beginTime;

            int spanSeconds = span.Minutes * 60 + span.Seconds;


            MSG.Text = "<font color=red>" + indexCount + "ƪ�����Ѿ��ɹ����������� ��ʱ:" + spanSeconds.ToString() + "��</font>";
            Response.Write("<script>javascript:alert('" + indexCount + "ƪ�����Ѿ��ɹ�����������" + "');</script>");


            ButtonRefreshSite.Enabled = true;




        }
        private void displayFileInfo(string destFullpath)
        {
            //�õ�����ļ����������:�ļ���,�ļ�����,�ļ���С 
            fname.Text = destFullpath;
            fenc.Text = myFile.PostedFile.ContentType;
            fsize.Text = myFile.PostedFile.ContentLength.ToString("###,##0");
        }
        protected void UploadFile(object sender, EventArgs E)
        {
            //����ϴ��ļ���Ϊ�� 
            if (myFile.PostedFile != null)
            {

                try
                {
                    string filename = UtilString.GetPureFilename(myFile.PostedFile.FileName);

                    if (string.IsNullOrEmpty(destFilepath.Value))
                        destFilepath.Value = "~\\uploads\\";

                    StringBuilder destFilepathSb = new StringBuilder(destFilepath.Value.Trim());
                    if (!destFilepathSb.ToString().EndsWith("\\"))
                        destFilepathSb.Append("\\");

                    destFilepathSb.Append(filename);
                    string destFullpath = Server.MapPath(destFilepathSb.ToString());

                    myFile.PostedFile.SaveAs(destFullpath);
                    Response.Write("<script>javascript:alert('�ļ��ϴ��ɹ���');</script>");
                    MSG_File.Text = "<font color=red>�ļ��ϴ��ɹ���</font>";
                    displayFileInfo(destFullpath);
                }
                catch (Exception ex)
                {
                    MSG_File.Text = "<font color=red>" + ex.Message + "</font>";
                }

            }
        }
        protected void ImportClientInfo(object sender, EventArgs E)
        {
            if (string.IsNullOrEmpty(ClientFilePath.Value))
                return;

            string csvFilepath = Server.MapPath(ClientFilePath.Value);


            IClientService clientService = ServiceFactory.GetClientService();


            int iSucessed = clientService.ImportClient(csvFilepath);


            LabelImport.Text = "����ͻ���Ϣ�ɹ��� " + iSucessed.ToString() + "����";
            Response.Write("<script>javascript:alert('" + LabelImport.Text + "');</script>");

            File.Delete(csvFilepath);
        }


        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: �õ����� ASP.NET Web ���������������ġ�
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {


        }
        #endregion
    }
}
