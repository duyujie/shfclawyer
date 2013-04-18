using System;
using com.hujun64.util;
using com.hujun64.type;
namespace com.hujun64
{
    /// <summary>
    /// add_art ��ժҪ˵����
    /// </summary>
    public partial class asynctask_page : PageBase
    {


        protected void Page_Load(object sender, System.EventArgs e)
        {

            //���ձ��ط�����ͨ��urlֱ�ӹ�������վҳ���������
            if (!Request.UserHostAddress.Equals("127.0.0.1") && !Total.ServerIpList.Contains(Request.UserHostAddress))
            {
                log4net.LogManager.GetLogger("AsyncTaskPage").Warn("�Ƿ�������ַ("+Request.UserHostAddress+")�ύ�����ڷǷ����첽��������");
                return;
            }

            string action = Request.Form[Total.QueryStringAction];
            try
            {

                if (action != null && action.Equals(AsyncTaskActionType.UPDATE_SITE.ToString()))
                {
                    //������վҳ��
                    string refreshQueryString = Request.Form[Total.QueryStringRefreshType];

                    if (!string.IsNullOrEmpty(refreshQueryString))
                    {
                        log4net.LogManager.GetLogger("AsyncTaskPage").Info("��ʼ����ҳ�����ݸ���-�첽");
                        UtilStatic aspx2Html = UtilStatic.GetInstance();
                        aspx2Html.ConvertAll(refreshQueryString);

                        return;
                    }
                }


            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger(this.ToString()).Error("��̨�첽�������", ex);
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
