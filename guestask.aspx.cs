using System;
using System.Text;
using System.Web;
using System.Data;
using System.Text.RegularExpressions;
using com.hujun64.logic;
using com.hujun64.po;
using com.hujun64.type;
using com.hujun64.util;

namespace com.hujun64
{
    /// <summary>
    /// guestbook ��ժҪ˵����
    /// </summary>
    public partial class guestask : PageBase
    {
        private IMainClassService classService = ServiceFactory.GetMainClassService();
        private IGuestbookService guestbookService = ServiceFactory.GetGuestbookService();

        protected string myLocation = "";
        protected string moduleClassName = "������ѯ";
        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!this.IsPostBack)
            {


                myLocation = UtilHtml.GetPageInfo(moduleClassName, PageType.GUESTBOOK_TYPE).locationHref;
            }
        }

        void addguestbook()
        {

            Guestbook guestbook = new Guestbook();

            string id = guestbookService.GenerateId();
            guestbook.id = id;
            guestbook.author = author.Text.Trim();
            guestbook.contact = contact.Text.Trim();
            guestbook.email = email.Text.Trim();
            guestbook.title = guesttitle.Text.Trim();
            guestbook.content = content.Text.TrimEnd();
            if (Request["sex"] != null)
                guestbook.sex = Request["sex"];
            else
                guestbook.sex = "";


            guestbook.content = UtilHtml.RemoveHtmlTag(guestbook.content.Trim());
            guestbook.ip_from = Request.UserHostAddress;
            guestbook.keywords = "";

            guestbook.big_class_id = Request["bigClassRadioList"] == null ? "" : Request["bigClassRadioList"].Trim();



            bool success = guestbookService.InsertGuestbook(guestbook);

            if (success)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("��ѯ��ϸ���ݵ�����ӣ�{0}<br />", UtilHtml.BuildHrefArticle(guestbook, true, true));
                sb.AppendFormat("�ظ���ѯ������ӣ�{0}<br />", UtilHtml.BuildHref(Total.SiteUrl + "/admin/guestbook_manage.aspx", "���Թ���", "���Թ���"));
                UtilMail.SendMailAsync("��վ��ѯ�Զ���ʾ��" + guestbook.title, sb.ToString(), Total.Email, new string[] { Total.AdminMail, Total.Email });
                //AsyncTaskService.SendMailByHujun64Async("��վ��ѯ�Զ���ʾ��" + guestbook.title, sb.ToString(), Total.Email, new string[] { Total.AdminMail, Total.Email });
            }

            guestbookService.RefreshCachedGuestbook();

            //AsyncTaskService.PostGuestbook2Hujun64Async(guestbook);

            if (!string.IsNullOrEmpty(guestbook.contact))
            {
                Regex regExp = new Regex(@"^1[0-9]{10}$");
                if (regExp.IsMatch(guestbook.contact))
                {
                    Client client = new Client(guestbook.author, guestbook.contact);

                    AsyncTaskService.InsertClientAsync(client);
                }
            }
            //������������
            LuceneSearcher.WriteIndex(guestbook, false);
        }


        protected void addbtn_Click(object sender, System.EventArgs e)
        {
            if (Session["VNum"] == null)
            {
                //�ظ��ύ�����Դ���


            }
            else if (Session["VNum"].ToString() != txtValidateCode.Text)
            {
                //��֤�벻��ȷ
                Response.Write("<script>javascript:alert('��֤�벻��ȷ��');</script>");
                txtValidateCode.Text = "";
                txtValidateCode.Focus();
                return;

            }

            else
            {
                //������֤��״̬����ֹ�ظ��ύ
                Session["VNum"] = null;


                addguestbook();

                //������վ            
                //try
                //{
                //    UtilStatic.GetInstance().ConvertAll(RefreshType.ONLY_GUESTASK);
                //}
                //catch (Exception)
                //{

                //}

                //�첽������վ
                AsyncTaskService.UpdateSiteAsync(RefreshType.ONLY_GUESTASK);

            }


            MSG.Text = "<font color=red>�ǳ���л�������ԣ�</font>";


            Response.Write("<script>javascript:if(confirm('�ǳ���л�������ԣ�ת����ѯ�б�...')) {window.location.href='guestbook.aspx';}</script>");


            guesttitle.Text = "";
            content.Text = "";
        }

        private void resetForm()
        {
            contact.Text = "";
            author.Text = "";
            guesttitle.Text = "";
            content.Text = "";

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
