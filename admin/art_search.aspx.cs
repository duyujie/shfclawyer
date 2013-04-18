using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading;
using System.Web;
using com.hujun64.po;
using com.hujun64.logic;
using com.hujun64.util;
using com.hujun64.type;
namespace com.hujun64.admin
{
    /// <summary>
    /// art_list ��ժҪ˵����
    /// </summary>
    public partial class art_search : AdminPageBase
    {


        IMainClassService mainClassService = ServiceFactory.GetMainClassService();
        private IArticleService articleService = ServiceFactory.GetArticleService();

        private readonly int INDEX_SORT_UP = 7, INDEX_SORT_DOWN = 8;
        private readonly int INDEX_REF_ID = 3, INDEX_REF_BY = 4;
        private static Dictionary<string, int> storedPageIndexCollection = new Dictionary<string, int>();

        protected string navigateUrlFormatString = "add_art.aspx?" + Total.QueryStringArticleId + "={0}";
        private static string queryingArticleId, queryingArticleTitle;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {

                recoverQueryCondition();

                getNewsList();
            }
         

            
            
        }

        private string getStoredPageIndexKey()
        {
            StringBuilder keySb = new StringBuilder();
            keySb.Append(queryingArticleId);
            keySb.Append(";");
            keySb.Append(queryingArticleTitle);
            return keySb.ToString();

        }

        private void recoverQueryCondition()
        {
            TextBoxSearchAticleId.Text = queryingArticleId;

            TextBoxSearchTitle.Text = queryingArticleTitle;



        }
      

