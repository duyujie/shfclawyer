using System;
using System.Data;
using com.hujun64.logic;
namespace com.hujun64
{
    
    public partial class sitemap : System.Web.UI.UserControl
    {

      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                repeaterMenuRoot.DataSource = ServiceFactory.GetMainClassService().GetDropMenuClassByBoot(0, Total.SiteId);
                repeaterMenuRoot.DataBind();
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
           // repeaterMenuRoot.ItemDataBound += new RepeaterItemEventHandler(repeaterMenuRoot_ItemDataBound);
        }
        #endregion

       
    }
}