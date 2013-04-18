using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.hujun64.util;
using com.hujun64.logic;
using com.hujun64.po;
namespace com.hujun64
{
    public partial class index : PageBase
    {
        public string title = "", url = "", id = "";
        private readonly int BANNER_WIDTH = 800;

        public PageMeta pageMeta;
        public string pageMetaName = "";

        private IMainClassService classService = ServiceFactory.GetMainClassService();
        private IArticleService articleService = ServiceFactory.GetArticleService();


        protected System.Web.UI.WebControls.DataList DataList1;
        protected System.Web.UI.WebControls.DataList DataList2;
        protected ImageUrl bannerImageUrl1, bannerImageUrl2;



        protected string wtwmClassId, basjClassId, xwkfClassId, tpxwClassId, indexClassId, lsbwClassId;
        private List<string> moduleNameList;
        private List<string> bigClassNameList;
        private List<ImageUrl> bannerList;

        protected string ownerLawyer = "胡珺律师";
        protected string ownerLawyerUrl;
        protected Article ownerLawyerArticle;

        protected string directorLawyer = "宋安成律师";
        protected string directorLawyerUrl;
        protected Article directorLawyerArticle;
        protected string requestModuleId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                requestModuleId = Request.QueryString[Total.QueryStringModuleClassId];

                if (!string.IsNullOrEmpty(requestModuleId))
                {
                    pageMetaName = classService.GetClassById(requestModuleId).class_name;
                }


                pageMeta = UtilPageMeta.GetPageMeta(pageMetaName);

                ownerLawyerArticle = articleService.GetArticleByTitle(ownerLawyer);
                ownerLawyerUrl = String.Format("{0}?{1}={2}", Total.AspxUrlIntro, Total.QueryStringIntroId, ownerLawyerArticle.id);

                directorLawyerArticle = articleService.GetArticleByTitle(directorLawyer);
                directorLawyerUrl = String.Format("{0}?{1}={2}", Total.AspxUrlIntro, Total.QueryStringIntroId, directorLawyerArticle.id);


                bannerImageUrl1 = new ImageUrl(Total.BannerObjectUrl, BANNER_WIDTH, 60);
                bannerImageUrl2 = new ImageUrl(Total.BannerProfessionalUrl, BANNER_WIDTH, 60);

                wtwmClassId = classService.GetClassByName(Total.ModuleNameGywm, Total.SiteId).id;
                basjClassId = classService.GetClassByName(Total.ModuleNameBasj, Total.SiteId).id;
                xwkfClassId = classService.GetClassByName(Total.ModuleNameXwkf, Total.SiteId).id;
                tpxwClassId = classService.GetClassByName(Total.ModuleNameTpxw, Total.SiteId).id;
                indexClassId = classService.GetClassByName(Total.ModuleNameIndex, Total.SiteId).id;
                lsbwClassId = classService.GetClassByName(Total.ModuleNameLsbw, Total.SiteId).id;

                moduleNameList = Total.IndexModuleClassIncludeBigClassNameList;
                bigClassNameList = new List<string>();
                bigClassNameList.Add(Total.BigClassNameYasf);
                bigClassNameList.Add(Total.BigClassNameFlkt);
                bigClassNameList.Add(Total.BigClassNameFgjd);

                bannerList = new List<ImageUrl>();

                bannerList.Add(new ImageUrl(Total.BannerObjectUrl, BANNER_WIDTH, 60));
                bannerList.Add(new ImageUrl(Total.BannerProfessionalUrl, BANNER_WIDTH, 60));



                List<SiteClass> categoryList;
                if (String.IsNullOrEmpty(requestModuleId))
                    categoryList = classService.GetSiteClassByMain(classService.GetModuleClassListByModuleNameList(moduleNameList, Total.SiteId), Total.SiteId);
                else
                {
                    categoryList = new List<SiteClass>();
                    SiteClass sc = classService.GetSiteClassByMain(classService.GetClassById(requestModuleId), Total.SiteId);
                    if (sc != null)
                        categoryList.Add(sc);
                }


                RepeaterArticlePicture.DataSource = articleService.GetTopPictureArticle(tpxwClassId, 1, 5);
                RepeaterArticlePicture.DataBind();


              

                List<Article> lsbwList = articleService.GetTopArticleByBigClassName(Total.ModuleNameLsbwsj, 8);
                //lsbwList.Remove(focusList[0]);
                RepeaterLsbw.DataSource = lsbwList;
                RepeaterLsbw.DataBind();



                RepeaterFwmm.DataSource = articleService.GetTopArticleByModuleName(Total.ModuleNameFwmm, 10);
                RepeaterFwmm.DataBind();

                RepeaterFwqs.DataSource = articleService.GetTopArticleByModuleName(Total.ModuleNameFwqs, 10);
                RepeaterFwqs.DataBind();



                RepeaterLhjc.DataSource = articleService.GetTopArticleByModuleName(Total.ModuleNameLhjc, 10);
                RepeaterLhjc.DataBind();

                RepeaterCqaz.DataSource = articleService.GetTopArticleByModuleName(Total.ModuleNameCqaz, 10);
                RepeaterCqaz.DataBind();



                RepeaterZldy.DataSource = articleService.GetTopArticleByModuleName(Total.ModuleNameZldy, 10);
                RepeaterZldy.DataBind();


                RepeaterWygl.DataSource = articleService.GetTopArticleByModuleName(Total.ModuleNameWygl, 10);
                RepeaterWygl.DataBind();

                RepeaterSszz.DataSource = articleService.GetTopArticleByBigClassName(Total.ModuleNameSszz, 10);
                RepeaterSszz.DataBind();

                RepeaterSyfg.DataSource = articleService.GetTopArticleByBigClassName(Total.ModuleNameSyfg, 10);
                RepeaterSyfg.DataBind();


            }

        }
    }
}
