namespace com.hujun64
{
    using System;
    using System.Data.SqlClient;
    using com.hujun64.po;
    using com.hujun64.type;
    using com.hujun64.util;
    using com.hujun64.logic;
    /// <summary>
    ///	linkapp ��ժҪ˵����
    /// </summary>
    public partial class linkapp : PageBase
    {
       
        protected string myLocation = "";
        private string moduleName = Total.ModuleNameSqyqlj;
        protected string prefixUrl = "http://www.";
        protected string applyNotice = "�ύ����ǰ�����Ȱ������˵����������վ�����ñ�վ�����ӣ�лл��<br /><br />�����ñ�վ���ӵ����뽫������ͨ����ˣ�����ʦ�����ύ�����������Ȩ�����ս���Ȩ��������������޷�ͨ����ˣ�������¡�";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect(Total.AspxUrlBuilding);
            myLocation = UtilHtml.GetPageInfo(moduleName, PageType.LINK_APP_TYPE).locationHref;
            
           
        }

        
        private void resetForm()
        {
            myUrl.Text = prefixUrl;
            siteName.Text = "";
            siteUrl.Text = prefixUrl;
            siteLogoUrl.Text = "";            
            siteDesc.Text = "";
        }
        protected void reset_Click(object sender, System.EventArgs e)
        {
            resetForm();
        }
        protected void submit_Click(object sender, System.EventArgs e)
        {
            if (!myUrl.Text.Trim().StartsWith("http://"))
            {
                Response.Write("<script>javascript:alert('�����뱾վ�ڹ�վҳ�����ȷ���ӵ�ַ��');</script>");
                
                myUrl.Focus();
                return;                
            }


            if (Session["VNum"] == null || Session["VNum"].ToString() != txtValidateCode.Text)
            {
                //��֤�벻��ȷ
                Response.Write("<script>javascript:alert('��֤�벻��ȷ��');</script>");
                txtValidateCode.Text = "";
                txtValidateCode.Focus();
                return;                
            }

            Link link = new Link();            
                        
            link.enabled = true;
            link.link_site_name=siteName.Text.Trim();
            link.link_site_url = siteUrl.Text.Trim();
            link.link_site_logo = siteLogoUrl.Text.Trim();
            link.link_description = UtilHtml.FormatTextToHtml(siteDesc.Text.TrimEnd());
            link.my_url = myUrl.Text.Trim();
            link.is_static = false;

            

            try
            {
                ILinkService linkService = ServiceFactory.GetLinkService();
                linkService.InsertLink(link);
                txtValidateCode.Text = "";
                UtilMail.SendMailAsync("�����Ѻ�����", UtilHtml.BuildHref(link.link_site_url, link.link_site_name, link.link_site_name, true), Total.AdminMail, null);
            }
            catch (Exception ex)
            {
                Response.Write("<script>javascript:alert('"+ ex.Message + "');</script>");
                siteUrl.Focus();
                return;
            }

            MSG.Text = "<font color=red>�ǳ���л�������룡�Ժ����ǻ�Դ˽�����ˡ�</font>";
            Response.Write("<script>javascript:alert('�ǳ���л�������룡�Ժ����ǻ�Դ˽�����ˡ�');</script>");
            resetForm();

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
