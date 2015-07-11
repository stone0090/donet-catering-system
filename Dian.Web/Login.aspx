<%@ Page Title="" Language="C#" MasterPageFile="TheFrontDeskShow.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Dian.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />

    <div class="am-form">

        <div class="am-g">
            <div class="am-u-md-3 am-hide-sm-only">&nbsp;</div>
            <div class="am-u-md-6 am-u-sm-12 am-form-group">
                <label for="doc-vld-name">账号：</label>
                <input type="text" id="tName" runat="server" minlength="3" maxlength="20" placeholder="输入用户名" class="am-form-field" required />
            </div>
            <div class="am-u-md-3 am-hide-sm-only"></div>
        </div>

        <div class="am-g">
            <div class="am-u-md-3 am-hide-sm-only">&nbsp;</div>
            <div class="am-u-md-6 am-u-sm-12 am-form-group">
                <label for="doc-vld-name">密码：</label>
                <input type="password" id="tPassword" runat="server" minlength="3" maxlength="20" placeholder="输入密码" class="am-form-field" required />
            </div>
            <div class="am-u-md-3 am-hide-sm-only"></div>
        </div>

        <div class="am-g">
            <div class="am-u-md-3 am-hide-sm-only">&nbsp;</div>
            <div class="am-u-md-6 am-u-sm-12 am-form-group">
                <button type="submit" class="am-btn am-btn-primary am-btn-default">登陆</button>
                <button type="button" class="am-btn am-btn-primary am-btn-default" onclick="self.location.href = '<%= base.UrlReferrer %>'">取消</button>
            </div>
            <div class="am-u-md-3 am-hide-sm-only"></div>
        </div>

        <div class="am-g">
            <div class="am-u-md-3 am-hide-sm-only">&nbsp;</div>
            <div class="am-u-md-6 am-u-sm-12 am-form-group">
                <label id="lMsg" runat="server" class="am-text-warning"></label>
            </div>
            <div class="am-u-md-3 am-hide-sm-only"></div>
        </div>

    </div>

    <br />
    <br />
    <br />
    <br />

</asp:Content>
