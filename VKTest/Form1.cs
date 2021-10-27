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

            Authorization();

            if (Properties.Settings.Default.PathDirectory_Value == null)
            {
                Properties.Settings.Default.PathDirectory_Value = @"C:\";
            }

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
                AccessToken = "91a2138d54ebe0aeb91699b4663f5b23ade0b75a78dd69cb3612f046e245f226225ae69ce9df3f4dd49e8",
                Login = "+79777243865",
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

                                img.Save(txt_SelectFolder.Text + item.OwnerId + "_" + +item.Attachments[i].Instance.Id + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
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

            for (int i = 1, j = CountImage; i <= 50; i++, j--)
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
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    var message = MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (message == DialogResult.OK)
                    { continue; }
                    else { break; }
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
            var photoGet = vkapi.Photo.Get(new PhotoGetParams { OwnerId = Convert.ToInt32(txt_UserPhotoOwnerID.Text), Count = (ulong)Convert.ToInt64(txt_UserPhotoCount.Text), Offset = (ulong)Convert.ToInt32(txt_UserPhotoOffset.Text), AlbumId = VkNet.Enums.SafetyEnums.PhotoAlbumType.Id(Convert.ToInt32(txt_UserPhotoAlbumID.Text)) });
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

        #region GetAlbums
        private void button1_Click_1(object sender, EventArgs e)
        {
            var AlbumId = vkapi.Photo.GetAlbums(new PhotoGetAlbumsParams { OwnerId = -192785852 });
            foreach (var ID in AlbumId)
            {
                richTextBox1.Text += ID.Title + ": " + ID.Id + "\n";
            }
        }

        #endregion

        #region Photo Save
        private void button2_Click_1(object sender, EventArgs e)
        {
            var CountImage = new DirectoryInfo(Environment.CurrentDirectory).GetFiles().Length;
            var satartNumber = Convert.ToInt32(txt_PhotoSave_i.Text);
            for (int i = satartNumber; i < CountImage; i++)
            {
                try
                {
                    var wc = new WebClient();

                    var albumID = Convert.ToInt32(txt_PhotoSaveAlbumID.Text);
                    var groupID = 192785852;

                    var uploadServer = vkapi.Photo.GetUploadServer(albumID, groupID);
                    var response = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl, Environment.CurrentDirectory + "/" + i + @".jpg"));
                    var attachment = vkapi.Photo.Save(new PhotoSaveParams { GroupId = groupID, AlbumId = albumID, SaveFileResponse = response });
                    richTextBox2.Text = i + "/" + CountImage;
                }
                catch
                {
                    continue;
                }
                Thread.Sleep(500);
            }

        }

        #endregion

    }

}


