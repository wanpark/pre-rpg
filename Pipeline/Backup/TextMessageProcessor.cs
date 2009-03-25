using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

namespace Sample.Pipeline
{
    /// <summary>
    /// TextMessageDescriptionからTextMessageContentに変換するプロセッサ
    /// </summary>

    // プロセッサクラスには、ContentProcessorAttributeを指定する
    [ContentProcessor(DisplayName = "テキストメッセージプロセッサ")]
    class TextMessageProcessor : ContentProcessor<TextMessageDescription, TextMessageContent>
    {
        public override TextMessageContent Process(TextMessageDescription input, ContentProcessorContext context)
        {
            // contextを通してExternalReference(外部参照)のアセットをビルド処理できる。
            // 通常、プロセッサを指定するが、ここではnullを指定することで、
            // インポート直後のタイプを取得している。
            FontDescription fontDescription = context.BuildAndLoadAsset<FontDescription, FontDescription>(input.FontDescription, null);
            string[] messageSource = context.BuildAndLoadAsset<string[], string[]>(input.Message, null);

            // FontDescriptionのCharactersにmessageSourceで使用している文字コードを追加する。
            int totalCharacterCount = 0;
            foreach (string line in messageSource)
            {
                foreach (char c in line)
                {
                    totalCharacterCount++;

                    // FontDescription.Characters.Addメソッド内で文字コード重複チェックをしているので
                    // ここでは重複を気にせずに文字を追加するだけでよい。
                    fontDescription.Characters.Add(c);
                }
            }

            // 最終結果に変換する
            TextMessageContent outContent = new TextMessageContent();

            // FontDescriptionProcessorを直接実行して、SpriteFontContentを取得する。
            FontDescriptionProcessor processor = new FontDescriptionProcessor();
            outContent.Font = processor.Process(fontDescription, context);

            // メッセージ文字列の処理。DiscardMessageフラグがTrueの場合は処理しない。
        if (!input.DiscardMessage)
            outContent.Message = ProcessMessage(messageSource);

            context.Logger.LogImportantMessage(String.Format("使用文字数{0}, 総文字数:{1}", fontDescription.Characters.Count, totalCharacterCount));

            return outContent;
        }

        /// <summary>
        /// テキストメッセージの処理
        /// このサンプルでは、単純に元のテキストを空白行を区切りとした
        /// 複数のメッセージに変換している。
        /// </summary>
        /// <param name="messageSource"></param>
        /// <returns></returns>
        string[] ProcessMessage(string[] messageSource)
        {
            List<string> messages = new List<string>();
            string curMessage = String.Empty;
            bool capturingMessage = false;

            foreach (string line in messageSource)
            {
                if (String.IsNullOrEmpty(line) == false )
                {
                    curMessage += line + "\n";
                    capturingMessage = true;
                }
                else
                {
                    if ( capturingMessage )
                    {
                        messages.Add(curMessage);
                        curMessage = String.Empty;
                        capturingMessage = false;
                    }
                }
            }

            if (capturingMessage)
            {
                messages.Add(curMessage);
            }

            return messages.ToArray();
        }

    }
}
