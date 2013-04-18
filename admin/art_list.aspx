<%@ Page Language="c#" Inherits="com.hujun64.admin.art_list" CodeFile="art_list.aspx.cs" %>

<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>�����б�</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <meta name="robots" content="noindex,follow" />
</head>
<body>
    <form id="ArtListForm" method="post" runat="server">
    <%--<uc1:search ID="SearchTop" runat="server"></uc1:search>--%>
    <table id="Table1" cellspacing="0" cellpadding="0" width="100%" align="center" border="1">
        
        <tbody>
            <tr>
                <td>
                    ������
                </td>
                <td>
                    <asp:DropDownList ID="moduleClassList" runat="server" AutoPostBack="True" DataTextField="class_name"
                        DataValueField="id" OnSelectedIndexChanged="moduleList_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Label ID="ignoreModuleLabel" runat="server" AutoPostBack="True" Text="����" />
                    <asp:CheckBox ID="ignoreModuleClass" runat="server" AutoPostBack="True" />
                </td>
            </tr>
        </tbody>
        <tbody>
            <tr>
                <td colspan="3">
                    <asp:DataGrid ID="newlistDGD" runat="server" Width="100%" AutoGenerateColumns="False"
                        DataKeyField="id" HeaderStyle-Font-Bold="true" OnItemCommand="newlistDGD_Command">
                        <Columns>
                            <asp:HyperLinkColumn DataNavigateUrlField="id" DataNavigateUrlFormatString="add_art.aspx?nid={0}"
                                DataTextField="title" HeaderText="����"></asp:HyperLinkColumn>
                            <asp:BoundColumn DataField="id" HeaderText="ID" ItemStyle-ForeColor="Red"></asp:BoundColumn>
                            <asp:BoundColumn DataField="addtime" HeaderText="���ʱ��" DataFormatString="{0:yyyy-MM-dd}">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ref_id" HeaderText="������" ItemStyle-ForeColor="Blue">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ref_by_list" HeaderText="������" ItemStyle-ForeColor="Blue">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="news_from" HeaderText="��Դ"></asp:BoundColumn>
                            <asp:ButtonColumn Text="ɾ��" HeaderText="ɾ��" CommandName="Delete"></asp:ButtonColumn>
                            <asp:ButtonColumn Text="����" HeaderText="����" CommandName="SortUp"></asp:ButtonColumn>
                            <asp:ButtonColumn Text="����" HeaderText="����" CommandName="SortDown"></asp:ButtonColumn>
                            <asp:ButtonColumn Text="���" HeaderText="���" CommandName="Open"></asp:ButtonColumn>
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
    <table cellspacing="0" cellpadding="0" width="60%" border="1">
        <tbody>
            <tr>
                <td colspan="3">
                    <asp:Label ID="MSG" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </tbody>
        <tbody>
            <tr>
                <td colspan="3">
                    <p>
                        <asp:Button ID="standardFormatButton" runat="server" Text="��׼��ʽ��" ForeColor="Blue"
                            Width="120px" Height="30px" Font-Bold="true" Font-Size="14px" OnClick="standardFormat_Click" />
                        &nbsp;&nbsp; ���б����������½��и�ʽ<font color="red">��׼��</font>
                    </p>
                </td>
            </tr>
        </tbody>
        <tbody>
            <tr>
                <td colspan="3">
                    <p>
                        <asp:Button ID="definedFormatButton" runat="server" Text="�Զ����ʽ��" ForeColor="Blue"
                            Width="120px" Height="30px" Font-Bold="true" Font-Size="14px" OnClick="definedFormat_Click" />
                        &nbsp;&nbsp; ���б����������½��и�ʽ<font color="red">�Զ��廯</font>
                    </p>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
