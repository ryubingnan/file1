<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterOA.master" AutoEventWireup="true" CodeFile="WorkLogList.aspx.cs" Inherits="admin_manage_WorkLogList" %>
<%@ Register Src="../Control/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <table class="tblist">
        <tr>
            <td>
                当前位置：工作日志 >> 日志列表
            </td>
        </tr>
    </table>
    <table class="tblist">
        <tr onmouseover="color=this.style.backgroundColor;this.style.backgroundColor='#ECF3DE'" onmouseout="this.style.backgroundColor=color;">
            <td class="width50 tdcenter">
                <input id="cbSelectAll" type="checkbox" onclick="SelectAll()" />
            </td>
            <td class="tdcenter">
                标题
            </td>
            <td class="width150 tdcenter">
                作者
            </td>
            <td class=" width150 tdcenter">
                状态
            </td>
            <td class=" width150 tdcenter">
                发送时间
            </td>
            <td class="width100 tdcenter">
                操作
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr onmouseover="color=this.style.backgroundColor;this.style.backgroundColor='#ECF3DE'" onmouseout="this.style.backgroundColor=color;">
                    <td class="width50 tdcenter">
                        <input type="checkbox" value='<%#Eval("id") %>' id="select<%#Eval("id") %>" name="select">
                    </td>
                    <td class="tdcenter">
                        <%#Eval("Title")%>
                    </td>
                    <td class="width150 tdcenter">
                       <%#GetUserName(Eval("userid").ToString())%>
                    </td>
                    <td class="tdcenter width150">
                     <%#(Eval("checkstate").ToString()=="1")?"审核通过":"未审核"%>
                    </td>
                    <td class="width150 tdcenter">
                        <%#Eval("ctime")%>
                    </td>
                    <td class="width100 tdcenter">
                        <a href="###" onclick="ShowWorkLog(<%#Eval("id")%>)" >查看</a> <a href="###" onclick="CloseWorkLog(<%#Eval("id")%>)" >关闭</a><a href="###" style=" display:<%#GetShowType()%> " onclick="checkWorkLog(<%#Eval("id")%>)" >审核</a>
                    </td>
                </tr>
                <tr id="tr<%#Eval("id")%>" style=" display:none;"><td colspan="6" style="padding-left:50px; height:120px;" ><%#Eval("contents")%></td></tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table class="tblist marginTop2">
        <tr>
            <td>
                
                <asp:Literal ID="ltr_batchDelete" runat="server"></asp:Literal>
                
                <uc1:Pager ID="Pager1" runat="server" />
            </td>
        </tr>
    </table>

    <script type="text/javascript" language="javascript">
        function ShowWorkLog(id) {
            $("#tr" + id).slideDown("slow");
        }
        function CloseWorkLog(id) {
            $("#tr" + id).slideUp("slow");
        }
        function checkWorkLog(id) {
            $.post("/common/ajax/ajax.aspx?" + Math.random(), { w: "checkWorkLog", _id:id}, function (data) {
                switch (data) {
                    case "1": document.location.reload(); break;
                    case "0": alert("审核失败！"); break;
                    default: alert("审核失败！"); break;
                }

            })
        }



        //全选
        function SelectAll() {
            var obtn = document.getElementById("cbSelectAll");
            var cbxs = document.getElementsByTagName("input");
            for (i = 0; i < cbxs.length; i++) {
                if (cbxs.item(i).type == "checkbox") {
                    if (obtn.checked == true) {
                        cbxs.item(i).checked = true;
                    }
                    else {
                        cbxs.item(i).checked = false;
                    }
                }
            }
        }

        //批量删除
        function DeleteSelect() {
            var Flag;
            Flag = confirm("系统提示：确认删除选取的记录吗？一旦删除将不可恢复！");
            if (Flag) {
                var idstr = "0";
                var cbxs = document.getElementsByName("select");
                for (i = 0; i < cbxs.length; i++) {
                    if (cbxs.item(i).checked) {
                        idstr += "," + cbxs.item(i).value;
                    }
                }
                idstr += ",0";
                $.post("/common/ajax/ajax.aspx?" + Math.random(), { w: "WorkLogBatchDelete", _idstr: idstr }, function (data) {
                    switch (data) {
                        case "1": document.location.reload(); break;
                        case "0": alert("删除失败！"); break;
                        default: alert("删除失败！"); break;
                    }

                })
            }
        }
    </script>

</asp:Content>
