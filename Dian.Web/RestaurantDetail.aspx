<%@ Page Title="" Language="C#" MasterPageFile="BackgroundManagement.Master" AutoEventWireup="true" CodeBehind="RestaurantDetail.aspx.cs" Inherits="Dian.Web.RestaurantDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="admin-content">

        <div class="am-cf am-padding">
            <div class="am-fl am-cf">
                <strong class="am-text-primary am-text-lg">店家管理</strong> / <small>
                    <label id="lTypeName" runat="server">新增</label>
                </small>
            </div>
        </div>

        <div class="am-tabs am-margin" data-am-tabs>
            <hr />
            <div class="am-form">

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">
                        店名
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <input type="text" class="am-input-sm" placeholder="必填" id="tRestaurantName" runat="server" maxlength="50" required>
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*必填</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">
                        地址
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <input type="text" class="am-input-sm" placeholder="必填" id="tAddress" runat="server" maxlength="50" required>
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*必填</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">
                        描述
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <input type="text" class="am-input-sm" placeholder="必填" id="tDescription" runat="server" maxlength="100" required>
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*必填</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">
                        车位
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <input type="number" class="am-input-sm" value="0" id="tPackingCount" min="0" max="100" required>
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*必填</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">等级</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <label class="am-radio-inline">
                            <input type="radio" value="1" name="optionsLevel" checked="checked">
                            一级
                        </label>
                        <label class="am-radio-inline">
                            <input type="radio" value="2" name="optionsLevel">
                            二级
                        </label>
                        <label class="am-radio-inline">
                            <input type="radio" value="3" name="optionsLevel">
                            三级
                        </label>
                        <label class="am-radio-inline">
                            <input type="radio" value="4" name="optionsLevel">
                            四级
                        </label>
                        <label class="am-radio-inline">
                            <input type="radio" value="5" name="optionsLevel">
                            五级
                        </label>
                    </div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">区域</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <label class="am-radio-inline">
                            <input type="radio" value="1" name="optionsArea" checked="checked">
                            华中
                        </label>
                        <label class="am-radio-inline">
                            <input type="radio" value="2" name="optionsArea">
                            华东
                        </label>
                        <label class="am-radio-inline">
                            <input type="radio" value="3" name="optionsArea">
                            华南
                        </label>
                        <label class="am-radio-inline">
                            <input type="radio" value="4" name="optionsArea">
                            华西
                        </label>
                        <label class="am-radio-inline">
                            <input type="radio" value="5" name="optionsArea">
                            华北
                        </label>
                    </div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">地图</div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <asp:FileUpload ID="fileMap" runat="server" />
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*图片大小不能超过2M</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">预览</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <img src="Images/OriginalImages/pic-none.png" class="am-img-responsive am-img-thumbnail" alt="" id="imgMap" runat="server" />
                        <button type="button" class="am-btn am-btn-warning am-btn-xs" onclick="deleteImg('<%= this.imgMap.ClientID %>', '<%= this.hDeleteImg.ClientID %>');">删除图片</button>
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

    <input type="hidden" id="hPackingCount" runat="server" />
    <input type="hidden" id="hLevel" runat="server" />
    <input type="hidden" id="hArea" runat="server" />
    <input type="hidden" id="hDeleteImg" runat="server" />

    <script type="text/javascript">

        //页面初始化

        var hPackingCount = "<%= this.hPackingCount.ClientID %>";
        var hLevel = "<%= this.hLevel.ClientID %>";
        var hArea = "<%= this.hArea.ClientID %>";

        $(function () {
            var temp = 0;
            if (!$.isEmpty($('#tPackingCount').val()))
                $('#tPackingCount').val($('#' + hPackingCount).val());
            if (!$.isEmpty($('#' + hLevel).val())) {
                temp = parseInt($('#' + hLevel).val()) - 1;
                $('input:radio[name=optionsLevel]')[temp].checked = true;
            }
            if (!$.isEmpty($('#' + hArea).val())) {
                temp = parseInt($('#' + hArea).val()) - 1
                $('input:radio[name=optionsArea]')[temp].checked = true;
            }
        })

        function beforeSave() {
            $('#' + hPackingCount).val($('#tPackingCount').val());
            $('#' + hLevel).val($('input:radio[name=optionsLevel]:checked').val());
            $('#' + hArea).val($('input:radio[name=optionsArea]:checked').val());
        }

    </script>

</asp:Content>
