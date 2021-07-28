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

            Variable.DataGridView = dataGridView1;

            Environment.CurrentDirectory = @"D:\utorrent\VK\Image\";
            CountImage.Text = new DirectoryInfo(@"D:\utorrent\VK\Image").GetFiles().Length.ToString();

            Authorization();

            VKGetBYIdInfo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = Properties.Settings.Default.RichTextBox_Value;
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.RichTextBox_Value = richTextBox1.Text;
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

        public void VKGetBYIdInfo()
        {
            string GroupKyda = txt_kyda.Text;

            var group = vkapi.Groups.GetById(null, GroupKyda, GroupsFields.All);

            foreach (var item in group)
            {
                GroupName.Text = item.Name;
                GroupAva.Load(item.Photo200.AbsoluteUri);
            }
        }

        public async Task<string> WallGet()
        {
            System.Drawing.Image img;
            ulong Offset = Convert.ToUInt64(txt_offset.Text);
            ulong CountPost = Convert.ToUInt64(txt_count.Text);

            int c = int.Parse(textBox1.Text);
            string[] sNums = richTextBox1.Text.Split(',');

            var URLList = new List<string>();

            int[] nums = new int[c];

            for (int j = 0; j < c; j++)
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

                                // dataGridView1.Rows.Add(false, item.OwnerId, item.Text, img, Convert.ToInt32(item.Attachments[i].Instance.Id), item.Date);

                                img.Save(item.Attachments[i].Instance.Id + ".png", System.Drawing.Imaging.ImageFormat.Png);
                            }
                        }
                    }
                }

                Thread.Sleep(1000);

            }
            return URLList.ToString();
        }

        /* public async void VKWallPost()
         {
             int GroupKyda = Convert.ToInt32(txt_kyda.Text);
             double addtime;
             DateTime date;

             for (int i = 0; i < Variable.DataGridView.Rows.Count - 1; i++)
             {
                 addtime = i;
                 addtime += i + Convert.ToDouble(txt_time.Text);
                 date = new DateTime();
                 date = DateTime.Today.AddHours(addtime);

                     WebClient wc = new WebClient();
                     await vkapi.Wall.PostAsync(new WallPostParams
                     {
                         OwnerId = -1 * GroupKyda,
                         FromGroup = true,
                         PublishDate = date,
                         Copyright = "pixiv.net",
                         Message = "#hentai_ka", //+ Variable.DataGridView[2, i].Value.ToString(),
                         Attachments = new List<MediaAttachment> { new Photo { OwnerId = Convert.ToInt64(Variable.DataGridView[1, i].Value.ToString()), Id = (Convert.ToInt64(Variable.DataGridView[4, i].Value.ToString())) } }
                     }); 
                 Thread.Sleep(1000);
             }
         }*/

        public void WallPost()
        {
            int GroupKyda = Convert.ToInt32(txt_kyda.Text);

            double addtime;
            DateTime date;

            for (int i = 1, j = Convert.ToInt32(CountImage.Text); i <= Convert.ToInt32(CountImage.Text); i++, j--)
            {
                //try
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
                    var response = Encoding.ASCII.GetString(wc.UploadFile(upServer.UploadUrl, @"D:\utorrent\VK\Image\ " + j + @".png"));

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

                    File.Delete(@"D:\utorrent\VK\Image\ " + j + @".png");

                    TimeSpan.FromMinutes(30);                }
               /* catch
                {
                    MessageBox.Show("ERRORRR");
                    break;
                }*/
            }
        }
    
        


        public void ReNameImage()
        {
            string added = textBox2.Text;
            int number = 0;//переменная для добавления номера к файлу
            string path = @"D:\utorrent\VK\Image\"; 

            DirectoryInfo my = new DirectoryInfo(path);
            foreach (FileInfo o in my.GetFiles())
            {

                number++;//увеличиваем каждый раз номер 
                string name = o.Name;
                File.Move(name, added + number + ".png");//само переименование
            }

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string[] sNums = richTextBox1.Text.Split(',');
            textBox1.Text = Convert.ToString(sNums.Length);

            WallGet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WallPost();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int delet = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(delet);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Variable.DataGridView.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = 1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReNameImage();
        }
    }

    class Variable
    {
        public static DataGridView DataGridView { get; set; }
    }
}

