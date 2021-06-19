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
            txt_time.Text = (1+DateTime.Now.Hour).ToString();

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
                AccessToken = "04442bbe00da2bd8d28e84ec0c36f303e2b662ac57a375351a77bb833816516954e2c336f21c0a1dbd728",
                Login = "+79777243865",
                Password = "AMG_FOREVER^^&@141",
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

        public async Task<string> VKwallGet()
        {
            int GroupKyda = Convert.ToInt32(txt_kyda.Text);
            ulong Offset = Convert.ToUInt64(txt_offset.Text);
            ulong CountPost = Convert.ToUInt64(txt_count.Text);

            //
            int c = int.Parse(textBox1.Text);
            string[] sNums = richTextBox1.Text.Split(',');

            if (c > sNums.Length)
            {
                MessageBox.Show("Длина массива не соответсвует введенному!");
            }

            var URLList = new List<string>();



            int[] nums = new int[c];

            for (int j = 0; j < c; j++)
            {
                nums[j] = int.Parse(sNums[j]);

                //



                var getwall = await vkapi.Wall.GetAsync(new WallGetParams { Count = CountPost, OwnerId = -1 * nums[j], Extended = true, Offset = Offset, Filter = VkNet.Enums.SafetyEnums.WallFilter.All });


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

                                dataGridView1.Rows.Add(false, item.OwnerId, item.Text, img, item.Attachments[i].Instance.Id, item.Date);
                            }
                        }
                    }
                }
            }
            return URLList.ToString();
        }

        public async void VKWallPost()
        {
            int GroupKyda = Convert.ToInt32(txt_kyda.Text);
            double addtime;
            DateTime date;

            for (int i = 0; i < Variable.DataGridView.Rows.Count - 1; i++)
            {
                addtime = i;
                addtime += Convert.ToDouble(txt_time.Text);
                date = new DateTime();
                date = DateTime.Today.AddHours(addtime);

                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "True")
                {
                    WebClient wc = new WebClient();
                    await vkapi.Wall.PostAsync(new WallPostParams
                    {
                        OwnerId = -1 * GroupKyda,
                        FromGroup = true,
                        PublishDate = date,
                        Copyright = "pixiv.net",
                        Message = "#hentai_ka", //+ Variable.DataGridView[2, i].Value.ToString(),
                        Attachments = new List<MediaAttachment> { new Photo { OwnerId = Convert.ToInt64(Variable.DataGridView[1, i].Value.ToString()), Id = (Convert.ToInt64(Variable.DataGridView[4, i].Value.ToString())) } }
                    }); ;
                }
                Thread.Sleep(1000);
            }
        }
    
        

        private void button1_Click(object sender, EventArgs e)
        {
            Variable.DataGridView = dataGridView1;
            string[] sNums = richTextBox1.Text.Split(',');
            textBox1.Text = Convert.ToString(sNums.Length);
            Authorization();
            VKGetBYIdInfo();
            VKwallGet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VKWallPost();
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
    }
}

