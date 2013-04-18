<%@ Page Language="C#" AutoEventWireup="true" CodeFile="linkapp.aspx.cs" Inherits="com.hujun64.linkapp"
    EnableViewState="false" EnableViewStateMac="false" %>

<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="ascx/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top" Src="ascx/top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="right" Src="ascx/right.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="ascx/footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="track" Src="ascx/track.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<!--head区开始位置-->
<head id="Head1" runat="server">
	<meta http-equiv="Content-Language" content="zh-cn">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <link type="text/css" href="css/style.css" rel="stylesheet" />
    <uc1:header ID="header1" runat="server"></uc1:header>
</head>
<!--head区结束--位置-->
<body>
    <form id="bodyForm" runat="server">
    <div align="center">
        <table border="0" width="100%" id="table1" cellspacing="0" cellpadding="0">
            <uc1:top ID="top" runat="server"></uc1:top>
            <tr>
                <td background="images/Header2.jpg" style="background-repeat: repeat-x; background-position: top"
                    height="800" valign="top">
                    <div align="center">
                        <table border="0" cellpadding="0" cellspacing="0" width="950" id="table4" height="100%">
                            <tr>
                                <td valign="top" bgcolor="FFFFFF" id="TheLongLine" style="padding-top: 10px;">
                                    <div align="center">
                                        <table border="0" cellpadding="0" cellspacing="0" width="940" id="table10" height="100%">
                                            <tr>
                                                
                                                <td valign="top" style="padding-top: 10px;" align="left">
                                                    <table align="left" cellspacing="0" rules="all" class="frameLinkAppTable">
                                                        <tbody>
                                                            <tr>
                                                                <td style="line-height: 180%;" width="100%" height="38" colspan="3">
                                                                    <table>
                                                                        <tr>
                                                                            <td width="600" align="center">
                                                                                <h3>
                                                                                    本站信息</h3>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table border="0" width="98%" align="center">
                                                                        <tr>
                                                                            <td width="65%" style="line-height: 150%" height="26">
                                                                                本站名称：<font color="blue"><%=Total.SiteName%></font>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="65%" style="line-height: 150%" height="26">
                                                                                本站地址：<font color="blue"><%=Total.SiteUrl%></font>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" style="line-height: 150%" height="26" colspan="2">
                                                                                本站LOGO：<%=UtilHtml.BuildHref(Total.SiteUrl, UtilHtml.GetFullImageUrl(Total.LinkLogo, Total.Title), Total.Title, true)%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" style="line-height: 150%" height="26" colspan="2">
                                                                                本站说明：<font color="blue"><%=Total.Description%></font>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                        <tbody>
                                                            <tr>
                                                                <td colspan="3" height="60px">
                                                                    <div style="margin-left: 1em; color: Red">
                                                                        <%=applyNotice%></div>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                        <tbody>
                                                            <tr>
                                                                <td width="100%" height="30" align="center" colspan="2">
                                                                    <b>请认真填写您需要提交的网站信息</b>（带<font color="#FF3300">*</font>号的项目必填）
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                        <tbody>
                                                            <tr>
                                                                <td width="18%" height="25" align="right">
                                                                    贵站上显示&nbsp;<br />
                                                                    本站的页面<font color="red">*</font>
                                                                </td>
                                                                <td width="82%" height="25">
                                                                    <asp:TextBox ID="myUrl" runat="server" Width="300px" MaxLength="100" ToolTip="您的网站上显示有本站链接的地址，请尽量先做好本站的链接"
                                                                        ForeColor="#FF3300">http://www.</asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="validMyUrl" runat="server" ControlToValidate="myUrl"
                                                                        Display="dynamic" SetFocusOnError="true">本站链接</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                        <tbody>
                                                            <tr>
                                                                <td width="18%" height="25" align="right">
                                                                    网站名称<font color="red">*</font>
                                                                </td>
                                                                <td width="82%" height="25">
                                                                    <asp:TextBox ID="siteName" runat="server" Width="300px" MaxLength="30" ForeColor="#FF3300"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="siteName"
                                                                        Display="dynamic" SetFocusOnError="true">网站名称不能为空</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                        <tbody>
                                                            <tr>
                                                                <td width="18%" height="25" align="right">
                                                                    验证码<font color="red">*</font>
                                                                </td>
                                                                <td>
                                                                    <img alt="" src="admin/ValidateCode.aspx">
                                                                    <asp:TextBox ID="txtValidateCode" runat="server" Width="40px" MaxLength="4" ToolTip="请填写左侧四位一组的验证码！"
                                                                        onkeyup="value=value.replace(/[^0-9_]/ig, '')" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtValidateCode"
                                                                        Display="dynamic" SetFocusOnError="true">验证码不能为空</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                        <tbody>
                                                            <tr>
                                                                <td width="18%" height="25" align="right">
                                                                    网站地址<font color="red">*</font>
                                                                </td>
                                                                <td width="82%" height="25">
                                                                    <asp:TextBox ID="siteUrl" runat="server" Width="300px" MaxLength="100" ForeColor="#FF3300">http://www.</asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="siteUrl"
                                                                        Display="dynamic" SetFocusOnError="true">网站地址不能为空</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                        <tbody>
                                                            <tr>
                                                                <td width="18%" height="25" align="right">
                                                                    LOGO地址
                                                                </td>
                                                                <td width="82%" height="25">
                                                                    <asp:TextBox ID="siteLogoUrl" runat="server" Width="300px" MaxLength="100" ForeColor="#FF3300"
                                                                        ToolTip="您要提交的网站的LOGO地址，有请尽量填写！"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                        <tbody>
                                                            <tr>
                                                                <td width="18%" height="25" align="right" valign="top">
                                                                    网站说明<font color="red">*</font>
                                                                </td>
                                                                <td width="100%" height="25">
                                                                    <asp:TextBox ID="siteDesc" runat="server" Width="300px" TextMode="MultiLine" Height="120px"
                                                                        MaxLength="2000"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="siteDesc"
                                                                        Display="dynamic" SetFocusOnError="true">网站说明不能为空</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                        <tbody>
                                                            <tr>
                                                                <td width="18%" height="25" align="right" valign="top">
                                                                </td>
                                                                <td width="100%" height="25" align="left">
                                                                    <asp:Button ID="submit_button" runat="server" Text="提 交" ForeColor="Red" OnClick="submit_Click"
                                                                        ToolTip="点击提交您的链接申请"></asp:Button>
                                                                    <asp:Button ID="reset_button" runat="server" Text="重 置" OnClick="reset_Click" ToolTip="点击重置您的链接申请">
                                                                    </asp:Button>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                        <tbody>
                                                            <tr>
                                                                <td width="18%" height="25" align="right" valign="top">
                                                                    <font color="silver">提示信息</font>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:Label ID="MSG" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                                <td width="327" valign="top" style="padding-top: 10px;">
                                                    <uc1:right ID="right" runat="server"></uc1:right>
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
    </td> </tr> </table>
    <uc1:footer ID="footer" runat="server" />
    </form>
</body>
</html>