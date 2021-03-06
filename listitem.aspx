﻿<%@ Page Language="c#" Inherits="com.hujun64.listitem" CodeFile="listitem.aspx.cs"
    CodeFileBaseClass="com.hujun64.PageBase" EnableViewState="false" %>

<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="ascx/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top" Src="ascx/top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="right" Src="ascx/right.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="ascx/footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="track" Src="ascx/track.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Language" content="zh-cn">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="keywords" content="<%=title+"" %>">
    <meta name="description" content="<%=title+"" %>">
    <link type="text/css" href="css/style.css" rel="stylesheet" />
    <uc1:header ID="header1" runat="server"></uc1:header>
    <title>
        <%=title + "_" + Total.Title%></title>
</head>
<body>
    <form id="bodyForm" runat="server">
    <uc1:top ID="top" runat="server"></uc1:top>
    <div class="w960 center clear mt1">
        <div class="pleft">
            <table border="0" cellpadding="0" cellspacing="0" width="950" id="table4" height="100%">
                <tr>
                    <td valign="top" bgcolor="FFFFFF" id="TheLongLine" style="padding-top: 10px;">
                        <div align="center">
                            <table border="0" cellpadding="0" cellspacing="0" width="940" id="table10" height="100%">
                                <tr>
                                    <td valign="top" style="padding-top: 10px;" align="left">
                                        <table style="width: 100%" class="Content">
                                            <tr>
                                                <td class="ModuleTitle" height="40">
                                                    <h3>
                                                        <strong>
                                                            <%=moduleClassName %></strong></h3>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 20px; background-image: url(Images/ShortLine.jpg); background-repeat: no-repeat;">
                                                    <table style="width: 100%">
                                                        <asp:Repeater ID="RepeaterArticles" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td style="width: 18px; height: 26px;">
                                                                        <img border="0" src="Images/YellowArrow.jpg" width="10" height="10">
                                                                    </td>
                                                                    <td style="width: 468px; height: 26px;">
                                                                        <a href="<%# Total.AspxUrlShowdetail %>?<%# Total.QueryStringArticleId %>=<%# Eval("id") %>"
                                                                            title="<%=pageMetaName %>_<%#UtilHtml.RemoveHtmlTag(Eval("title").ToString(),true)%>"
                                                                            target="_blank">
                                                                            <%# UtilHtml.RemoveHtmlTag(Eval("title").ToString(), true)%><%#UtilHtml.GetImageOfNewArticle(Eval("id").ToString(),(DateTime)Eval("addtime")) %>
                                                                        </a>
                                                                    </td>
                                                                    <td style="height: 26px">
                                                                        [<%# String.Format( "{0:yyyy-MM-dd}", Eval( "addtime"))%>]
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                                                        CurrentPageButtonPosition="Center" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条"
                                                        FirstPageText="首页" LastPageText="尾页" LayoutType="Table" NextPageText="下一页" PageIndexBoxType="DropDownList"
                                                        PagingButtonLayoutType="Span" PrevPageText="上一页" ShowCustomInfoSection="Left"
                                                        SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" UrlPaging="true">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <uc1:right ID="right" runat="server"></uc1:right>
    </div>
    <uc1:footer ID="footer" runat="server" />
    </form>
</body>
</html>
