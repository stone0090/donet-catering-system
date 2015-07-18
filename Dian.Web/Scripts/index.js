
$(function () {
    getOrderData();
    //setInterval('getOrderData()', 10000);
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
    var oUnconfirmData = getJsonObject(hUnconfirmData);
    if (oUnconfirmData[id] !== undefined && oUnconfirmData[id].COUNT > 0) {
        oUnconfirmData[id].COUNT = oUnconfirmData[id].COUNT - 1;
        $('#' + hUnconfirmData).val(JSON.stringify(oUnconfirmData));
        bindMenu();
        bindCart();
        updateOrder(id, 'cut');
    }
}

//新增一道菜
function addFood(id) {
    var oUnconfirmData = getJsonObject(hUnconfirmData);
    if (oUnconfirmData[id] !== undefined) {
        oUnconfirmData[id].COUNT = oUnconfirmData[id].COUNT + 1;
    } else {
        oUnconfirmData[id] = {};
        oUnconfirmData[id].COUNT = 1;
        oUnconfirmData[id].PRICE = parseFloat($('#liFood' + id).attr('foodprice'));
        oUnconfirmData[id].FOOD_NAME = $('#liFood' + id).attr('foodname');
    }
    $('#' + hUnconfirmData).val(JSON.stringify(oUnconfirmData));
    bindMenu();
    bindCart();
    updateOrder(id, 'add');
}

//清空购物车
function clearCart() {
    $('#' + hUnconfirmData).val('');
    bindMenu();
    bindCart();
    var orderId = $('#' + hOrderId).val();
    if (!$.isEmpty(orderId)) {
        $.ajax({
            type: 'Post',
            url: 'Operation/ClearCart.ashx?r=' + Math.random(),
            data: { oid: orderId },
            dataType: "json",
            async: true,
            success: function (result) {
                if (result.success)
                    console.log('清空购物车成功！');
                else
                    console.log('清空购物车失败，原因是：' + result.msg);
            }
        });
    }

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
    var oUnconfirmData = getJsonObject(hUnconfirmData);
    if (oUnconfirmData[id] !== undefined) {
        var taste = oUnconfirmData[id].TASTE;
        var remark = oUnconfirmData[id].REMARK;
        if (!$.isEmpty(taste))
            $('#btnTaste' + taste).addClass('am-active');
        if (!$.isEmpty(remark))
            $('#remarkFoodRemark').val(remark);
    }
}

//设置口味
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


function getJsonObject(id) {
    var strOrderData = $('#' + id).val();
    return $.isEmpty(strOrderData) ? {} : JSON.parse(strOrderData);
}


//从“已下单”的数据中，过滤出“未确认”的数据，添加到hUnconfirmData中。(因为“未确认”的数据是可以修改的，所以要把“已下单”和“未确认”的数据区别开来操作)
function initUnconfirmData() {
    var oOrderData = getJsonObject(hOrderData);
    var oUnconfirmData = {};
    for (var index in oOrderData) {
        if ($.isEmpty(oOrderData[index].CONFIRM_TIME)) {
            var foodId = oOrderData[index].FOOD_ID;
            oUnconfirmData[foodId] = {};
            oUnconfirmData[foodId].COUNT = parseInt(oOrderData[index].COUNT);
            oUnconfirmData[foodId].PRICE = parseFloat(oOrderData[index].PRICE);
            oUnconfirmData[foodId].TASTE = oOrderData[index].TASTE;
            oUnconfirmData[foodId].REMARK = oOrderData[index].REMARK;
            oUnconfirmData[foodId].FOOD_NAME = oOrderData[index].FOOD_NAME;
        }
    }
    $('#' + hUnconfirmData).val(JSON.stringify(oUnconfirmData));
}

function bindMenu() {

    //0、清除菜单数量
    $('label[id^=lFoodCount]').each(function () {
        $(this).text('0');
    });

    //1、绑定“已确认”的菜单
    var foodCount = 0;
    var oOrderData = getJsonObject(hOrderData);
    for (var index in oOrderData) {
        if (!$.isEmpty(oOrderData[index].CONFIRM_TIME)) {
            foodCount = parseInt($('#lFoodCount' + oOrderData[index].FOOD_ID).text());
            $('#lFoodCount' + oOrderData[index].FOOD_ID).text(foodCount + parseInt(oOrderData[index].COUNT));
        }
    }

    //2、绑定“未确认”的菜单
    var oUnconfirmData = getJsonObject(hUnconfirmData);
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
    var oOrderData = getJsonObject(hOrderData);
    for (var index in oOrderData) {
        if (!$.isEmpty(oOrderData[index].CONFIRM_TIME)) {
            $('#tConfirmCart').append(
                '<tr>' +
                '<td>' + oOrderData[index].FOOD_NAME + '</td>' +
                '<td>' + parseFloat(oOrderData[index].PRICE) + '</td>' +
                '<td>' + parseInt(oOrderData[index].COUNT) + '</td>' +
                '<td>' + getStatus(oOrderData[index]) + '</td>' +
                '</tr>');

            var remark = getRemark(oOrderData[index]);
            if (!$.isEmpty(remark))
                $('#tConfirmCart').append('<tr><td></td><td colspan="3" class="am-list-item-text">' + remark + '</td></tr>');

            totalPrice += parseFloat(oOrderData[index].PRICE) * parseInt(oOrderData[index].COUNT);
        }
    }

    if (totalPrice === 0) {
        $('#divConfirmCart').hide();
    }

    //2、绑定“未确认”的购物车
    var oUnconfirmData = getJsonObject(hUnconfirmData);
    for (var foodId in oUnconfirmData) {
        if (oUnconfirmData[foodId].COUNT > 0) {
            $('#tUnconfirmCart').append(
                '<tr>' +
                '<td><a data-am-modal="{target: \'#divRemark\', width: 260, height: 450}" href="javascript:loadRemark(\'' + foodId + '\')">' + oUnconfirmData[foodId].FOOD_NAME + '</a></td>' +
                '<td>' + oUnconfirmData[foodId].PRICE + '</td>' +
                '<td>' +
                '<button type="button" class="am-btn am-btn-success am-btn-xs" onclick="cutFood(\'' + foodId + '\');">减</button>' +
                '&nbsp;' + oUnconfirmData[foodId].COUNT + '&nbsp;' +
                '<button type="button" class="am-btn am-btn-success am-btn-xs" onclick="addFood(\'' + foodId + '\');">加</button>' +
                '</td>' +
                '</tr>');

            var remark = getRemark(oUnconfirmData[foodId]);
            if (!$.isEmpty(remark))
                $('#tUnconfirmCart').append('<tr><td></td><td colspan="3" class="am-list-item-text">' + remark + '</td></tr>');

            totalPrice += oUnconfirmData[foodId].PRICE * oUnconfirmData[foodId].COUNT;
        }
    }

    var orderId = $('#' + hOrderId).val();
    if ($.isEmpty(orderId)) {
        $('#divConfirmCart').hide();
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
        return '<span class="am-text-danger">烹饪中...</span>';
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

function payOrder() {
    alert('立即结账');
}

function createOrder() {
    var oUnconfirmData = getJsonObject(hUnconfirmData);
    var count = 0;
    var oPostData = [];
    for (var foodId in oUnconfirmData) {
        if (oUnconfirmData[foodId].COUNT !== 0) {
            oPostData[count] = {};
            oPostData[count].FOOD_ID = parseInt(foodId);
            oPostData[count].COUNT = oUnconfirmData[foodId].COUNT;
            oPostData[count].PRICE = oUnconfirmData[foodId].PRICE;
            oPostData[count].TASTE = $.isEmpty(oUnconfirmData[foodId].TASTE) ? '' : oUnconfirmData[foodId].TASTE;
            oPostData[count].REMARK = $.isEmpty(oUnconfirmData[foodId].REMARK) ? '' : oUnconfirmData[foodId].REMARK;
            count++;
        }
    }

    if (count > 0) {
        $.ajax({
            type: 'Post',
            url: 'Operation/CreateOrder.ashx?rid=' + restaurantId + '&tid=' + tableId + '&r=' + Math.random(),
            data: { orderData: JSON.stringify(oPostData), price: $('#sTotalPrice').text() },
            dataType: "json",
            async: false,
            success: function (result) {
                if (result.success) {
                    $('#' + hOrderId).val(result.id);
                    getOrderData();
                    alert('下单成功！');
                } else {
                    alert('下单失败，原因是：' + result.msg);
                }
            },
            error: function (request, error, exception) {
                alert('下单失败2，原因是：' + error + '，' + exception);
            }
        });
    }
}

function getOrderData() {
    var orderId = $('#' + hOrderId).val();
    if (!$.isEmpty(orderId)) {
        $.ajax({
            type: 'Post',
            url: 'Operation/GetOrderData.ashx?r=' + Math.random(),
            data: { oid: orderId },
            dataType: "json",
            async: true,
            success: function (result) {
                $('#' + hOrderData).val(JSON.stringify(result));
                initUnconfirmData();
                bindMenu();
                bindCart();
            }
        });
    }
}

function updateOrder(foodId, op) {
    var orderId = $('#' + hOrderId).val();
    if (!$.isEmpty(orderId)) {

        var oUnconfirmData = getJsonObject(hUnconfirmData);
        var count = 0;
        var oPostData = {};
        oPostData.FOOD_ID = foodId;
        if (oUnconfirmData[foodId] === undefined) {
            oPostData.COUNT = 0;
            oPostData.PRICE = 0;
            oPostData.TASTE = '';
            oPostData.REMARK = '';
        } else {
            oPostData.COUNT = oUnconfirmData[foodId].COUNT;
            oPostData.PRICE = oUnconfirmData[foodId].PRICE;
            oPostData.TASTE = $.isEmpty(oUnconfirmData[foodId].TASTE) ? '' : oUnconfirmData[foodId].TASTE;
            oPostData.REMARK = $.isEmpty(oUnconfirmData[foodId].REMARK) ? '' : oUnconfirmData[foodId].REMARK;
        }

        $.ajax({
            type: 'Post',
            url: 'Operation/UpdateOrder.ashx?r=' + Math.random(),
            data: { oid: orderId, fop: op, orderData: JSON.stringify(oPostData) },
            dataType: "json",
            async: true,
            success: function (result) {
                if (result.success)
                    console.log('更新订单成功！');
                else
                    console.log('更新订单失败，原因是：' + result.msg);
            }
        });
    }
}
