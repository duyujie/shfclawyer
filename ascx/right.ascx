<%@ Control Language="c#" Inherits="com.hujun64.right" CodeFile="right.ascx.cs" %>
<%@ OutputCache Duration="60" VaryByParam="*" Shared="True" %>
<%@ Register TagPrefix="uc1" TagName="shfzb" Src="shfzb.ascx" %>
<div class="clear" style="width: 240px">
    <div class="tbox">
        <dt><strong>本站律师</strong></dt>
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
                                <img border="0" src="<%=Total.ImgProfileUrl %>" width="134" height="172" alt="上海胡珺律师" />
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
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <font color="red">胡珺律师</font>是沪上知名的盈科(上海)律师事务所合伙人律师，执业多年，办理离婚继承类案件过百余件，经验丰富，尤其擅长离婚财产分割、与婚恋继承有关的房产纠纷和子女抚养官司。
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <div class="hot mt1">
                                <dl class="tbox">
                                    <dt><strong>联系方式</strong></dt>
                                    <dd>
                                        <ul class="c1 ico2">
                                            <p>
                                                联系电话：021-60561339<br>
                                                联系手机：13636542941<br>
                                                联系地址：闸北区恒丰路500号洲际商务中心16楼
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
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <font color="red">宫克律师</font>是沪上知名的盈科(上海)律师事务所合伙人律师，执业多年，高校法学教师，理论功底深厚，尤为擅长与离婚、继承相关的房产、企业股权资产纠纷，愿为您提供优质、专业、高效的法律服务。
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <div class="hot mt1">
                                <dl class="tbox">
                                    <dt><strong>联系方式</strong></dt>
                                    <dd>
                                        <ul class="c1 ico2">
                                            <p>
                                                联系电话：021-60561339<br>
                                                联系手机：13636542941<br>
                                                联系地址：闸北区恒丰路500号洲际商务中心16楼
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
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <font color="red">邓仙律师助理</font>是沪上知名的盈科(上海)律师事务所实习律师，对婚姻法律尤为感兴趣，主要负责离婚案件代理中的事务性环节，让您体验更周到和及时的法律服务。
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <div class="hot mt1">
                                <dl class="tbox">
                                    <dt><strong>联系方式</strong></dt>
                                    <dd>
                                        <ul class="c1 ico2">
                                            <p>
                                                联系电话：021-60561339<br>
                                                联系手机：13636542941<br>
                                                联系地址：闸北区恒丰路500号洲际商务中心16楼
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
                        <dt><a href="news_show.aspx?title=律师收费标准" target="_blank"><strong><font color="blue">
                            收费标准</font></strong></a> </dt>
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
                        <dt><a href="news_show.aspx?title=服务特色" target="_blank"><strong><font color="blue">服务特色</font></strong></a>
                        </dt>
                    </dl>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="hot mt1 tbox">
                    <dl class="tbox">
                        <dt><a href="guestbook.aspx" target="_blank"><strong><font color="blue">在线咨询</font></strong></a>
                            <a href="guestask.aspx" target="_blank"><strong><font color="blue">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img
                                src="images/reg.gif" border="0" height="18px" />&nbsp;&nbsp;留言咨询 </font></strong>
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
                                        <a href="guestbook.aspx" style="font-size: 12px;">更多&gt;&gt;</a></div>
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
                        <dt><strong>业务范围</strong>
                            <dd>
                                <ul class="c1 ico2">
                                    <p>
                                        <font size="-1">·陪同购房&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            ·商品房买卖<br>
                                            ·期房买卖&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ·二手房买卖<br>
                                            ·房屋拆迁&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; ·离婚与继承<br>
                                            ·物业管理&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ·商住铺租赁<br>
                                            ·公房纠纷&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ·房地产调查<br>
                                            ·中介谈判&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ·诉讼与仲裁<br>
                                            ·房产公司常年法律顾问<br>
                                            ·房屋买卖全程法律服务&nbsp;</font>
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
