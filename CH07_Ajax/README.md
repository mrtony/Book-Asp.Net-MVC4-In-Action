# Asp.net MVC的Ajax功能
本章範例會在主畫面放入4個連結, 分別呈現不同的功能及作法.

## Example01
示範如何使用Ajax取得PartialView資料, 並呈現在Client端.

---
 
## Example02
示範如何使用Ajax提交表單資料.

其原理如下:

1. 主畫面會將留言清單逐筆顯示.
2. 主畫面的表單透過```jQuery.serialize()```將表單資料序列化後POST到```AddComment```的action.
3. Addcomment會將透過繫結傳入的資料存入List中, 並判斷是否為透過Ajax呼叫, 如果是則將這次接收到的
資料放入Viewbag, 並由PartialView()中將該資料以```li```包裝後, 回傳到JS的Ajax的response. 然後
再用JS將此```<li>comment</li>```做```append```加入到id為comments的ul中.

所以它整個的流程如下:
Index回傳List<string>的物件 --> 使用者輸入文字到TextArea --> 按送出以Ajax Post傳送到AddComment的Action
--> AddComment回傳Partial view, 只有傳li包留言資料 --> Client JS端收到回應後, append留言到ul中.

---
## Example03
以Example-01為範本, 將jQuery做Ajax的方式改為使用Ajax Helper. 它有以下的方法:
* Ajax.ActionLink
* Ajax.RouteLink
* Ajax.BeginForm
* Ajax.BeginRouteForm
* Ajax.GlobalizationScript
* Ajax.JavaScriptStringEncode

>Note:web.config中, 要將UnobtrusiveJavaScriptEnabled設為true, AjaxHelper才會使用jQuery Ajax Adaptor.
``` 
<appSettings>
<add key="UnobtrusiveJavaScriptEnabled" value="true"/>
</appSettings>
```

此範例使用Ajax.ActionLink來示範AjaxHelper.

1. 一定要引入```jquery.unobtrusive-ajax.js```
```
Install-Package jQuery.Ajax.Unobtrusive
```

>**重要!!** 將jquery.unobtrusive-ajax.js中的所有呼叫```.live```都改成```.on```, 因為jQuery自1.7後就不支援.live, 都改成.on了.

2. Helper寫法(在index.cshtml中)
	```
	<script type="text/javascript" src="@Url.Content("~/scripts/jquery.unobtrusive-ajax.js")"></script>
	
	@Ajax.ActionLink("Show the Privacy Policy", "PrivacyPolicy", new AjaxOptions { 
		UpdateTargetId = "privacy", 
		InsertionMode = InsertionMode.Replace 
	})
	```
會產生的HTML
```
<a data-ajax="true" data-ajax-mode="replace" data-ajax-update="#privacy" href="/AjaxHelpers/PrivacyPolicy">Show the Privacy Policy</a>
```

其他有可參考的資料:
* http://www.itorian.com/2013/02/ajaxactionlink-and-htmlactionlink-in-mvc.html
* http://mscodingblog.blogspot.tw/2013/04/how-to-do-ajax-in-aspnet-mvc4.html