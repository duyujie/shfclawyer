<%@ Control Language="C#" AutoEventWireup="true" Inherits="com.hujun64.footer" CodeFile="footer.ascx.cs" %>
<%@ Register TagPrefix="uc1" TagName="track" Src="track.ascx" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%" id="table1" style="margin-top: 10px">
    <tr>
        <td height="200" valign="top">
            <div align="center" class="Content">
                <table border="0" cellpadding="4" cellspacing="0" id="table2">
                    <tr>
                        <td width="200px" class="ModuleTitle">
                            <strong>�Ե绰��ʽ��ϵ����</strong>
                        </td>
                        <td width="200px" class="ModuleTitle">
                            <a href="guestask.aspx"><strong><font color="blue">������ѯ���ɹ��� </font></strong></a>
                        </td>
                    </tr>
                    <tr>
                        <td width="180px">
                            <div align="center">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%" id="table3">
                                    <tr>
                                        <td valign="top">
                                            ������з����������⣬��ҪԤԼ��̸���벦����ѯ�绰����վ������ʦ���ڵ�һʱ��Ϊ������������⣬�����Ż��
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <b>��ϵ�绰��</b><span style="font-size: 16px;"><strong>13636542941</strong></span><br>
                                            <b>E-Mail�� &nbsp; </b>hujun64@gmail.com
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
                                            ��������ѡ������������ѯ�ķ�ʽ��ԤԼ��ϯ��ʦ����ѯ������չ��������ί����ʦ���߹�ͨ��
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="ModuleTitle" width="902" colspan="3">
                            <br />
                            <strong>��������</strong>
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
                          &nbsp;&nbsp;&nbsp;  <a href="linkapp.aspx" target="_blank" class="more">������������&gt;&gt;</a>
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
                    ��ϵ��ַ���Ϻ���բ�������·500���޼���������16¥<br />
                    <%--ӯ��(�Ϻ�)��ʦ������<br />--%>
                    �����ţ���ICP��09011496��</p>
            </div>
        </td>
    </tr>
</table>
<div align="center">
    <uc1:track ID="track" runat="server"></uc1:track>
</div>
