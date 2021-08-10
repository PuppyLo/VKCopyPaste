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
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;

namespace VKTest
{
    public partial class Form1 : Form
    {
        VkApi vkapi = new VkApi();

        public Form1()
        {
            InitializeComponent();

            Environment.CurrentDirectory = textBox3.Text;


            Authorization(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = Properties.Settings.Default.RichTextBox_Value;
            textBox3.Text = Properties.Settings.Default.PathDirectory_Value;
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.RichTextBox_Value = richTextBox1.Text;
            Properties.Settings.Default.PathDirectory_Value = textBox3.Text;
            Properties.Settings.Default.Save();
        }

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

        public async Task<string> WallGet()
        {
            System.Drawing.Image img;
            ulong Offset = Convert.ToUInt64(txt_offset.Text);
            ulong CountPost = Convert.ToUInt64(txt_count.Text);


            string[] sNums = richTextBox1.Text.Split(',');

            var URLList = new List<string>();

            int[] nums = new int[Convert.ToInt32(sNums)];

            for (int j = 0; j < Convert.ToInt32(sNums); j++)
            {
                nums[j] = int.Parse(sNums[j]);

                var getwall = await vkapi.Wall.GetAsync(new WallGetParams { Count = CountPost, OwnerId = -nums[j], Extended = true, Offset = Offset, Filter = VkNet.Enums.SafetyEnums.WallFilter.All });

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

                                img.Save(item.Attachments[i].Instance.Id + ".png", System.Drawing.Imaging.ImageFormat.Png);
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
            var GroupKyda = Convert.ToInt32(txt_kyda.Text);

            var CountImage = new DirectoryInfo(Environment.CurrentDirectory).GetFiles().Length;

            double addtime;
            DateTime date;

            for (int i = 1, j = CountImage - 2; i <= Convert.ToInt32(CountImage); i++, j--)
            {
                try
                {
                    addtime = i;
                    addtime += i * 30;
                    //addtime += Convert.ToDouble(txt_time.Text);
                    date = new DateTime();
                    date = DateTime.Now.AddDays(Convert.ToDouble(txt_Day.Text)).AddHours(Convert.ToDouble(txt_Hour.Text)).AddMinutes(addtime);

                    var wc = new WebClient();

                    // Получить адрес сервера для загрузки картинок в сообщении
                    var upServer = vkapi.Photo.GetWallUploadServer(GroupKyda);

                    // Загрузить картинку на сервер VK.
                    var response = Encoding.ASCII.GetString(wc.UploadFile(upServer.UploadUrl, textBox3.Text + j + @".jpg"));

                    // Сохранить загруженный файл
                    var photos = vkapi.Photo.SaveWallPhoto(response, null, Convert.ToUInt64(GroupKyda));

                    //Отправить сообщение с нашим вложением
                    vkapi.Wall.Post(new WallPostParams
                    {
                        OwnerId = -GroupKyda, //Id группы
                        Attachments = photos, //Вложение
                        FromGroup = true,
                        PublishDate = date,
                        Copyright = "pixiv.net",
                        Message = "#hentai_ka",
                    });

                    File.Delete(textBox3.Text + j + @".jpg");

                    var time = TimeSpan.FromMinutes(30);
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
            string[] sNums = richTextBox1.Text.Split(',');

            WallGet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WallPost();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string path = null;
            using (var dialog = new FolderBrowserDialog())
                if (dialog.ShowDialog() == DialogResult.OK)
                    path = dialog.SelectedPath;
                    textBox3.Text = path + @"\";
                    Environment.CurrentDirectory = textBox3.Text; 
        }
    }
}

