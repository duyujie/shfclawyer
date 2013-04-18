<%@ Page Language="c#" Inherits="com.hujun64.news_show" CodeFile="news_show.aspx.cs"
    CodeFileBaseClass="com.hujun64.PageBase" EnableViewState="false" %>

<%@ Register TagPrefix="uc1" TagName="header" Src="ascx/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top" Src="ascx/top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="right" Src="ascx/right.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="ascx/footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="track" Src="ascx/track.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Language" content="zh-cn">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="keywords" content="<%= articleKeywords +"|"+Total.Keywords%>">
    <meta name="description" content="<% = metaDescription +""%>"> 
    <uc1:header ID="header1" runat="server"></uc1:header>
    <title>
        <%=  title + "_" + Total.Title%></title>

</head>
<body>
    <form id="bodyForm" runat="server">
    <div align="center">
        <uc1:top ID="top" runat="server"></uc1:top>
        <div style="width: 960px; height: 100%; padding-top: 10px;">
            <asp:Repeater ID="RepeaterNews" runat="server">
                <ItemTemplate>
                    <div style="float: left; width: 700px" >
                        <div class="ModuleTitle" height="40" align="left" style="margin-bottom:5px">
                            <strong><a href="listitem.aspx?class_name=<%=moduleClassName %>">
                                <%=moduleClassName %></a></strong>
                        </div>
                        <div style="height: 40px; text-align: center; color: blue">
                            <h2 style="line-height: 120%">
                                <strong>
                                    <%#Eval("title")%></strong></h2>
                        </div>
                        <div>
                            <%=picUrl %>
                        </div>
                        <div align="left" style="padding-top: 20px; background-image: url(Images/ShortLine.jpg); background-repeat: no-repeat;">
                            <%#Eval("content")%>
                        </div>
                    </div>
                    <div style="float: left">
                        <uc1:right ID="right" runat="server"></uc1:right>
                    </div>
                    </td>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <uc1:footer ID="footer" runat="server" />
    </form>
</body>
</html>
