using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using com.hujun64.po;
using com.hujun64.logic;
using com.hujun64.util;
using com.hujun64.type;
namespace com.hujun64.admin
{
    /// <summary>
    /// art_list ��ժҪ˵����
    /// </summary>
    public partial class recyle : AdminPageBase
    { 

        private IArticleService articleService = ServiceFactory.GetArticleService();

         
        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!IsPostBack)
            {

                newsListBind();
            }


        }

        void newsListBind()
        {

            newlistDGD.DataSource = articleService.GetDeletedArticleList(false);
            newlistDGD.DataBind();



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



        private void newlistDGD_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {

            try
            {
                string articleId = newlistDGD.DataKeys[e.Item.ItemIndex].ToString();

                Article deletedArticle = articleService.GetDeletedArticle(articleId, false);

                bool success = articleService.PurgeArticle(articleId, deletedArticle.site_list);
                if (success)
                    MSG.Text = "����ɾ���ɹ���";
                else
                    MSG.Text = "����ɾ��ʧ�ܣ�";
                Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");

            }
            catch (Exception ex)
            {
                MSG.Text = ex.Message.ToString();//���������Ϣ
            }
            finally
            {

                newsListBind();
            }

        }
        protected void newlistDGD_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Article article = (Article)e.Item.DataItem;


            }

        }


        protected void newlistDGD_Command(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {


            string keyId = newlistDGD.DataKeys[e.Item.ItemIndex].ToString();

            string[] idArray = keyId.Split(',');
            string articleId = idArray[0];



            if (e.CommandName == "Open")
            {
                Article article = articleService.GetDeletedArticle(articleId, false);

                Response.Write("<script>javascript:window.open('../" + UtilHtml.GetAspxUrl(article.id, article.page_type) + "');</script>");
            }
        }
    }
}
