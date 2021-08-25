using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
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
using VkNet.Enums.SafetyEnums;
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
        public static string ImagePath;

        const string BotCommandSuf = "";

        public MonteceVk()
        {
            Initialization();
            LoadLibrary();
        }

        public static void Initialization()
        {
            Console.Title = "Hentai-ka bot";
            ColorMessage("Hentai-ka bot", ConsoleColor.Yellow);

            Web = new WebClient();
            vkapi = new VkApi();
            _Random = new Random();
            CommandsPath = Environment.CurrentDirectory + @"/Commands";
            ImagePath = @"C:\Users\Lo_N\YandexDisk\вк";
            
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

       

        private static void Start()
        {
            ColorMessage("Авторизация успешно завершена.", ConsoleColor.Green);
            EyeInit();
            Console.WriteLine("Запросов в секунду доступно: " + vkapi.RequestsPerSecond);
        }

        static void LoadLibrary()
        {
            if (!Directory.Exists(CommandsPath) || !File.Exists(CommandsPath + @"/Commands.txt"))
            {
                Directory.CreateDirectory(CommandsPath);
                File.Create(CommandsPath + @"/Commands.txt");
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

        static string[] Commands = { "команды", "хентай", /*"учи~<Сообщение>~<Ответ> ,"*/ "ай", "альбедо", "асуна", "боруто", "чика","эрина","геншин","хестия", "изуми", "кабанери","кана", "коносуба","кирису", "мегумин", "нир", "микаса", "рафталия","сенко","шинон","татсумаки","умару","02" };

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
                    case "команды":
                        string msg = "";
                        for (int j = 0; j < Commands.Length; j++) msg += Commands[j] + ", "
                                +"\n";
                        SendMessage(msg);
                        break;
                    case "хентай":
                        int HentaiPath = 270921652;
                        Hentai(HentaiPath);
                        break;
                    case "ай":
                        int Ai = 280644067;
                        Hentai(Ai);
                        break;
                    case "альбедо":
                        int Albedo = 280644069;
                        Hentai(Albedo);
                        break;
                    case "асуна":
                        int Asuna = 280644071;
                        Hentai(Asuna);
                        break;
                    case "боруто":
                        int Boruto = 280644074;
                        Hentai(Boruto);
                        break;
                    case "чика":
                        int Chika = 280644076;
                        Hentai(Chika);
                        break;
                    case "эрина":
                        int Erina = 280644077;
                        Hentai(Erina);
                        break;
                    case "геншин":
                        int Genshin = 280644078;
                        Hentai(Genshin);
                        break;
                    case "хестия":
                        int Hestia = 280644080;
                        Hentai(Hestia);
                        break;
                    case "изуми":
                        int Izumi = 280644082;
                        Hentai(Izumi);
                        break;
                    case "кабанери":
                        int Kabaneri = 280644083;
                        Hentai(Kabaneri);
                        break;
                    case "кана":
                        int Kana = 280644087;
                        Hentai(Kana);
                        break;
                    case "коносуба":
                        int Konosuba = 280644088;
                        Hentai(Konosuba);
                        break;
                    case "кирису":
                        int Kirisu = 280644089;
                        Hentai(Kirisu);
                        break;
                    case "лоли":
                        int Loli = 280644092;
                        Hentai(Loli);
                        break;
                    case "мегумин":
                        int Megumin = 280644093;
                        Hentai(Megumin);
                        break;
                    case "нир":
                        int Nier = 280644097;
                        Hentai(Nier);
                        break;
                    case "микаса":
                        int Mikasa = 280644096;
                        Hentai(Mikasa);
                        break;
                    case "рафталия":
                        int Folder = 280644098;
                        Hentai(Folder);
                        break;
                    case "сенко":
                        int Senko = 280644099;
                        Hentai(Senko);
                        break;
                    case "шинон":
                        int Sinon = 280644103;
                        Hentai(Sinon);
                        break;
                    case "татсумаки":
                        int Tatsumaki = 280644105;
                        Hentai(Tatsumaki);
                        break;
                    case "умару":
                        int Umaru = 280644107;
                        Hentai(Umaru);
                        break;
                    case "02":
                        int Zero02 = 280644108;
                        Hentai(Zero02);
                        break;
                    default:
                        //---СОСТАВНЫЕ КОММАНДЫ---//
                        if (Message.Contains("учи~"))
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
            foreach (string Line in File.ReadAllLines(CommandsPath + @"/Commands.txt"))
            {
                if (Line.Substring(0, Line.IndexOf('~')).ToLower() == Command)
                {
                    return Line.Substring(Line.IndexOf('~') + 1);
                }
            }
            return "";
        }

       /* public static void Hentai(int s)
        {
            var random = new Random();
            var randomImage = random.Next(1, new DirectoryInfo(s).GetFiles().Length);

            var wc = new WebClient();
            var uploadServer = vkapi.Photo.GetMessagesUploadServer(userID);
            var response = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl, s + "/" + randomImage + @".jpg"));
            var attachment = vkapi.Photo.SaveMessagesPhoto(response);

            vkapi.Messages.Send(new MessagesSendParams
            {
                UserId = userID, //Id получателя
                Attachments = attachment, //Вложение
                RandomId = new Random().Next(999999) //Уникальный идентификатор
            });
        }*/

        public static void Hentai(int Albumid)
        {
            vkapi.Authorize(new ApiAuthParams
            {
                //AccessToken = "44ff296744ff296744ff2967bf44889659444ff44ff2967246b1e413baf476f19e8a415",
                Login = "+79017930178",
                Password = "AMG_FOREVER^^&@!$!",
                ApplicationId = 7847742,
                Settings = Settings.All
            });
            
            var photoGet = vkapi.Photo.Get(new PhotoGetParams { Count = 1000, OwnerId = -192785852, AlbumId = PhotoAlbumType.Id(Albumid) });

            var randomCount = new Random().Next(0, photoGet.Count);

            for (int i = 11; i > 5; i--)
            {
                vkapi.Authorize(new ApiAuthParams { AccessToken = "3fccfa54ed7a5c8fa15ab967e127dd1027104adb8c2cce515faed7df6e5a2d329d7f5ea37e7fa90b60a6d" });

                try
                {
                    var wc = new WebClient();
                    System.Drawing.Image img = new Bitmap(wc.OpenRead(photoGet[randomCount].Sizes[i].Url));
                    img.Save(Environment.CurrentDirectory + photoGet[randomCount].Id + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                    var uploadServer = vkapi.Photo.GetMessagesUploadServer(userID);
                    var response = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl, (Environment.CurrentDirectory + photoGet[randomCount].Id + ".jpg")));
                    var attachment = vkapi.Photo.SaveMessagesPhoto(response);

                    vkapi.Messages.Send(new MessagesSendParams
                    {
                        UserId = userID, //Id получателя
                        Attachments = attachment, //Вложение
                        RandomId = new Random().Next(999999) //Уникальный идентификатор
                    });
                    File.Delete(Environment.CurrentDirectory + photoGet[randomCount].Id + ".jpg");
                    break;
                }
                catch { continue; }
            }
        }
    

        static string Learn(string message)
        {
            try
            {
                File.AppendAllText(CommandsPath + @"/Commands.txt", message + Environment.NewLine);
                return "Команда добавлена)";
            }
            catch
            {
                return "Команда не была добавлена(";
            }
        }

        #endregion
    }
}
