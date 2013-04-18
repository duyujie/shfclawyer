using System;
using System.Text;
using System.Collections.Generic;
using com.hujun64.logic;
using com.hujun64.po;
using com.hujun64.util;
using com.hujun64.type;
namespace com.hujun64.admin
{
    /// <summary>
    /// bulk_mail ��ժҪ˵����
    /// </summary>
    public partial class bulk_sms : AdminPageBase
    {


        private IClientService clientService = ServiceFactory.GetClientService();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("BulkSMS");
        private string MyMobileCode = Total.Mobile.Replace(" ", "");
        private string MyMobileCode2 = Total.Mobile2.Replace(" ", "");
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                StringBuilder sb = new StringBuilder("ף�����տ��֣�<br />�����κη������⣬������ϵ�Ϻ�����ʦ���绰");
                sb.Append(MyMobileCode);
                sb.Append("��");
                sb.Append(Total.SiteUrl);
                ContentEditor.Value = sb.ToString();


                SpecMobileSend.Text = MyMobileCode + "," + MyMobileCode2;
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



        protected void submit_query(object sender, System.EventArgs e)
        {
            try
            {
                //��ѯ���
                int i = InternetWebService.SmsQuery();
                MSG.Text = "�� " + i.ToString() + "�����š�";
            }
            catch (Exception ex)
            {
                log.Error("��ѯ����������", ex);
                MSG.Text = "��ѯ���������� " + ex.Message;
            }
            Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");
        }
        protected void submit_changepw(object sender, System.EventArgs e)
        {
            if (PasswordNew.Text.Equals(PasswordNewRepeat.Text))
            {
                try
                {
                    //��������
                    bool bSuccessed = InternetWebService.SmsChangePassword(PasswordNew.Text);
                    log.Info("���Ķ�������ɹ���");
                    MSG_Password.Text = "���Ķ�������ɹ������޸Ķ�Ӧ�������ļ���";

                }
                catch (Exception ex)
                {
                    log.Error("���Ķ����������", ex);
                    MSG_Password.Text = "���Ķ���������� " + ex.Message;
                }
                Response.Write("<script>javascript:alert('" + MSG_Password.Text + "');</script>");
            }
        }
        protected void submit_all(object sender, System.EventArgs e)
        {

            bulkSms(ContentEditor.Value, false, false);
        }
        protected void submit_shanghai(object sender, System.EventArgs e)
        {

            bulkSms(ContentEditor.Value, true, false);
        }
        protected void submit_spec(object sender, System.EventArgs e)
        {

            bulkSms(ContentEditor.Value, true, true);
        }



        //֪ͨ��ѯ��
        private void bulkSms(string notice, bool isOnlyShanghai, bool isOnlyTest)
        {
            notice = UtilHtml.RemoveHtmlTag(UtilHtml.RemoveEnterBreak(notice));

            if (string.IsNullOrEmpty(notice) || notice.Length > Total.MaxSmsMsgSize)
            {
                MSG.Text = "�������ݲ���Ϊ�գ�Ҳ���ܳ���" + Total.MaxSmsMsgSize.ToString() + "�֣�";
                Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");
                return;
            }



            List<string> mobileCodeList = new List<string>();

            if (isOnlyTest)
            {
                string[] specMobileArray = SpecMobileSend.Text.Trim().Split(',');
                foreach (string specMobile in specMobileArray)
                {
                    if (!string.IsNullOrEmpty(specMobile))
                        mobileCodeList.Add(specMobile);
                }
            }
            else
            {
                List<Client> clientList = ServiceFactory.GetClientService().GetAllClients(isOnlyShanghai);
                foreach (Client client in clientList)
                {
                    if (client.status == ClientStatus.SMS_ENABLED)
                        mobileCodeList.Add(client.mobile_code);
                }

                if (!mobileCodeList.Contains(MyMobileCode))
                    mobileCodeList.Insert(0, MyMobileCode);

                if (!mobileCodeList.Contains(MyMobileCode2))
                    mobileCodeList.Add(MyMobileCode2);


            }

            int iSuccess = 0;
            try
            {
                //���Ͷ���              
                iSuccess = InternetWebService.SmsSend(notice, mobileCodeList);

                MSG.Text = "���Ͷ�����ɣ� " + iSuccess.ToString() + "/" + mobileCodeList.Count.ToString();
                log.Info(MSG.Text);

            }
            catch (Exception ex)
            {
                log.Error("Ⱥ�����ų���", ex);
                MSG.Text = "Ⱥ�����ų��� " + ex.Message;
            }


            Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");
        }

    }
}
