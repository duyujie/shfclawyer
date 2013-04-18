<%@ Page Language="c#" AutoEventWireup="true" Inherits="com.hujun64.admin.add_art"
    CodeFile="add_art.aspx.cs" ValidateRequest="false" %>

<%--<%@ Register TagPrefix="FCKeditorV2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>���/��������</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta name="robots" content="noindex,follow" />
    
    <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>

    <script type="text/javascript" src="../xheditor/xheditor-zh-cn.min.js"></script>

    <script type="text/javascript">
        //        $(pageInit);
        function pageInit() {

        }

        $(document).ready(function () {
            var content = "#" + '<%=this.ContentEditor.ClientID %>';
            $(content).xheditor(true, { tools: 'full'
            });

        });

    </script>
</head>
<body>
    <form id="FormArt" method="post" runat="server">
      <asp:HiddenField ID="newsId" runat="server"></asp:HiddenField>
    <table border="1" align="center" width="100%" cellpadding="0" cellspacing="0" id="Table1">
        
        <tbody>
            <tr>
                <td width="15%" align="right">
                    �����ࣺ
                </td>
                <td>
                    <asp:DropDownList ID="moduleClassList" runat="server" AutoPostBack="True" DataTextField="class_name"
                        DataValueField="id" OnSelectedIndexChanged="moduleClassList_SelectedIndexChanged" />
                    <asp:Label ID="ignoreModuleLabel" runat="server" AutoPostBack="True" Text="����" />
                    <asp:CheckBox ID="ignoreModuleClass" runat="server" AutoPostBack="True" OnCheckedChanged="ignoreModule_SelectedIndexChanged" />
                </td>
            </tr>
        </tbody>
        <tbody>
            <tr>
                <td width="15%" align="right">
                    ��ǰ����ID��
                </td>
                <td>
                    <asp:TextBox ID="TextBoxAticleId" runat="server" Width="100" MaxLength="10" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="15%" align="right">
                    ��������ID��
                </td>
                <td>
                    <asp:TextBox ID="RefArticleId" runat="server" Width="100" MaxLength="10" OnTextChanged="RefId_Changed"></asp:TextBox>
                    ����<asp:CheckBox ID="RefCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="RefCheckBox_Selected" />
                </td>
            </tr>
        </tbody>
       
        <tbody>
            <tr>
                <td width="15%" align="right">
                    ���⣺
                </td>
                <td>
                    <asp:TextBox ID="arttitle" runat="server" Width="90%" MaxLength="100"></asp:TextBox>
                </td>
            </tr>
        </tbody>
        <tbody>
            <tr>
                <td width="15%" align="right">
                    ���ߣ�
                </td>
                <td>
                    <asp:TextBox ID="author" runat="server" Width="200" MaxLength="100"></asp:TextBox>
                </td>
            </tr>
        </tbody>
        <tbody>
            <tr>
                <td width="15%" align="right">
                    ������Դ��
                </td>
                <td>
                    <asp:TextBox ID="artFrom" runat="server" Width="200" MaxLength="100">��վԭ��</asp:TextBox>
                </td>
            </tr>
        </tbody>
        <tbody>
            <tr>
                <td width="15%" align="right">
                    �ؼ��ʻ㣺
                </td>
                <td>
                    <asp:TextBox ID="keywords" runat="server" Width="90%" MaxLength="100"></asp:TextBox>
                </td>
            </tr>
        </tbody>
        <tbody>
            <tr>
                 <td width="15%" align="right">
                    �ϴ��ļ���
                </td>
                <td>
                    <asp:FileUpload ID="imgFile" runat="server" name="imgFile" size="80"/>
                    <asp:Button value="�� ��" onclick="UploadFile" runat="server" id="uploadButton" Text="�ϴ�"
                        name="uploadButton" />
                    <br />
                    <asp:Label runat="server" id="refImgUrl" name="refImgUrl" size="80" onchange="ReferenceFile" />
                </td>
            </tr>
            <%if (!string.IsNullOrEmpty(uploadImgUrl))
              {%>
            <tr>
                <td width="15%" align="right">
                    ͼƬԤ����
                </td>
                <td>
                    <img src="<%=uploadImgUrl%>" alt="" />
                </td>
            </tr>
            <% }%>
            <tr>
                <td width="15%" align="right">
                    ���ݣ�
                </td>
                <td>
                 <asp:TextBox ID="ContentEditor" TextMode="MultiLine" runat="server" Rows="30" Columns="100" />
                   <%-- <FCKeditorV2:FCKeditor ID="ContentEditor" runat="server" Width="90%" Height="600px">
                    </FCKeditorV2:FCKeditor>--%>
                </td>
            </tr>
            <tr>
                <td width="15%" align="right">
                    <asp:Button ID="submit_button" runat="server" Text="��׼��ʽ����" ForeColor="Blue" Width="120px"
                        Height="30px" Font-Bold="true" Font-Size="14px" OnClick="submit_Click" />
                </td>
                <td>
                    <asp:Button ID="definedSubmit_button" runat="server" Text="�Զ����ʽ����" ForeColor="Blue"
                        Width="120px" Height="30px" Font-Bold="true" Font-Size="14px" OnClick="definedSubmit_Click" />
                </td>
            </tr>
        </tbody>
        <tbody>
            <tr>
                <td colspan="2">
                    <asp:Label ID="MSG" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
