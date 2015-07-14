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
                    <li><a href="#">登陆</a></li>
                </ul>
            </div>
        </header>

        <div class="am-cf admin-main">
            <!-- sidebar start -->
            <div class="admin-sidebar am-offcanvas" id="admin-offcanvas">
                <div class="am-offcanvas-bar admin-offcanvas-bar">
                    <ul class="am-list admin-sidebar-list">
                        <li><a href="javascript:loadFoodTypeData();">全部</a></li>
                        <asp:Repeater ID="repeater1" runat="server">
                            <ItemTemplate>
                                <li><a href="javascript:loadFoodTypeData('<%# Eval("FOOD_TYPE_ID") %>');"><%# Eval("FOOD_TYPE_NAME") %></a></li>
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
                            <ul class="am-list am-avg-sm-1 am-avg-md-1 am-thumbnails">
                                <!--缩略图在标题左边-->

                                <asp:Repeater ID="repeater2" runat="server">
                                    <ItemTemplate>
                                        <li class="am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-left">
                                            <div class="am-u-sm-4 am-list-thumb">
                                                <a href="#">
                                                    <img src="<%# Eval("FOOD_IMAGE_NAIL1") %>" alt="<%# Eval("FOOD_NAME") %>" class="am-img-thumbnail">
                                                </a>
                                            </div>
                                            <div class="am-u-sm-8 am-list-main">
                                                <h3 class="am-list-item-hd">
                                                    <a href="#"><%# Eval("FOOD_NAME") %></a>
                                                </h3>
                                                <div class="am-list-item-text"><%# Eval("DESCRIPTION") %></div>
                                                <div style="margin-top: 10px;">
                                                    <label class="am-text-danger">￥<%# Eval("PRICE") %></label>
                                                    <button type="button" class="am-btn am-btn-success am-btn-xs am-fr">加入购物车</button>
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
                            <table class="am-table am-table-bd am-table-striped admin-content-table">
                                <tbody>
                                    <tr>
                                        <td>鱼香肉丝</td>
                                        <td>单价：<label>35</label></td>
                                        <td>份数：
                                            <button type="button" class="am-btn am-btn-success am-btn-xs">减</button>
                                            <label>1</label>
                                            <button type="button" class="am-btn am-btn-success am-btn-xs">加</button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>白切鸡</td>
                                        <td>单价：<label>28</label></td>
                                        <td>份数：
                                            <button type="button" class="am-btn am-btn-success am-btn-xs">减</button>
                                            <label>1</label>
                                            <button type="button" class="am-btn am-btn-success am-btn-xs">加</button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>正宗北京烤鸭</td>
                                        <td>单价：<label>68</label></td>
                                        <td>份数：
                                            <button type="button" class="am-btn am-btn-success am-btn-xs">减</button>
                                            <label>1</label>
                                            <button type="button" class="am-btn am-btn-success am-btn-xs">加</button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>剁椒鱼头</td>
                                        <td>单价：<label>42</label></td>
                                        <td>份数：
                                            <button type="button" class="am-btn am-btn-success am-btn-xs">减</button>
                                            <label>1</label>
                                            <button type="button" class="am-btn am-btn-success am-btn-xs">加</button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>宫爆鸡丁</td>
                                        <td>单价：<label>38</label></td>
                                        <td>份数：
                                            <button type="button" class="am-btn am-btn-success am-btn-xs">减</button>
                                            <label>1</label>
                                            <button type="button" class="am-btn am-btn-success am-btn-xs">加</button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <label class="am-text-danger am-fr">合计：￥211元</label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <div class="am-g">
                        <div style="text-align: center;">
                            <button type="button" class="am-btn am-btn-success am-btn-xl">清空购物车</button>
                            <button type="button" class="am-btn am-btn-warning am-btn-xl">立即下单</button>
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
                <a href="javascript:showMenu();" style="line-height: 49px;">
                    <span>菜单(88)</span>
                </a>
            </li>
            <li>
                <a href="javascript:showCart();" style="line-height: 49px;">
                    <span>购物车(5)</span>
                </a>
            </li>
        </ul>
    </div>

    <script type="text/javascript">

        function showMenu() {
            $('#divMenu').show();
            $('#divCart').hide();
        }

        function showCart() {
            $('#divMenu').hide();
            $('#divCart').show();
        }

        function loadFoodTypeData(type) {

        }

    </script>

</body>
</html>
