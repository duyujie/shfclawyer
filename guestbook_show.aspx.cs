using System;
using System.Collections.Generic;
using System.Data;
using com.hujun64.po;
using com.hujun64.type;
using com.hujun64.util;
using com.hujun64.logic;

namespace com.hujun64
{
    /// <summary>
    /// guestbook 的摘要说明。
    /// </summary>
    public partial class guestbook_show : PageBase
    {
        private IGuestbookService guestboookService = ServiceFactory.GetGuestbookService();

        public string title = "";
        public string guestbookKeywords = "";
        protected string myLocation = "";
        protected string moduleName = Total.ModuleNameFlzx;
        protected string guestbookId = "";
        protected string metaDescription = "";
        protected Guestbook prevGuestbook, nextGuestbook;

        protected string bigClassName = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                guestbookId = Request.QueryString[Total.QueryStringGuestbookId];

                if (!string.IsNullOrEmpty(guestbookId))
                {
                    guestbookId = guestbookId.ToUpper();

                    Guestbook guestbook = guestboookService.GetGuestbook(guestbookId);
                    if (guestbook != null && !string.IsNullOrEmpty(guestbook.id))
                    {

                        title = guestboookService.GeneratePageTitle(guestbook);

                        guestbookKeywords = guestbook.keywords;
                        bigClassName = ServiceFactory.GetMainClassService().GetRadioBigClassNameById(guestbook.big_class_id);

                    }
                    else
                    {
                        Response.Redirect(Total.AspxUrlGuestbook);
                        return;
                    }
                    metaDescription = UtilHtml.ExtractMetaDesc(guestbook);

                    List<Guestbook> guestbookList = new List<Guestbook>(1);
                    guestbookList.Add(guestbook);
                    RepeaterNews.DataSource = guestbookList;
                    RepeaterNews.DataBind();

                   
                }

                myLocation = UtilHtml.GetPageInfo(moduleName, PageType.GUESTBOOK_TYPE).locationHref;

                guestboookService.GetNeighborGuestbook(guestbookId, out prevGuestbook, out nextGuestbook);
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
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}
