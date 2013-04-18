using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using com.hujun64.logic;
using com.hujun64.po;
using com.hujun64.util;
using com.hujun64.type;
namespace com.hujun64.admin
{
    /// <summary>
    /// add_art ��ժҪ˵����
    /// </summary>
    public partial class add_art : AdminPageBase
    {
        private ICommonService commonService = ServiceFactory.GetCommonService();
        private IMainClassService classService = ServiceFactory.GetMainClassService();
        private IArticleService articleService = ServiceFactory.GetArticleService();

        private readonly string BIG_CLASS_ALL = "";
        protected string IMG_UPLOAD_PATH = @"~\images\upload\";
        protected static string uploadImgUrl;

        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!IsPostBack)
            {
                uploadImgUrl = "";

                moduleClassBind();
                moduleClassList.SelectedValue = Total.ModuleNameLsbwsj;

                string articleId = Request.QueryString[Total.QueryStringArticleId];
                string deletedArticleId = Request.QueryString[Total.QueryStringDeletedArticleId];


                if (string.IsNullOrEmpty(articleId) && string.IsNullOrEmpty(deletedArticleId))
                {
                    recoverClassCookie();
                    author.Text = Total.Author;
                    submit_button.Text = "��׼��ʽ����";
                    definedSubmit_button.Text = "�Զ����ʽ����";

                }
                else
                {
                    submit_button.Text = "��׼��ʽ����";
                    definedSubmit_button.Text = "�Զ����ʽ����";


                    if (!string.IsNullOrEmpty(deletedArticleId))
                    {

                        getUpdateNews(deletedArticleId, true);
                    }
                    else
                    {
                        getUpdateNews(articleId, false);
                    }
                }
                if (moduleClassList.SelectedItem.Text.Trim().Equals(Total.ModuleNameFzrd))
                {
                    author.Text = "";
                    artFrom.Text = "";
                }
            }


        }
        protected void ReferenceFile(object sender, EventArgs E)
        {
            uploadImgUrl = refImgUrl.Text.Trim();
        }
        protected void UploadFile(object sender, EventArgs E)
        {
            //����ϴ��ļ���Ϊ�� 
            if (imgFile.PostedFile != null)
            {
                try
                {
                    string filename = UtilString.GetPureFilename(imgFile.PostedFile.FileName);

                    StringBuilder destFilepathSb = new StringBuilder(IMG_UPLOAD_PATH);


                    destFilepathSb.Append(filename);
                    string destFullpath = Server.MapPath(destFilepathSb.ToString());
                    refImgUrl.Text = destFilepathSb.Replace(@"~\", Total.CurrentSiteRootUrl).Replace(@"\", "/").ToString();

                    imgFile.PostedFile.SaveAs(destFullpath);


                    Response.Write("<script>javascript:alert('���ͼƬ�ϴ��ɹ���');</script>");
                    MSG.Text = "<font color=red>���ͼƬ�ϴ��ɹ���</font>";

                }
                catch (Exception ex)
                {
                    MSG.Text = "<font color=red>" + ex.Message + "</font>";
                }

            }
        }
        private void getUpdateNews(string nid, bool isDeleted)
        {

            Article article;
            bool isRefArticle = false;
            if (isDeleted)
                article = articleService.GetDeletedArticle(nid, true);
            else
                article = articleService.GetArticle(nid, true);

            if (article.articlePicture != null && !string.IsNullOrEmpty(article.articlePicture.pic_url))
            {
                refImgUrl.Text = article.articlePicture.pic_url;
                uploadImgUrl = article.articlePicture.pic_url;
            }


            TextBoxAticleId.Text = article.id;
            if (!string.IsNullOrEmpty(article.ref_id))
            {

                isRefArticle = true;
                RefArticleId.Text = article.ref_id;
                RefCheckBox.Checked = true;
                RefArticleChecked();

            }
            newsId.Value = nid;
            string moduleClassId = moduleClassList.SelectedValue.ToString();


            moduleClassList.SelectedValue = article.module_class_id;


            if (!isRefArticle)
            {
                arttitle.Text = article.title;
                ContentEditor.Text = article.content;

                author.Text = article.author;
                artFrom.Text = article.news_from;
                keywords.Text = article.keywords;
            }
            if (article.articlePicture != null)
            {
                refImgUrl.Text = article.articlePicture.pic_url;
                uploadImgUrl = article.articlePicture.pic_url;

            }
        }



        void moduleClassBind()//�������
        {
            List<string> moduleNameList=new List<string>();
            moduleNameList.Add(Total.ModuleNameLsbwsj);
            moduleNameList.Add(Total.ModuleNameSszs);
            moduleNameList.Add(Total.ModuleNameSyfg);
            moduleNameList.Add(Total.ModuleNameLsjs);
            moduleNameList.Add(Total.ModuleNameFwmm);
            moduleNameList.Add(Total.ModuleNameFwqs);
            moduleNameList.Add(Total.ModuleNameLhjc);
            moduleNameList.Add(Total.ModuleNameCqaz);
            moduleNameList.Add(Total.ModuleNameZldy);
            moduleNameList.Add(Total.ModuleNameWygl);
            moduleNameList.Add(Total.ModuleNameShfzb);
            moduleNameList.Add(Total.ModuleNameTpxw);
            List<MainClass> moduleList = classService.GetModuleClassListByModuleNameList(moduleNameList, Total.SiteId);
            moduleClassList.DataSource = moduleList;
            moduleClassList.DataBind();

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


        protected void bigClassList_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            saveClassCookie();
        }
        protected void moduleClassList_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            saveClassCookie();
        }

        protected void ignoreBigClass_SelectedIndexChanged(object sender, System.EventArgs e)
        {


            saveClassCookie();
        }
        protected void ignoreSmallClass_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            saveClassCookie();
        }
        private void alterIngnore()
        {
            Response.Write("<script >function window.onload() {alert('�������з��඼���ԣ�����ѡ��һ�����࣡');}</script>");

        }

        protected void ignoreModule_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            saveClassCookie();
        }
        protected void RefCheckBox_Selected(object sender, System.EventArgs e)
        {
            RefArticleChecked();

        }
        private void RefArticleChecked()
        {
            hiddenArticle(!RefCheckBox.Checked);
            displayRefArticle();
            if (!RefCheckBox.Checked)
                resetForm();

        }
        protected void RefId_Changed(object sender, System.EventArgs e)
        {
            displayRefArticle();

        }
        private void displayRefArticle()
        {
            RefArticleId.Text = RefArticleId.Text.Trim();
            if (RefCheckBox.Checked && !string.IsNullOrEmpty(RefArticleId.Text))
            {

                Article article = articleService.GetArticle(RefArticleId.Text, false);
                arttitle.Text = article.title;
                artFrom.Text = article.news_from;
                author.Text = article.author;
                keywords.Text = article.keywords;
            }
        }
        private void hiddenArticle(bool enabled)
        {
            arttitle.Enabled = enabled;
            artFrom.Enabled = enabled;
            author.Enabled = enabled;
            keywords.Enabled = enabled;
            ContentEditor.Visible = enabled;
            definedSubmit_button.Enabled = enabled;
        }

        private void resetForm()
        {
            newsId.Value = "";
            arttitle.Text = "";
            ContentEditor.Text = "";
            author.Text = Total.Author;
            artFrom.Text = Total.ByOriginal;
            keywords.Text = "";
            uploadImgUrl = "";
            refImgUrl.Text = "";
            //ignoreBigClass.Checked = false;
            //ignoreSmallClass.Checked = false;
            //ignoreModule.Checked = false;

        }

        protected void reset_Click(object sender, System.EventArgs e)
        {
            resetForm();
        }
        private void setArticleClass(Article article)
        {
            string moduleClassId = moduleClassList.SelectedValue.ToString();


            if (ignoreModuleClass.Checked)
            {
                moduleClassId = "";

            }

            article.module_class_id = moduleClassId;


        }
        private void saveClassCookie()
        {

            DateTime cookieExpires = DateTime.Now.AddDays(Total.CookieExpiresDays);
            Response.Cookies["add_moduleClassId"].Value = moduleClassList.SelectedValue.ToString(); Response.Cookies["add_moduleClassId"].Expires = cookieExpires;

            Response.Cookies["add_ignoreModuleClass"].Value = ignoreModuleClass.Checked.ToString(); Response.Cookies["add_ignoreModuleClass"].Expires = cookieExpires;



        }
        private void recoverClassCookie()
        {

            if (Request.Cookies["add_moduleClassId"] != null)
                moduleClassList.SelectedValue = Request.Cookies["add_moduleClassId"].Value;





            if (Request.Cookies["add_ignoreModuleClass"] != null)
                ignoreModuleClass.Checked = Convert.ToBoolean(Request.Cookies["add_ignoreModuleClass"].Value);





        }
        private void submit(object sender, System.EventArgs e, bool isStandard)
        {
            List<string> siteIdList = new List<string>();

            siteIdList.Add(Total.SiteId);

            if (!string.IsNullOrEmpty(refImgUrl.Text.Trim()))
            {
                uploadImgUrl = refImgUrl.Text.Trim();
            }

            if (RefCheckBox.Checked && !string.IsNullOrEmpty(RefArticleId.Text))
            {

                if (string.IsNullOrEmpty(arttitle.Text))
                {

                    MSG.Text = "�Բ������������������ID��Ч��������������ȷ������ID��";
                    Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");
                    RefArticleId.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(TextBoxAticleId.Text))
                {
                    Article articleRef = new Article();
                    articleRef.ref_id = RefArticleId.Text.Trim();
                    Article article = articleService.GetArticle(articleRef.ref_id, false);

                    articleRef.articlePicture = article.articlePicture;
                    setArticleClass(articleRef);


                    articleRef.site_list = siteIdList;


                    articleService.InsertArticleRef(articleRef);



                     
                  

                    MSG.Text = "����������óɹ���";

                    Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");
                    return;

                }
                else
                {
                    Article articleRef = articleService.GetArticle(TextBoxAticleId.Text);
                    articleRef.ref_id = RefArticleId.Text.Trim();
                    setArticleClass(articleRef);
                    articleRef.site_list = siteIdList;
                    articleService.UpdateArticle(articleRef);



                  

                    MSG.Text = "�����������óɹ���";

                    Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");
                    return;

                }
            }
            else

                if (arttitle.Text.Trim() != "" && ContentEditor.Text != "")
                {
                    Article article;
                    try
                    {


                        if (newsId.Value.ToString() != "")
                        {
                            article = articleService.GetArticle(newsId.Value.ToString(), false);
                            if (string.IsNullOrEmpty(article.id))
                            {
                                article = articleService.GetDeletedArticle(newsId.Value.ToString(), false);
                                arttitle.Enabled = true;
                            }

                        }
                        else
                        {
                            article = new Article();
                        }




                        setArticleClass(article);
                        article.site_list = siteIdList;
                        article.content = UtilHtml.FormatArticleContent(ContentEditor.Text, isStandard);




                        article.title = arttitle.Text.Trim();
                        article.author = author.Text.Trim();
                        article.news_from = artFrom.Text.Trim();
                        if (string.IsNullOrEmpty(article.news_from))
                        {
                            article.news_from = "����ת��";
                        }


                        article.is_static = false;
                        article.enabled = true;


                        article.keywords = UtilHtml.FormatKeywords(keywords.Text);


                        if (newsId.Value.ToString() != "")
                        {
                            if (article.articlePicture != null)
                            {
                                article.articlePicture.pic_url = uploadImgUrl;
                            }
                            else if (!string.IsNullOrEmpty(uploadImgUrl))
                            {
                                article.articlePicture = new ArticlePicture();
                                article.articlePicture.pic_url = uploadImgUrl;
                            }
                            articleService.UpdateArticle(article);
                            ContentEditor.Text = article.content;

                            //�첽������վ
                            AsyncTaskService.UpdateSiteAsync(RefreshType.ONLY_CHANGED);
                            AsyncTaskService.PostArticle2ShfclawyerAsync(article);
                            MSG.Text = "���³ɹ���";


                        }
                        else
                        {
                            if (articleService.ExistsTitle(article.title, true))
                            {
                                MSG.Text = "�Ѿ�������ͬ��������£�����ı��⣡";
                                Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");
                                return;
                            }


                            article.id = articleService.GenerateId();
                            if (!string.IsNullOrEmpty(uploadImgUrl))
                            {
                                article.articlePicture = new ArticlePicture();
                                article.articlePicture.pic_url = uploadImgUrl;
                            }


                            articleService.InsertArticle(article);
 
                            MSG.Text = "��ӳɹ���";

                            resetForm();

                        }
                        articleService.RefreshCachedArticle();

                        //������������
                        LuceneSearcher.WriteIndex(article, false);

                        article = articleService.GetArticle(article.id, false);
                        Response.Write("<script>javascript:if(confirm('�����ɹ����Ƿ���������£�')){window.open('../" + UtilHtml.GetAspxUrl(article.id, article.page_type) + "');}</script>");



                    }
                    catch (Exception ex)
                    {
                        MSG.Text = "<font color=red>" + ex.Message.ToString() + "</font>";//���������Ϣ
                        Response.Write("<script>javascript:alert('������Ϣ��" + ex.Message.ToString() + "');</script>");
                    }

                }
                else
                {
                    MSG.Text = "��ѡ����࣡��������ݲ���Ϊ�գ�";
                    Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");
                }
        }
        protected void definedSubmit_Click(object sender, System.EventArgs e)
        {
            submit(sender, e, false);
        }
        protected void submit_Click(object sender, System.EventArgs e)
        {

            submit(sender, e, true);

        }



    }
}
