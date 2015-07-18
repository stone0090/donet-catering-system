<%@ Page Title="" Language="C#" MasterPageFile="BackgroundManagement.Master" AutoEventWireup="true" CodeBehind="FoodDetail.aspx.cs" Inherits="Dian.Web.FoodDetail" %>

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
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">店家</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <asp:DropDownList ID="ddlRestaurant" runat="server" data-am-selected="{btnSize: 'sm'}" required>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">分类</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <asp:DropDownList ID="ddlFoodType" runat="server" data-am-selected="{btnSize: 'sm'}" required>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">口味</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <asp:DropDownList ID="ddlTaste" runat="server" data-am-selected="{btnSize: 'sm'}" required>
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
                        菜名
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <input type="text" class="am-input-sm" placeholder="必填" id="tFoodName" runat="server" maxlength="25" required>
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*必填</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">
                        详情
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <textarea rows="5" placeholder="必填" id="tDescription" runat="server" maxlength="200" required></textarea>
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*必填</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">
                        单价
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <input type="text" class="am-input-sm" placeholder="必填，只能保留2位小数" id="tPrice" required>
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*必填</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">图片1</div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <asp:FileUpload ID="fileMap1" runat="server" />
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*图片大小不能超过2M</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">预览1</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <img src="Images/OriginalImages/pic-none.png" class="am-img-responsive am-img-thumbnail" alt="" id="img1" runat="server" />
                        <button type="button" class="am-btn am-btn-warning am-btn-xs" onclick="deleteImg('<%= this.img1.ClientID %>', '<%= this.hDeleteImg.ClientID %>');">删除图片</button>
                    </div>
                </div>

                <div style="display: none;">
                    <div class="am-g am-margin-top">
                        <div class="am-u-sm-2 am-u-md-2 am-text-right">图片2</div>
                        <div class="am-u-sm-10 am-u-md-6">
                            <asp:FileUpload ID="fileMap2" runat="server" />
                        </div>
                        <div class="am-hide-sm-only am-u-md-4">*图片大小不能超过2M</div>
                    </div>

                    <div class="am-g am-margin-top">
                        <div class="am-u-sm-2 am-u-md-2 am-text-right">预览2</div>
                        <div class="am-u-sm-10 am-u-md-10">
                            <img src="Images/OriginalImages/pic-none.png" class="am-img-responsive am-img-thumbnail" alt="" id="img2" runat="server" />
                            <button type="button" class="am-btn am-btn-warning am-btn-xs" onclick="deleteImg('<%= this.img2.ClientID %>', '<%= this.hDeleteImg.ClientID %>');">删除图片</button>
                        </div>
                    </div>

                    <div class="am-g am-margin-top">
                        <div class="am-u-sm-2 am-u-md-2 am-text-right">图片3</div>
                        <div class="am-u-sm-10 am-u-md-6">
                            <asp:FileUpload ID="fileMap3" runat="server" />
                        </div>
                        <div class="am-hide-sm-only am-u-md-4">*图片大小不能超过2M</div>
                    </div>

                    <div class="am-g am-margin-top">
                        <div class="am-u-sm-2 am-u-md-2 am-text-right">预览3</div>
                        <div class="am-u-sm-10 am-u-md-10">
                            <img src="Images/OriginalImages/pic-none.png" class="am-img-responsive am-img-thumbnail" alt="" id="img3" runat="server" />
                            <button type="button" class="am-btn am-btn-warning am-btn-xs" onclick="deleteImg('<%= this.img3.ClientID %>', '<%= this.hDeleteImg.ClientID %>');">删除图片</button>
                        </div>
                    </div>

                    <div class="am-g am-margin-top">
                        <div class="am-u-sm-2 am-u-md-2 am-text-right">图片4</div>
                        <div class="am-u-sm-10 am-u-md-6">
                            <asp:FileUpload ID="fileMap4" runat="server" />
                        </div>
                        <div class="am-hide-sm-only am-u-md-4">*图片大小不能超过2M</div>
                    </div>

                    <div class="am-g am-margin-top">
                        <div class="am-u-sm-2 am-u-md-2 am-text-right">预览4</div>
                        <div class="am-u-sm-10 am-u-md-10">
                            <img src="Images/OriginalImages/pic-none.png" class="am-img-responsive am-img-thumbnail" alt="" id="img4" runat="server" />
                            <button type="button" class="am-btn am-btn-warning am-btn-xs" onclick="deleteImg('<%= this.img4.ClientID %>', '<%= this.hDeleteImg.ClientID %>');">删除图片</button>
                        </div>
                    </div>
                </div>

            </div>

            <div class="am-margin">
                <button type="submit" class="am-btn am-btn-primary am-btn-xs" onclick="beforeSave();">提交保存</button>
                <button type="button" class="am-btn am-btn-primary am-btn-xs" onclick="self.location.href = '<%= base.UrlReferrer %>'">放弃保存</button>
            </div>

            <label id="lMsg" runat="server" class="am-text-danger"></label>
        </div>
    </div>

    <input type="hidden" id="hDeleteImg" runat="server" />
    <input type="hidden" id="hPrice" runat="server" />

    <script type="text/javascript">

        var hPrice = "<%= this.hPrice.ClientID %>";

        $(window).bind('load', function () {
            $('#tPrice').val($('#' + hPrice).val());
        });

        function beforeSave() {
            $('#' + hPrice).val($('#tPrice').val());
        }

    </script>

</asp:Content>
