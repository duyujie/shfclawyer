using System;
using com.hujun64.util;
namespace com.hujun64.admin
{
	/// <summary>
	/// ValidateCode ��ժҪ˵����
	/// </summary>
	public partial class ValidateCode : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//���Ҫ��ҳ��a.aspx������֤�룬���ڸ�ҳ�����һ��ͼƬ�ؼ�����������Ϊ��Image1��Ȼ����page_Load�¼���д���´��룺
			//ImageButton1.ImageUrl = "ValidateCode.aspx";
			//�����Ϳ���������֤���ˣ�ValidateCode.aspxҳ������������������Ҫע��Image1.src Ҫд�ԣ�ͬ������ֱ��дValidateCode.aspx����һ��д../ValidateCode.aspx���ܷ���ɡ�

			if(!IsPostBack)
			{
				//RndNum��һ���Զ��庯��
				//���������4������ʾ����4λ����֤�ַ�����
				//string VNum=RndNum(4); 
				string VNum=Util.GenerateRandom(4);
				Session["VNum"] = VNum;
                Util.ValidateCode(VNum,Response);
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
		

	}}