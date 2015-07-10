<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Restaurant.aspx.cs" Inherits="Dian.Web.Restaurant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>店家</title>
    <link href="CSS/Default.css" rel="stylesheet" />
</head>
<body>
    <form id="FormRestaurant" runat="server">
        <div class="MainBody">
            <div style="text-align:right;">
                <asp:Button ID="BtnClose" runat="server" Text="关闭" OnClientClick="window.opener=null;window.close();" />
            </div>
            <table style="width: 100%;">
                <tr>
                    <td style="width: 20%;">店名</td>
                    <td>
                        <input type="text" id="TBRestaurantName" runat="server" style="width: 100%;" /></td>
                    <td>
                        <a style="color: red">*</a>
                    </td>
                </tr>
                <tr>
                    <td>地址</td>
                    <td>
                        <input type="text" id="TBAddress" runat="server" style="width: 100%;" /></td>
                    <td>
                        <a style="color: red">*</a>
                    </td>
                </tr>
                <tr>
                    <td>店家描述</td>
                    <td>
                        <input type="text" id="TBDescription" runat="server" style="width: 100%;" /></td>
                    <td>
                        <a style="color: red">*</a>
                    </td>
                </tr>
                <tr>
                    <td>等级</td>
                    <td>
                        <asp:DropDownList ID="DDLLevel" runat="server">
                            <asp:ListItem Value="1" Text="一级" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="2" Text="二级"></asp:ListItem>
                            <asp:ListItem Value="3" Text="二级"></asp:ListItem>
                            <asp:ListItem Value="4" Text="二级"></asp:ListItem>
                            <asp:ListItem Value="5" Text="二级"></asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        <a style="color: red">*</a>
                    </td>
                </tr>
                <tr>
                    <td>区域</td>
                    <td>
                        <asp:DropDownList ID="DDLArea" runat="server">
                            <asp:ListItem Value="1" Text="华中" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="2" Text="华东"></asp:ListItem>
                            <asp:ListItem Value="3" Text="华南"></asp:ListItem>
                            <asp:ListItem Value="4" Text="华西"></asp:ListItem>
                            <asp:ListItem Value="5" Text="华北"></asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        <a style="color: red">*</a>
                    </td>
                </tr>
                <tr>
                    <td>停车位</td>
                    <td>
                        <input type="text" id="TBPackingCount" runat="server" value="0" style="width: 100%;" /></td>
                    <td>
                        <a style="color: red">*</a>
                    </td>
                </tr>
                <tr>
                    <td>店家地图</td>
                    <td>
                        <asp:FileUpload ID="FURestaurantMap" runat="server" Width="100%" />
                    </td>
                    <td>
                        <%-- <a style="color:red">*</a>--%>
                    </td>
                </tr>

            </table>
            <div style="text-align: center;">
                <asp:Button ID="BtnSave" runat="server" Text="保存" OnClick="BtnSave_Click" style="height: 21px" />
            </div>
            <div  style="text-align: center;">
                <img id="ImgRestaurantMap" runat="server" src="~/Images/OriginalImages/default.jpg" />

            </div>
            <div>
                <asp:Label ID="LBMessage" runat="server" ForeColor="Red" Text="*号为必填项目"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
