using System;

namespace com.hujun64
{
    /// <summary>
    /// PageBase ��ժҪ˵����
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        
        protected void PageBase_Error(object sender, System.EventArgs e)
        {
            string errMsg;
            //�õ�ϵͳ��һ���쳣
            Exception currentError = Server.GetLastError();      
      
            log4net.ILog log = log4net.LogManager.GetLogger(this.ToString());
            log.Error("ҳ���쳣��", currentError);


            errMsg = "<h1>ҳ�����</h1><hr/>��ҳ�淢��һ��������󣬶Դ����Ƿǳ���Ǹ��" +
                "�˴�����Ϣ�ѷ��͸�ϵͳ����Ա���뼰ʱ��ϵ���ǣ����ǻἰʱ��������⣡ <br/>" +
                "������λ�ã� " + Request.Url.ToString() + "<br/>" +
                "������Ϣ�� <font class=\"ErrorMessage\">" + currentError.Message.ToString() + "</font><hr/>" +
                "<b>Stack Trace:</b><br/>" +
                currentError.ToString();

            Session["err"] = errMsg;
            //�����������Ӧ�ó������
            if (!(currentError is ApplicationException))
            {
                //��Windows�¼���־��д�������־
                //LogEvent( currentError.ToString(), EventLogEntryType.Error );
            }
            //��ҳ������ʾ����
            //Response.Write( errMsg );
            
            Response.Redirect(com.hujun64.Total.ErrorPage);
            //����쳣
            Server.ClearError();
        }


        private void PageBase_Load(object sender, System.EventArgs e)
        {

        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Error += new System.EventHandler(this.PageBase_Error);
            base.Load += new EventHandler(this.PageBase_Load);
        }

    }
}
