using System;
using com.hujun64.logic;
using com.hujun64.type;
using com.hujun64.util;

namespace com.hujun64
{
    
    /// <summary>
    ///		stat ��ժҪ˵����
    /// </summary>
    public partial class statclick : PageBase
    {
       
        protected int clickTimes=1;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                    
           
                PageInfo pageInfo = UtilHtml.GetPageInfoOfRequet(Request);
            
                AsyncTaskService.VisitPageAsync(pageInfo);    
            }
            catch (Exception)
            {

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
