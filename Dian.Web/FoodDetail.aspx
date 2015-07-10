<%@ Page Title="" Language="C#" MasterPageFile="~/BackgroundManagement.Master" AutoEventWireup="true" CodeBehind="FoodDetail.aspx.cs" Inherits="Dian.Web.FoodDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="admin-content">

        <div class="am-cf am-padding">
            <div class="am-fl am-cf">
                <strong class="am-text-primary am-text-lg">菜品详情</strong> / <small>
                    <label id="lTypeName" runat="server">新增</label>
                </small>
            </div>
        </div>

        <div class="am-tabs am-margin" data-am-tabs>
            <hr />
            <div class="am-form">

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">
                        菜名
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <input type="text" class="am-input-sm" placeholder="必填" id="tFoodTypeName" runat="server" maxlength="50" required>
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*必填</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">店家</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <asp:DropDownList ID="ddlRestaurant" runat="server" data-am-selected="{btnSize: 'sm'}">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">分类</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <asp:DropDownList ID="ddlFoodType" runat="server" data-am-selected="{btnSize: 'sm'}">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">口味</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <asp:DropDownList ID="ddlTaste" runat="server">
                            <asp:ListItem Value="1" Text="无"></asp:ListItem>
                            <asp:ListItem Value="2" Text="酸"></asp:ListItem>
                            <asp:ListItem Value="3" Text="甜"></asp:ListItem>
                            <asp:ListItem Value="4" Text="苦"></asp:ListItem>
                            <asp:ListItem Value="5" Text="辣"></asp:ListItem>
                            <asp:ListItem Value="6" Text="咸"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">
                        详情
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <input type="text" class="am-input-sm" placeholder="必填" id="Text2" runat="server" maxlength="50" required>
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*必填</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">图片1</div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <asp:FileUpload ID="fileMap" runat="server" />
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*选填，图片大小不能超过2M</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">预览1</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <img src="../Images/OriginalImages/default.jpg" class="am-img-responsive am-img-thumbnail" alt="" id="imgMap" runat="server" />
                    </div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">图片2</div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*选填，图片大小不能超过2M</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">预览2</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <img src="../Images/OriginalImages/default.jpg" class="am-img-responsive am-img-thumbnail" alt="" id="img1" runat="server" />
                    </div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">图片3</div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <asp:FileUpload ID="FileUpload2" runat="server" />
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*选填，图片大小不能超过2M</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">预览3</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <img src="../Images/OriginalImages/default.jpg" class="am-img-responsive am-img-thumbnail" alt="" id="img2" runat="server" />
                    </div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">图片4</div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <asp:FileUpload ID="FileUpload3" runat="server" />
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*选填，图片大小不能超过2M</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">预览4</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <img src="../Images/OriginalImages/default.jpg" class="am-img-responsive am-img-thumbnail" alt="" id="img3" runat="server" />
                    </div>
                </div>

            </div>
        </div>

        <div class="am-margin">
            <button type="submit" class="am-btn am-btn-primary am-btn-xs" onclick="beforeSave();">提交保存</button>
            <button type="button" class="am-btn am-btn-primary am-btn-xs" onclick="self.location.href = '<%= base.UrlReferrer %>'">放弃保存</button>
        </div>

        <label id="lMsg" runat="server" class="am-text-warning"></label>
    </div>

</asp:Content>
