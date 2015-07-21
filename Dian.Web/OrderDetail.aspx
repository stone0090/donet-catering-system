<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Background.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="Dian.Web.OrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="admin-content">

        <div class="am-cf am-padding">
            <div class="am-fl am-cf">
                <strong class="am-text-primary am-text-lg">订单详情</strong> / <small>
                    <label id="lTableId" runat="server">桌号</label>
                </small>
            </div>
        </div>

        <div class="am-g">
            <div class="am-u-sm-12 am-u-md-12">
                <button type="button" class="am-btn am-btn-default am-btn-xs" onclick="self.location.href = '<%= base.UrlReferrer %>'">返回上一页</button>
                <button type="button" class="am-btn am-btn-default am-btn-xs order-status" onclick="beforeConfirmAll()">全部确认</button>
                <button type="button" class="am-btn am-btn-default am-btn-xs order-status" onclick="beforeFinishAll()">全部上菜</button>
            </div>
        </div>

        <div class="am-g">
            <div class="am-u-sm-12" runat="server" id="divUnconfirm">
                <table class="am-table am-table-bd am-table-striped">
                    <thead>
                        <tr>
                            <th>状态</th>
                            <th>菜名</th>
                            <th>单价</th>
                            <th>份数</th>
                            <th class="order-status">操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rUnconfirm">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <span class="am-text-warning">未确认</span></td>
                                    <td><%# Eval("FOOD_NAME") %></td>
                                    <td><%# Eval("PRICE") %></td>
                                    <td><%# Eval("COUNT") %></td>
                                    <td class="order-status">
                                        <button type="button" class="am-btn am-btn-default am-btn-xs am-text-danger" onclick="beforeCancel('<%# Eval("LIST_ID") %>');"><span class="am-icon-trash-o"></span>取消</button>
                                        <button type="button" class="am-btn am-btn-default am-btn-xs am-text-warning" onclick="beforeConfirm('<%# Eval("LIST_ID") %>');"><span class="am-icon-check"></span>确认</button>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater runat="server" ID="rConfirm">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <span class="am-text-secondary">烹饪中</span></td>
                                    <td><%# Eval("FOOD_NAME") %></td>
                                    <td><%# Eval("PRICE") %></td>
                                    <td><%# Eval("COUNT") %></td>
                                    <td class="order-status">
                                        <button type="button" class="am-btn am-btn-default am-btn-xs am-text-danger" onclick="beforeCancel('<%# Eval("LIST_ID") %>');"><span class="am-icon-trash-o"></span>取消</button>
                                        <button type="button" class="am-btn am-btn-default am-btn-xs am-text-secondary" onclick="beforeFinish('<%# Eval("LIST_ID") %>');"><span class="am-icon-check"></span>上菜</button>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater runat="server" ID="rFinish">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <span class="am-text-success">已上菜</span></td>
                                    <td><%# Eval("FOOD_NAME") %></td>
                                    <td><%# Eval("PRICE") %></td>
                                    <td><%# Eval("COUNT") %></td>
                                    <td class="order-status">
                                        <button type="button" class="am-btn am-btn-default am-btn-xs am-text-danger" onclick="beforeCancelFinish('<%# Eval("LIST_ID") %>');"><span class="am-icon-trash-o"></span>取消上菜</button>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td colspan="5">
                                <label class="am-text-danger am-fr">合计：￥ <span runat="server" id="sTotalPrice"></span>元</label></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

        <label id="lMsg" runat="server" class="am-text-danger"></label>
        <input type="hidden" runat="server" id="hOrderStatus" />
        <input type="hidden" runat="server" id="hOperation" />

    </div>

    <script type="text/javascript">

        $(window).bind('load', function () {
            if ($('#<%= this.hOrderStatus.ClientID %>').val() !== '1')
                $('.order-status').hide();
        });

        function beforeConfirmAll() {
            $('#<%= this.hOperation.ClientID %>').val('confirmall');
            $('#' + form1).submit();
        }

        function beforeFinishAll() {
            $('#<%= this.hOperation.ClientID %>').val('finishall');
            $('#' + form1).submit();
        }

        function beforeCancel(id) {
            $('#<%= this.hOperation.ClientID %>').val('cancel|' + id);
            $('#' + form1).submit();
        }

        function beforeConfirm(id) {
            $('#<%= this.hOperation.ClientID %>').val('confirm|' + id);
            $('#' + form1).submit();
        }

        function beforeFinish(id) {
            $('#<%= this.hOperation.ClientID %>').val('finish|' + id);
            $('#' + form1).submit();
        }

        function beforeCancelFinish(id) {
            $('#<%= this.hOperation.ClientID %>').val('cancelfinish|' + id);
            $('#' + form1).submit();
        }

        function beforeDelete(id) {
            if (confirm("您确定要删除本条记录吗？\r\n删除点击“确定”，不删除点击“取消”。")) {
                $('#<%= this.hDeleteId.ClientID %>').val(id);
                $('#' + form1).submit();
            }
        }

    </script>

</asp:Content>
