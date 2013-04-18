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
    /// guestbook ��ժҪ˵����
    /// </summary>
    public partial class guestbook : PageBase
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
        private IGuestbookService guestbookService = ServiceFactory.GetGuestbookService();
        private IMainClassService classService = ServiceFactory.GetMainClassService();

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                moduleClassName = "������ѯ";
                moduleClassId = classService.GetClassByName(moduleClassName, Total.SiteId).id; 


                pageMetaName = classService.GetClassById(moduleClassId).class_name;


                pageMeta = UtilPageMeta.GetPageMeta(pageMetaName);


                PageInfo pageInfo = UtilHtml.GetPageInfo(bigClassId, smallClassId, moduleClassId);

                myLocation = pageInfo.locationHref;
                title = pageInfo.title;




                classImgUrl = UtilHtml.GetFullImageUrl(Total.ImgProfileUrl, UtilHtml.RemoveHtmlTag(Total.Profile));

                RPDataBind();
            }

        }
       
        private void RPDataBind()
        {
            if (AspNetPager1.CurrentPageIndex > 1)
                currentPageIndex = "_��" + AspNetPager1.CurrentPageIndex.ToString() + "ҳ";
            else
                currentPageIndex = "";

            title += currentPageIndex;

            AspNetPager1.AlwaysShow = true;
            AspNetPager1.PageSize = 30;


            int totalCount = 0;
            List<Guestbook> guestbookList = guestbookService.GetTopGuestbookList("", AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1) + 1, AspNetPager1.PageSize, out totalCount);
            AspNetPager1.RecordCount = totalCount;
            RepeaterArticles.DataSource = guestbookList;
            RepeaterArticles.DataBind();



        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            RPDataBind();
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
