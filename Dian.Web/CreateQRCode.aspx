<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Background.Master" AutoEventWireup="true" CodeBehind="CreateQRCode.aspx.cs" Inherits="Dian.Web.CreateQRCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="admin-content">

        <div class="am-cf am-padding">
            <div class="am-fl am-cf">
                <strong class="am-text-primary am-text-lg">生成二维码</strong>  <small>
                    <label id="lTypeName" runat="server"></label>
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
                        桌号
                    </div>
                    <div class="am-u-sm-10 am-u-md-6">
                        <input type="number" class="am-input-sm" placeholder="必填" id="tTableId" min="1" max="1000" required>
                    </div>
                    <div class="am-hide-sm-only am-u-md-4">*必填</div>
                </div>

            </div>
        </div>

        <div class="am-margin">
            <button type="submit" class="am-btn am-btn-primary am-btn-xs" onclick="beforeCreateQRCode();">生成二维码</button>
            <button type="button" class="am-btn am-btn-primary am-btn-xs" onclick="self.location.href = '<%= base.UrlReferrer %>'">取消</button>
        </div>

        <label id="lMsg" runat="server" class="am-text-danger"></label>


        <input type="hidden" id="hTableId" runat="server" />

        <script type="text/javascript">

            function beforeCreateQRCode() {
                $('#<%= this.hTableId.ClientID %>').val($('#tTableId').val());
            }

        </script>

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

    </div>

</asp:Content>
