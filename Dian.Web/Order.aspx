<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="Dian.Web.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="width:900px">
    <form id="form1" runat="server">
    <div>
        点菜页面
        <asp:GridView ID="gridFood" runat="server" AllowPaging="True" AllowSorting="true" AutoGenerateColumns="true" PageSize="10">
            <RowStyle Height="34px" />
            <Columns>
                <asp:ImageField  DataImageUrlField ="~\Image\123.gif">
                </asp:ImageField>
                <asp:TemplateField HeaderText="菜名" >
                 </asp:TemplateField>
               </Columns>
        </asp:GridView>
        <table >
            <tr>
                <td style="background-image:url('~/image/123.gif') "></td>

            </tr>

        </table>
    
    </div>
    </form>
</body>
</html>
