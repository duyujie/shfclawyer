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
    /// add_art 的摘要说明。
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
                    submit_button.Text = "标准格式发表";
                    definedSubmit_button.Text = "自定义格式发表";

                }
                else
                {
                    submit_button.Text = "标准格式更新";
                    definedSubmit_button.Text = "自定义格式更新";


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
            //检查上传文件不为空 
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


                    Response.Write("<script>javascript:alert('相关图片上传成功！');</script>");
                    MSG.Text = "<font color=red>相关图片上传成功！</font>";

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



        void moduleClassBind()//版块分类绑定
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
            Response.Write("<script >function window.onload() {alert('不能所有分类都忽略，至少选择一个分类！');}</script>");

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

                    MSG.Text = "对不起，您输入的引用文章ID无效，请重新输入正确的文章ID！";
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



                     
                  

                    MSG.Text = "添加文章引用成功！";

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



                  

                    MSG.Text = "更新文章引用成功！";

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
                            article.news_from = "网络转引";
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

                            //异步更新网站
                            AsyncTaskService.UpdateSiteAsync(RefreshType.ONLY_CHANGED);
                            AsyncTaskService.PostArticle2ShfclawyerAsync(article);
                            MSG.Text = "更新成功！";


                        }
                        else
                        {
                            if (articleService.ExistsTitle(article.title, true))
                            {
                                MSG.Text = "已经存在相同标题的文章，请更改标题！";
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
 
                            MSG.Text = "添加成功！";

                            resetForm();

                        }
                        articleService.RefreshCachedArticle();

                        //更新搜索索引
                        LuceneSearcher.WriteIndex(article, false);

                        article = articleService.GetArticle(article.id, false);
                        Response.Write("<script>javascript:if(confirm('操作成功！是否浏览该文章？')){window.open('../" + UtilHtml.GetAspxUrl(article.id, article.page_type) + "');}</script>");



                    }
                    catch (Exception ex)
                    {
                        MSG.Text = "<font color=red>" + ex.Message.ToString() + "</font>";//输出错误信息
                        Response.Write("<script>javascript:alert('错误信息：" + ex.Message.ToString() + "');</script>");
                    }

                }
                else
                {
                    MSG.Text = "请选择分类！标题和内容不能为空！";
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
