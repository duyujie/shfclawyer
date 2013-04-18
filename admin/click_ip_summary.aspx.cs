using System;
using System.Data;
using com.hujun64.logic;
namespace com.hujun64.admin
{
    /// <summary>
    /// visited_history ��ժҪ˵����
    /// </summary>
    public partial class click_ip_summary : AdminPageBase
    {
        private IClientService clientService = ServiceFactory.GetClientService();
        private int defaultPeriodDays = 0, defaultTopRows = 50;
       


        protected void Page_Load(object sender, System.EventArgs e)
        {


            if (!IsPostBack)
            {
                dateTo.Text = DateTime.Today.ToString("yyyy-MM-dd");
                dateFrom.Text = DateTime.Today.AddDays(-defaultPeriodDays).ToString("yyyy-MM-dd");

                topRows.Text = defaultTopRows.ToString();
             

                listBind();
            }

        }
        protected void submit_Click(object sender, System.EventArgs e)
        {
            listBind();
        }
        private void listBind()
        {
            DateTime summaryDateFrom = DateTime.Parse(dateFrom.Text);
            DateTime summaryDateTo = DateTime.Parse(dateTo.Text);
            ClickIpSummary clickSummary = clientService.SummaryClickIp(summaryDateFrom, summaryDateTo);
            LabelClick.Text = clickSummary.click.ToString();
            LabelIp.Text = clickSummary.ip.ToString();
            LabelIpShanghai.Text = clickSummary.ip_shanghai.ToString();

            DataSet ds = clientService.SummaryClickSource(summaryDateFrom, summaryDateTo, Convert.ToInt32(topRows.Text));
            listDGD.DataSource = ds;
            listDGD.DataBind();

        }



        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            listBind();
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
