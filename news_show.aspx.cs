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
    /// news_show ��ժҪ˵����
    /// </summary>
    public partial class news_show : PageBase
    {
        
        protected string title = "";
        protected string articleKeywords = "";
        protected string metaDescription = "";

        protected string moduleClassName;
        private IArticleService articleService = ServiceFactory.GetArticleService();
        private IMainClassService classService = ServiceFactory.GetMainClassService();

        protected string author, newsFrom;
        protected string picUrl="";


        protected string articleId = "";
        protected string myLocation = "";

        protected Article prevArticle, nextArticle;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Article article;

                articleId = Request.QueryString[Total.QueryStringArticleId];
               string guestbookId = Request.QueryString[Total.QueryStringGuestbookId];
               if (string.IsNullOrEmpty(articleId) && !string.IsNullOrEmpty(guestbookId))
               {
                   Response.Redirect("guestbook_show.aspx?" + Total.QueryStringGuestbookId + "=" + guestbookId);
                   return;
               }
                
                string articleTitle = Request.QueryString["title"];
                if (string.IsNullOrEmpty(articleId) && !string.IsNullOrEmpty(Request.QueryString[Total.QueryStringDeletedArticleId]))
                {

                    article = articleService.GetDeletedArticle(Request.QueryString[Total.QueryStringDeletedArticleId].ToUpper(), true);

                }
                else if (!String.IsNullOrEmpty(articleTitle))
                {
                    article = articleService.GetArticleByTitle(articleTitle, true);
                    if(article!=null)
                        articleId = article.id;
                }
                else if (articleId == null)
                {
                    return;
                }else
                {
                    articleId = articleId.ToUpper();
                    article = articleService.GetArticle(articleId, true);
                }


                if (article!=null && string.IsNullOrEmpty(article.id))
                {
                    if (articleId!=null && articleId.StartsWith("G"))
                    {
                        Response.Redirect("guestbook_show.aspx?" + Total.QueryStringGuestbookId + "=" + articleId);
                        return;
                    }
                }else
                 
                {

                    this.moduleClassName = classService.GetClassById(article.module_class_id).class_name;

                    if (!string.IsNullOrEmpty(article.author))
                    {
                        author = article.author;
                    }
                    else
                    {
                        author = "����";
                    }
                    if (!string.IsNullOrEmpty(article.news_from))
                    {
                        newsFrom = article.news_from;
                    }
                    else
                    {
                        newsFrom = "����";
                    }
                    title = UtilHtml.RemoveHtmlTag(article.title);
                    string metaKeywords=UtilHtml.ExtractMetaKeywords(article);
                    articleKeywords = metaKeywords.Substring(0, Math.Min(50,metaKeywords.Length));
                    metaDescription = UtilHtml.ExtractMetaDesc(article);

                    myLocation = UtilHtml.GetPageInfo(article.big_class_id, article.class_id, article.module_class_id).locationHref;


                    if(article.articlePicture!=null){
                        picUrl=UtilHtml.GetFullImageUrl(article.articlePicture.pic_url, article.articlePicture.pic_alt);
                    }


                    List<Article> articleList = new List<Article>(1);
                    articleList.Add(article);
                    RepeaterNews.DataSource = articleList;
                    RepeaterNews.DataBind();

                    articleService.GetNeighborArticle(articleId, out prevArticle, out nextArticle);
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
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}
