using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System;
using System.Net;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Utils;

namespace AvaloniaApplication3
{
    public partial class MainWindow : Window
    {
        VkApi vkapi = new VkApi();


        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new VK() { GroupName = "Название группы", GroupAva = new Bitmap((new WebClient()).OpenRead(@"D:\utorrent\VK\Image\a.png" )).ToString()};



#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

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
            string GroupKyda = 193939494.ToString();

            var group = vkapi.Groups.GetById(null, GroupKyda, GroupsFields.All);

            foreach (var item in group)
            {
                var groupAva = this.DataContext = new VK() { GroupName = @"D:\utorrent\VK\Image\a.png" }; 
                var groupInfo = this.DataContext = new VK() {GroupName = item.Name };

                //Bitmap bmp = new Bitmap((new WebClient()).OpenRead(item.Photo200));

            }
        }

        public void StartButton(object sender, RoutedEventArgs e)
        {

            Authorization();
            VKGetBYIdInfo();
        }
    }
}
