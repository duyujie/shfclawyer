<%@ Control Language="c#" Inherits="com.hujun64.right" CodeFile="right.ascx.cs" %>
<%@ OutputCache Duration="60" VaryByParam="*" Shared="True" %>
<%@ Register TagPrefix="uc1" TagName="shfzb" Src="shfzb.ascx" %>
<div class="clear" style="width: 240px">
    <div class="tbox">
        <dt><strong>��վ��ʦ</strong></dt>
    </div>
    <table border="0" cellspacing="0" width="240px">
        <tr>
            <td>
                <table id="Lawyer1" style="width: 100%;">
                    <tr>
                        <td style="text-align: center;" height="200px;">
                            <div style="float: left; margin-left: 20px; margin-top: 80px; margin-right: 10px">
                                <img alt="" height="14" src="images/left-blue-arrow.gif" onclick="Lawyer1.style.display='none';Lawyer2.style.display='none';Lawyer3.style.display='block';"
                                    width="14" /></div>
                            <div style="float: left">
                                <img border="0" src="<%=Total.ImgProfileUrl %>" width="134" height="172" alt="�Ϻ����B��ʦ" />
                            </div>
                            <div style="float: left; margin-top: 80px; margin-left: 10px">
                                <img alt="" height="14" src="images/right-blue-arrow.gif" onclick="Lawyer1.style.display='none';Lawyer2.style.display='block';Lawyer3.style.display='none';"
                                    style="cursor: hand;" width="14" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="bottom">
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <font color="red">���B��ʦ</font>�ǻ���֪����ӯ��(�Ϻ�)��ʦ�������ϻ�����ʦ��ִҵ���꣬�������̳��స���������������ḻ�������ó����Ʋ��ָ������̳��йصķ������׺���Ů������˾��
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <div class="hot mt1">
                                <dl class="tbox">
                                    <dt><strong>��ϵ��ʽ</strong></dt>
                                    <dd>
                                        <ul class="c1 ico2">
                                            <p>
                                                ��ϵ�绰��021-60561339<br>
                                                ��ϵ�ֻ���13636542941<br>
                                                ��ϵ��ַ��բ�������·500���޼���������16¥
                                            </p>
                                        </ul>
                                    </dd>
                                </dl>
                            </div>
                        </td>
                    </tr>
                </table>
                <table id="Lawyer2" style="width: 100%; display: none;">
                    <tr>
                        <td style="text-align: center;" height="200px">
                            <div style="float: left; margin-left: 20px; margin-top: 80px; margin-right: 10px">
                                <img alt="" height="14" src="images/left-blue-arrow.gif" onclick="Lawyer1.style.display='block';Lawyer2.style.display='none';Lawyer3.style.display='none';"
                                    style="cursor: hand;" width="14"></div>
                            <div style="float: left">
                                <img border="0" src="images/gk.png" width="134" height="172">
                            </div>
                            <div style="float: left; margin-top: 80px; margin-left: 10px">
                                <img alt="" height="14" src="images/right-blue-arrow.gif" onclick="Lawyer1.style.display='none';Lawyer2.style.display='none';Lawyer3.style.display='block';"
                                    width="14">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="bottom">
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <font color="red">������ʦ</font>�ǻ���֪����ӯ��(�Ϻ�)��ʦ�������ϻ�����ʦ��ִҵ���꣬��У��ѧ��ʦ�����۹��������Ϊ�ó�����顢�̳���صķ�������ҵ��Ȩ�ʲ����ף�ԸΪ���ṩ���ʡ�רҵ����Ч�ķ��ɷ���
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <div class="hot mt1">
                                <dl class="tbox">
                                    <dt><strong>��ϵ��ʽ</strong></dt>
                                    <dd>
                                        <ul class="c1 ico2">
                                            <p>
                                                ��ϵ�绰��021-60561339<br>
                                                ��ϵ�ֻ���13636542941<br>
                                                ��ϵ��ַ��բ�������·500���޼���������16¥
                                            </p>
                                        </ul>
                                    </dd>
                                </dl>
                            </div>
                        </td>
                    </tr>
                </table>
                <table id="Lawyer3" style="width: 100%; display: none;">
                    <tr>
                        <td style="text-align: center;" height="200px">
                            <div style="float: left; margin-left: 20px; margin-top: 80px; margin-right: 10px">
                                <img alt="" height="14" src="images/left-blue-arrow.gif" onclick="Lawyer1.style.display='none';Lawyer2.style.display='block';Lawyer3.style.display='none';"
                                    style="cursor: hand;" width="14"></div>
                            <div style="float: left">
                                <img border="0" src="images/dengx.jpg" width="134" height="172">
                            </div>
                            <div style="float: left; margin-top: 80px; margin-left: 10px">
                                <img alt="" height="14" src="images/right-blue-arrow.gif" width="14" onclick="Lawyer1.style.display='block';Lawyer2.style.display='none';Lawyer3.style.display='none';">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="bottom">
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <font color="red">������ʦ����</font>�ǻ���֪����ӯ��(�Ϻ�)��ʦ������ʵϰ��ʦ���Ի���������Ϊ����Ȥ����Ҫ������鰸�������е������Ի��ڣ�����������ܵ��ͼ�ʱ�ķ��ɷ���
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <div class="hot mt1">
                                <dl class="tbox">
                                    <dt><strong>��ϵ��ʽ</strong></dt>
                                    <dd>
                                        <ul class="c1 ico2">
                                            <p>
                                                ��ϵ�绰��021-60561339<br>
                                                ��ϵ�ֻ���13636542941<br>
                                                ��ϵ��ַ��բ�������·500���޼���������16¥
                                            </p>
                                        </ul>
                                    </dd>
                                </dl>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="hot mt1">
                    <dl class="tbox">
                        <dt><a href="news_show.aspx?title=��ʦ�շѱ�׼" target="_blank"><strong><font color="blue">
                            �շѱ�׼</font></strong></a> </dt>
                    </dl>
                </div>
            </td>
        </tr>
        <br />
        <br />
        <tr>
            <td colspan="2">
                <div class="hot mt1">
                    <dl class="tbox">
                        <dt><a href="news_show.aspx?title=������ɫ" target="_blank"><strong><font color="blue">������ɫ</font></strong></a>
                        </dt>
                    </dl>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="hot mt1 tbox">
                    <dl class="tbox">
                        <dt><a href="guestbook.aspx" target="_blank"><strong><font color="blue">������ѯ</font></strong></a>
                            <a href="guestask.aspx" target="_blank"><strong><font color="blue">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img
                                src="images/reg.gif" border="0" height="18px" />&nbsp;&nbsp;������ѯ </font></strong>
                            </a>
                            <dd>
                                <ul class="c1 ico2">
                                    <asp:Repeater ID="RepeaterGuestbook" runat="server">
                                        <ItemTemplate>
                                            <li><a href="guestbook_show.aspx?<%# Total.QueryStringGuestbookId %>=<%# Eval("id") %>"
                                                title="<%#UtilHtml.RemoveHtmlTag(Eval("title").ToString(),false)%>" target="_blank">
                                                <%# UtilHtml.TitleSubstring(Eval("id").ToString(), Eval("title").ToString() + " - " + Eval("content").ToString(), 20, (DateTime)Eval("addtime"))%>
                                            </a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <div style="float: right">
                                        <a href="guestbook.aspx" style="font-size: 12px;">����&gt;&gt;</a></div>
                                </ul>
                            </dd>
                        </dt>
                    </dl>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="hot mt1">
                    <dl class="tbox">
                        <dt><strong>ҵ��Χ</strong>
                            <dd>
                                <ul class="c1 ico2">
                                    <p>
                                        <font size="-1">����ͬ����&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            ����Ʒ������<br>
                                            ���ڷ�����&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �����ַ�����<br>
                                            �����ݲ�Ǩ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; �������̳�<br>
                                            ����ҵ����&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ����ס������<br>
                                            ����������&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �����ز�����<br>
                                            ���н�̸��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ���������ٲ�<br>
                                            ��������˾���귨�ɹ���<br>
                                            ����������ȫ�̷��ɷ���&nbsp;</font>
                                    </p>
                                </ul>
                            </dd>
                    </dl>
                </div>
            </td>
        </tr>
        
    </table>

     <uc1:shfzb ID="shfzb" runat="server"></uc1:shfzb>
</div>
