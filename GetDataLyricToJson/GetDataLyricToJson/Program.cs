using GetDataLyricToJson.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace GetDataLyricToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\git\LyricApp\LoiBaiHat";
            var filePaths = Directory.GetFiles(path);
            // "C:\git\LyricApp\LoiBaiHat\1 Lần - Tr?ng Hiếu .docx"
            List<LyricClass> list = new List<LyricClass>();
            int i = 1;
            foreach (var item in filePaths)
            {
                try
                {
                    if (item.Contains(".txt"))
                    {
                        var lyr = getTxtItem(item, i);
                        list.Add(lyr);
                    }
                    else
                    {
                        var lyr = getLyricInfo(item, i);
                        list.Add(lyr);
                    }
                }
                catch
                {
                    Console.WriteLine("Lỗi at: " + item);
                }

                i++;
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var jsonData = JsonSerializer.Serialize(list, options);
            var nameFileToWrite = getFileString();
            File.WriteAllText(@"C:\git\LyricApp\JsonFile\" + nameFileToWrite, jsonData, Encoding.Default);
            Console.WriteLine("OK!");
        }

        public static string getFileString()
        {
            DateTime d = DateTime.Now;
            return d.Year + "-" + d.Month + "-" + d.Day + " " + d.Hour + "h" + d.Minute + "m" + d.Second + "s.json";
        }

        public static LyricClass getLyricInfo(string item, int i)
        {
            LyricClass tmp = new LyricClass();

            var _backslackIdx = item.LastIndexOf(@"\");
            var _minusIdx = item.LastIndexOf("-");
            var _dotIdx = item.LastIndexOf(".");

            // id
            tmp.id = i;

            // name
            var _name = item.Substring(_backslackIdx + 1, _minusIdx - _backslackIdx - 1);
            while (_name[0] == ' ')
            {
                _name = _name.Substring(1, _name.Length - 1);
            }
            while (_name[_name.Length - 1] == ' ')
            {
                _name = _name.Substring(0, _name.Length - 1);
            }
            tmp.name = _name;

            // composer
            var _composer = item.Substring(_minusIdx + 1, _dotIdx - _minusIdx - 1);
            while (_composer[0] == ' ')
            {
                _composer = _composer.Substring(1, _composer.Length - 1);
            }
            while (_composer[_composer.Length - 1] == ' ')
            {
                _composer = _composer.Substring(0, _composer.Length - 1);
            }
            tmp.composer = _composer;

            // filename
            var _fileName = item.Substring(_backslackIdx + 1, item.Length - _backslackIdx - 1);
            tmp.filename = _fileName;

            // url
            tmp.url = item;

            // type
            var _type = item.Substring(_dotIdx + 1, item.Length - _dotIdx - 1);
            tmp.type = _type;

            return tmp;
        }

        public static LyricClass getTxtItem(string item, int i)
        {
            LyricClass tmp = new LyricClass();

            var lines = File.ReadAllLines(item, Encoding.UTF8);
            //var test = string.Join("\n", lines);

            var _backslackIdx = item.LastIndexOf(@"\");

            /*
            // Create a pattern for a word that starts with letter "M"  
            string pattern = @"\b[M]\w+";
            // Create a Regex  
            Regex rg = new Regex(pattern);

            // Long string  
            string authors = "Mahesh Chand, Raj Kumar, Mike Gold, Allen O'Neill, Marshal Troll";
            // Get all matches  
            MatchCollection matchedAuthors = rg.Matches(authors);
            // Print all matched authors  
            for (int count = 0; count < matchedAuthors.Count; count++)
                Console.WriteLine(matchedAuthors[count].Value);
            */

            // id
            tmp.id = i;

            // name
            tmp.name = lines[1];

            // composer
            tmp.composer = lines[3];

            // filename
            var _fileName = item.Substring(_backslackIdx + 1, item.Length - _backslackIdx - 1);
            tmp.filename = _fileName;

            // url
            tmp.url = item;

            // type
            tmp.type = "txt";

            return tmp;
        }

    }
}
