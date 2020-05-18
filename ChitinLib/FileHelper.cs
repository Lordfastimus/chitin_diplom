using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ChitinLib
{
    public static class FileHelper
    {
        public static string GetAnalyseFolder() 
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Файлы анализа");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static IEnumerable<string> GetFileNamesForDirectory(string selectedFolderPath)
        {
            return Directory.GetFiles(selectedFolderPath, "*.*", SearchOption.AllDirectories)
                .Where(file => file.ToLower().EndsWith(".exe") || file.ToLower().EndsWith(".dll"));
        }

        public static void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, serializableObject);
                stream.Position = 0;
                xmlDocument.Load(stream);
                xmlDocument.Save(fileName);
            }
        }

        public static T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            string xmlString = xmlDocument.OuterXml;

            using (StringReader read = new StringReader(xmlString))
            {
                Type outType = typeof(T);

                XmlSerializer serializer = new XmlSerializer(outType);
                using (XmlReader reader = new XmlTextReader(read))
                {
                    objectOut = (T)serializer.Deserialize(reader);
                }
            }

            return objectOut;
        }

        public static T OpenFile<T>() where T : new()
        {            
            var dialog = new VistaOpenFileDialog();
            dialog.DefaultExt = ".xml";
            dialog.FileName = GetAnalyseFolder() + "/";

            if ((bool)dialog.ShowDialog())
            {
                try
                {
                    return DeSerializeObject<T>(dialog.FileName);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Ошибка загрузки");
                    return default;
                }
            }
            return default;
        }
    }
}
