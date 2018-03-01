using REST_polynomials.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace REST_polynomials.DataLayer
{
    //provides methods for save and read data from files
    public class FileLayer
    {
        private string pathDir; 

        private string fileName;

        public FileLayer()
        {
            Initialize();
        }

        private void Initialize()
        {
            fileName = "polinom";

            pathDir = string.Empty;

            pathDir = System.Configuration.ConfigurationManager.AppSettings["DestinationDir"];

            if (pathDir == string.Empty)
            {
                Console.WriteLine("No DestinationDir setting  in web.config");
            }
        }

        public void SaveAsTxt(Polinom polinom)
        {
            if (!new DirectoryInfo(pathDir).Exists)
                Directory.CreateDirectory(pathDir);

            fileName = getFileName(string.Format("{0}\\{1}", pathDir, fileName));

            File.WriteAllText(fileName, prepareFileContent(polinom));
        }

        public string getFileName(string filePath)
        {
            int count = 0;

            string initialPath = filePath;

            //find
            while (File.Exists(filePath + ".txt"))
            {
                filePath = initialPath + "(" + count.ToString() + ")";
                count++;
            }
            return filePath+".txt";
        }

        private string prepareFileContent(Polinom polinom)
        {
            string result = string.Empty;

            foreach (var item in polinom.items)
            {
                result += string.Format("{0};", item.ToString());
            }

            return result += polinom.freeConstant.ToString();
        }

        public List<Polinom> GetDataFromFileStorage()
        {
            var polinoms = new List<Polinom>();

            foreach (var file in Directory.GetFiles(pathDir))
            {
                var tmpPolinom = new Polinom();

                string fileContent = File.ReadAllText(file);

                if (fileContent.Length == 0)
                    continue;

                var splitedData = fileContent.Split(';').ToList();
                tmpPolinom.freeConstant = int.Parse(splitedData.Last());

                splitedData.Remove(splitedData.Last());

                foreach (var strItem in splitedData)
                {
                    string[] strPair = strItem.Split('X');
                    tmpPolinom.items.Add(new PolinomItem(int.Parse(strPair[0]), int.Parse(strPair[1])));
                }
                polinoms.Add(tmpPolinom);
            }

            return polinoms;
        }
    }
}