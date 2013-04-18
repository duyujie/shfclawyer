using System;
using System.Web;
using System.Web.Security;
using com.hujun64.logic;
namespace com.hujun64.admin
{
    /// <summary>
    /// admin ��ժҪ˵����
    /// </summary>
    public partial class admin : System.Web.UI.Page
    {

        IAdminService adminService = ServiceFactory.GetAdminService();

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["VNum"] = null;
                string logMethod = Request.QueryString["method"];

                if (logMethod == "logout")
                {
                    HttpCookie cookie = Request.Cookies["uname"];
                    if (cookie != null)
                    {
                        cookie.Expires = DateTime.Now.AddDays(-2);
                        Response.Cookies.Set(cookie);
                    }
                }
                else
                {
                    login();
                }
            }
            else if (Request.ServerVariables["request_method"] == "POST")
            {
                login();
            }


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


        private void login()
        {
            if (Request.Cookies["saveLogin"] != null && Request.Cookies["uname"] != null && Request.Cookies["upass"] != null)//������� cookies
            {

                if (Request.Cookies["saveLogin"].Value.Equals("on") && adminService.Islogin(Request.Cookies["uname"].Value, Request.Cookies["upass"].Value))
                    Response.Redirect("index.htm");
            }

            if (Session["VNum"] != null && Session["VNum"].ToString() == Request["txtValidateCode"])
            {
                //��֤����ȷ
                string pwd = adminService.GetPassword(Request["username"]);

                string upwd = FormsAuthentication.HashPasswordForStoringInConfigFile(Request["pass"], "MD5");//admin888���ܺ��ǣ�7FEF6171469E80D32C0559F88B377245
                if (pwd != null && upwd == pwd)
                {
                    string saveLogin = Request["chkSaveLogin"];
                    if (saveLogin != null && saveLogin.Equals("on"))
                    {
                        DateTime cookieExpires = DateTime.Now;
                        if (Response.Cookies["cookieExpires"].Value == null)
                        {
                            cookieExpires = DateTime.Now.AddDays(Total.CookieExpiresDays);
                            Response.Cookies["cookieExpires"].Value = cookieExpires.ToString();
                            Response.Cookies["cookieExpires"].Expires = cookieExpires;
                        }
                        else {
                            
                            cookieExpires =Convert.ToDateTime(Response.Cookies["cookieExpires"].Value);
                        }

                        Response.Cookies["saveLogin"].Value = Request["chkSaveLogin"];
                        Response.Cookies["saveLogin"].Expires = cookieExpires;

                        Response.Cookies["uname"].Value = Request["username"];
                        Response.Cookies["uname"].Expires = cookieExpires;

                        Response.Cookies["upass"].Value = FormsAuthentication.HashPasswordForStoringInConfigFile(Request["pass"], "MD5");
                        Response.Cookies["upass"].Expires = cookieExpires;
                    }
                    else
                    {
                        Response.Cookies["saveLogin"].Value = saveLogin;


                        Response.Cookies["uname"].Value = Request["username"];


                        Response.Cookies["upass"].Value = FormsAuthentication.HashPasswordForStoringInConfigFile(Request["pass"], "MD5");

                    }

                    Response.Redirect("index.htm");
                }
                else
                {
                    labelMsg.Text = "���벻��ȷ��";
                }

            }
            else
            {
                labelMsg.Text = "��֤�벻��ȷ��";
            }
        }
    }
}
