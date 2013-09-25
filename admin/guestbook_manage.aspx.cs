using System;
using System.Drawing;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Threading;
using com.hujun64.logic;
using com.hujun64.po;
using com.hujun64.type;
using com.hujun64.util;

namespace com.hujun64.admin
{
    /// <summary>
    /// guestbook_del ��ժҪ˵����
    /// </summary>
    public partial class guestbook_manage : AdminPageBase
    {

        private IMainClassService classService = ServiceFactory.GetMainClassService();
        private IGuestbookService guestbookService = ServiceFactory.GetGuestbookService();
        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //AsyncTask.UpdateIpProvinceAsync("", "");
                dgd_bind();
               
            }


        }
        private void dgd_bind()
        {

            StringBuilder sqlSb = new StringBuilder();
            sqlSb.AppendFormat("select v.id,title,contact,author,sex,isnull(class_name,'����') as big_class,v.addtime,click,province_from,case when reply is not null then 'Y' else 'N' end as is_replied from view_guestbook v  left outer join main_class m on v.big_class_id=m.id  where v.enabled=1 and site_id='{0}' order by v.addtime desc", Total.SiteId);
            int totalCount;
            DataSet ds = ServiceFactory.GetCommonService().GetPagerDataSet(sqlSb.ToString(), AspNetPager1.CurrentPageIndex, Total.PageSizeDefault, out totalCount);
            AspNetPager1.RecordCount = totalCount;
            AspNetPager1.PageSize = Total.PageSizeDefault;
            DataGridTitle.DataSource = ds;
            DataGridTitle.DataBind();


        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            dgd_bind();
        }


        //֪ͨ��ѯ��
        private void email_guest(Guestbook guestbook)
        {

            if (!string.IsNullOrEmpty(guestbook.email) && !string.IsNullOrEmpty(guestbook.reply))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<style type=\"text/css\"> p {text-indent:2em;margin-top:1em;margin-bottom:1em} </style>");
                sb.Append("�𾴵� ");
                sb.Append(guestbook.author);
                sb.Append("��<p>���ã�����ʦ�Ѿ��ظ�������");
                sb.Append(guestbook.addtime.ToString("yyyy-MM-dd HH:mm:ss"));
                sb.Append("�ύ����ѯ��");
                sb.Append(guestbook.title);
                sb.Append("��<br /><br /><p>");

                sb.Append("��������ʣ� ");
                sb.Append(UtilHtml.BuildHref(Total.CurrentSiteRootUrl + UtilHtml.GetAspxUrl(guestbook.id, PageType.GUESTBOOK_TYPE)));

                sb.Append("<br />���ʼ�Ϊϵͳ�Զ����ͣ�����ظ���");
                sb.Append("</p>");
                UtilMail.SendMailAsync("������ѯ�ظ� - " + guestbook.title, sb.ToString(), guestbook.email, null);


            }

        }
        protected void reply_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(guestId.Value))
                return;


            Guestbook guestbook = guestbookService.GetGuestbook(guestId.Value.ToString(), true);
            guestbook.reply = reply.Text.Trim();
            guestbook.keywords = UtilHtml.FormatKeywords(keywords.Text);
            guestbook.title = guesttitle.Text.Trim();
            guestbook.content = content.Text.Trim();
            guestbook.is_static = false;



            guestbookService.ReplyGuestbook(guestbook);
          

            //�Զ�֪ͨ��ѯ��
            if (email_guest_check.Checked)
                email_guest(guestbook);

            //������վ
            AsyncTaskService.UpdateSiteAsync(RefreshType.ONLY_CHANGED);

            //������������
            //LuceneSearcher.WriteIndex(guestbook,false);

            MSG.Text = "�ظ��ɹ���";
            Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");

            dgd_bind();

            LaebelSelectedId.Text = "";
            guestId.Value = "";
            guesttitle.Text = "";
            author.Text = "";
            contact.Text = "";
            sex.Text = "";
            addtime.Text = "";
            keywords.Text = "";
            content.Text = "";
            reply.Text = "";
            replytime.Text = "";
            ipProvince.Text = "";
            email.Text = "";
        }
        protected void DataGridTitle_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
            {
                System.Data.DataRowView rowv = (System.Data.DataRowView)e.Item.DataItem;
                e.Item.Cells[1].Text = UtilHtml.BuildHref("../" + UtilHtml.GetAspxUrl(rowv["id"].ToString(), PageType.GUESTBOOK_TYPE), rowv["title"].ToString(), rowv["title"].ToString(), true);

                if (e.Item.Cells[6].Text == "N")
                {
                    e.Item.Cells[6].ForeColor = Color.Red;
                }


                if (e.Item.Cells[3].Text.Contains("�Ϻ���"))
                {
                    e.Item.Cells[3].ForeColor = Color.Red;
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
            this.DataGridTitle.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
            DataGridTitle.ItemDataBound += new DataGridItemEventHandler(DataGridTitle_ItemDataBound);

        }
        #endregion

        protected void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string id = DataGridTitle.SelectedItem.Cells[0].Text;
            LaebelSelectedId.Text = id;
            Guestbook guestbook = guestbookService.GetGuestbook(id, true);

            if (guestbook != null)
            {
                guestId.Value = guestbook.id;
                guesttitle.Text = guestbook.title;
                keywords.Text = guestbook.keywords;
                author.Text = guestbook.author;
                sex.Text = guestbook.sex;
                contact.Text = guestbook.contact;
                email.Text = guestbook.email;
                ipProvince.Text = guestbook.province_from;
                if (guestbook.addtime != DateTime.MinValue)
                    addtime.Text = guestbook.addtime.ToString();
                else
                    addtime.Text = "";

                content.Text = guestbook.content;
                reply.Text = guestbook.reply;
               

                if (guestbook.replytime != DateTime.MinValue)
                {
                    replytime.Text = guestbook.replytime.ToString();

                }
                else
                {
                    replytime.Text = "";
                   
                }

                reply.Focus();

            }




        }

        private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            string id = DataGridTitle.DataKeys[e.Item.ItemIndex].ToString();

            try
            {

                string htmlUrl = UtilHtml.GetHtmlUrl(id, PageType.GUESTBOOK_TYPE);
                if (guestbookService.DeleteGuestbook(id))
                {
                    //AsyncTaskService.DeleteArticle4ShfclawyerAsync(id);
                    string filePath = HttpContext.Current.Server.MapPath("~/") + htmlUrl;
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }


                    UtilSitemap.DeleteSitemapXml(HttpContext.Current.Server.MapPath("~/") + Total.Sitemap, filePath, SitemapType.Google);

                    ServiceFactory.GetGuestbookService().RefreshCachedGuestbook();
                    UtilStatic.GetInstance().ConvertAll(RefreshType.ONLY_GUESTASK);
                }
                MSG.Text = "<font color=red>ɾ���ɹ���</font>";
                Response.Write("<script>javascript:alert('ɾ���ɹ���');</script>");
            }
            catch (Exception ex)
            {
                MSG.Text = "<font color=red>" + ex.Message.ToString() + "</font>";//���������Ϣ
            }
            finally
            {

                dgd_bind();
            }
        }
    }
}
