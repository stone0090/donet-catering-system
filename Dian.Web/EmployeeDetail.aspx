<%@ Page Title="" Language="C#" MasterPageFile="BackgroundManagement.Master" AutoEventWireup="true" CodeBehind="EmployeeDetail.aspx.cs" Inherits="Dian.Web.EmployeeDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="admin-content">

        <div class="am-cf am-padding">
            <div class="am-fl am-cf">
                <strong class="am-text-primary am-text-lg">用户管理</strong> / <small>
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
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">
                        账号
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <input type="text" class="am-input-sm" placeholder="必填，不可重复" id="tEmployeeId" runat="server" maxlength="10" required>
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*必填，不可重复</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">
                        姓名
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <input type="text" class="am-input-sm" placeholder="必填" id="tEmployeeName" runat="server" maxlength="10" required>
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*必填</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">
                        密码
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <input type="text" class="am-input-sm" placeholder="必填" id="tPassword" runat="server" minlength="6" maxlength="20" required>
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*必填</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">
                        手机
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <input type="text" class="am-input-sm" placeholder="必填" id="tMobilePhone" runat="server" maxlength="20" required>
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*必填</div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">
                        座机
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <input type="text" class="am-input-sm" id="tOfficePhone" runat="server" maxlength="20">
                    </div>
                    <div class="am-hide-sm-only am-u-md-4"></div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">性别</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <label class="am-radio-inline">
                            <input type="radio" value="1" name="optionsSex" checked="checked">
                            男
                        </label>
                        <label class="am-radio-inline">
                            <input type="radio" value="2" name="optionsSex">
                            女
                        </label>
                        <label class="am-radio-inline">
                            <input type="radio" value="3" name="optionsSex">
                            保密
                        </label>

                    </div>
                </div>

                <div class="am-g am-margin-top">
                    <div class="am-u-sm-2 am-u-md-2 am-text-right">超管</div>
                    <div class="am-u-sm-10 am-u-md-10">
                        <input type="checkbox" id="cIsAdmin" runat="server" />
                        <label class="am-text-danger" for="<%= this.cIsAdmin.ClientID %>">是否为超级管理员</label>
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

    <input type="hidden" id="hSex" runat="server" />

    <script type="text/javascript">

        //页面初始化
        var hSex = "<%= this.hSex.ClientID %>";

        $(function () {
            var temp = 0;
            if (!$.isEmpty($('#' + hSex).val())) {
                temp = parseInt($('#' + hSex).val()) - 1
                $('input:radio[name=optionsSex]')[temp].checked = true;
            }
        })

        function beforeSave() {
            $('#' + hSex).val($('input:radio[name=optionsSex]:checked').val());
        }

    </script>

</asp:Content>
