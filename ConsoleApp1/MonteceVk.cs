using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using VkNet;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace ConsoleApp1
{
    class MonteceVk
    {
        static WebClient Web;
        static VkApi vkapi;
        static Random _Random;
        static long userID = 193939494;
        public static string CommandsPath;
        static bool IsChat = false;
        const string BotCommandSuf = "";

        public MonteceVk()
        {
            Initialization();
            LoadLibrary();
        }

        public static void Initialization()
        {
            Console.Title = "Hentai-ka bot";
            ColorMessage("Hentaika-vot bot", ConsoleColor.Yellow);

            Web = new WebClient();
            vkapi = new VkApi();
            _Random = new Random();
            CommandsPath = Environment.CurrentDirectory + @"\Commands";
        }

        public static bool Authorization(string groupid)
        {
            MonteceVk VK = new MonteceVk();
            try
            {
                Console.WriteLine("Попытка авторизации...");
                vkapi.Authorize(new ApiAuthParams { AccessToken = groupid });
                Start();
                return true;
            }
            catch (Exception e)
            {
                ColorMessage("Не удалось произвести авторизацию!" + Environment.NewLine + e.Message, ConsoleColor.Red);
                return false;
            }
        }

        public static bool Authorization(string login, string password, ulong appid, Settings settings)
        {
            MonteceVk VK = new MonteceVk();
            try
            {
                Console.WriteLine("Попытка авторизации...");
                vkapi.Authorize(new ApiAuthParams
                {
                    ApplicationId = appid,
                    Login = login,
                    Password = password,
                    Settings = settings
                });
                Start();
                return true;
            }
            catch (Exception e)
            {
                ColorMessage("Не удалось произвести авторизацию!" + Environment.NewLine + e.Message, ConsoleColor.Red);
                return false;
            }
        }

        private static void Start()
        {
            ColorMessage("Авторизация успешно завершена.", ConsoleColor.Green);
            EyeInit();
            Console.WriteLine("Запросов в секунду доступно: " + vkapi.RequestsPerSecond);
        }

        static void LoadLibrary()
        {
            if (!Directory.Exists(CommandsPath) || !File.Exists(CommandsPath + @"\Commands.txt"))
            {
                Directory.CreateDirectory(CommandsPath);
                File.Create(CommandsPath + @"\Commands.txt");
                Restart();
            }
            else ColorMessage("Директория сообщений создана успешно загружена.", ConsoleColor.Green);
        }

        static void MonteceVkBot_Logout(VkApi owner)
        {
            ColorMessage("Отключение от VK...", ConsoleColor.Red);
        }

        public static void ColorMessage(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void SendMessage(string message)
        {
            try
            {
                vkapi.Messages.Send(new MessagesSendParams
                {
                    UserId = userID,
                    Message = message,
                    RandomId = new Random().Next(999999)
                });

            }
            catch (Exception e)
            {
                ColorMessage("Ошибка! " + e.Message, ConsoleColor.Red);
            }
        }

        #region Watcher
        static ulong? Ts;
        static ulong? Pts;
        static bool IsActive;
        static Timer WatchTimer = null;
        static byte MaxSleepSteps = 3;
        static int StepSleepTime = 333;
        static byte CurrentSleepSteps = 1;
        delegate void MessagesRecievedDelegate(VkApi owner, ReadOnlyCollection<VkNet.Model.Message> messages);
        static event MessagesRecievedDelegate NewMessages;

        static void EyeInit()
        {
            LongPollServerResponse Pool = vkapi.Messages.GetLongPollServer(true);
            StartAsync((ulong?)Convert.ToInt64(Pool.Ts), Pool.Pts);
            NewMessages += MonteceVkBot_NewMessages;
            vkapi.OnTokenExpires += MonteceVkBot_Logout;
            ColorMessage("Слежение за сообщениями активировано.", ConsoleColor.Yellow);
        }

        static void MonteceVkBot_NewMessages(VkApi owner, ReadOnlyCollection<Message> messages)
        {
            Console.Beep();
            for (int i = 0; i < messages.Count; i++)
            {
                if (messages[i].Type != MessageType.Sended && messages[i].Text.Contains(BotCommandSuf))
                {
                    string MSG = messages[i].Text.Substring(BotCommandSuf.Length);
                    userID = messages[i].PeerId.Value;

                    var Name = vkapi.Users.Get(new long[] { userID }).FirstOrDefault();
                    Console.WriteLine("Новое сообщение: {0} {1} : {2} ", Name.FirstName, Name.LastName, messages[i].Text);

                    Console.Beep();
                    Command(MSG);
                }
            }
        }

        static LongPollServerResponse GetLongPoolServer(ulong? lastPts = null)
        {
            LongPollServerResponse response = vkapi.Messages.GetLongPollServer(false);
            Ts = (ulong)Convert.ToInt64(response.Ts);
            Pts = Pts == null ? response.Pts : lastPts;
            return response;
        }

        static Task<LongPollServerResponse> GetLongPoolServerAsync(ulong? lastPts = null)
        {
            return Task.Run(() =>
            {
                return GetLongPoolServer(lastPts);
            });
        }

        static LongPollHistoryResponse GetLongPoolHistory()
        {
            if (!Ts.HasValue) GetLongPoolServer(null);
            MessagesGetLongPollHistoryParams rp = new MessagesGetLongPollHistoryParams();
            rp.Ts = Ts.Value;
            rp.Pts = Pts;
            int i = 0;
            LongPollHistoryResponse history = null;
            string errorLog = "";

            while (i < 5 && history == null)
            {
                i++;
                try
                {
                    history = vkapi.Messages.GetLongPollHistory(rp);
                }
                catch (TooManyRequestsException)
                {
                    Thread.Sleep(150);
                    i--;
                }
                catch (Exception ex)
                {
                    errorLog += string.Format("{0} - {1}{2}", i, ex.Message, Environment.NewLine);
                }
            }

            if (history != null)
            {
                Pts = history.NewPts;
                foreach (var m in history.Messages)
                {
                    m.FromId = m.Type == MessageType.Sended ? vkapi.UserId : m.UserId;
                }
            }
            else ColorMessage(errorLog, ConsoleColor.Red);
            return history;
        }

        static Task<LongPollHistoryResponse> GetLongPoolHistoryAsync()
        {
            return Task.Run(() => { return GetLongPoolHistory(); });
        }

        static async void WatchAsync(object state)
        {
            LongPollHistoryResponse history = await GetLongPoolHistoryAsync();
            if (history.Messages.Count > 0)
            {
                CurrentSleepSteps = 1;
                NewMessages?.Invoke(vkapi, history.Messages);
            }
            else if (CurrentSleepSteps < MaxSleepSteps) CurrentSleepSteps++;
            WatchTimer.Change(CurrentSleepSteps * StepSleepTime, Timeout.Infinite);
        }

        static async void StartAsync(ulong? lastTs = null, ulong? lastPts = null)
        {
            if (IsActive) ColorMessage("Messages for {0} already watching", ConsoleColor.Red);
            IsActive = true;
            await GetLongPoolServerAsync(lastPts);
            WatchTimer = new Timer(new TimerCallback(WatchAsync), null, 0, Timeout.Infinite);
        }

        static void Stop()
        {
            if (WatchTimer != null) WatchTimer.Dispose();
            IsActive = false;
            WatchTimer = null;
        }

        public static void Restart()
        {
            Process.Start((Process.GetCurrentProcess()).ProcessName);
            Environment.Exit(0);
        }
        #endregion

        #region Commands

        static string[] Commands = { "помощь", "хентай", "случайное число <Мин> <Макс>", "новости", "учи~<Сообщение>~<Ответ>" };

        static void Command(string Message)
        {
            Message = Message.ToLower();
            string a = CheckCommand(Message);
            if (a != "") SendMessage(a);
            else
            {
                //Простые и составные комманды
                switch (Message)
                {
                    case "помощь":
                        string msg = "";
                        for (int j = 0; j < Commands.Length; j++) msg += Commands[j] + ", ";
                        SendMessage(msg);
                        break;
                    case "хентай":
                        Hentai();
                        break;
                    case "новости":
                        SendMessage(News("https://lenta.ru/rss/top7"));
                        break;
                    default:
                        //---СОСТАВНЫЕ КОММАНДЫ---
                        if (Message.Contains("случайное число "))
                        {
                            string Numbers = Message.Substring(Message.IndexOf("число") + 6);
                            int Min = int.Parse(Numbers.Substring(0, Numbers.IndexOf(' ')));
                            int Max = int.Parse(Numbers.Substring(Numbers.IndexOf(' '), Numbers.Length - Numbers.IndexOf(' ')));
                            SendMessage(Rand(Min, Max));
                        }
                        else if (Message.Contains("учи~"))
                        {
                            SendMessage(Learn(Message.Substring(4, Message.Length - 4)));
                        }
                        else
                            SendMessage("Скоро мой хозяин ответит тебе, если оно требуется ^^  \n  \n Или ты просто ввёл не ту команду:>  \n (P.S.список доступных команд будет выложен в группу позже)");
                        break;
                }
            }
        }

        static string CheckCommand(string Command)
        {
            foreach (string Line in File.ReadAllLines(CommandsPath + @"\Commands.txt"))
            {
                if (Line.Substring(0, Line.IndexOf('~')).ToLower() == Command)
                {
                    return Line.Substring(Line.IndexOf('~') + 1);
                }
            }
            return "";
        }

        public static void Hentai()
        {
            var random = new Random();
            var randomImage = random.Next(1, new DirectoryInfo(@"D:\utorrent\VK\Image\").GetFiles().Length);

            var wc = new WebClient();
            // Получить адрес сервера для загрузки картинок в сообщении
            var uploadServer = vkapi.Photo.GetMessagesUploadServer(userID);

            // Загрузить картинку на сервер VK.
            var response = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl, @"D:\utorrent\VK\Image\ " + randomImage + @".png"));

            // Сохранить загруженный файл
            var attachment = vkapi.Photo.SaveMessagesPhoto(response);

            vkapi.Messages.Send(new MessagesSendParams
            {
                UserId = userID, //Id получателя
                //Message = "Message", //Сообщение
                Attachments = attachment, //Вложение
                RandomId = new Random().Next(999999) //Уникальный идентификатор
            });
        }

        public static string News(string url)
        {

            string Result = Web.DownloadString(url);
            XDocument Doc = XDocument.Parse(Result);
            List<RssNews> a = (from descendant in Doc.Descendants("item")
                               select new RssNews()
                               {
                                   Description = descendant.Element("description").Value,
                                   Title = descendant.Element("title").Value,
                                   PublicationDate = descendant.Element("pubDate").Value
                               }).ToList();
            string News = "";
            if (a != null)
            {
                int i = _Random.Next(0, a.Count - 1);
                News = a[i].Title + Environment.NewLine + "------------------" + Environment.NewLine + a[i].Description;
                byte[] bytes = Encoding.Default.GetBytes(News);
                News = Encoding.UTF8.GetString(bytes);
                return News;
            }
            else return "";
        }

        static string Rand(int Min, int Max)
        {
            return _Random.Next(Min, Max).ToString();
        }

        static string Learn(string message)
        {
            try
            {
                File.AppendAllText(CommandsPath + @"\Commands.txt", message + Environment.NewLine);
                return "Команда добавлена)";
            }
            catch
            {
                return "Команда не была добавлена(";
            }
        }

        #endregion
    }

    public class RssNews
    {
        public string Title;
        public string PublicationDate;
        public string Description;
    }
}
