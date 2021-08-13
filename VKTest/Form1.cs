using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using System.Collections.ObjectModel;
using System.Diagnostics;
using VkNet.Enums;
using VkNet.Exception;

namespace VKTest
{
    public partial class Form1 : Form
    {
        VkApi vkapi = new VkApi();


        public Form1()
        {
            InitializeComponent();

            Authorization();

            Environment.CurrentDirectory = Properties.Settings.Default.PathDirectory_Value;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_GroupWallGetOwnerID.Text = Properties.Settings.Default.RichTextBox_Value;
            txt_SelectFolder.Text = Properties.Settings.Default.PathDirectory_Value;
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.RichTextBox_Value = txt_GroupWallGetOwnerID.Text;
            Properties.Settings.Default.PathDirectory_Value = txt_SelectFolder.Text;
            Properties.Settings.Default.Save();
        }

        #region Auth

        public void Authorization()
        {
            vkapi.Authorize(new ApiAuthParams()
            {
                //AccessToken = "2943f696837fb2befcf3132463b0774282a8b0bf2d43dabb2edccca8cf83605618d7d5e6262b3b105f992",
                Login = "+79017930178",
                Password = "AMG_FOREVER^^&@!$!",
                ApplicationId = 7847742,
                Settings = Settings.All
            });
        }

        #endregion

        #region Select Folder

        private void button6_Click(object sender, EventArgs e)
        {
            string path = null;
            using (var dialog = new FolderBrowserDialog())
                if (dialog.ShowDialog() == DialogResult.OK)
                    path = dialog.SelectedPath;
            txt_SelectFolder.Text = path + @"\";
            Environment.CurrentDirectory = txt_SelectFolder.Text;
        }

        #endregion

        #region Wall Get&Post

