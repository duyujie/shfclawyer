using System;
using System.Text;
using System.Collections.Generic;
using com.hujun64.logic;
using com.hujun64.po;
using com.hujun64.util;
namespace com.hujun64.admin
{
    /// <summary>
    /// bulk_mail ��ժҪ˵����
    /// </summary>
    public partial class bulk_email : AdminPageBase
    {


        
        private string MyMobileCode = Total.Mobile.Replace(" ", "");
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                noticeTitle.Text = "����ʦ�Ľ���ף��";

                StringBuilder sb = new StringBuilder("&nbsp;&nbsp;&nbsp;&nbsp;ף�����տ��֣���;���ģ�������죡<br />&nbsp;&nbsp;&nbsp;&nbsp;�������������������κη������⣬������ֱ����ϵ�Ϻ����B��ʦ���绰��");
                sb.Append(MyMobileCode);
                sb.Append("������ʦ�����԰������");

                ContentEditor.Value = sb.ToString();
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





        protected void submit_all(object sender, System.EventArgs e)
        {

            bulkEmail(noticeTitle.Text, ContentEditor.Value, false);
        }
        protected void submit_shanghai(object sender, System.EventArgs e)
        {

            bulkEmail(noticeTitle.Text, ContentEditor.Value, true);
        }
        //֪ͨ��ѯ��
        private void bulkEmail(string title, string notice, bool isOnlyShanghai)
        {
            if (string.IsNullOrEmpty(notice))
            {
                MSG.Text = "��������⣡";
                Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");
                return;
            }
            IGuestbookService guestbookService = ServiceFactory.GetGuestbookService();
            Dictionary<string, string> guestEmailDict = guestbookService.GetAllGuestEmailDict(isOnlyShanghai);

            //Dictionary<string, string> guestEmailDict = new Dictionary<string, string>();
            //guestEmailDict.Add("�����", "yujied@gmail.com");


            StringBuilder sb = new StringBuilder();
            int iSuccess = 0;
            foreach (string guestName in guestEmailDict.Keys)
            {
                try
                {
                    sb.Remove(0, sb.Length);
                    sb.Append("<style type=\"text/css\"> p {text-indent:2em;margin-top:1em;margin-bottom:1em} </style>");
                    sb.Append("�𾴵� ");
                    sb.Append(guestName);
                    sb.Append("��<br />");

                    //Ⱥ������
                    sb.Append(notice);



                    UtilMail.SendMailAsync(title, sb.ToString(), guestEmailDict[guestName], null);
                    iSuccess++;
                }
                catch (Exception ex)
                {
                    log4net.LogManager.GetLogger(this.ToString()).Error("���� " + guestName + " ����", ex);
                }

            }
            MSG.Text = "�����ʼ���ɣ� " + iSuccess.ToString() + "/" + guestEmailDict.Count.ToString();
            Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");
        }

    }
}
