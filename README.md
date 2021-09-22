# SampleDeltaTime

`Application.targetFrameRate`と`QualitySettings.vsyncCount`の組み合わせが`Time.deltaTime`へどのような影響を与えるかを確認する為の検証プロジェクトです。

## 動作確認環境

### Unityバージョン
- Unity2018.4.36f1
- Unity2019.4.28f1
- Unity2020.3.18f1
- Unity2021.1.11f1

### プラットフォーム

Android

## 使い方

![image](https://user-images.githubusercontent.com/29646672/134296140-76f0193d-834b-49ee-a4f8-30e9f41b5048.png)

VSYNCとTarget Frame RateをRuntimeで切り替え、Time.deltaTimeの値を確認するだけでのプロジェクトです。

Unity2019.2以降の場合、Optimized Frame Pacingの有効・無効で何が変わるのか確認してみましょう。
![image](https://user-images.githubusercontent.com/29646672/134296444-df51f804-6382-425e-a0df-29304de74482.png)

端末側でリフレッシュレートを切り替える事が出来る場合、切り替えることによって、Time.deltaTimeの値がどのように変化するか確認してみましょう。