        private void newsListBind(List<Article> articleList, int totalCount)
        {
            LabelCount.Text = totalCount.ToString() + "��";


            newlistDGD.DataSource = articleList;
            newlistDGD.DataBind();


            //���һ�в��ܽ���
            if (newlistDGD.Items.Count > 0)
                newlistDGD.Items[newlistDGD.Items.Count - 1].Cells[INDEX_SORT_DOWN].Enabled = false;
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
            this.newlistDGD.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.newlistDGD_DeleteCommand);
            newlistDGD.ItemDataBound += new DataGridItemEventHandler(newlistDGD_ItemDataBound);

        }
        #endregion


        protected void click_ArticleQueryById(object sender, System.EventArgs e)
        {
            queryingArticleId = TextBoxSearchAticleId.Text.Trim();
            queryingArticleTitle = "";

            ArticleQueryById();
        }
        private void ArticleQueryById()
        {

            List<Article> articleList = new List<Article>();
            if (!string.IsNullOrEmpty(queryingArticleId))
            {

                Article article = articleService.GetArticle(queryingArticleId);
                if (article != null && !string.IsNullOrEmpty(article.id))
                {
                    articleList.Add(article);

                }

            }

            newsListBind(articleList, articleList.Count);
        }

        protected void click_ArticleQueryByTitle(object sender, System.EventArgs e)
        {
            queryingArticleTitle = TextBoxSearchTitle.Text.Trim();
            queryingArticleId = "";
            ArticleQueryByTitle();
        }
        private void ArticleQueryByTitle()
        {


            List<Article> articleList = new List<Article>();
            if (!string.IsNullOrEmpty(queryingArticleTitle))
            {
                articleList = articleService.GetArticleListLikeTitle(queryingArticleTitle);


            }

            newsListBind(articleList, articleList.Count);
        }


        private void newlistDGD_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {

            try
            {
                string id = newlistDGD.DataKeys[e.Item.ItemIndex].ToString();
                Article article = articleService.GetArticle(id, false);
                string htmlUrl = UtilHtml.GetHtmlUrl(id, article.page_type);
                if (articleService.DeleteArticle(id))
                {

                    string filePath = HttpContext.Current.Server.MapPath("~/") + htmlUrl;
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    MSG.Text = "ɾ���ɹ���";
                }
                else
                    MSG.Text = "ɾ��ʧ�ܣ�";
                Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");

            }
            catch (Exception ex)
            {
                MSG.Text = ex.Message.ToString();//���������Ϣ
            }
            finally
            {

            }

        }
        private void getNewsList()
        {
            if (!string.IsNullOrEmpty(queryingArticleId))
                ArticleQueryById();
            else if (!string.IsNullOrEmpty(queryingArticleTitle))
                ArticleQueryByTitle();
        }
        protected void newlistDGD_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.ItemIndex == 0)
                {
                    //��һ�в��ܽ�������
                    e.Item.Cells[INDEX_SORT_UP].Enabled = false;
                }
                Article article = (Article)e.Item.DataItem;
                if (!string.IsNullOrEmpty(article.ref_id))
                {
                    string refId = article.ref_id;

                    StringBuilder refUrlSb = new StringBuilder();

                    refUrlSb.AppendFormat("add_art.aspx?nid={0}", refId);



                    string refPageInfo = UtilHtml.FormatHtmlToText(UtilHtml.GetPageInfo(articleService.GetArticle(refId, false)).locationHref);


                    e.Item.Cells[INDEX_REF_ID].Text = UtilHtml.BuildHref(refUrlSb.ToString(), refId, refPageInfo, false);
                }
                if (!string.IsNullOrEmpty(article.ref_by_list))
                {
                    string[] refByArray = article.ref_by_list.Split(' ');
                    StringBuilder sb = new StringBuilder();
                    foreach (string refById in refByArray)
                    {
                        string refByUrl = Total.ApplicationPath + "/" + UtilHtml.GetAspxUrl(refById, PageType.ARTICLE_TYPE);
                        string refByPageInfo = UtilHtml.FormatHtmlToText(UtilHtml.GetPageInfo(articleService.GetArticle(refById, false)).locationHref);
                        sb.Append(UtilHtml.BuildHref(refByUrl, refById, refByPageInfo, true)); sb.Append(" ");
                    }
                    e.Item.Cells[INDEX_REF_BY].Text = sb.ToString();
                }



            }

        }

        protected void newlistDGD_Command(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            string idCurrent, idOther;
            int indexOther;
            Article articleCurrent, articleOther;
            SortObject sortCurrent, sortOther;


            idCurrent = newlistDGD.DataKeys[e.Item.ItemIndex].ToString();




            if (e.CommandName == "SortUp" || e.CommandName == "SortDown")
            {
                try
                {
                    articleCurrent = articleService.GetArticle(idCurrent, false);

                    sortCurrent = new SortObject(articleCurrent.id, articleCurrent.sort_seq);

                    if (e.CommandName == "SortUp")
                    {
                        indexOther = e.Item.ItemIndex - 1;
                    }
                    else
                    {
                        indexOther = e.Item.ItemIndex + 1;
                    }

                    idOther = newlistDGD.DataKeys[indexOther].ToString();

                    articleOther = articleService.GetArticle(idOther, false);

                    sortOther = new SortObject(articleOther.id, articleOther.sort_seq);

                    if (e.CommandName == "SortUp")
                    {
                        sortOther = sortCurrent.ExchangeDownSortSeq(sortOther);
                    }
                    else
                    {
                        sortOther = sortCurrent.ExchangeUpSortSeq(sortOther);
                    }

                    articleCurrent.sort_seq = sortCurrent.sortSeq;
                    articleOther.sort_seq = sortOther.sortSeq;

                    articleService.UpdateSortSeq(idCurrent, articleCurrent.sort_seq);
                    articleService.UpdateSortSeq(idOther, articleOther.sort_seq);

                }
                catch (Exception ex)
                {
                    MSG.Text = ex.Message.ToString();//���������Ϣ
                    Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");
                }
                finally
                {
                    getNewsList();
                }
            }
            else if (e.CommandName == "Open")
            {
                Article article = articleService.GetArticle(idCurrent, false);

                Response.Write("<script>javascript:window.open('../" + UtilHtml.GetAspxUrl(article.id, article.page_type) + "');</script>");
            }
        }
     
    }

}
