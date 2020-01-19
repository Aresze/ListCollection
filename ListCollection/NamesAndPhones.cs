using System;

namespace ListCollection
{
    public class NamesAndPhones
    {
        private string[] name;
        private string[] phone;
        Random rand;
        public NamesAndPhones()
        {
            rand = new Random();
            name = new string[] { "Rabbi Aiden", "Alison Barbosa",
                                              "Ann Becerra", "Aidan Barrera",
                                              "Armaan Bonilla", "Aston Bynum",
                                              "Ameera Brennan", "Tallulah Addis",
                                              "Faith Atkins","Maariyah Ames"};
            phone = new string[] {"(322) 591-1530",
                                              "(611) 302-5305",
                                              "(945) 970-8053",
                                              "(331) 580-8693",
                                              "(779) 859-3829",
                                              "(819) 852-6063",
                                              "(536) 543-9217",
                                              "(404) 451-7749",
                                              "(639) 844-9484",
                                              "(795) 227-1651"};
        }
        public string getRandomName()
        {
            return name[rand.Next(0, name.Length - 1)];
        }
        public string getRandomPhone()
        {
            return phone[rand.Next(0, phone.Length - 1)];
        }
    }

}
