using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using com.hujun64.logic;
using com.hujun64.po;
using com.hujun64.util;

namespace com.hujun64
{
    /// <summary>
    /// ListItem 的摘要说明。
    /// </summary>
    public partial class listitem : PageBase
    {

        public string title = "";

        protected string moduleClassName;

        protected string bigClassId = "";
        protected string smallClassId = "";

        protected string moduleClassId;
        protected string myLocation = "";
        protected string classImgUrl;
        protected string currentPageIndex = "";
        public PageMeta pageMeta;
        public string pageMetaName;
        private IArticleService articleService = ServiceFactory.GetArticleService();
        private IMainClassService classService = ServiceFactory.GetMainClassService();

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                moduleClassName = Request.QueryString["class_name"];
                moduleClassId = classService.GetClassByName(moduleClassName, Total.SiteId).id;


                if (string.IsNullOrEmpty(bigClassId) && !string.IsNullOrEmpty(smallClassId))
                {
                    bigClassId = classService.GetBigClassBySmall(smallClassId).id;
                }



                pageMetaName = classService.GetClassById(moduleClassId).class_name;


                pageMeta = UtilPageMeta.GetPageMeta(pageMetaName);


                PageInfo pageInfo = UtilHtml.GetPageInfo(bigClassId, smallClassId, moduleClassId);

                myLocation = pageInfo.locationHref;
                title = pageInfo.title;
                if (string.IsNullOrEmpty(title))
                    title = moduleClassName;




                classImgUrl = UtilHtml.GetFullImageUrl(Total.ImgProfileUrl, UtilHtml.RemoveHtmlTag(Total.Profile));

                RPDataBind();
            }

        }

        private void RPDataBind()
        {
            if (AspNetPager1.CurrentPageIndex > 1)
                currentPageIndex = "_第" + AspNetPager1.CurrentPageIndex.ToString() + "页";
            else
                currentPageIndex = "";

            title += currentPageIndex;

            AspNetPager1.AlwaysShow = true;
            AspNetPager1.PageSize = 30;


            int totalCount = 0;
            List<Article> articleList;
            if (!string.IsNullOrEmpty(moduleClassId))
                articleList = articleService.GetTopArticle(bigClassId, smallClassId, moduleClassId, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1) + 1, AspNetPager1.PageSize, out totalCount);
            else
                articleList = null;
            AspNetPager1.RecordCount = totalCount;
            RepeaterArticles.DataSource = articleList;
            RepeaterArticles.DataBind();

            

        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            RPDataBind();
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
