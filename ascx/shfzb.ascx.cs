using System;
using System.Data;

using com.hujun64.logic;

namespace com.hujun64
{
    
    /// <summary>
    ///	法律知识
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

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		设计器支持所需的方法 - 不要使用代码编辑器
        ///		修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}
