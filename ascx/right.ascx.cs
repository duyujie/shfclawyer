using System;
using System.Data;

using com.hujun64.logic;

namespace com.hujun64
{
    
    /// <summary>
    ///	����֪ʶ
    /// </summary>
    public partial class right : System.Web.UI.UserControl
    {
        
        private IGuestbookService guestbookService = ServiceFactory.GetGuestbookService();

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            { 
                RepeaterGuestbook.DataSource = guestbookService.GetTopGuestbookList("", 12);
                RepeaterGuestbook.DataBind();
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
        ///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
        ///		�޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}
