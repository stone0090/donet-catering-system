<%@ Page Title="" Language="C#" MasterPageFile="~/BackgroundManagement.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Dian.Web.MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="admin-content">
        <div class="am-cf am-padding">
            <div class="am-fl am-cf"><strong class="am-text-primary am-text-lg">首页</strong> / <small>热点信息</small></div>
        </div>        
        <div class="am-g">
            <div class="am-u-sm-12">
                <table class="am-table am-table-bd am-table-striped admin-content-table">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>用户名</th>
                            <th>最后成交任务</th>
                            <th>成交订单</th>
                            <th>管理</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td>John Clark</td>
                            <td><a href="#">Business management</a></td>
                            <td><span class="am-badge am-badge-success">+20</span></td>
                            <td>
                                <div class="am-dropdown" data-am-dropdown>
                                    <button class="am-btn am-btn-default am-btn-xs am-dropdown-toggle" data-am-dropdown-toggle><span class="am-icon-cog"></span><span class="am-icon-caret-down"></span></button>
                                    <ul class="am-dropdown-content">
                                        <li><a href="#">1. 编辑</a></li>
                                        <li><a href="#">2. 下载</a></li>
                                        <li><a href="#">3. 删除</a></li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>风清扬</td>
                            <td><a href="#">公司LOGO设计</a> </td>
                            <td><span class="am-badge am-badge-danger">+2</span></td>
                            <td>
                                <div class="am-dropdown" data-am-dropdown>
                                    <button class="am-btn am-btn-default am-btn-xs am-dropdown-toggle" data-am-dropdown-toggle><span class="am-icon-cog"></span><span class="am-icon-caret-down"></span></button>
                                    <ul class="am-dropdown-content">
                                        <li><a href="#">1. 编辑</a></li>
                                        <li><a href="#">2. 下载</a></li>
                                        <li><a href="#">3. 删除</a></li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>詹姆斯</td>
                            <td><a href="#">开发一款业务数据软件</a></td>
                            <td><span class="am-badge am-badge-warning">+10</span></td>
                            <td>
                                <div class="am-dropdown" data-am-dropdown>
                                    <button class="am-btn am-btn-default am-btn-xs am-dropdown-toggle" data-am-dropdown-toggle><span class="am-icon-cog"></span><span class="am-icon-caret-down"></span></button>
                                    <ul class="am-dropdown-content">
                                        <li><a href="#">1. 编辑</a></li>
                                        <li><a href="#">2. 下载</a></li>
                                        <li><a href="#">3. 删除</a></li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>4</td>
                            <td>云适配</td>
                            <td><a href="#">适配所有网站</a></td>
                            <td><span class="am-badge am-badge-secondary">+50</span></td>
                            <td>
                                <div class="am-dropdown" data-am-dropdown>
                                    <button class="am-btn am-btn-default am-btn-xs am-dropdown-toggle" data-am-dropdown-toggle><span class="am-icon-cog"></span><span class="am-icon-caret-down"></span></button>
                                    <ul class="am-dropdown-content">
                                        <li><a href="#">1. 编辑</a></li>
                                        <li><a href="#">2. 下载</a></li>
                                        <li><a href="#">3. 删除</a></li>
                                    </ul>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>5</td>
                            <td>呵呵呵</td>
                            <td><a href="#">基兰会获得BUFF</a></td>
                            <td><span class="am-badge">+22</span></td>
                            <td>
                                <div class="am-dropdown" data-am-dropdown>
                                    <button class="am-btn am-btn-default am-btn-xs am-dropdown-toggle" data-am-dropdown-toggle><span class="am-icon-cog"></span><span class="am-icon-caret-down"></span></button>
                                    <ul class="am-dropdown-content">
                                        <li><a href="#">1. 编辑</a></li>
                                        <li><a href="#">2. 下载</a></li>
                                        <li><a href="#">3. 删除</a></li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
