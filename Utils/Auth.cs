﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoveAnim.Utils
{
    public class Auth
    {
        public static void GetCodeUrl()
        {
            //string str = "((!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+[])+(!+[]+!![]+!![]+!![])+(+!![])+(+[])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(+!![]))/+((!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+[])+(+[])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(+!![])+(!+[]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+!![]))";
            //string str1 = "+((!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+[])+(!+[]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![])+(+[])+(!+[]+!![]+!![]))/+((!+[]+!![]+!![]+!![]+!![]+!![]+!![]+[])+(!+[]+!![]+!![])+(!+[]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![])+(+[])+(!+[]+!![]+!![])+(!+[]+!![]+!![])+(!+[]+!![])+(!+[]+!![]+!![]+!![]))";
            //string str2 = "+((!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+[])+(!+[]+!![])+(+[])+(!+[]+!![]+!![]+!![])+(+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![])+(!+[]+!![]+!![]))/+((!+[]+!![]+!![]+[])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![])+(+[]))";
            //string str3 = "+((!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+[])+(!+[]+!![]+!![]+!![])+(+!![])+(+[])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(+!![]))/+((!+[]+!![]+[])+(+[])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![])+(+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![]))";

            //decimal a = AnalysisCode(str);
            //decimal b = AnalysisCode(str1);
            //decimal c = AnalysisCode(str2);
            //decimal d = AnalysisCode(str3);
            //Debug.WriteLine(a*b*c*d);

            Dictionary<string,string> list = new Dictionary<string, string>();
            list.Add("+((!+[]+!![]+!![]+!![]+!![]+!![]+!![]+[])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![])+(+[])+(+[])+(!+[]+!![]+!![])+(!+[]+!![]+!![]+!![])+(!+[]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]))/+((!+[]+!![]+!![]+!![]+[])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![]+!![]+!![])+(!+[]+!![]+!![]+!![]+!![])+(+!![])+(!+[]+!![]+!![])+(!+[]+!![])+(+!![]))","|");
            list.Add("+((!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![] +[]) + (!+[] + !![]) + (+[]) + (!+[] + !![] + !![] + !![]) + (+!![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![]) + (!+[] + !![] + !![])) / +((!+[] + !![] +[]) + (!+[] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![]) + (!+[] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![]) + (+[]))","*");
            list.Add("+((!+[] + !![] + !![] + !![] + !![] + !![] + !![] +[]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (+[]) + (+[]) + (!+[] + !![] + !![]) + (!+[] + !![] + !![] + !![]) + (!+[] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![])) / +((!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![] +[]) + (!+[] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![]) + (!+[] + !![]))","-");
            list.Add("+((!+[] + !![] + !![] + !![] + !![] + !![] + !![] +[]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (+[]) + (+[]) + (!+[] + !![] + !![]) + (!+[] + !![] + !![] + !![]) + (!+[] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![])) / +((!+[] + !![] + !![] + !![] + !![] + !![] + !![] +[]) + (!+[] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (+[]))","+");
            list.Add("+((!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] +[]) + (!+[] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![]) + (+[]) + (!+[] + !![] + !![])) / +((!+[] + !![] + !![] + !![] +[]) + (!+[] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![]) + (+!![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![]))","-");
            list.Add("+((!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] +[]) + (+!![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![]) + (+[]) + (!+[] + !![] + !![] + !![]) + (!+[] + !![]) + (!+[] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![])) / +((!+[] + !![] + !![] +[]) + (!+[] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (+!![]) + (!+[] + !![] + !![] + !![] + !![]))","+");
            list.Add("+((!+[] + !![] + !![] + !![] + !![] + !![] + !![] +[]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (+[]) + (+[]) + (!+[] + !![] + !![]) + (!+[] + !![] + !![] + !![]) + (!+[] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![])) / +((!+[] + !![] + !![] +[]) + (!+[] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![]) + (!+[] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![]))","-");
            list.Add("+((!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![] +[]) + (!+[] + !![]) + (+[]) + (!+[] + !![] + !![] + !![]) + (+!![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![]) + (!+[] + !![] + !![])) / +((!+[] + !![] + !![] + !![] +[]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (+!![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (+[]) + (+!![]))","+");
            list.Add("+((!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![] +[]) + (+!![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![]) + (+[]) + (!+[] + !![] + !![] + !![]) + (!+[] + !![]) + (!+[] + !![] + !![] + !![]) + (!+[] + !![] + !![])) / +((!+[] + !![] + !![] + !![] +[]) + (!+[] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![] + !![] + !![] + !![] + !![] + !![] + !![]) + (!+[] + !![]) + (!+[] + !![] + !![]) + (!+[] + !![] + !![] + !![]) + (+[]))","*");


            decimal result = 0;
            foreach(var i in list)
            {
                decimal a = AnalysisCode(i.Key);
                //Debug.WriteLine(a);
                switch (i.Value)
                {
                    case "*":
                        result *= a;
                        break;
                    case "/":
                        result /= a;
                        break;
                    case "+":
                        result += a;
                        break;
                    case "-":
                        result -= a;
                        break;
                    default:
                        result = a;
                        break;
                }
            }
            Debug.WriteLine(Math.Round(result,10));

        }

        public static decimal AnalysisCode(string code)
        {
            code = code.Replace("!+[]", "1").Replace("!![]", "1").Replace("[]", "0");

            string[] codes = code.Split('/');
            List<decimal> vs = new List<decimal>();
            foreach(string str in codes)
            {
                string sum = "";
                MatchCollection matchCollection = Regex.Matches(str, "[(]([01+].+?)[)]");
                foreach(Match match in matchCollection)
                {
                    int i = 0;
                    MatchCollection matchs = Regex.Matches(match.Groups[1].Value, "[1]");
                    foreach(Match m in matchs)
                    {
                        i += int.Parse(m.Value);
                    }
                    sum += i;
                }
                vs.Add(decimal.Parse(sum));
            }
            decimal result = vs[0];
            for(int i = 1; i < vs.Count; i++)
            {
                result /= vs[i];
            }
            
            return result;
        }
    }
}