        public async Task<string> WallGet()
        {
            System.Drawing.Image img;
            var Offset = Convert.ToUInt64(txt_GroupWallGetOffset.Text);
            var CountPost = Convert.ToUInt64(txt_GroupWallGetCount.Text);

            var URLList = new List<string>();

            int[] GroupCount = txt_GroupWallGetOwnerID.Text.Split(',').Select(int.Parse).ToArray();

            for (int j = 0; j < GroupCount.Length; j++)
            {
                var getwall = await vkapi.Wall.GetAsync(new WallGetParams { Count = CountPost, OwnerId = -GroupCount[j], Extended = true, Offset = Offset, Filter = VkNet.Enums.SafetyEnums.WallFilter.All });

                foreach (var item in getwall.WallPosts)
                {
                    if (item.Attachments.Any())
                    {
                        for (int i = 0; i < item.Attachments.Count; i++)
                        {
                            if (item.Attachments[i].Instance is Photo photo)
                            {
                                Photo items = (Photo)item.Attachments[i].Instance;
                                List<Photo> photos = getwall.WallPosts.Select(x => x.Attachments.FirstOrDefault()?.Instance).OfType<Photo>().ToList();

                                string phLink = (item.Attachments[i].Instance as Photo)?.Sizes[6].Url.ToString();
                                URLList.Add(phLink);

                                WebClient wc = new WebClient();
                                img = new Bitmap(wc.OpenRead(phLink));

                                img.Save(txt_SelectFolder.Text + item.OwnerId + "_" + + item.Attachments[i].Instance.Id + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                        }
                    }
                }

                Thread.Sleep(1000);

            }
            return URLList.ToString();
        }

        public void WallPost()
        {
            var GroupKyda = Convert.ToInt64(txt_WallPostOwnerID.Text);
            var CountImage = new DirectoryInfo(Environment.CurrentDirectory).GetFiles().Length;
            var Day = Convert.ToSByte(txt_WallPostDay.Text);
            var Hour = Convert.ToSByte(txt_WallPostHours.Text);

            float addtime;
            DateTime date;

            for (int i = 1, j = CountImage-2; i <= CountImage; i++, j--)
            {
                try
                {
                    addtime = i;
                    addtime += i * 30;
                    date = new DateTime();
                    date = DateTime.Now.AddDays(Day).AddHours(Hour).AddMinutes(addtime);

                    var wc = new WebClient();
                    var upServer = vkapi.Photo.GetWallUploadServer(GroupKyda);
                    var response = Encoding.ASCII.GetString(wc.UploadFile(upServer.UploadUrl, txt_SelectFolder.Text + j + @".jpg"));
                    var photos = vkapi.Photo.SaveWallPhoto(response, null, (ulong)GroupKyda);

                    vkapi.Wall.Post(new WallPostParams
                    {
                        OwnerId = -GroupKyda,
                        Attachments = photos,
                        FromGroup = true,
                        PublishDate = date,
                        Copyright = "pixiv.net",
                        Message = "#hentai_ka",
                    });

                    File.Delete(txt_SelectFolder.Text + j + @".jpg");

                    //var time = TimeSpan.FromMinutes(30);
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WallGet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WallPost();
        }

        #endregion

        #region User Get Photo

        private void btn_UserPhotoGet_Click(object sender, EventArgs e)
        {
            var photoGet = vkapi.Photo.Get(new PhotoGetParams { OwnerId = Convert.ToInt32(txt_UserPhotoOwnerID.Text), Count = (ulong)Convert.ToInt64(txt_UserPhotoCount.Text), Offset = (ulong)Convert.ToInt32(txt_UserPhotoOffset.Text),AlbumId = VkNet.Enums.SafetyEnums.PhotoAlbumType.Id(Convert.ToInt32(txt_UserPhotoAlbumID.Text)) });
            {
                foreach (var photo in photoGet)
                {
                    for (int i = 6; i < 11; i++)
                    {
                        try
                        {
                            string phLink = photo?.Sizes[i].Url.ToString();

                            WebClient wc = new WebClient();
                            System.Drawing.Image img = new Bitmap(wc.OpenRead(phLink));

                            img.Save(txt_SelectFolder.Text + photo.OwnerId + "_" + photo.Id + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        //Thread.Sleep(500);
                    }
                }
            }
        }

        #endregion

        #region User Group

        private void btn_UserGroup_Click(object sender, EventArgs e)
        {

            txt_UserGroupListOwnerID.Clear();

            var groupGet = vkapi.Groups.Get(new GroupsGetParams { UserId = Convert.ToInt32(txt_UserGroupUserID.Text), Count = Convert.ToInt32(txt_UserGroupCount.Text), Offset = Convert.ToInt32(txt_UserGroupOffset.Text) });

            foreach (var group in groupGet)
            {

                lb_UserGroupCount.Text = "Group Count: " + groupGet.Count.ToString();

                    txt_UserGroupListOwnerID.Text += group.Id + "," + "\n";
            }
        }
        #endregion

        #region Bot
        //

        public WebClient Web;
        public Random _Random;
        public long userID = 193939494;

        public string CommandsPath;
        public string ImagePath;

        public bool IsChat = false;
        const string BotCommandSuf = "";

        public void Bot()
        {
            BotInitialization();
            BotAuthorization();
            LoadLibrary();
        }

        public void BotInitialization()
        {
            Log("Hentai-ka bot", null, null, null);

            Web = new WebClient();
            vkapi = new VkApi();
            _Random = new Random();
            CommandsPath = Environment.CurrentDirectory + @"\Commands";
            ImagePath = Environment.CurrentDirectory + @"\Image";
        }

        public bool BotAuthorization()
        {

            try
            {
                Log("Попытка авторизации..." + null, null, null, null);
                vkapi.Authorize(new ApiAuthParams { AccessToken = "3fccfa54ed7a5c8fa15ab967e127dd1027104adb8c2cce515faed7df6e5a2d329d7f5ea37e7fa90b60a6d" });
                Start();
                return true;
            }
            catch (Exception e)
            {
                Log("Не удалось произвести авторизацию!" + Environment.NewLine + e.Message, null, null, null);
                return false;
            }
        }

        private void Start()
        {
            Log("Авторизация успешно завершена." + null, null, null, null);
            EyeInit();
            Log("Запросов в секунду доступно: " + vkapi.RequestsPerSecond + null, null, null, null);
        }

        public void LoadLibrary()
        {
            if (!Directory.Exists(CommandsPath) || !File.Exists(CommandsPath + @"\Commands.txt"))
            {
                Directory.CreateDirectory(CommandsPath);
                File.Create(CommandsPath + @"\Commands.txt");
            }
            else Log("Директория сообщений создана успешно загружена." + null, null, null, null);
        }

        public void MonteceVkBot_Logout(VkApi owner)
        {
            Log("Отключение от VK...", null, null, null);
        }

        public void SendMessage(string message)
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
                Log("Ошибка! " + e.Message, null, null, null);
            }
        }

        #region Watcher
        public ulong? Ts;
        public ulong? Pts;
        public bool IsActive;
        public System.Threading.Timer WatchTimer = null;
        public byte MaxSleepSteps = 3;
        public int StepSleepTime = 333;
        public byte CurrentSleepSteps = 1;
        public delegate void MessagesRecievedDelegate(VkApi owner, ReadOnlyCollection<VkNet.Model.Message> messages);
        public event MessagesRecievedDelegate NewMessages;

        public void EyeInit()
        {
            LongPollServerResponse Pool = vkapi.Messages.GetLongPollServer(true);
            StartAsync((ulong?)Convert.ToInt64(Pool.Ts), Pool.Pts);
            NewMessages += MonteceVkBot_NewMessages;
            vkapi.OnTokenExpires += MonteceVkBot_Logout;
            Log("Слежение за сообщениями активировано.", null, null, null);
        }

        public void MonteceVkBot_NewMessages(VkApi owner, ReadOnlyCollection<VkNet.Model.Message> messages)
        {
            Console.Beep();
            for (int i = 0; i < messages.Count; i++)
            {
                if (messages[i].Type != MessageType.Sended && messages[i].Text.Contains(BotCommandSuf))
                {
                    string MSG = messages[i].Text.Substring(BotCommandSuf.Length);
                    userID = messages[i].PeerId.Value;

                    var Name = vkapi.Users.Get(new long[] { userID }).FirstOrDefault();
                    Log("Новое сообщение: ", Name.FirstName.ToString() + " ", Name.LastName.ToString() + ": ", messages[i].Text);

                    Console.Beep();
                    Command(MSG);
                }
            }
        }

        public LongPollServerResponse GetLongPoolServer(ulong? lastPts = null)
        {
            LongPollServerResponse response = vkapi.Messages.GetLongPollServer(false);
            Ts = (ulong)Convert.ToInt64(response.Ts);
            Pts = Pts == null ? response.Pts : lastPts;
            return response;
        }

        public Task<LongPollServerResponse> GetLongPoolServerAsync(ulong? lastPts = null)
        {
            return Task.Run(() =>
            {
                return GetLongPoolServer(lastPts);
            });
        }

        public LongPollHistoryResponse GetLongPoolHistory()
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
            else Log(errorLog, null, null, null);
            return history;
        }

        public Task<LongPollHistoryResponse> GetLongPoolHistoryAsync()
        {
            return Task.Run(() => { return GetLongPoolHistory(); });
        }

        public async void WatchAsync(object state)
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

        public async void StartAsync(ulong? lastTs = null, ulong? lastPts = null)
        {
            if (IsActive) Log("Messages for {0} already watching", null, null, null);
            IsActive = true;
            await GetLongPoolServerAsync(lastPts);
            WatchTimer = new System.Threading.Timer(new TimerCallback(WatchAsync), null, 0, Timeout.Infinite);
        }

        #endregion

        #region Commands

        public string[] Commands = { "помощь", "хентай", "случайное число <Мин> <Макс>", "новости", "учи~<Сообщение>~<Ответ>" };

        public void Command(string Message)
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

        public string CheckCommand(string Command)
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

        public void Hentai()
        {
            var random = new Random();
            var randomImage = random.Next(1, new DirectoryInfo(ImagePath).GetFiles().Length);

            var wc = new WebClient();
            // Получить адрес сервера для загрузки картинок в сообщении
            var uploadServer = vkapi.Photo.GetMessagesUploadServer(userID);

            // Загрузить картинку на сервер VK.
            var response = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl, ImagePath + "/ " + randomImage + @".png"));

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

        public string News(string url)
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

        public string Rand(int Min, int Max)
        {
            return _Random.Next(Min, Max).ToString();
        }

        public string Learn(string message)
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

        public void Log(string _in1, string _in2, string _in3, string _in4)
        {
            if (IsHandleCreated)
            {
                txt_BotLog.Invoke(new Action(() => txt_BotLog.Text += _in1 + _in2 + _in3 + _in4 + "\n" + "***********" + "\n"));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bot();
        }

        //
        #endregion

    }

}


public class RssNews
{
    public string Title;
    public string PublicationDate;
    public string Description;
}

