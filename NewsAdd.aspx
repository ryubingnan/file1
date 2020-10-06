<%@ Page Language="C#" MasterPageFile="~/master/MasterOA.master" AutoEventWireup="true"
    CodeFile="NewsAdd.aspx.cs" Inherits="admin_manage_NewsAdd" Title="无标题页" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <table class="tblist">
        <tr>
            <td>
                当前位置：新闻系统 >> 发布新闻
            </td>
        </tr>
    </table>
    <table class="tblist">
        <tr>
            <td class="tdright">
                标题：
            </td>
            <td>
                <asp:TextBox ID="tbTitle" runat="server" CssClass="width400"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdright">
                作者：
            </td>
            <td>
                <asp:TextBox ID="tbAuthor" runat="server" Text=""></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdright">
                来源：
            </td>
            <td>
                <asp:TextBox ID="tbsource" runat="server" Text=""></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdright">
                时间：
            </td>
            <td>
                <asp:TextBox ID="tbAddTime" runat="server" CssClass="Wdate" onFocus="WdatePicker({startDate:'%y-%M-%d hh:mm:ss',dateFmt:'yyyy-MM-dd HH:mm:ss',alwaysUseStartDate:true})"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdright">
                类别：
            </td>
            <td>
                <asp:Literal ID="ltr_class" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdright">
                主图：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" Style="background-color: White" />
            </td>
        </tr>
        <tr>
            <td class="tdright">
                内容：
            </td>
            <td>
                <FCKeditorV2:FCKeditor ID="FCKContent" runat="server" BasePath="../Files/" Width="100%"
                    Height="400px" ToolbarSet="www.yykj520.cn">
                </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr style="display: none">
            <td class="tdright">
                属性：
            </td>
            <td>
                
            </td>
        </tr>
        <tr style="display: none">
            <td class="tdright">
                权限：
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="发布" OnClick="Button1_Click" OnClientClick="return check()" />
            </td>
        </tr>
    </table>

    <script type="text/javascript" language="javascript">
    function check()
    {
        var otitle=document.getElementById("ctl00_ContentPlaceHolder1_tbTitle");
        if(!otitle.value.length>0)
        {
            alert("请填写标题!");
            otitle.focus();
            return false;       
        }
        var otbAuthor=document.getElementById("ctl00_ContentPlaceHolder1_tbAuthor");
        if(!otbAuthor.value.length>0)
        {
            alert("请填写作者!");
            otbAuthor.focus();
            return false;
        }
        var otbsource=document.getElementById("ctl00_ContentPlaceHolder1_tbsource");
        if(!otbsource.value.length>0)
        {
            alert("请填写来源");
            otbsource.focus();
            return false;       
        }
        
        var otbAddTime=document.getElementById("ctl00_ContentPlaceHolder1_tbAddTime");
        if(!otbAddTime.value.length>0)
        {
            alert("请选择发布时间");
            otbAddTime.focus();
            return false;       
        }
        
        
        var oEditor =FCKeditorAPI.GetInstance("ctl00_ContentPlaceHolder1_FCKContent"); 
        var Content=oEditor.GetXHTML(); 
        if(Content=="") 
        { 
            alert("请填写内容!"); 
            oEditor.Focus();//获取焦点 
            return false; 
        }
    }
    </script>

</asp:Content>
