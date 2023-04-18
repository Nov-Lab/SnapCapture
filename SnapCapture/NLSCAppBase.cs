// 23/04/18

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;

using NovLab;


namespace SnapCapture
{
    public class NLSCAppBase
    {
    }


    //====================================================================================================
    /// <summary>
    /// 【イメージ形式種別】イメージ形式の種類を示す列挙値です。
    /// </summary>
    //====================================================================================================
    public enum ImageFormatKind
    {
        BMP = 0,
        JPG,
        PNG,
    }


    //====================================================================================================
    /// <summary>
    /// 【イメージ形式情報】イメージ形式に関する情報(種別、表示名、拡張子、ImageFormat値)をひとまとめに管理します。
    /// </summary>
    //====================================================================================================
    public class ImageFormatInfo
    {
        //====================================================================================================
        // static 公開プロパティー
        //====================================================================================================

        /// <summary>
        /// 【選択肢テーブル】
        /// </summary>
        public static ImageFormatInfo[] options = new ImageFormatInfo[] {
            new ImageFormatInfo(ImageFormatKind.BMP, "BMP - ビットマップ形式", "bmp", ImageFormat.Bmp),
            new ImageFormatInfo(ImageFormatKind.JPG, "JPEG形式", "jpg", ImageFormat.Jpeg),
            new ImageFormatInfo(ImageFormatKind.PNG, "PNG形式", "png", ImageFormat.Png),
        };


        //====================================================================================================
        // 公開プロパティーと公開フィールド
        // ・ValueMember や DisplayMember に指定するものは、readonly なバッキングフィールドを、読み取り専用プロパティーを通じて取得します。
        //   ①ValueMember や DisplayMember はプロパティーでなければならない(フィールドだと動作しない)
        //   ②readonly(宣言またはコンストラクターでのみ初期化可能)はフィールドに対してのみ指定できる
        //====================================================================================================

        /// <summary>
        /// 【イメージ形式種別(読み取り専用)】イメージ形式の種類を示す列挙値です。コンボボックス値やキー値として使用します。
        /// </summary>
        public ImageFormatKind Kind => bf_kind;
        protected readonly ImageFormatKind bf_kind;

        /// <summary>
        /// 【表示名(読み取り専用)】コンボボックスやラベルに表示する表示名です。
        /// </summary>
        public string DisplayText => bf_displayText;
        protected readonly string bf_displayText;

        /// <summary>
        /// 【拡張子(読み取り専用。ピリオドなし)】
        /// </summary>
        public readonly string extension;

        /// <summary>
        /// 【ImageFormat値(読み取り専用)】
        /// </summary>
        public readonly ImageFormat imageFormat;


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【種別からイメージ形式情報を取得】
        /// </summary>
        /// <param name="kind">[In ]：イメージ形式種別</param>
        /// <returns>
        /// 保存イメージ形式情報(null = 該当なし)
        /// </returns>
        //--------------------------------------------------------------------------------
        public static ImageFormatInfo FromKind(ImageFormatKind kind)
        {
            foreach (var item in options)
            {
                if (item.Kind == kind)
                {
                    return item;
                }
            }

            return null;
        }


        //====================================================================================================
        // コンストラクター
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【完全コンストラクター】すべての内容を指定して保存イメージ形式情報を生成します。
        /// </summary>
        /// <param name="kind">       [In ]：イメージ形式種別</param>
        /// <param name="displayText">[In ]：表示名</param>
        /// <param name="extension">  [In ]：拡張子(ピリオドなし)</param>
        /// <param name="imageFormat">[In ]：ImageFormat値</param>
        //--------------------------------------------------------------------------------
        public ImageFormatInfo(ImageFormatKind kind, string displayText, string extension, ImageFormat imageFormat)
        {
            this.bf_kind = kind;
            this.bf_displayText = displayText;
            this.extension = extension;
            this.imageFormat = imageFormat;
        }


        // ・コンボボックス の ValueMember を空文字列にして ToString の結果を表示名に用いることもできるが、
        //   「例外がスローされました: 'System.InvalidOperationException' (mscorlib.dll の中)」が表示されてしまうのが気になるのでやめておく。
        // public override string ToString() => bf_displayText;
    }


    //====================================================================================================
    /// <summary>
    /// 【コンフィグ設定情報】本アプリケーションのコンフィグ設定を管理します。
    /// </summary>
    //====================================================================================================
    public class AppConfig
    {
        //====================================================================================================
        // static 公開プロパティー
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【ベースファイル名】画像を保存する際のベースファイル名です。
        /// </summary>
        //--------------------------------------------------------------------------------
        public static string BaseFileName
        {
            get
            {
                //------------------------------------------------------------
                /// ベースファイル名を正規化して取得する
                //------------------------------------------------------------
                return BaseFileNameString.Normalize(bf_baseFileName);
            }

            set
            {
                //------------------------------------------------------------
                /// ベースファイル名を正規化して設定する
                //------------------------------------------------------------
                bf_baseFileName = BaseFileNameString.Normalize(value);
            }
        }
        protected static string bf_baseFileName;


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【保存先フォルダー名(フルパス)】
        /// 画像の保存先フォルダー名です。
        /// </summary>
        /// <remarks>
        /// ・Nullまたは空文字列を指定した場合は MyPictures に保存します。<br></br>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static string SavePathFolder
        {
            get
            {
                //------------------------------------------------------------
                /// 保存先フォルダー名(フルパス)を取得する
                //------------------------------------------------------------
                if (string.IsNullOrEmpty(bf_savePathFolder))
                {                                                           //// バッキングフィールドの内容が Null または 空文字列 の場合
                    return                                                  /////  戻り値 = "マイ ピクチャ" フォルダー で関数終了
                        Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                }
                else
                {                                                           //// バッキングフィールドに有効な値が設定されている場合
                    return bf_savePathFolder;                               /////  戻り値 = バッキングフィールドの値 で関数終了
                }
            }
            set => bf_savePathFolder = value;
        }
        protected static string bf_savePathFolder;


