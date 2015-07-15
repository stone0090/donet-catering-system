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
                            <table id="tConfirmCart" class="am-table am-table-bd am-table-striped admin-content-table">
                                <thead>
                                    <tr>
                                        <th colspan="4">已确认的菜单</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                        <div class="am-u-sm-12">
                            <table id="tUnconfirmCart" class="am-table am-table-bd am-table-striped">
                                <thead>
                                    <tr>
                                        <th colspan="4">未确认的菜单</th>
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
                            <button type="button" id="btnCreateOrder" class="am-btn am-btn-warning am-btn-xl" onclick="CreateOrder()"><span class="am-icon-shopping-cart"></span>&nbsp;立即下单</button>
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

        <!-- “已下单的数据”和“购物车所有数据”(json格式) -->
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
                                <input type="text" id="remarkFoodRemark" class="am-input-sm" placeholder="给店家交代点什么" maxlength="50" required>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        $(function () {
            //从“已下单”的数据中，过滤出“未确认”的数据，添加到hUnconfirmData中。(因为“未确认”的数据是可以修改的，所以要把“已下单”和“未确认”的数据区别开来操作)
            var strOrderData = $('#<%= this.hOrderData.ClientID %>').val();
            if (!$.isEmpty(strOrderData)) {
                var oOrderData = JSON.parse(strOrderData);
                var oUnconfirmData = {};
                for (var oOrderDetail in oOrderData) {
                    if ($.isEmpty(oOrderDetail.CONFIRM_TIME)) {
                        oUnconfirmData[oOrderDetail.FOOD_ID] = {};
                        oUnconfirmData[oOrderDetail.FOOD_ID].COUNT = oOrderDetail.COUNT;
                        oUnconfirmData[oOrderDetail.FOOD_ID].PRICE = oOrderDetail.PRICE;
                        oUnconfirmData[oOrderDetail.FOOD_ID].TASTE = oOrderDetail.TASTE;
                        oUnconfirmData[oOrderDetail.FOOD_ID].REMARK = oOrderDetail.REMARK;
                        oUnconfirmData[oOrderDetail.FOOD_ID].FOOD_NAME = oOrderDetail.FOOD_NAME;
                    }
                }
                $('#<%= this.hUnconfirmData.ClientID %>').val(JSON.stringify(oUnconfirmData));
            }

            //绑定点菜数量
            bindMenu();

            //绑定购物车数据
            bindCart();
        });

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
        function loadFoodByType(type) {
            showMenu();
            $('#uiFootList').find('li').each(function (index) {
                $(this).show();
                if (type !== '0' && type !== $(this).attr('foodtypeid'))
                    $(this).hide();
            });
        }

        //减少一道菜
        function cutFood(id) {
            var oUnconfirmData = getJsonObject('<%= this.hUnconfirmData.ClientID %>');
            if (oUnconfirmData[id] !== undefined && oUnconfirmData[id].COUNT > 0) {
                oUnconfirmData[id].COUNT = oUnconfirmData[id].COUNT - 1;
                $('#<%= this.hUnconfirmData.ClientID %>').val(JSON.stringify(oUnconfirmData));
                bindMenu();
                bindCart();
            }
        }

        //新增一道菜
        function addFood(id) {
            var oUnconfirmData = getJsonObject('<%= this.hUnconfirmData.ClientID %>');
            if (oUnconfirmData[id] !== undefined) {
                oUnconfirmData[id].COUNT = oUnconfirmData[id].COUNT + 1;
            } else {
                oUnconfirmData[id] = {};
                oUnconfirmData[id].COUNT = 1;
                oUnconfirmData[id].PRICE = $('#liFood' + id).attr('foodprice');
                oUnconfirmData[id].FOOD_NAME = $('#liFood' + id).attr('foodname');
            }
            $('#<%= this.hUnconfirmData.ClientID %>').val(JSON.stringify(oUnconfirmData));
            bindMenu();
            bindCart();
        }

        //清空购物车
        function clearCart() {
            $('#<%= this.hUnconfirmData.ClientID %>').val('');
            bindMenu();
            bindCart();
        }

        function bindMenu() {

            //0、清除菜单数量
            $('label[id^=lFoodCount]').each(function () {
                $(this).text('0');
            });

            //1、绑定“已确认”的菜单
            var foodCount = 0;
            for (var oOrderDetail in getJsonObject('<%= this.hOrderData.ClientID %>')) {
                if (!$.isEmpty(oOrderDetail.CONFIRM_TIME)) {
                    foodCount = parseInt($('#lFoodCount' + oOrderData.FOOD_ID).text());
                    $('#lFoodCount' + oOrderDetail.FOOD_ID).text(foodCount + oOrderDetail.COUNT);
                }
            }

            //2、绑定“未确认”的菜单
            var oUnconfirmData = getJsonObject('<%= this.hUnconfirmData.ClientID %>');
            for (var foodId in oUnconfirmData) {
                foodCount = parseInt($('#lFoodCount' + foodId).text());
                $('#lFoodCount' + foodId).text(foodCount + oUnconfirmData[foodId].COUNT);
            }

            //3、重新计算菜单分类数量
            recalFoodTypeCount();
        }

        function recalFoodTypeCount() {

            //1、清空分类数据
            $('label[id^=lFoodTypeCount]').each(function () {
                $(this).text('');
            });

            //2、重算分类数据
            $('#uiFootList').find('li').each(function (index) {
                var id = $(this).attr('foodid');
                var foodCount = parseInt($('#lFoodCount' + id).text());
                if (foodCount > 0) {
                    var foodCountTotal = 0;
                    var type = $(this).attr('foodtypeid');
                    if (!$.isEmpty($('#lFoodTypeCount' + type).text()))
                        foodCountTotal = parseInt($('#lFoodTypeCount' + type).text());
                    $('#lFoodTypeCount' + type).text(foodCountTotal + foodCount);
                }
            });

        }

        function bindCart() {

            var totalPrice = 0;

            //0、清除购物车和菜单总价格
            $('#tConfirmCart tbody').empty();
            $('#tUnconfirmCart tbody').empty();
            $('#sTotalPrice').text('0');

            //1、绑定“已确认”的购物车
            for (var oOrderDetail in getJsonObject('<%= this.hOrderData.ClientID %>')) {
                if (!$.isEmpty(oOrderDetail.CONFIRM_TIME)) {
                    $('#tConfirmCart').append(
                        '<tr>' +
                        '<td>' + oOrderDetail.FOOD_NAME + '</td>' +
                        '<td>单价：&nbsp;<label>' + oOrderDetail.PRICE + '</label>&nbsp;</td>' +
                        '<td>份数：&nbsp;<label>' + oOrderDetail.COUNT + '</label>&nbsp;</td>' +
                        '<td>状态：&nbsp;<label>' + getStatus(oOrderDetail) + '</label>&nbsp;</td>' +
                        '</tr>');

                    var remark = getRemark(oOrderDetail);
                    if (!$.isEmpty(remark))
                        $('#tConfirmCart').append('<tr><td></td><td colspan="3" class="am-list-item-text">' + remark + '</td></tr>');

                    totalPrice += oOrderDetail.PRICE * oOrderDetail.COUNT;
                }
            }


            if (totalPrice === 0) {
                $('#tConfirmCart').hide();
            } else {
                $('btnClearCart').text('清空未确认的菜单');
                $('btnCreateOrder').text('加菜');
            }

            //2、绑定“未确认”的购物车
            var oUnconfirmData = getJsonObject('<%= this.hUnconfirmData.ClientID %>');
            for (var foodId in oUnconfirmData) {
                if (oUnconfirmData[foodId].COUNT > 0) {
                    $('#tUnconfirmCart').append(
                        '<tr>' +
                        '<td><a data-am-modal="{target: \'#divRemark\', width: 260, height: 450}" href="javascript:loadRemark(\'' + foodId + '\')">' + oUnconfirmData[foodId].FOOD_NAME + '</a></td>' +
                        '<td>单价：&nbsp;<label>' + oUnconfirmData[foodId].PRICE + '</label>&nbsp;</td>' +
                        '<td>' +
                        '份数：' +
                        '<button type="button" class="am-btn am-btn-success am-btn-xs" onclick="cutFood(\'' + foodId + '\');">减</button>' +
                        '&nbsp;<label>' + oUnconfirmData[foodId].COUNT + '</label>&nbsp;' +
                        '<button type="button" class="am-btn am-btn-success am-btn-xs" onclick="addFood(\'' + foodId + '\');">加</button>' +
                        '</td>' +
                        '</tr>');

                    var remark = getRemark(oUnconfirmData[foodId]);
                    if (!$.isEmpty(remark))
                        $('#tUnconfirmCart').append('<tr><td></td><td colspan="3" class="am-list-item-text">' + remark + '</td></tr>');

                    totalPrice += oUnconfirmData[foodId].PRICE * oUnconfirmData[foodId].COUNT;
                }
            }

            //3、计算总价格
            $('#sTotalPrice').text(totalPrice);
            $('#tUnconfirmCart').append('<tr><td colspan="4"><label class="am-text-danger am-fr">合计：￥' + totalPrice + '元</label></td></tr>');
        }

        function getStatus(oOrderDetail) {
            if (!$.isEmpty(oOrderDetail.CANCEL_TIME))
                return '已取消';
            if (!$.isEmpty(oOrderDetail.FINISH_TIME))
                return '已上菜';
            if (!$.isEmpty(oOrderDetail.CONFIRM_TIME))
                return '已确认';
            if (!$.isEmpty(oOrderDetail.ORDER_TIME))
                return '已下单';
            else return '';
        }

        function getRemark(oOrderDetail) {
            var result = ''

            //添加口味
            if (oOrderDetail.TASTE === '1')
                result = '口味：免辣';
            else if (oOrderDetail.TASTE === '2')
                result = '口味：微辣';
            else if (oOrderDetail.TASTE === '3')
                result = '口味：中辣';
            else if (oOrderDetail.TASTE === '4')
                result = '口味：特辣';
            else result = '';

            //添加备注
            if (!$.isEmpty(oOrderDetail.REMARK)) {
                if (!$.isEmpty(result))
                    result += "，";
                result += "备注：" + oOrderDetail.REMARK;
            }

            return result;
        }


        function loadRemark(id) {

            //清空备注窗口原有的值
            $('#remarkFoodRemark').val('');
            $('button[id^=btnTaste]').each(function () {
                $(this).removeClass('am-active');
            });

            //初始化备注窗口新的值
            var id = $('#liFood' + id).attr('foodid');
            var name = $('#liFood' + id).attr('foodname');
            var image = $('#liFood' + id).attr('foodimage');
            $('#remarkFoodId').val(id);
            $('#remarkFoodName').text(name);
            $('#remarkFoodImage').attr('src', image);
            $('#remarkFoodImage').attr('alt', name);

            //从“未确认”的菜单中找taste和remark
            var oUnconfirmData = getJsonObject('<%= this.hUnconfirmData.ClientID %>');
            if (oUnconfirmData[id] !== undefined) {
                var taste = oUnconfirmData[id].TASTE;
                var remark = oUnconfirmData[id].REMARK;
                if (!$.isEmpty(taste))
                    $('#btnTaste' + taste).addClass('am-active');
                if (!$.isEmpty(remark))
                    $('#remarkFoodRemark').val(remark);
            }
        }

        function setTaste(that) {
            if ($(that).hasClass('am-active')) {
                $(that).removeClass('am-active');
            } else {
                $('button[id^=btnTaste]').each(function () {
                    $(this).removeClass('am-active');
                });
                $(that).addClass('am-active');
            }
        }

        //备注窗口关闭事件
        $('#divRemark').on('closed.modal.amui', function () {
            var id = $('#remarkFoodId').val();
            var oUnconfirmData = getJsonObject('<%= this.hUnconfirmData.ClientID %>');
            if (oUnconfirmData[id] === undefined) {
                oUnconfirmData[id] = {};
                oUnconfirmData[id].COUNT = 0;
                oUnconfirmData[id].PRICE = $('#liFood' + id).attr('foodprice');
                oUnconfirmData[id].FOOD_NAME = $('#liFood' + id).attr('foodname');
            }
            oUnconfirmData[id].TASTE = $('.am-active').attr('value');
            oUnconfirmData[id].REMARK = $('#remarkFoodRemark').val();
            $('#<%= this.hUnconfirmData.ClientID %>').val(JSON.stringify(oUnconfirmData));
            bindCart();
        });

        function getJsonObject(id) {
            var strOrderData = $('#' + id).val();
            return $.isEmpty(strOrderData) ? {} : JSON.parse(strOrderData);
        }

        function CreateOrder() {
            var oUnconfirmData = getJsonObject('<%= this.hUnconfirmData.ClientID %>');
            var count = 0;
            for (var foodId in oUnconfirmData) {
                if (oUnconfirmData[foodId].COUNT = 0)
                    delete oUnconfirmData[foodId];
                else
                    count++;
            }
            if (count > 0) {
                $('#<%= this.hUnconfirmData.ClientID %>').val(JSON.stringify(oUnconfirmData));
                $('#<%= this.form1.ClientID %>').submit();
            }
        }

    </script>
</body>
</html>
