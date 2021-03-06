using System;
using System.Data;

using com.hujun64.logic;

namespace com.hujun64
{
    
    /// <summary>
    ///	法律知识
    /// </summary>
    public partial class right : System.Web.UI.UserControl
    {
        
        private IGuestbookService guestbookService = ServiceFactory.GetGuestbookService();

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            { 
                RepeaterGuestbook.DataSource = guestbookService.GetTopGuestbookList("", 12);
                RepeaterGuestbook.DataBind();
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