        /// <summary>
        /// 【保存時イメージ形式種別】
        /// </summary>
        public static ImageFormatKind SaveImageFormatKind { get; set; }


        /// <summary>
        /// 【保存時ImageFormat値(読み取り専用)】保存時イメージ形式種別に対応するImageFormat値
        /// </summary>
        /// <remarks>
        /// ・保存時イメージ形式種別の値が不正な場合は例外が発生します。(バグがない限りありえない)
        /// </remarks>
        public static ImageFormat SaveImageFormat => ImageFormatInfo.FromKind(SaveImageFormatKind).imageFormat;


        /// <summary>
        /// 【保存時拡張子(ピリオドなし。読み取り専用)】保存時イメージ形式種別に対応する拡張子
        /// </summary>
        /// <remarks>
        /// ・保存時イメージ形式種別の値が不正な場合は例外が発生します。(バグがない限りありえない)
        /// </remarks>
        public static string SaveExtention => ImageFormatInfo.FromKind(SaveImageFormatKind).extension;


        //====================================================================================================
        // static 公開メソッド
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【パスなし保存ファイル名作成】パスなし保存ファイル名を作成します。
        /// </summary>
        /// <param name="seqNo">[In ]：連番</param>
        /// <returns>
        /// パスなし保存ファイル名
        /// </returns>
        //--------------------------------------------------------------------------------
        public static string MakeSaveFileName(int seqNo)
        {
            //------------------------------------------------------------
            /// パスなし保存ファイル名を作成する
            //------------------------------------------------------------
            var seqNoString = seqNo.ToString("0000");                   //// 連番文字列を作成する
            return BaseFileName + seqNoString + "." + SaveExtention;    //// 戻り値 = ベースファイル名＋連番文字列＋拡張子 で関数終了
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【フルパス保存ファイル名作成】保存ファイル名をフルパスで作成します。
        /// </summary>
        /// <param name="seqNo">[In ]：連番</param>
        /// <returns>
        /// フルパス保存ファイル名
        /// </returns>
        //--------------------------------------------------------------------------------
        public static string MakeSavePathFile(int seqNo)
        {
            //------------------------------------------------------------
            /// 保存ファイル名をフルパスで作成する
            //------------------------------------------------------------
            return Path.Combine(SavePathFolder, MakeSaveFileName(seqNo));
        }
    }


    //====================================================================================================
    /// <summary>
    /// 【ベースファイル名文字列】ベースファイル名文字列の操作機能を提供します。
    /// </summary>
    //====================================================================================================
    public class BaseFileNameString
    {
        //====================================================================================================
        // 内部定数
        //====================================================================================================
        /// <summary>
        /// 【既定のベースファイル名】
        /// </summary>
        protected const string M_DEFAULT_VALUE = "Snap";


        //====================================================================================================
        // static 公開メソッド
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【ベースファイル名文字列正規化】ベースファイル名文字列を正規化して返します。
        /// </summary>
        /// <param name="baseFileName">[in ]：ベースファイル名文字列</param>
        /// <returns>
        /// 取得結果(現在のインスタンスの内容を変更せずに、処理結果の新しいインスタンスを返します)
        /// </returns>
        /// <remarks>
        /// ・末尾が半角数字の場合は、連番とつながってしまうのを防ぐため、自動的に"_"を付加します。<br></br>
        /// ・Null または 空文字列 を指定した場合は、既定のベースファイル名になります。<br></br>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static string Normalize(string baseFileName)
        {
            //------------------------------------------------------------
            /// ベースファイル名文字列を正規化して返す
            //------------------------------------------------------------
            if (string.IsNullOrEmpty(baseFileName))
            {                                                           //// ベースファイル名が Null または 空文字列 の場合
                baseFileName = M_DEFAULT_VALUE;                         /////  ベースファイル名 = 既定のベースファイル名
            }

            baseFileName = baseFileName.Trim();                         //// ベースファイル名をトリムする
            if (baseFileName == string.Empty)
            {                                                           //// トリムによって空文字列になった場合
                baseFileName = M_DEFAULT_VALUE;                         /////  ベースファイル名 = 既定のベースファイル名
            }

            if ("0123456789".IndexOf(baseFileName.XRight(1)) != -1)
            {                                                           //// 末尾の文字が半角数字の場合
                baseFileName += "_";                                    /////  末尾に"_"を付加する
            }

            return baseFileName;                                        //// 戻り値 = 正規化したベースファイル名 で関数終了
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【ベースファイル名文字列検証】ベースファイル名文字列の内容を検証します。
        /// </summary>
        /// <param name="baseFileName">[in ]：ベースファイル名文字列</param>
        /// <returns>
        /// エラーメッセージ[null または空文字列 = エラーなし]
        /// </returns>
        //--------------------------------------------------------------------------------
        public static string Validate(string baseFileName)
        {
            //------------------------------------------------------------
            /// ベースファイル名文字列を検証する
            //------------------------------------------------------------
            if (baseFileName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            {                                                           //// ベースファイル名の中にファイル名に使えない文字が含まれる場合
                return "ファイル名に使えない文字が含まれています。";    /////  戻り値 = 「ファイル名に使えない文字が含まれています」 で関数終了
            }

            return null;                                                //// 上記チェックをすべてパスした場合、戻り値 = null(エラーなし) で関数終了
        }
    }

}
