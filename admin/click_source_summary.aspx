<%@ Page Language="c#" Inherits="com.hujun64.admin.click_source_summary" CodeFile="click_source_summary.aspx.cs" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>��������̨��־</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta name="robots" content="noindex,follow"/>
</head>
<body>
    <form id="logForm" runat="server">
    <table id="TablePageSummay" cellspacing="0" cellpadding="0" width="75%" align="left" border="1">
        <tbody>
            <tr>
               <%-- <td>
                    ͳ���������
                    <asp:TextBox ID="days" runat="server" Width="30px" onkeyup="value=value.replace(/[^0-9_]/ig, '')"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="days"
                        Display="dynamic" SetFocusOnError="true">ͳ����������Ϊ��</asp:RequiredFieldValidator>
                   
                    <asp:Button ID="submit_button" runat="server" Text="�ύ"  ForeColor="Blue" OnClick="submit_Click"></asp:Button>
                </td>--%>
                <td>
                    ͳ������
                    <asp:TextBox ID="dateFrom" runat="server" Width="100px"></asp:TextBox>
                   <asp:TextBox ID="dateTo" runat="server" Width="100px"></asp:TextBox>
                   
                    <asp:Button ID="submit_button" runat="server" Text="�ύ"  ForeColor="Blue" OnClick="submit_Click"></asp:Button>
                </td>
            </tr>
        </tbody>
        <tbody>
            <tr>
                <td>
                   <br />
                </td>
            </tr>
        </tbody>
        <tbody>
            <tr>
                <td>
                    ������ܼ�
                    <asp:Label ID="LabelClick" runat="server" Width="50px" ForeColor="Red" ></asp:Label>                    
                    IP���ܼ�
                    <asp:Label ID="LabelIp" runat="server" Width="50px"  ForeColor="Red"></asp:Label>
                    �Ϻ�IP���ܼ�
                    <asp:Label ID="LabelIpShanghai" runat="server" Width="50px"  ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </tbody>
        <tbody>
            <tr>
                <td colspan="3">
                    <asp:DataGrid ID="listDGD" runat="server" Width="100%" AutoGenerateColumns="False"
                        DataKeyField="click_source" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center">
                        <Columns>                            
                            <asp:BoundColumn DataField="click" HeaderText="���ʴ���" ItemStyle-Width="80px" ItemStyle-ForeColor="Red"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ip" HeaderText="����IP��" ItemStyle-Width="80px"></asp:BoundColumn>
                            <asp:BoundColumn DataField="click_source" HeaderText="������Դվ��"></asp:BoundColumn>
                            
                            
                        </Columns>
                    </asp:DataGrid>
                </td>
            </tr>
        </tbody>
    </table>
    <table align="center">
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
    </form>
    
   
</body>
</html>
