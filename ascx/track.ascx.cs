using System;


namespace com.hujun64
{


    public partial class track : System.Web.UI.UserControl
    {
       

        protected string statUrl = Total.AspxUrlStat + "?" + Total.QueryStringReferrer + "=";
        protected void Page_Load(object sender, System.EventArgs e)
        {


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
        ///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
        ///		�޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            // repeaterMenuRoot.ItemDataBound += new RepeaterItemEventHandler(repeaterMenuRoot_ItemDataBound);
        }
        #endregion


    }
}