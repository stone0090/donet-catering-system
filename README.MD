# 点餐系统
帮朋友做的点餐系统，主要是为了让顾客在餐桌上，使用微信扫描二维码，就可以直接点菜，吃完使用微信付款。  

- 账户名和密码均为：admin。（**请不要删除admin用户**）  
- [GitHub Clone 地址](https://github.com/stone0090/Dian)

## 更新

- 20161106：移除外部类库的引用，改用[stone0090/s-donet](https://github.com/stone0090/s-donet)中的方法。

## 简介
餐厅系统分为前台和后台两个部分：
- 前台是用户点菜页面，无需登录即可点菜，但必须在url里带上“店铺id”和“桌号id”，不然会报404错误。
- 后台是店家管理页面，必须登录才能操作，主要有 店铺管理、用户管理、菜品管理、菜品分类、订单管理、生成二维码 等6大模块。

## 演示
点菜页面只适配了 iphone6，使用5寸以上手机，微信扫描二维码，即可进入点菜页面。  
效果等同于访问网址：[**dian.shijiajie.com/index.aspx?rid=1&tid=1**](http://dian.shijiajie.com/Index.aspx?rid=1&tid=1)  
![](http://7xkhp9.com1.z0.glb.clouddn.com/github.com/stone0090/Dian/DianQRCode.jpg)

### 点菜页面如下：
![](http://7xkhp9.com1.z0.glb.clouddn.com/github.com/stone0090/Dian/menu.jpg)
- 备注：因为顾客已经下单，所以此时扫码是加菜模式，在购物车中可以查看已点菜的状态。

### 管理页面如下：
![](http://7xkhp9.com1.z0.glb.clouddn.com/github.com/stone0090/Dian/background_1.jpg)
![](http://7xkhp9.com1.z0.glb.clouddn.com/github.com/stone0090/Dian/background_2.jpg)

## 安装说明
- 在 Sql Server 中新建一个数据库 `DIAN`。
- 在 `DIAN` 数据库中执行脚本 `dian.sql`。
- 在 IIS 中新建一个网站 `dian`，物理路径指向 dian 文件夹。
- 修改 dian 文件夹中 `Web.config` 中的链接字符串。
- 网站部署完毕，请启动您的网站。

## 答疑解惑
本系统完成度80%，但由于朋友后来不需要了，就没有继续开发了。如果大家感兴趣，可以通过以下方式联系我，我再继续更新、维护这个项目。

- 在文章[《DoNet开源项目-基于Amaze UI的点餐系统》](http://shijiajie.com/2016/01/17/donet-opensource-dian-introduction/#ds-thread)的评论区给我留言。
- 发送邮件到 <a href="mailto:stone0090@126.com">stone0090@126.com</a> 给我留言。
- 如有bug可到 [issues页面](https://github.com/stone0090/Dian/issues/new) 进行反馈。

## LICENSE

This project is released under the [GPL](https://github.com/stone0090/donet-catering-system/blob/master/LICENSE).