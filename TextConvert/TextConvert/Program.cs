using System.ComponentModel;
using System.Text.Json.Nodes;

namespace TextConvert
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool check = true;
            while (check == true)
            {
                Console.WriteLine("1-открыть txt файл\n" + "2-открыть json файл\n" + "3-открыть xml файл\n" + "4-создать txt файл\n" + "5-создать json файл\n" + "6-выйти");
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1: Read.ReadPath(); Read.TxtRead(); break;
                    case 2: Read.ReadPath(); Read.JsonRead(); break;
                    case 3: Read.ReadPath(); Read.XmlRead(); break;
                    case 4: Save.ReadPath(); Save.TxtSave(); break;
                    case 5: Save.ReadPath(); Save.JsonSave(); break;
                    case 6: exit();break;
                }

            }
            void exit()
            {
                check = false;
            }
        }
    }
}