<%@ Control Language="C#" AutoEventWireup="true" Inherits="com.hujun64.footer" CodeFile="footer.ascx.cs" %>
<%@ Register TagPrefix="uc1" TagName="track" Src="track.ascx" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%" id="table1" style="margin-top: 10px">
    <tr>
        <td height="200" valign="top">
            <div align="center" class="Content">
                <table border="0" cellpadding="4" cellspacing="0" id="table2">
                    <tr>
                        <td width="200px" class="ModuleTitle">
                            <strong>以电话方式联系我们</strong>
                        </td>
                        <td width="200px" class="ModuleTitle">
                            <a href="guestask.aspx"><strong><font color="blue">在线咨询法律顾问 </font></strong></a>
                        </td>
                    </tr>
                    <tr>
                        <td width="180px">
                            <div align="center">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%" id="table3">
                                    <tr>
                                        <td valign="top">
                                            如果您有房产法律问题，或要预约面谈，请拨打咨询电话，本站房产律师会在第一时间为您解答疑难问题，并安排会晤。
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <b>联系电话：</b><span style="font-size: 16px;"><strong>13636542941</strong></span><br>
                                            <b>E-Mail： &nbsp; </b>hujun64@gmail.com
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td width="325" valign="top">
                            <div align="center">
                                <table border="0" cellpadding="0" cellspacing="0" width="320" id="table5">
                                    <tr>
                                        <td valign="top" width="200px" height="84">
                                            您还可以选择在线留言咨询的方式，预约首席律师、查询案件进展、和您的委托律师在线沟通。
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="ModuleTitle" width="902" colspan="3">
                            <br />
                            <strong>友情链接</strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="840" colspan="2" align="left">
                            <asp:Repeater ID="RepeaterLink" runat="server">
                                <ItemTemplate>
                                    &nbsp;&nbsp; <a href="<%# Eval("link_site_url") %>" title="<%# Eval("link_description") %>"
                                        target="_blank" class="myLink">
                                        <%#Eval("link_site_name")%>
                                    </a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                        <td align="right" width="120">
                          &nbsp;&nbsp;&nbsp;  <a href="linkapp.aspx" target="_blank" class="more">申请友情链接&gt;&gt;</a>
                        </td>
                    </tr>
                    
                </table>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <div class="footer w960 center mt1 clear">
                <p class="copyright">
                    Copyright@shfclawyer.com&nbsp;
                    <%=Total.SiteName %><br>
                    联系地址：上海市闸北区恒丰路500号洲际商务中心16楼<br />
                    <%--盈科(上海)律师事务所<br />--%>
                    备案号：沪ICP备09011496号</p>
            </div>
        </td>
    </tr>
</table>
<div align="center">
    <uc1:track ID="track" runat="server"></uc1:track>
</div>
