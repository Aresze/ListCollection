using System;
namespace ListCollection
{
    class Photo
    {
        Random rand = new Random();
        private string[] photo = new string[] {"avatar_1", "avatar_2",
                                              "avatar_3", "avatar_4",
                                              "avatar_5", "avatar_6",
                                              "avatar_7", "avatar_8",
                                              "avatar_9", "avatar_10"};
        public string getRandomPhoto()
        {
            return photo[rand.Next(0, photo.Length - 1)];
        }
    }
}