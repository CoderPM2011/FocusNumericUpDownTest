# NumericUpDown control with focus in C# WinForm
C# WinForm中，具有焦點的NumericUpDown控制項
- 不具焦點時，將滑鼠滾輪動作攔截，並應用到具有垂直捲軸的父容器處理
- 滑鼠離開控制項時，盡可能將焦點設定為父容器，使自身失去焦點

在Windows 10中有一項預設啟用的新功能 **"當我將滑鼠游標移到非使用中視窗上方時捲動該視窗"**   
這會導致只要滑鼠在的控制項上，就算不具焦點，滑鼠滾輪依舊能正常影響控制項

## 實作原理
- 具有焦點  
  不攔截滑鼠滾輪事件  
  只要滑鼠離開控制項，搜尋能設定焦點的最內層父容器並設定，若無符合條件的父容器則不設定  
- 不具焦點  
  攔截滑鼠滾輪事件，並搜尋具有捲軸的最內層父容器，將滑鼠滾輪事件參數直接應用到父容器的捲軸上，若無符合條件的父容器則不設定  

## 實際比較
![NumericUpDown](https://user-images.githubusercontent.com/7456441/194601063-aae3a856-74b5-4b6e-aa79-ceb574c7dc8d.gif)
![FocusNumericUpDown](https://user-images.githubusercontent.com/7456441/194601100-da9002de-0fa7-4828-be27-ac24e3e30c61.gif)

## 已知問題
- 2022/10/08 在.Net 4.8.1中，NumericUpDown使用滑鼠滾輪時，會產生NonComVisibleBaseClass例外，因此繼承自NumericUpDown的FocusNumericUpDown也有一樣的問題

## 參考
- https://stackoverflow.com/q/58095510
- https://stackoverflow.com/a/4431657
- https://stackoverflow.com/a/60698003
