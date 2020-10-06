<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterOA.master" AutoEventWireup="true" CodeFile="WorkLogEdit.aspx.cs" Inherits="admin_manage_WorkLogEdit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <table class="tblist" >
<tr><td class="tdright" >标题：</td><td><asp:TextBox ID="tbTitle" runat="server" Width="400" ></asp:TextBox></td></tr>
<tr><td class="tdright">内容：</td><td>
 <FCKeditorV2:FCKeditor ID="FCKContent" runat="server" BasePath="../Files/" Width="100%"
                    Height="400px" ToolbarSet="www.yykj520.cn">
 </FCKeditorV2:FCKeditor>
</td></tr>
<tr><td></td><td><asp:Button ID="Button1" runat="server" Text="保存日志" 
        onclick="Button1_Click" OnClientClick="return Check();" /></td></tr>
</table>
<script type="text/javascript">
    function Check() {
        var o = $("#ctl00_ContentPlaceHolder1_tbTitle");
        if (!o.val().length > 0) {
            alert("请输入标题！");
            o.focus();
            return false;
        }
        var oEditor = FCKeditorAPI.GetInstance("ctl00_ContentPlaceHolder1_FCKContent");
        var Content = oEditor.GetXHTML();
        if (Content == "") {
            alert("请填写内容!");
            oEditor.Focus(); //获取焦点 
            return false;
        }


    }

</script>
</asp:Content>
