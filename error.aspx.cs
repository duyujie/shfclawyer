using System;
using com.hujun64.util;
namespace com.hujun64
{


    /// <summary>
    /// error ��ժҪ˵����
    /// </summary>
    public partial class error : System.Web.UI.Page
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("PageError");
        protected void Page_Load(object sender, System.EventArgs e)
        {
            string errorAspxPath = Request.QueryString["aspxerrorpath"];
            if (errorAspxPath == null)
                errorAspxPath = "δ֪λ��";
            if (!string.IsNullOrEmpty(Request.QueryString[Total.QueryStringAction]) && Request.QueryString[Total.QueryStringAction].ToLower() == "notfound")
            {
                Label1.Text = "�Բ���Ŀ����ҳ�����ڣ������Ѿ���ɾ������ַ�����뷵��" + UtilHtml.BuildHref(Total.SiteUrl, "��ҳ", "��ҳ") + "��лл��";
                Response.Status = "404 Not Found";
            }
            else
                if (Session["err"] != null)
                {
                    log.Error(Session["err"].ToString());

                    UtilMail.SendMailAsync("��վ���󱨸�", Session["err"].ToString(), Total.AdminMail, null);

                    Label1.Text = Session["err"].ToString();
                }
                else
                {
                    log.Error("δ֪����Դ��" + errorAspxPath, Server.GetLastError());

                    Label1.Text = "δ֪����Դ��" + errorAspxPath + ":" + Server.GetLastError().Message;
                }
            if (Request.Path.Contains(Total.SiteUrl))
                Response.Redirect("/index.aspx");
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
