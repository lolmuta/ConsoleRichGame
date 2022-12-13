# ConsoleRichGame

![1__playerInfo](https://user-images.githubusercontent.com/19727471/207271396-c5df1f69-2f2a-4ae0-be3d-a92e145ad856.png)
![2__gamemap](https://user-images.githubusercontent.com/19727471/207271426-9dcb7325-cb18-42b3-a722-7e6046d444da.png)
![3__playerRollDice](https://user-images.githubusercontent.com/19727471/207271502-e8307c2f-a0c7-4a01-b4e8-057d98389f39.png)

![3__playerMoveAndWaitBuyLand](https://user-images.githubusercontent.com/19727471/207271453-88188639-d63c-420a-9b0c-b3d3fb965844.png)
![4__playerbuyLand](https://user-images.githubusercontent.com/19727471/207271588-65399f95-789a-45a8-abf8-762b94f31050.png)
![5__computerPlay](https://user-images.githubusercontent.com/19727471/207271628-a9b98a54-6f38-441f-a6c4-297d9bf7a671.png)


# 執行方式
- 到 https://github.com/lolmuta/ConsoleRichGame/releases/tag/untagged-66f96ea9afb28e931306
- 下載檔案
- 解壓縮
- 隨意建立資料，將解壓縮檔案夾放進行
- 執行 ConsoleRichGame.exe 

# 專案特點
- 應用 abrstract class 為玩家，給 玩家電腦 與 玩家 共同 extends
  - 需實作當到達土地時，要作怎麼樣的行為
  - 需實作扔骰子的動作
- 純 console 繪圖
- 玩家判斷土地是否是自己的，還是別人的，還是空地，這是用 functional 的方式去實作，將 if else 包起來
