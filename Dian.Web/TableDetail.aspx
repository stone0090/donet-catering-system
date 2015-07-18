<%@ Page Title="" Language="C#" MasterPageFile="BackgroundManagement.Master" AutoEventWireup="true" CodeBehind="TableDetail.aspx.cs" Inherits="Dian.Web.TableDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="admin-content">

        <div class="am-cf am-padding">
            <div class="am-fl am-cf">
                <strong class="am-text-primary am-text-lg">餐桌管理</strong> / <small>
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
                        桌名
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <input type="text" class="am-input-sm" placeholder="必填" id="tTableName" runat="server" maxlength="25" required>
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*必填</div>
                </div>

            </div>
        </div>

        <div class="am-margin">
            <button type="submit" class="am-btn am-btn-primary am-btn-xs">提交保存</button>
            <button type="button" class="am-btn am-btn-primary am-btn-xs" onclick="self.location.href = '<%= base.UrlReferrer %>'">放弃保存</button>
        </div>

        <label id="lMsg" runat="server" class="am-text-danger"></label>

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

    </div>

</asp:Content>
