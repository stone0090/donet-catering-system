// 分页代码
function initPagination(curPage, totalCount, pageCount, url) {
    curPage = parseInt(curPage);
    totalCount = parseInt(totalCount);
    pageCount = parseInt(pageCount);
    if (totalCount <= 0) {
        $("#labelPage").text("暂无数据，请新增！");
        $("#divPage").hide();
    } else {
        $("#labelPage").text("共 " + totalCount + " 条记录");
        if (pageCount === 1)
            $("#divPage").hide();
        else {
            if (curPage === 1) {
                $("#aFirst").parent().addClass("am-disabled");
                $("#aPrev").parent().addClass("am-disabled");
            } else if (curPage === pageCount) {
                $("#aNext").parent().addClass("am-disabled");
                $("#aLast").parent().addClass("am-disabled");
            }
            $("#aCur").text(curPage + " / " + pageCount);
            $("#aFirst").attr("href", url + "?page=1")
            $("#aPrev").attr("href", url + "?page=" + (curPage - 1))
            $("#aNext").attr("href", url + "?page=" + (curPage + 1))
            $("#aLast").attr("href", url + "?page=" + pageCount)
        }
    }
}

// 删除图片
function deleteImg(imgId, delId) {
    $('#' + imgId).attr('src', 'Images/OriginalImages/pic-none.png');
    if ($('#' + delId).val().indexOf(imgId) === -1) {
        $('#' + delId).val($('#' + delId).val() + imgId + '|');
    }
}