<%@ Control Language="c#" Inherits="com.hujun64.shfzb" CodeFile="shfzb.ascx.cs" %>
<table border="0" cellspacing="0" width="240px">
    <%if (shfzbVisiable)
      { %>
    <tr>
        <td>
            <div class="hot mt1">
                <dl class="tbox">
                    <dt><strong>�Ϻ����α�</strong>
                        <dd>
                            <ul class="c1 ico2">
                                <asp:Repeater ID="RepeaterShfzb" runat="server">
                                    <ItemTemplate>
                                        <li><a href="<%# Total.AspxUrlShowdetail %>?<%# Total.QueryStringArticleId %>=<%# Eval("id") %>"
                                            title="<%#UtilHtml.RemoveHtmlTag(Eval("title").ToString(),true)%>" target="_blank">
                                            <%# UtilHtml.RemoveHtmlTag(Eval("title").ToString(), true)%><%#UtilHtml.GetImageOfNewArticle(Eval("id").ToString(),(DateTime)Eval("addtime")) %>
                                        </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div style="float: right">
                                    <a href="listitem.aspx?class_name=�Ϻ����α�" style="font-size: 12px;">����&gt;&gt;</a></div>
                            </ul>
                        </dd>
                    </dt>
                </dl>
            </div>
        </td>
    </tr>
    <%} %>
</table>
