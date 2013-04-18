<%@ Page Language="c#" Inherits="com.hujun64.admin.visited_history" CodeFile="visited_history.aspx.cs" %>

<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>��������̨��־</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta name="robots" content="noindex,follow" />
</head>
<body>
    <form id="logForm" runat="server">
    <table id="Table1" cellspacing="0" cellpadding="0" width="100%" align="center" border="1">
        <tbody>
            <tr>
                <td>
                    Date:
                    <asp:TextBox ID="logDateQuery" runat="server" AutoPostBack="True" OnTextChanged="queryDate_Changed"
                        MaxLength="10" Width="100px" />
                    
                    <br />
                </td>
            </tr>
        </tbody>
        <tbody>
            <tr>
                <td>
                    <asp:DataGrid ID="listDGD" runat="server" Width="100%" AutoGenerateColumns="False"
                        DataKeyField="id" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center">
                        <Columns>
                            <asp:BoundColumn DataField="id" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="visited_time" HeaderText="visited_time" DataFormatString="{0:MM-dd HH:mm:ss}"
                                ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ip_province" HeaderText="ip_province" ItemStyle-Width="200px">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="page_class" HeaderText="page_class" ItemStyle-Width="50px">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="page_id" HeaderText="page_id" ItemStyle-Width="50px">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="page_title" HeaderText="page_title"></asp:BoundColumn>
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
