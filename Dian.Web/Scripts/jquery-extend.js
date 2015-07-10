//扩展jquery的方法
$.extend({
    /* check is json or not */
    isJson: function (obj) {
        return typeof (obj) == "object" && Object.prototype.toString.call(obj).toLowerCase() == "[object object]" && !obj.length && Object.keys(obj).length;
    },
    /*input more json data to o*/
    apply: function (o) {
        var c = arguments;
        for (var i = 1; i < c.length; i++) {
            if (o && c[i] && typeof c[i] == 'object')
                for (var p in c[i]) o[p] = (c[i])[p];
        }
        return o;
    },
    copy: function (o) {
        var c = {};
        for (var p in o) {
            switch (typeof o[p]) {
                case "object": c[p] = this.copy(o[p]); break;
                default: c[p] = o[p];
            }
        }
        return c;
    },
    reverse: function (str) {
        var tmp = str.toString();
        var ret = [];
        for (i = tmp.length; i >= 0; i -= 1)
            ret.push(tmp.substring(i, i + 1));
        return ret.join('');
    },
    applyIf: function (o, c) {
        if (o) {
            for (var p in c) {
                if ($.isEmpty(o[p])) {
                    o[p] = c[p];
                }
            }
        }
        return o;
    },
    isEmpty: function (v, allowBlank) {
        return (typeof (v) == 'string' && $.trim(v).length == 0) || v === null || v === undefined || (($.isArray(v) && !v.length)) || (!allowBlank ? v === '' : false);
    },
    isObject: function (v) {
        return v && typeof v == "object";
    },
    isPrimitive: function (v) {
        var t = typeof v;
        return t == 'string' || t == 'number' || t == 'boolean';
    },
    queryString: function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]);
        return "";
    },
    value: function (data, name, def) {
        var value = data[name];
        return !$.isEmpty(value) ? value : def;
    },
    json2xml: function (prop, tagName) {
        if (!prop) return "";
        var json = [];
        if (!$.isEmpty(tagName)) json.push("<" + tagName + ">");
        var self = this, v, name;
        for (var key in prop) {
            v = prop[key];
            switch (typeof v) {
                case "function": case "undefined": break;
                case "object":
                    json.push('<', key, '>');
                    if ($.isArray(v))
                        $.every(v, function (i, row) { json.push(self._jsonToXml(row, "ITEM")) });
                    else
                        json.push(this.json2xml(v, "ITEM"));
                    json.push('</', key, '>');
                    break;
                default:
                    json.push('<', key, '>', v, '</', key, '>');
            }
        }
        if (!$.isEmpty(tagName)) json.push("</" + tagName + ">");
        return json.join('');
    },
    /*将数据转为json*/
    array2json: function (field, data) {
        var ret = [];
        var json = {};
        $.each(data, function (i, row) {
            if ($.isArray(row)) {
                ret.push($.array2json(field, row)[0]);
            }
            else {
                json[field[i]] = row;
            }
        });
        if (ret.length == 0) ret.push(json);
        return ret;
    }
});