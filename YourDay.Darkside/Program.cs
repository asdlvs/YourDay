using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using YourDay.DAL;

namespace YourDay.Darkside
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = "D:\\1.csv";
            //string[] doc = File.ReadAllLines(path, Encoding.Default);
            //using (DAL.YourDayEntities context = new DAL.YourDayEntities())
            //{
            //    POCO.Category category = null;
            //    foreach (string row in doc)
            //    {
            //        string[] rowdata = row.Split(';');

                    
            //        if (!String.IsNullOrEmpty(rowdata[0]))
            //        {
            //            category = new POCO.Category();
            //            category.Title = rowdata[1];
            //            category.Weight = 1;
            //            context.Categories.AddObject(category);
            //            Console.WriteLine(rowdata[1]);
            //        }
            //        else
            //        {
            //            POCO.SubCategory sc = new POCO.SubCategory();
            //            sc.Category = category;
            //            sc.Title = rowdata[1];
            //            context.SubCategories.AddObject(sc);
            //            Console.WriteLine(rowdata[1]);
            //        }
            //    }
            //    context.SaveChanges();
            //    Console.WriteLine("Done");
            //}
            //Console.ReadKey();
            //using (DAL.YourDayEntities context = new DAL.YourDayEntities())
            //{
            //    var w = context.Users.ToArray();
            //    var q = context.Users.OfType<POCO.SimpleUser>().ToArray();
            //}

            //TimeSpan ts1 = TimeSpan.Parse("18:00");
            //TimeSpan ts2 = TimeSpan.Parse("20:00");


            //Console.WriteLine(ts1 < ts2);
            //Console.WriteLine(ts2 == ts2);
            //Console.WriteLine(ts2 < ts1);


            //Test t = Test.a;
            //Console.WriteLine((int)t);
            //t = Test.a | Test.c;
            //Console.WriteLine((int)t);
            //Console.ReadKey();

            //^\<form \w*?\>(<html> \w{0,})\</form\>$
            //string rInput = "<form method=\"post\" action=\"../WS.asmx\" id=\"ctl00\">\r\n<div class=\"aspNetHidden\">\r\n<input type=\"hidden\" name=\"__VIEWSTATE\" id=\"__VIEWSTATE\" value=\"/wEPDwUBMA9kFgJmD2QWAmYPZBYGAgEPFgIeA3NyYwVOaHR0cDovL2xvY2FsaG9zdDo4NDAxL0ltYWdlcy9hc2RmZ2hqa2x6eGNAeWFuZGV4LnJ1L2F2YXRhcl8zMC5wbmc/cm5kPTQzOTg2MzExZAIDDw8WAh4EVGV4dAUd0JLQuNGC0LDQu9C40Lkg0JvQtdCx0LXQtNC10LJkZAIFDxYCHgtfIUl0ZW1Db3VudAIEFghmD2QWAgIBDw8WAh4LTmF2aWdhdGVVcmwFEy9jb250cmFjdG9yL2V2ZW50cy9kFgJmDxUBFdCc0L7QuCDRgdC+0LHRi9GC0LjRj2QCAQ9kFgICAQ8PFgIfAwUUL2NvbnRyYWN0b3IvcmVwb3J0cy9kFgJmDxUBE9Cc0L7QuCDQvtGC0YfQtdGC0YtkAgIPZBYCAgEPDxYCHwMFFS9jb250cmFjdG9yL21lc3NhZ2VzL2QWAmYPFQES0KHQvtC+0LHRidC10L3QuNGPZAIDD2QWAgIBDw8WAh8DBRgvY29udHJhY3Rvci9wcmVmZXJlbmNlcy9kFgJmDxUBEtCd0LDRgdGC0YDQvtC50LrQuGRk9bmXOKrLz8+pPXxbC6EG/BQ7kVZ0jh3160sD4lx3B5w=\" />\r\n</div>\r\n\r\n\r\n<div class=\"headerlinks\">\r\n    <div class=\"cell userimg\">\r\n        <img src=\"http://localhost:8401/Images/asdfghjklzxc@yandex.ru/avatar_30.png?rnd=43986311\" id=\"ctl01_userimg\" />\r\n    </div>\r\n    <div class=\"cell name\">\r\n        <span id=\"ctl01_LabelUserName\">Виталий Лебедев</span>\r\n    </div>\r\n    <div class=\"cell links\">\r\n       \r\n            <div class=\"one\">\r\n                <a href=\"/contractor/events/\">Мои события</a>\r\n            </div>\r\n            <div class=\"whitespace\"></div>\r\n        \r\n            <div class=\"one\">\r\n                <a href=\"/contractor/reports/\">Мои отчеты</a>\r\n            </div>\r\n            <div class=\"whitespace\"></div>\r\n        \r\n            <div class=\"one\">\r\n                <a href=\"/contractor/messages/\">Сообщения</a>\r\n            </div>\r\n            <div class=\"whitespace\"></div>\r\n        \r\n            <div class=\"one\">\r\n                <a href=\"/contractor/preferences/\">Настройки</a>\r\n            </div>\r\n            <div class=\"whitespace\"></div>\r\n        \r\n    </div>\r\n    <div class=\"cell exit\">\r\n        <a href=\"#\" onclick=\"logout(''); return false\" class=\"yellow\">Выход</a>\r\n    </div>\r\n</div>\r\n</form>";
            //Regex r = new Regex(@"^<form(\s|\S)*?>(?<html>(\s|\S)*)</form>$"); //?rnd\d{1,8}$
            //if (r.IsMatch(rInput)) //?rnd63735434
            //    Console.WriteLine("Dooog");
            //else
            //    Console.WriteLine("Baaad");

            //string result = r.Replace(rInput, "${html}");
            //Console.WriteLine(result);
            //Console.ReadKey();

            using (MailEntities context = new MailEntities())
            {
                var v = context.MailQueue.Take(5).ToList();
                Console.WriteLine(v);

            }
            Console.ReadKey();

        }
    }

    //[Flags]
    //public enum Test
    //{ 
    //    a = 1,
    //    b = 2,
    //    c = 4
    //}
}
