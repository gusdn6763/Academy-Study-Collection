using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CH03
    {
        static void Main()
        {
            string tmp = "Hello World.jpg";

            int save=tmp.IndexOf("W");
            Console.WriteLine(save);

            //검색하는 순서만 달라서 값은 똑같이 나옴
            int save1 = tmp.LastIndexOf("W");
            Console.WriteLine(save1);

            int save2 = tmp.IndexOf("o", 5);
            Console.WriteLine(save2);

            bool save3 = tmp.StartsWith("Helo");
            Console.WriteLine(save3);

            bool save4 = tmp.EndsWith("jpg");
            Console.WriteLine(save4);

            bool save5 = tmp.Contains("o W");
            Console.WriteLine(save5);

            string save6 = tmp.Replace("o W", "O w");
            Console.WriteLine(save6);

            Console.WriteLine();
            string tmp1="abccdefghijk";
            Console.WriteLine(tmp1);

            string save7 = tmp1.Insert(3, "x").Insert(7, "y");
            Console.WriteLine(save7);

            string save8 = tmp1+"llll";
            Console.WriteLine(save8);

            string save9 = tmp1.Remove(5);
            Console.WriteLine(save9);
            Console.WriteLine();

            
            

            //,를 기준으로 주면 ,기준으로 배열형태로 들어옴
            string tmp2 = "Hello World11, Hello World12,Hello World13, Hello World14,Hello World";

            //6에서 부터 5개의 문자 반환
            string newtmp2 = tmp2.Substring(6,5);
            string[] strArr = tmp2.Split(',');


            Console.WriteLine(newtmp2);
            Console.WriteLine(strArr[0]);
            Console.WriteLine(strArr[1]);
            Console.WriteLine(strArr[2]);
            Console.WriteLine();

            //콤마를 기준으로 순서 변경
            string str1 = string.Format("{1} {0}", "Hello", "World");
            Console.WriteLine(str1);

            //-값 +값 정렬 위치 차이
            string str2 = string.Format("{0, -10}: {1}", "이름", "홍길동");
            Console.WriteLine(str2);

            //정렬 후 삽입
            string str3 = string.Format("{0, 10}: {1}", "나이", 23);
            Console.WriteLine(str3);


            string str4 = string.Format("{0:N0}", 123456789);
            string str5 = string.Format("{0:F1}", 1.2345);
            string str6 = string.Format("{0:E}", 1234567.89);
            Console.WriteLine(str4);
            Console.WriteLine(str5);
            Console.WriteLine(str6);


            DateTime datetime = new DateTime(2019, 08, 18, 20, 59, 00);
            string dateStr1 = string.Format("{0:yyyy-MM-dd tt hh:mm:ss (ddd)}", datetime);
            string dateStr2 = datetime.ToString();

            CultureInfo cultureinfo =new CultureInfo("en-US");
            string dateStr3 = datetime.ToString("yyyy-MM-dd tt hh:mm:ss (ddd)", cultureinfo);

            Console.WriteLine(dateStr1);
            Console.WriteLine(dateStr2);
            Console.WriteLine(dateStr3);
        }
    }
}
