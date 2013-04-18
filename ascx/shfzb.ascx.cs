using System;
using System.Data;

using com.hujun64.logic;

namespace com.hujun64
{
    
    /// <summary>
    ///	����֪ʶ
    /// </summary>
    public partial class shfzb : System.Web.UI.UserControl
    {
        protected bool shfzbVisiable = true;
        private IArticleService articleService = ServiceFactory.GetArticleService(); 

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.Path.ToLower().IndexOf("/index.aspx") < 0 && !Request.Path.ToLower().EndsWith(Total.SiteUrl))
                {
                    shfzbVisiable = false;
                    RepeaterShfzb.DataSource = articleService.GetTopArticleByModuleName(Total.ModuleNameShfzb, 15);
                    RepeaterShfzb.DataBind();
                }
                
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
        ///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
        ///		�޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}
