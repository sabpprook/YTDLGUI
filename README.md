# YTDLGUI

## 演示圖片
![cover](https://i.imgur.com/kiIy7Ig.png)

## 主程式
* [YTDLGUI.exe](https://github.com/sabpprook/YTDLGUI/releases/latest/download/YTDLGUI.exe)


## 影片下載
* 下載模式

    * Default : 無參數預設下載模式
    * MP4 : 最佳影片、音訊下載模式；格式 : [H264] + [AAC]
    * Webm : 最佳影片、音訊下載模式；格式 : [VP9] + [Opus]

## 音訊下載
* 轉檔格式

    * best : 單純分離音訊檔案，無二次轉檔
    * m4a : 有損格式；位元率參照轉檔音質
    * mp3 : 有損格式；位元率參照轉檔音質
    * vorbis : 有損格式；位元率參照轉檔音質
    * flac : 無損格式
    * wav : 無損格式

* 轉檔音質

    * 固定位元率 : 96 ~ 320Kbps

## 可用選項
* 下載撥放清單 : 預設不啟用撥放清單解析

    * 開啟 : 無播放清單
    * 關閉 : 下載播放清單

* 影片最大解析度 : 限制影片下載解析度

    * 360P : 640 x 360
    * 480P : 848 x 480
    * 720P : 1280 x 720
    * 1080P : 1920 x 1080
    * 1440P : 2160 x 1440
    * 2160P : 3840 x 2160
    * 4320P : 7680 x 4320

* 多執行續分片下載 : 處理 m3u8/MPD 同時下載多少個分片

* 下載完整直播 : 僅支援 YouTube

* 使用 Aria2c 下載器 : 使用 Aria2c 作為外部下載器，某些時候能提供更快速度下載
