using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using System.Threading;

namespace VKTest
{
    public partial class Form1 : Form
    {
        VkApi vkapi = new VkApi();

        public Form1()
        {
            InitializeComponent();

            string GroupOtkyda = txt_otkeda.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Authorization()
        {
            vkapi.Authorize(new ApiAuthParams()
            {
                Login = "+79777243865",
                Password = "AMG_FOREVER^^&@141",
                ApplicationId = 7847742,
                Settings = Settings.All
            });
        }
        
        public void VKGetBYIdInfo()
        {
            string GroupOtkyda = txt_otkeda.Text;

            var group = vkapi.Groups.GetById(null, GroupOtkyda, GroupsFields.All);

            foreach (var item in group) 
            {
                GroupName.Text = item.Name;
                GroupAva.Load(item.Photo200.AbsoluteUri);
            }
        }

        public async Task<string> VKwallGet()
        {
            int GroupOtkyda = Convert.ToInt32(txt_otkeda.Text);
            int GroupKyda = Convert.ToInt32(txt_kyda.Text);
            ulong Offset = Convert.ToUInt64(txt_offset.Text);
            ulong CountPost = Convert.ToUInt64(txt_count.Text);


            var URLList = new List<string>();

            var getwall = await vkapi.Wall.GetAsync(new WallGetParams{Count = CountPost, OwnerId = -1 * GroupOtkyda, Extended = true,Offset = Offset , Filter = VkNet.Enums.SafetyEnums.WallFilter.All});

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
                            System.Drawing.Image img = new Bitmap(wc.OpenRead(phLink));

                            dataGridView1.Rows.Add(false, item.ToString(), item.Text, img, item.Attachments[i].Instance.Id);
                        }
                    }
                }
            }
             return URLList.ToString();
        }

        public async void VKWallPost()
        {
            int GroupOtkyda = Convert.ToInt32(txt_otkeda.Text);
            int GroupKyda = Convert.ToInt32(txt_kyda.Text);
            double  addtime;
            DateTime date;
            try
            {
                for (int i = 0; i < Variable.DataGridView.Rows.Count - 1; i++)
                {


                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "True")
                    {

                        addtime = i;
                        addtime += Convert.ToDouble(txt_time.Text);
                        date = new DateTime();
                        date = DateTime.Today.AddHours(addtime);


                        WebClient wc = new WebClient();
                        await vkapi.Wall.PostAsync(new WallPostParams
                        {
                            OwnerId = -1 * GroupKyda,
                            FromGroup = true,
                            PublishDate = date,
                            Message = "#hentai_ka" + Variable.DataGridView[2, i].Value.ToString(),
                            Attachments = new List<MediaAttachment> { new Photo { OwnerId = -1 * GroupOtkyda, Id = (Convert.ToInt64(Variable.DataGridView[4, i].Value.ToString())) } }
                        }); ;

                    }

                    Thread.Sleep(1000);
                }
            }
            catch
            {
                MessageBox.Show("ошибка"); //сообщение об ошибке
            }
        }

        public static double UnixEncoding(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Variable.DataGridView = dataGridView1;
            Authorization();
            VKGetBYIdInfo();
            VKwallGet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VKWallPost();
        }

    }
}

