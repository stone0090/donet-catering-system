<%@ Page Title="" Language="C#" MasterPageFile="Background.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="Dian.Web.OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="admin-content">

        <div class="am-cf am-padding">
            <div class="am-fl am-cf">
                <strong class="am-text-primary am-text-lg">订单管理</strong> / <small>
                    <label runat="server" id="lType">列表</label></small>
            </div>
        </div>

        <div class="am-g">
            <div class="am-u-sm-12 am-u-md-12">
                <asp:DropDownList ID="ddlRestaurant" runat="server" AutoPostBack="true" data-am-selected="{btnSize: 'xs'}" required>
                </asp:DropDownList>
                <button type="button" class="am-btn am-btn-default am-btn-xs" onclick="beforeSearch(0)">全部订单</button>
                <button type="button" class="am-btn am-btn-secondary am-btn-xs" onclick="beforeSearch(1)">未完成的订单</button>
                <button type="button" class="am-btn am-btn-success am-btn-xs" onclick="beforeSearch(2)">已完成的订单</button>
                <button type="button" class="am-btn am-btn-danger am-btn-xs" onclick="beforeSearch(3)">已取消的订单</button>
            </div>
        </div>

        <div class="am-g">
            <div class="am-u-sm-12">
                <div class="am-form">
                    <table class="am-table am-table-striped am-table-hover table-main">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th class="restaurant-name">店名</th>
                                <th>状态</th>
                                <th>桌号</th>
                                <th>总价</th>
                                <th>数量</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("ORDER_ID") %></td>
                                        <td class="restaurant-name"><%# Eval("RESTAURANT_NAME") %></td>
                                        <td><%# GetStatusName(Eval("ORDER_FLAG").ToString()) %></td>
                                        <td><%# Eval("TABLE_ID") %></td>
                                        <td><%# Eval("PRICE") %></td>
                                        <td>
                                            <span class="am-badge am-badge-default"><%# Eval("ALLORDER") %> </span>
                                            <span class="am-badge am-badge-success"><%# Eval("FINISH") %> </span>
                                            <span class="am-badge am-badge-secondary"><%# Eval("CONFIRM") %> </span>
                                            <span class="am-badge am-badge-warning"><%# Eval("UNCONFIRM") %> </span>
                                        </td>
                                        <td>
                                            <div class="am-btn-toolbar">
                                                <div class="am-btn-group am-btn-group-xs">
                                                    <button type="button" class="am-btn am-btn-default am-btn-xs am-text-secondary" onclick="beforeDetail('<%# Eval("ORDER_ID") %>');"><span class="am-icon-pencil-square-o"></span>详情</button>
                                                    <button type="button" <%# GetButtonStyle(Eval("ORDER_FLAG").ToString()) %> class="am-btn am-btn-default am-btn-xs am-text-success" onclick="beforeFinish('<%# Eval("ORDER_ID") %>');"><span class="am-icon-check"></span>完成订单</button>
                                                    <button type="button" <%# GetButtonStyle(Eval("ORDER_FLAG").ToString()) %> class="am-btn am-btn-default am-btn-xs am-text-danger" onclick="beforeCancel('<%# Eval("ORDER_ID") %>');"><span class="am-icon-trash-o"></span>取消订单</button>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                    <div class="am-cf">
                        <label id="labelPage"></label>
                        <div class="am-fr" id="divPage">
                            <ul class="am-pagination">
                                <li><a id="aFirst" href="#">第一页</a></li>
                                <li><a id="aPrev" href="#">上一页</a></li>
                                <li><a id="aCur" href="#">1/3</a></li>
                                <li><a id="aNext" href="#">下一页</a></li>
                                <li><a id="aLast" href="#">最末页</a></li>
                            </ul>
                        </div>
                    </div>

                    <label id="lMsg" runat="server" class="am-text-warning"></label>

                </div>
            </div>
        </div>
        <br />
        <br />
    </div>


    <input type="hidden" id="hCurPageNum" runat="server" />
    <input type="hidden" id="hOrderStatus" runat="server" />
    <input type="hidden" id="hOperationId" runat="server" />

    <script type="text/javascript">

        $(window).bind('load', function () {
            // 分页代码
            curPage = parseInt('<%= CurPage.ToString() %>');
            totalCount = parseInt('<%= TotalCount.ToString() %>');
            pageCount = parseInt('<%= PageCount.ToString() %>');
            if (totalCount <= 0) {
                $("#labelPage").text("暂无数据，请新增！");
                $("#divPage").hide();
            } else {
                if (pageCount === 1) {
                    $("#divPage").hide();
                } else {
                    if (curPage === 1) {
                        $("#aFirst").parent().addClass("am-disabled");
                        $("#aPrev").parent().addClass("am-disabled");
                    } else if (curPage === pageCount) {
                        $("#aNext").parent().addClass("am-disabled");
                        $("#aLast").parent().addClass("am-disabled");
                    }
                    $("#aCur").text(curPage + " / " + pageCount);
                    $("#aFirst").attr("href", "javascript:beforePageTurning(1)");
                    $("#aPrev").attr("href", "javascript:beforePageTurning(" + (curPage - 1) + ")");
                    $("#aNext").attr("href", "javascript:beforePageTurning(" + (curPage + 1) + ")");
                    $("#aLast").attr("href", "javascript:beforePageTurning(" + pageCount + ")");
                }
                if (totalCount > 8) {
                    $("#labelPage").text("每页 8 条，共" + totalCount + "条记录");
                } else {
                    $("#labelPage").text("共 " + totalCount + " 条记录");
                }
            }
        });

        function beforePageTurning(num) {
            $('#<%= this.hOperationId.ClientID %>').val('');
            $('#<%= this.hCurPageNum.ClientID %>').val(num);
            $('#' + form1).submit();
        }

        function beforeSearch(type) {
            $('#<%= this.hOperationId.ClientID %>').val('');
            $('#<%= this.hOrderStatus.ClientID %>').val(type);
            $('#' + form1).submit();
        }

        function beforeDetail(id) {
            self.location.href = 'OrderDetail.aspx?id=' + id;
        }

        function beforeFinish(id) {
            if (confirm("您确定要完成该订单吗？\r\n完成订单点击“确定”，否则点击“取消”。")) {
                $('#<%= this.hOperationId.ClientID %>').val('finish|' + id);
                $('#' + form1).submit();
            }
        }

        function beforeCancel(id) {
            if (confirm("您确定要取消该订单吗？\r\n取消订单点击“确定”，否则点击“取消”。")) {
                $('#<%= this.hOperationId.ClientID %>').val('cancel|' + id);
                $('#' + form1).submit();
            }
        }

    </script>

</asp:Content>
