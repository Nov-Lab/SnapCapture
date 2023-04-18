﻿# スクリーンショット支援ツール SnapCapture

クリップボードへコピーされた画像を即座に保存する Windows アプリケーションです。
本アプリケーションを起動した状態で `PrintScreen` キーを押すだけで、画面全体のキャプチャー画像を「ピクチャ」フォルダーに保存することができます。


# 動作環境

- Windows 8.1以降
- .NET Framework 4.0 以降、または互換性のある .NET 実装


# 使い方

本アプリケーションを起動した状態で以下の操作をすることで、キャプチャー画像などを即座に保存することができます。
画像は「ピクチャ」フォルダーに保存されます。

・`PrintScreen` キーを押す。
  画面全体をキャプチャーして保存します。
  ※Windows の標準機能と連携して動作しますので、Windows 側の設定によっては動作が変わることがあります。

・`Alt` + `PrintScreen` キーを押す。
  アクティブウィンドウをキャプチャーして保存します。
  ※Windows の標準機能と連携して動作しますので、Windows 側の設定によっては動作が変わることがあります。

・ブラウザ上で画像を右クリックして「画像をコピー」。
  選択した画像を保存します。
  ※操作方法はブラウザによって異なります。

・画像編集ソフトや画像閲覧ソフトでコピー操作。
  編集中／閲覧中の画像を保存します。
  ※操作方法はソフトによって異なります。


# フォルダー構成

- `binfile` ：コンパイル済みのバイナリーファイルです。
- `SnapCapture` ：SnapCapture のプロジェクトです。


# 依存リポジトリ

- [NovLab.Base](https://github.com/Nov-Lab/NovLab.Base) クラスライブラリ

### ローカルリポジトリにおけるフォルダー配置について

本リポジトリのソリューションと、依存リポジトリのソリューションは、以下のように同じ親フォルダーの下へ配置してください。
```
＜親フォルダー＞
  ├ SnapCapture ソリューション
  └ NovLab.Base ソリューション
```


# ライセンス

本ソフトウェアは、MITライセンスに基づいてライセンスされています。

ただし、改変する場合は、namespace の名前を変えて重複や混乱を避けることを強く推奨します。


# 開発環境

## 開発ツール、SDKなど
- Visual Studio Community 2019
  - ワークロード：.NET デスクトップ開発

## 言語
- C#


# その他

Nov-Lab 独自の記述ルールと用語については [NovLabRule.md](https://github.com/Nov-Lab/Nov-Lab/blob/main/NovLabRule.md) を参照してください。
