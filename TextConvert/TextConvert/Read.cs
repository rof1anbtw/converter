using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace TextConvert
{
    internal class Read
    {
        public static Path NewPath = new Path();
        
        public static void ReadPath()
        {
            Console.WriteLine("Укажите путь до файла:");
            string path = Console.ReadLine();
            NewPath.path = path;

        }
        public static void TxtRead()
        {
            Model.listofmodels.Clear();
            string[] txt = File.ReadAllLines(NewPath.path);
            for (int i = 0; i < txt.Length; i += 3)
            {
                Model model = new Model();
                model.Name = txt[i];
                model.Width = txt[i + 1];
                model.Height = txt[i + 2];
                Model.listofmodels.Add(model);
                foreach (Model n in Model.listofmodels)
                {
                    Console.WriteLine(n.Name);
                    Console.WriteLine(n.Width);
                    Console.WriteLine(n.Height);
                }
            }
        }
        public static void JsonRead()
        {
            Model.listofmodels.Clear();
            string json = File.ReadAllText(NewPath.path);
            Model.listofmodels = JsonConvert.DeserializeObject<List<Model>>(json);
            foreach (Model n in Model.listofmodels)
            {
                Console.WriteLine(n.Name);
                Console.WriteLine(n.Width);
                Console.WriteLine(n.Height);
            }
        }
        public static void XmlRead()
        {
            Model.listofmodels.Clear();
            Model xmlText;
            XmlSerializer xml = new XmlSerializer(typeof(Model));
            using (FileStream fs = new FileStream(NewPath.path, FileMode.Open))
            {
                xmlText = (Model)xml.Deserialize(fs);
            }
            Model.listofmodels.Add(xmlText);
            foreach (Model n in Model.listofmodels)
            {
                Console.WriteLine(n.Name);
                Console.WriteLine(n.Width);
                Console.WriteLine(n.Height);
            }
        }
    }
}
