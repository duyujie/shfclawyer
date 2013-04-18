<%@ Page Language="c#" Inherits="com.hujun64.admin.link_manage" CodeFile="link_manage.aspx.cs"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD html 4.0 Transitional//EN" >
<link href="../css/style.css" rel="stylesheet" rev="stylesheet" type="text/css" />
<html>
<head>
    <title>���Թ���</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta name="robots" content="noindex,follow"/>
</head>
<body>
    <form id="FormAsk" method="post" runat="server">
    <font face="����">
        <table id="Table1" cellspacing="0" cellpadding="0" width="800" align="center" border="1">
            
            <tr>
                <td colspan="3">
                    <h2>
                        �������ӹ���</h2>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:DataGrid ID="DataGridTitle" runat="server" Width="752px" AutoGenerateColumns="False"
                        DataKeyField="id" OnSelectedIndexChanged="DataGrid1_SelectedIndexChanged" OnItemCommand="DataGrid1_SortCommand" HeaderStyle-Font-Bold="true">
                        <Columns>
                            <asp:BoundColumn Visible="False" DataField="id"></asp:BoundColumn>
                            <asp:BoundColumn DataField="site_name" HeaderText="��վ����"></asp:BoundColumn>                                           
                            <asp:BoundColumn DataField="addtime" HeaderText="����ʱ��"></asp:BoundColumn>
                            <asp:BoundColumn DataField="status" HeaderText="���״̬"></asp:BoundColumn>
                            <asp:BoundColumn DataField="approve_time" HeaderText="���ʱ��"></asp:BoundColumn>
                            <asp:ButtonColumn Text="ѡ��" HeaderText="�鿴" CommandName="Select"></asp:ButtonColumn>
                            <asp:ButtonColumn Text="ɾ��" HeaderText="ɾ��" CommandName="Delete"></asp:ButtonColumn>
                            <asp:ButtonColumn Text="����" HeaderText="����" CommandName="SortUp"></asp:ButtonColumn>
                            <asp:ButtonColumn Text="����" HeaderText="����" CommandName="SortDown"></asp:ButtonColumn>
                        </Columns>
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
        <p>
        </p>
        <p>
        </p>
        <table id="Table2" cellspacing="0" cellpadding="0" width="800" align="center" border="1">
            <tr>
                <td colspan="3" style="color: #CC3300; font-weight: bold;">
                    <h2>
                        �Ѻ���������</h2>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="linkApprove">
                    ��վ�ڸ�վ��ַ
                </td>
                <td>
                    <asp:HiddenField ID="linkId" runat="server" />
                    <asp:Label ID="my_url" runat="server"></asp:Label>
                    &nbsp; -><asp:TextBox ID="my_url_edit" runat="server" Width="500px"> </asp:TextBox>
                </td>
            </tr>
            <tr>
            <td colspan="2" class="linkApprove">
                ��վ����
            </td>
            <td>
                <asp:Label ID="site_name" runat="server"></asp:Label>
                &nbsp; -><asp:TextBox ID="site_name_edit" runat="server" Width="500px"> </asp:TextBox>
            </td>
            </tr>
            <tr>
                <td colspan="2" class="linkApprove">
                    <span class="linkApprove">��վ��ַ</span>
                </td>
                <td>
                    <asp:TextBox ID="site_url_edit" runat="server" Width="500px"></asp:TextBox>                    
                </td>
            </tr>
            <tr>
                <td colspan="2" class="linkApprove">
                    <span class="linkApprove">��վlogo</span>
                </td>
                <td>
                    <asp:Label ID="site_logo" runat="server"></asp:Label>
                    &nbsp; -><asp:TextBox ID="site_logo_edit" runat="server" Width="500px"> </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="80px" colspan="2" class="linkApprove">
                    ��վ����
                </td>
                <td height="80px">
                    <asp:TextBox ID="site_desc" runat="server" Width="500px" Height="80px"  TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td  colspan="2" class="linkApprove">
                    ����ʱ��
                </td>
                <td>
                    <asp:Label ID="addtime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  colspan="2" class="linkApprove">
                    ���״̬
                </td>
                <td>
                    <asp:Label ID="status" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  colspan="2" class="linkApprove">
                    ���ʱ��
                </td>
                <td>
                    <asp:Label ID="approve_time" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="approve_button" runat="server" Text="���ͨ��" ForeColor="Green" Width="100px"
                        Height="30px" Font-Bold="true" Font-Size="14px" OnClick="approve_Click"  ></asp:Button>
                </td>
                <td colspan="2">
                    <asp:Button ID="reject_button" runat="server" Text="��˾ܾ�" ForeColor="Red" Width="100px"
                        Height="30px" Font-Bold="true" Font-Size="14px" OnClick="reject_Click"  ></asp:Button>
                </td>
                </tr>
                <tr>
                <td colspan="2">
                    <asp:Button ID="update_button" runat="server" Text="��������" ForeColor="Blue" Width="100px"
                        Height="30px" Font-Bold="true" Font-Size="14px" OnClick="update_Click" ></asp:Button>
                </td>
            </tr>
            <tr>
                <td class="linkApprove" colspan="2">
                </td>
                <td>
                    <asp:Label ID="MSG" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </font>
    </form>
</body>
</html>
