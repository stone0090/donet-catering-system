<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Food.aspx.cs" Inherits="Dian.Web.Food" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>菜品</title>
    <link href="CSS/Default.css" rel="stylesheet" />
</head>
<body>
    <form id="FormFood" runat="server">
        <div class="MainBody">
              <div style="text-align:right;">
                <asp:Button ID="BtnClose" runat="server" Text="关闭" OnClientClick="window.opener=null;window.close();" />
            </div>
            <table style="width:100%;" >
                <tr >
                    <td style="width:20%;" >菜品名称
                    </td>
                    <td>
                        <input type="text" id="TBFoodName" runat="server" style="width:100%;" />
                    </td>
                    <td>
                        <a style="color: red">*</a>
                    </td>
                </tr>
                <tr>
                    <td>店家名称
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLRestaurantName" runat="server" style="width:100%;" >
                            <asp:ListItem Value="1" Text="店名"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <a style="color: red">*</a>
                    </td>
                </tr>
                <tr>
                    <td>菜品类型
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLFoodType" runat="server">
                            <asp:ListItem Value="0" Text="无"></asp:ListItem>
                            <asp:ListItem Value="1" Text="酸"></asp:ListItem>
                            <asp:ListItem Value="2" Text="甜"></asp:ListItem>
                            <asp:ListItem Value="3" Text="苦"></asp:ListItem>
                            <asp:ListItem Value="4" Text="辣"></asp:ListItem>
                            <asp:ListItem Value="5" Text="咸"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <a style="color: red">*</a>
                    </td>
                </tr>
                <tr>
                    <td>菜品类型等级
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLFoodTypeLevel" runat="server">
                            <asp:ListItem Value="1" Text="很淡"></asp:ListItem>
                            <asp:ListItem Value="2" Text="淡"></asp:ListItem>
                            <asp:ListItem Value="3" Text="正常"></asp:ListItem>
                            <asp:ListItem Value="4" Text="中"></asp:ListItem>
                            <asp:ListItem Value="5" Text="中上"></asp:ListItem>
                            <asp:ListItem Value="6" Text="重"></asp:ListItem>
                            <asp:ListItem Value="7" Text="较重"></asp:ListItem>
                            <asp:ListItem Value="8" Text="很重"></asp:ListItem>
                            <asp:ListItem Value="9" Text="超重"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <a style="color: red">*</a>
                    </td>
                </tr>
                <tr>
                    <td>菜品介绍
                    </td>
                    <td>
                        <input type="text" id="TBDescription" runat="server" style="width:100%;"  />
                    </td>
                    <td>
                        <a style="color: red">*</a>
                    </td>
                </tr>
                <tr>
                    <td>菜品图片
                    </td>
                    <td>
                        <asp:FileUpload ID="FUImage1" runat="server" style="width:100%;" />
                    </td>
                    <td>
                        <a style="color: red">*</a>
                    </td>
                </tr>
                <tr>
                    <td>菜品图片
                    </td>
                    <td>
                        <asp:FileUpload ID="FUImage2" runat="server" style="width:100%;" />
                    </td>
                    <td>
                        <a style="color: red">*</a>
                    </td>
                </tr>
                <tr>
                    <td>菜品图片
                    </td>
                    <td>
                        <asp:FileUpload ID="FUImage3" runat="server" style="width:100%;" />
                    </td>
                    <td>
                        <a style="color: red">*</a>
                    </td>
                </tr>
                <tr>
                    <td>菜品图片
                    </td>
                    <td>
                        <asp:FileUpload ID="FUImage4" runat="server" style="width:100%;" />
                    </td>
                    <td>
                        <a style="color: red">*</a>
                    </td>
                </tr>

            </table>
            <div style="text-align:center;">
                <asp:Button ID="BtnSave" runat="server" Text="保存" OnClick="BtnSave_Click" />
            </div>
        </div>
    </form>
</body>
</html>
