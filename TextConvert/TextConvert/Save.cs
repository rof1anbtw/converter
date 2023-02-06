using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace TextConvert
{
    internal class Save
    {
        public static Path NewPath = new Path();
        public static void ReadPath()
        {
            Console.WriteLine("Укажите путь куда вы хотите сохранить файл:");
            string path = Console.ReadLine();
            NewPath.path = path;
        }
        public static void TxtSave()
        {
            if (File.Exists(NewPath.path))
            {
                string txt = "";
                foreach (Model n in Model.listofmodels)
                {
                    txt += n.Name+n.Width+n.Height;
                }
                File.WriteAllText(NewPath.path, txt);
            }
            else
            {
                File.Create(NewPath.path);
            }
        }
        public static void JsonSave()
        {
            if(File.Exists(NewPath.path))
            {
                string json;
                json = JsonConvert.SerializeObject(Model.listofmodels);
                File.WriteAllText(NewPath.path, json);
            }
            else
            {
                File.Create(NewPath.path);
                JsonSave();
            }
        }
    }
}
