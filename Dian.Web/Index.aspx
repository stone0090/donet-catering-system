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
                        <li><a href="javascript:loadFoodTypeData('0');">全部</a></li>
                        <asp:Repeater ID="repeater1" runat="server">
                            <ItemTemplate>
                                <li><a href="javascript:loadFoodTypeData('<%# Eval("FOOD_TYPE_ID") %>');">
                                    <%# Eval("FOOD_TYPE_NAME") %>
                                    <label id="<%# "lFoodType" + Eval("FOOD_TYPE_ID").ToString() %>" class="am-badge am-badge-warning am-margin-right am-fr"></label>
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
                                        <li class="am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-left" id="<%# "liFood" + Eval("FOOD_ID").ToString() %>" foodid="<%# Eval("FOOD_ID") %>" foodtypeid="<%# Eval("FOOD_TYPE_ID") %>" foodprice="<%# Eval("PRICE") %>" foodname="<%# Eval("FOOD_NAME") %>" foodimage="<%# Eval("FOOD_IMAGE1") %>">
                                            <div class="am-u-sm-4 am-list-thumb">
                                                <a href="#">
                                                    <img src="<%# Eval("FOOD_IMAGE_NAIL1") %>" alt="<%# Eval("FOOD_NAME") %>" class="am-img-thumbnail">
                                                </a>
                                                &nbsp;
                                            </div>
                                            <div class="am-u-sm-8 am-list-main">
                                                <h3 class="am-list-item-hd">
                                                    <a href="#"><%# Eval("FOOD_NAME") %></a>
                                                </h3>
                                                <div class="am-list-item-text"><%# Eval("DESCRIPTION") %></div>
                                                <div style="margin-top: 10px;">
                                                    <label class="am-text-danger">￥<%# Eval("PRICE") %></label>
                                                    <span class="am-fr">
                                                        <button type="button" class="am-btn am-btn-success am-btn-xs" onclick="cutFood('<%# Eval("FOOD_ID") %>');">减</button>
                                                        <label id="<%# "lFood" + Eval("FOOD_ID").ToString() %>">0</label>
                                                        <button type="button" class="am-btn am-btn-success am-btn-xs" onclick="addFood('<%# Eval("FOOD_ID") %>');">加</button>
                                                        <button type="button" class="am-btn am-btn-warning am-btn-xs js-modal-open" data-am-modal="{target: '#divRemark', width: 280, height: 450}" onclick="loadRemark('<%# Eval("FOOD_ID") %>');">备注</button>
                                                    </span>
                                                </div>
                                                <input type="hidden" id="<%# "hFoodRemark" + Eval("FOOD_ID").ToString() %>" />
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
                            <table id="tCart" class="am-table am-table-bd am-table-striped admin-content-table">
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <div class="am-g">
                        <div style="text-align: center;">
                            <button type="button" class="am-btn am-btn-success am-btn-xl" onclick="clearCart();">清空购物车</button>
                            <button type="button" class="am-btn am-btn-warning am-btn-xl"><span class="am-icon-shopping-cart"></span>&nbsp;立即下单</button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- content end -->
        </div>

        <a href="#" class="am-show-sm-only admin-menu" data-am-offcanvas="{target: '#admin-offcanvas'}" style="z-index: 9999;">
            <span class="am-icon-btn am-icon-th-list"></span>
        </a>

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
                <a href="javascript:showCart();" style="line-height: 49px;">购物车，合计&nbsp;<span id="sTotalPrice">0.00</span>&nbsp;元
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
                                <input type="text" id="remarkFoodDetail" class="am-input-sm" placeholder="给店家交代点什么" maxlength="50" required>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        //显示菜单
        function showMenu() {
            $('#divMenu').show();
            $('#divCart').hide();
        }

        //显示购物车
        function showCart() {
            $('#divMenu').hide();
            $('#divCart').show();
        }

        //按类型显示菜品
        function loadFoodTypeData(type) {
            showMenu();
            $('#uiFootList').find('li').each(function (index) {
                $(this).show();
                if (type !== '0' && type !== $(this).attr('foodtypeid'))
                    $(this).hide();
            });
        }

        //简单一道菜
        function cutFood(id) {
            var count = parseInt($('#lFood' + id).text());
            if (count > 0) {
                $('#lFood' + id).text(count - 1);
                recal();
            }
        }

        //新增一道菜
        function addFood(id) {
            var count = parseInt($('#lFood' + id).text());
            $('#lFood' + id).text(count + 1);
            recal();
        }

        //重算所有数量和价格
        function recal() {
            //清除购物车
            $('#tCart tbody').empty();
            //清除总价格
            $('#sTotalPrice').text('0.00');
            //清除分类数量
            $('label[id^=lFoodType]').each(function () {
                $(this).text('');
            });

            var totalPrice = 0.00;
            $('#uiFootList').find('li').each(function (index) {
                var id = $(this).attr('foodid');
                var name = $(this).attr('foodname');
                var price = parseFloat($(this).attr('foodprice'));
                var count = parseInt($('#lFood' + id).text());
                if (count > 0) {
                    var typeCount = 0;
                    var type = $(this).attr('foodtypeid');
                    if (!$.isEmpty($('#lFoodType' + type).text()))
                        typeCount = parseInt($('#lFoodType' + type).text());
                    $('#lFoodType' + type).text(typeCount + count);
                    totalPrice += price * count;
                    recalCart(id, name, price, count);
                }
            });
            $('#sTotalPrice').text(totalPrice);
            $('#tCart').append('<tr><td colspan="4"><label class="am-text-danger am-fr">合计：￥' + totalPrice + '元</label></td></tr>');
        }

        //重算购物车数据
        function recalCart(id, name, price, count) {
            $('#tCart').append(
                "<tr>" +
                "<td>" + name + "</td>" +
                "<td>单价：&nbsp;<label>" + price + "</label>&nbsp;</td>" +
                "<td>份数：" +
                '<button type="button" class="am-btn am-btn-success am-btn-xs" onclick="cutFood(\'' + id + '\');">减</button>' +
                "&nbsp;<label>" + count + "</label>&nbsp;" +
                '<button type="button" class="am-btn am-btn-success am-btn-xs" onclick="addFood(\'' + id + '\');">加</button>' +
                "</td>" +
                "</tr>");

            var strRemark = $('#hFoodRemark' + id).val();
            if (!$.isEmpty(strRemark)) {
                var oRemark = JSON.parse(strRemark);
                var result = '';
                if (!$.isEmpty(oRemark.taste)) {
                    if (oRemark.taste === '1')
                        result = "口味：免辣";
                    else if (oRemark.taste === '2')
                        result = "口味：微辣";
                    else if (oRemark.taste === '3')
                        result = "口味：中辣";
                    else if (oRemark.taste === '4')
                        result = "口味：特辣";
                }
                if (!$.isEmpty(oRemark.detail)) {
                    if (!$.isEmpty(result))
                        result += "，";
                    result += "备注：" + oRemark.detail;
                }
                if (!$.isEmpty(result))
                    $('#tCart').append('<tr><td></td><td colspan="3" class="am-list-item-text">' + result + '</td></tr>');
            }
        }

        //清空购物车
        function clearCart() {
            $('label[id^=lFood]').each(function () {
                $(this).text('0');
            });
            recal();
        }

        //备注窗口初始化
        function loadRemark(id) {
            $('#remarkFoodDetail').val('');
            $('button[id^=btnTaste]').each(function () {
                $(this).removeClass('am-active');
            });

            var id = $('#liFood' + id).attr('foodid');
            var name = $('#liFood' + id).attr('foodname');
            var price = parseFloat($('#liFood' + id).attr('foodprice'));
            var count = parseInt($('#liFood' + id).text());
            var image = $('#liFood' + id).attr('foodimage');
            $('#remarkFoodId').val(id);
            $('#remarkFoodName').text(name);
            $('#remarkFoodImage').attr('src', image);
            $('#remarkFoodImage').attr('alt', name);
            var strRemark = $('#hFoodRemark' + id).val();
            if (!$.isEmpty(strRemark)) {
                var oRemark = JSON.parse(strRemark);
                if (!$.isEmpty(oRemark.taste))
                    $('#btnTaste' + oRemark.taste).addClass('am-active');
                if (!$.isEmpty(oRemark.detail))
                    $('#remarkFoodDetail').val(oRemark.detail);
            }
        }

        function setTaste(that) {
            $('button[id^=btnTaste]').each(function () {
                $(this).removeClass('am-active');
            });
            $(that).addClass('am-active');
        }

        //备注窗口关闭事件
        $('#divRemark').on('closed.modal.amui', function () {
            var id = $('#remarkFoodId').val();
            var oRemark = {};
            oRemark.id = id;
            oRemark.taste = $('.am-active').attr('value');
            oRemark.detail = $('#remarkFoodDetail').val();
            $('#hFoodRemark' + id).val(JSON.stringify(oRemark));
            recal();
        });

    </script>
</body>
</html>
