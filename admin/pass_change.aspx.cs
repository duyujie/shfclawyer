using System;
using System.Web.Security;
using com.hujun64.logic;
namespace com.hujun64.admin
{
    /// <summary>
    /// pass_change ��ժҪ˵����
    /// </summary>
    public partial class pass_change : AdminPageBase
    {

        private IAdminService adminService = ServiceFactory.GetAdminService();
        protected void Page_Load(object sender, System.EventArgs e)
        {

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

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string username = Request.Cookies["uname"].Value;


            string pass = adminService.GetPassword(username);
            if (pass != null)
            {
                if (FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordOld.Text, "MD5") == pass)
                {
                    string userpass = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordNew.Text, "MD5");
                    if (adminService.ChangePassword(username, userpass))
                    {
                        DateTime cookieExpires=DateTime.Now ;
                        if (Response.Cookies["saveLogin"].Value!=null && Response.Cookies["saveLogin"].Value.Equals("on"))
                        {                           
                            cookieExpires = Convert.ToDateTime(Response.Cookies["cookieExpires"].Value);
                        }
                        Response.Cookies["uname"].Value = username;
                        Response.Cookies["uname"].Expires = cookieExpires;

                        Response.Cookies["upass"].Value = userpass;
                        Response.Cookies["upass"].Expires = cookieExpires;

                        MSG.Text = "�޸ĳɹ���";
                    }
                    else
                        MSG.Text = "�޸�ʧ�ܣ�";

                    
                }
                else
                {
                    MSG.Text = "ԭ����������������룡";
                }

                Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");
            }
            else
            {
                Response.Write("<script>javascript:alert('�Ƿ��û�������');window.parent.location.href=('admin.aspx');</script>");
            }


        }
    }
}
