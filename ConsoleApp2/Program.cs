using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Net;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;

namespace ConsoleApp2
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Authorization();
            PhotoGet();
        }

        public static void Authorization()
        {
            VkApi vkapi = new VkApi();
        }

        public static void PhotoGet()
        {


            VkApi vkapi = new VkApi();

            vkapi.Authorize(new ApiAuthParams()
            {
                //AccessToken = "0d2722015a5a8c9023934927244e04d7965ebc881c1c420408ded01aa5af43ee0082179db8e0122a64121",
                Login = "+79017930178",
                Password = "AMG_FOREVER^^&@!$!",
                ApplicationId = 7847742,
                Settings = Settings.All
            });

            var photoGet = vkapi.Photo.GetAll(new PhotoGetAllParams { OwnerId = 415135351, Count = 200, Offset = 600 });

            {
                foreach (var photo in photoGet)
                {
                    for (int i = 0; i <= 10; i++)
                    {

                        try
                        {
                            string phLink = photo?.Sizes[i].Url.ToString();

                            WebClient wc = new WebClient();
                            System.Drawing.Image img = new Bitmap(wc.OpenRead(phLink));


                            img.Save(photo.Id + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        }
                        catch
                        {
                            Console.WriteLine(" ошибка" + photo.Id.ToString());
                            continue;
                        }
                    }
                }
            }

        }
    }


}

