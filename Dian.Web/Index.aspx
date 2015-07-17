<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Dian.Web.Index" %>

<!doctype html>
<html class="no-js">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>XX系统</title>
    <meta name="description" content="XX系统" />
    <meta name="keywords" content="index" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta name="renderer" content="webkit" />
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link rel="stylesheet" href="assets/css/amazeui.min.css" />
    <link rel="stylesheet" href="assets/css/admin.css" />
</head>
<body>

    <!--[if lte IE 9]>
    <p class="browsehappy">你正在使用<strong>过时</strong>的浏览器，系统暂不支持。 请 <a href="http://browsehappy.com/" target="_blank">升级浏览器</a>
      以获得更好的体验！</p>
    <![endif]-->
    <!--[if lt IE 9]>
    <script src="http://libs.baidu.com/jquery/1.11.1/jquery.min.js"></script>
    <script src="http://cdn.staticfile.org/modernizr/2.8.3/modernizr.js"></script>
    <script src="assets/js/amazeui.ie8polyfill.min.js"></script>
    <![endif]-->
    <!--[if (gte IE 9)|!(IE)]><!-->
    <script src="assets/js/jquery.min.js"></script>
    <!--<![endif]-->

    <script src="assets/js/amazeui.min.js"></script>
    <script src="assets/js/app.js"></script>
    <script src="Scripts/jquery-extend.js"></script>
    <script src="Scripts/common.js"></script>
    <script src="Scripts/index.js"></script>

    <form id="form1" runat="server">

        <header class="am-topbar admin-header">
            <div class="am-topbar-brand">
                <strong>XX系统</strong> <small>菜单</small>
            </div>
            <button type="button" class="am-topbar-btn am-topbar-toggle am-btn am-btn-sm am-btn-success am-show-sm-only" data-am-collapse="{target: '#topbar-collapse'}"><span class="am-sr-only">导航切换</span> <span class="am-icon-bars"></span></button>
            <div class="am-collapse am-topbar-collapse" id="topbar-collapse">
                <ul class="am-nav am-nav-pills am-topbar-nav am-topbar-right admin-header-list">
                    <li><a id="aLogin" runat="server" href="Login.aspx">登陆</a></li>
                </ul>
            </div>
        </header>

        <div class="am-cf admin-main">
            <!-- sidebar start -->
            <div class="admin-sidebar am-offcanvas" id="admin-offcanvas">
                <div class="am-offcanvas-bar admin-offcanvas-bar">
                    <ul class="am-list admin-sidebar-list">
                        <li><a href="javascript:loadFoodByType('0');">全部</a></li>
                        <asp:Repeater ID="repeater1" runat="server">
                            <ItemTemplate>
                                <li><a href="javascript:loadFoodByType('<%# Eval("FOOD_TYPE_ID") %>');">
                                    <%# Eval("FOOD_TYPE_NAME") %>
                                    <label id="<%# "lFoodTypeCount" + Eval("FOOD_TYPE_ID").ToString() %>" class="am-badge am-badge-warning am-margin-right am-fr"></label>
                                </a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="am-panel am-panel-default admin-sidebar-panel">
                        <div class="am-panel-bd">
                            <p><span class="am-icon-bookmark"></span>公告</p>
                            <p>祝您：健康饮食，健康生活。</p>
                        </div>
                    </div>
                </div>
            </div>
            <!-- sidebar end -->
            <!-- content start -->
            <div id="divMenu">
                <div class="admin-content">
                    <div data-am-widget="list_news" class="am-list-news am-list-news-default am-no-layout">
                        <div class="am-list-news-bd">
                            <ul class="am-list am-avg-sm-1 am-avg-md-1 am-thumbnails" id="uiFootList">
                                <!--缩略图在标题左边-->

                                <asp:Repeater ID="repeater2" runat="server">
                                    <ItemTemplate>
                                        <li class="am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-left" id="<%# "liFood" + Eval("FOOD_ID").ToString() %>" foodid="<%# Eval("FOOD_ID") %>" foodtypeid="<%# Eval("FOOD_TYPE_ID") %>" foodname="<%# Eval("FOOD_NAME") %>" foodimage="<%# Eval("FOOD_IMAGE1") %>" foodprice="<%# Eval("PRICE") %>">
                                            <div class="am-u-sm-4 am-list-thumb">
                                                <a data-am-modal="{target: '#divRemark', width: 260, height: 450}" href="javascript:loadRemark('<%# Eval("FOOD_ID") %>')">
                                                    <img src="<%# Eval("FOOD_IMAGE_NAIL1") %>" alt="<%# Eval("FOOD_NAME") %>" class="am-img-thumbnail">
                                                </a>
                                                &nbsp;
                                            </div>
                                            <div class="am-u-sm-8 am-list-main">
                                                <h3 class="am-list-item-hd">
                                                    <a data-am-modal="{target: '#divRemark', width: 260, height: 450}" href="javascript:loadRemark('<%# Eval("FOOD_ID") %>')"><%# Eval("FOOD_NAME") %></a>
                                                </h3>
                                                <div class="am-list-item-text"><%# Eval("DESCRIPTION") %></div>
                                                <div style="margin-top: 10px;">
                                                    <label class="am-text-danger">￥<%# Eval("PRICE") %></label>
                                                    <span class="am-fr">
                                                        <button type="button" class="am-btn am-btn-success am-btn-xs" onclick="cutFood('<%# Eval("FOOD_ID") %>');">减</button>
                                                        <label id="<%# "lFoodCount" + Eval("FOOD_ID").ToString() %>">0</label>
                                                        <button type="button" class="am-btn am-btn-success am-btn-xs" onclick="addFood('<%# Eval("FOOD_ID") %>');">加</button>
                                                    </span>
                                                </div>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div id="divCart" style="display: none;">

                <div class="admin-content" style="margin-top: 10px;">

                    <div class="am-g">
                        <div class="am-u-sm-12">
                            <div class="am-list-item-text">已确认的菜单</div>
                            <table id="tConfirmCart" class="am-table am-table-bd am-table-striped admin-content-table">
                                <thead>
                                    <tr>
                                        <th>菜名</th>
                                        <th>单价</th>
                                        <th>份数</th>
                                        <th>状态</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                            <hr />
                        </div>
                        <div class="am-u-sm-12">
                            <div class="am-list-item-text">未确认的菜单</div>
                            <table id="tUnconfirmCart" class="am-table am-table-bd am-table-striped">
                                <thead>
                                    <tr>
                                        <th>菜名</th>
                                        <th>单价</th>
                                        <th>份数</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <div class="am-g">
                        <div style="text-align: center;">
                            <button type="button" id="btnClearCart" class="am-btn am-btn-success am-btn-xl" onclick="clearCart();">清空购物车</button>
                            <button type="button" id="btnCreateOrder" class="am-btn am-btn-warning am-btn-xl" onclick="createOrder()"><span class="am-icon-shopping-cart"></span>&nbsp;<span id="sCreateOrder">立即下单</span></button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- content end -->
        </div>

        <a href="#" class="am-show-sm-only admin-menu" data-am-offcanvas="{target: '#admin-offcanvas'}" style="z-index: 9999;">
            <span class="am-icon-btn am-icon-th-list"></span>
        </a>

        <!-- 订单ID -->
        <input type="hidden" id="hOrderId" runat="server" />

        <!-- “已下单的数据”和“未确认的数据”(json格式) -->
        <input type="hidden" id="hOrderData" runat="server" />
        <input type="hidden" id="hUnconfirmData" runat="server" />

    </form>

    <br />

    <!-- Navbar -->
    <div data-am-widget="navbar" class="am-navbar am-cf am-navbar-default" id="">
        <ul class="am-navbar-nav am-cf am-avg-sm-2 am-thumbnails">
            <li>
                <a href="javascript:showMenu();" style="line-height: 49px;">菜单
                </a>
            </li>
            <li>
                <a href="javascript:showCart();" style="line-height: 49px;">购物车，合计&nbsp;<span id="sTotalPrice">0</span>&nbsp;元
                </a>
            </li>
        </ul>
    </div>

    <!-- remark -->
    <div class="am-modal am-modal-no-btn" tabindex="-1" id="divRemark">
        <div class="am-modal-dialog">
            <div class="am-modal-hd">
                <input type="hidden" id="remarkFoodId" />
                <span id="remarkFoodName"></span>
                <a href="javascript: void(0)" class="am-close am-close-spin" data-am-modal-close>&times;</a>
            </div>
            <div class="am-modal-bd">
                <hr />
                <div>
                    <img id="remarkFoodImage" src="" alt="" class="am-img-responsive am-img-thumbnail" style="height: 200px;">
                    <br />
                    <div class="am-form" style="text-align: left;">
                        <div class="am-form-group">
                            <div>口味</div>
                            <div>
                                <button type="button" class="am-btn am-btn-default am-btn-xs" id="btnTaste1" value="1" onclick="setTaste(this);">免辣</button>
                                <button type="button" class="am-btn am-btn-default am-btn-xs" id="btnTaste2" value="2" onclick="setTaste(this);">微辣</button>
                                <button type="button" class="am-btn am-btn-default am-btn-xs" id="btnTaste3" value="3" onclick="setTaste(this);">中辣</button>
                                <button type="button" class="am-btn am-btn-default am-btn-xs" id="btnTaste4" value="4" onclick="setTaste(this);">特辣</button>
                            </div>
                        </div>
                        <div class="am-form-group">
                            <div>备注</div>
                            <div>
                                <input type="text" id="remarkFoodRemark" class="am-input-sm" placeholder="给店家交代点什么" maxlength="50" required>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        var hUnconfirmData = '<%= this.hUnconfirmData.ClientID %>';
        var hOrderData = '<%= this.hOrderData.ClientID %>';
        var hOrderId = '<%= this.hOrderId.ClientID %>';
        var restaurantId = <%= RestaurantId %>;
        var tableId = <%= TableId %>;

        //备注窗口关闭事件
        $('#divRemark').on('closed.modal.amui', function () {
            var id = $('#remarkFoodId').val();
            var oUnconfirmData = getJsonObject(hUnconfirmData);
            if (oUnconfirmData[id] === undefined) {
                oUnconfirmData[id] = {};
                oUnconfirmData[id].COUNT = 0;
                oUnconfirmData[id].PRICE = parseFloat($('#liFood' + id).attr('foodprice'));
                oUnconfirmData[id].FOOD_NAME = $('#liFood' + id).attr('foodname');
            }
            oUnconfirmData[id].TASTE = $('.am-active').attr('value');
            oUnconfirmData[id].REMARK = $('#remarkFoodRemark').val();
            $('#' + hUnconfirmData).val(JSON.stringify(oUnconfirmData));
            bindCart();
            updateOrder(id, 'remark');
        });

    </script>

</body>
</html>
