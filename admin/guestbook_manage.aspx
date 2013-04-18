<%@ Page Language="c#" Inherits="com.hujun64.admin.guestbook_manage" CodeFile="guestbook_manage.aspx.cs"
    ValidateRequest="false" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
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
    
        <table id="Table1" cellspacing="0" cellpadding="0" width="1100" align="center" border="1">
            
            <tbody>
                <tr>
                    <td colspan="3">
                        <h2>
                            ���Թ���</h2>
                    </td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td colspan="3">
                        <asp:DataGrid ID="DataGridTitle" runat="server" Width="100%" AutoGenerateColumns="False"
                            DataKeyField="id" OnSelectedIndexChanged="DataGrid1_SelectedIndexChanged" HeaderStyle-Font-Bold="true">
                            <Columns>
                                <asp:BoundColumn  DataField="id" HeaderText="ID" ItemStyle-ForeColor="Blue"></asp:BoundColumn>
                                <asp:BoundColumn DataField="title" HeaderText="����"></asp:BoundColumn>                                
                                <asp:BoundColumn DataField="author" HeaderText="��ѯ��" ItemStyle-Width="100px"></asp:BoundColumn>
                                <asp:BoundColumn DataField="province_from" HeaderText="����" ItemStyle-Width="150px">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="sex" HeaderText="�Ա�" ItemStyle-Width="30px"></asp:BoundColumn>
                                <asp:BoundColumn DataField="addtime" HeaderText="��ѯʱ��" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                    ItemStyle-Width="100px" ItemStyle-Wrap="false"></asp:BoundColumn>
                                <asp:BoundColumn DataField="is_replied" HeaderText="�ظ�" ItemStyle-Width="30px"></asp:BoundColumn>
                                <asp:ButtonColumn Text="ѡ��" HeaderText="�鿴" CommandName="Select" ItemStyle-Width="30px">
                                </asp:ButtonColumn>
                                <asp:ButtonColumn Text="ɾ��" CommandName="Delete" ItemStyle-Width="30px"></asp:ButtonColumn>
                            </Columns>
                        </asp:DataGrid>
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
        <table align="center" >
        <tbody>
            <tr valign="top">
                <td>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                        CurrentPageButtonPosition="Center" CustomInfoHTML="��%CurrentPageIndex%ҳ����%PageCount%ҳ��ÿҳ%PageSize%��"
                        FirstPageText="��ҳ" LastPageText="βҳ" LayoutType="Table" NextPageText="��һҳ" PageIndexBoxType="DropDownList"
                        PagingButtonLayoutType="Span" PrevPageText="��һҳ" ShowCustomInfoSection="Left"
                        SubmitButtonText="Go" TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��" UrlPaging="true">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </tbody>
    </table>
        <table id="Table2" cellspacing="0" cellpadding="0" width="800" align="left" border="1">
            <tbody>
                <tr>
                    <td colspan="3" style="color: #CC3300; font-weight: bold;">
                        <h2>
                            ��������</h2>
                    </td>
                </tr>
            </tbody>
             <tbody>
                <tr>
                    <td align="right"  class="guestreply">
                        ID
                    </td>
                    <td>
                        <asp:Label ID="LaebelSelectedId" runat="server" Width="50px" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
            </tbody>
          
            <tbody>
                <tr>
                    <td align="right" class="guestreply">
                        ����
                    </td>
                    <td>
                        <asp:HiddenField ID="guestId" runat="server" />
                        <asp:TextBox ID="guesttitle" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td align="right"  class="guestreply">
                        <span class="guestreply">��ѯ��</span>
                    </td>
                    <td>
                        <asp:Label ID="author" runat="server"></asp:Label>
                    </td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td align="right" class="guestreply">
                        <span class="guestreply">�Ա�</span>
                    </td>
                    <td>
                        <asp:Label ID="sex" runat="server"></asp:Label>
                    </td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td align="right"  class="guestreply">
                        ��ϵ��ʽ
                    </td>
                    <td>
                        <asp:Label ID="contact" runat="server"></asp:Label>
                    </td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td align="right"  class="guestreply">
                        �ʼ���ַ
                    </td>
                    <td>
                        <asp:Label ID="email" runat="server"></asp:Label>
                    </td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td align="right"  class="guestreply">
                        ����ʱ��
                    </td>
                    <td>
                        <asp:Label ID="addtime" runat="server"></asp:Label>
                    </td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td align="right"  class="guestreply">
                        ��ѯ�ߵ���
                    </td>
                    <td>
                        <asp:Label ID="ipProvince" runat="server"></asp:Label>
                    </td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td align="right" height="120"  class="guestreply">
                        ����
                    </td>
                    <td height="120">
                        <asp:TextBox ID="content" runat="server" Width="100%" Height="120" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td align="right"  class="guestreply">
                        <span class="guestreply">�ؼ��ʻ�</span>
                    </td>
                    <td>
                        <asp:TextBox ID="keywords" runat="server" Width="100%" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td align="right" height="150" class="guestreply">
                        �ظ�
                    </td>
                    <td height="150">
                        <asp:TextBox ID="reply" runat="server" TextMode="MultiLine" Width="100%" Height="150" />
                    </td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td align="right" class="guestreply">
                        �ظ�ʱ��
                    </td>
                    <td>
                        <asp:Label ID="replytime" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td align="right">
                        <asp:Button ID="reply_button" runat="server" Text="�ύ�ظ�"  ForeColor="Blue"  Font-Bold="true"
                            Font-Size="Medium" OnClick="reply_Click"></asp:Button>
                    </td>
                    <td>
                        <asp:CheckBox ID="email_guest_check" Checked="true" runat="server" />�Զ��ʼ�֪ͨ��ѯ��
                    </td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                <td align="right" class="guestreply">
                        ��Ϣ
                    </td>
                    <td >                    
                        <asp:Label ID="MSG" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
    
    </form>
</body>


</html>
