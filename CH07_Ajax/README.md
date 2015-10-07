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