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
    /// add_art ��ժҪ˵����
    /// </summary>
    public partial class add_cgw : AdminPageBase
    {
        private ICgwService cgwService = ServiceFactory.GetCgwService();



        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!IsPostBack)
            {
                getCgwWordsList();
            }

        }
        protected void submit_Click(object sender, System.EventArgs e)
        {


            if (string.IsNullOrEmpty(TextBoxOriginalWords.Text.Trim()) || string.IsNullOrEmpty(TextBoxNewWords.Text.Trim()))
            {
                MSG.Text = "���дʺ�����ʲ���Ϊ�գ�";

            }
            else
            {
                CgwWords words = new CgwWords();
                words.original_words = TextBoxOriginalWords.Text.Trim();
                words.new_words = TextBoxNewWords.Text.Trim();

                int i = cgwService.InsertOrUpdateCgwWords(words);
                MSG.Text = i.ToString() + "����¼�����£�";
                cgwService.RefreshCacheCgw();
                getCgwWordsList();
            }


            Response.Write("<script>javascript:alert('" + MSG.Text + "');</script>");

        }
        private void getCgwWordsList()
        {
            List<CgwWords> cgwWordsList= cgwService.GetAllWordsList();

            StringBuilder sb = new StringBuilder();
            foreach (CgwWords words in cgwWordsList)
            {
                sb.AppendFormat("<div>{0} : {1} - {2}</div>", words.id, words.original_words, words.new_words);
            }
            ContentEditor.Text = sb.ToString();
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
