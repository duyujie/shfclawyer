<%@ Page language="c#" Inherits="com.hujun64.admin.pass_change" CodeFile="pass_change.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�������</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="robots" content="noindex,follow"/>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table id="Table1" style="Z-INDEX: 101; LEFT: 176px; WIDTH: 474px; POSITION: absolute; TOP: 80px; HEIGHT: 178px"
					cellSpacing="1" cellPadding="1" width="474" border="1">
					<tr>
						<td style="HEIGHT: 20px" colSpan="3">�޸Ĺ���Ա����</td>
					</tr>
					<tr>
						<td>�����룺</td>
						<td>
							<asp:TextBox TextMode="Password" id="PasswordOld" runat="server"></asp:TextBox></td>
						<td>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="�������룡" ControlToValidate="PasswordOld"></asp:RequiredFieldValidator></td>
					</tr>
					<tr>
						<td>�����룺</td>
						<td>
							<asp:TextBox TextMode="Password" id="PasswordNew" runat="server"></asp:TextBox></td>
						<td>
							<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="�������룡" ControlToValidate="PasswordNew"></asp:RequiredFieldValidator></td>
					</tr>
					<tr>
						<td style="HEIGHT: 25px">�ظ���</td>
						<td style="HEIGHT: 25px">
							<asp:TextBox TextMode="Password" id="PasswordNewRepeat" runat="server"></asp:TextBox></td>
						<td style="HEIGHT: 25px">
							<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="2�����벻һ�£�" ControlToValidate="PasswordNewRepeat"
								ControlToCompare="PasswordNew"></asp:CompareValidator></td>
					</tr>
					<tr>
						<td colSpan="3">
							<asp:Button id="Button1" runat="server" Text="�޸�" onclick="Button1_Click"></asp:Button>
							<asp:Label id="MSG" runat="server" ForeColor="Red"></asp:Label></td>
					</tr>
				</table>
			
		</form>
	</body>
</HTML>
