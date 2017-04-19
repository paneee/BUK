using BUK.Model;
using BUK.ViewModel;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUK.DataWEB
{
    public static class DataFromWEB
    {
        //public List<Bet> listBet = new List<Bet>();

        private enum Field
        {
            NameHomeTeam = 0,
            NameAwayTeam = 1,

            Course_1 = 2,
            Course_0 = 3,
            Course_2 = 4,

            Course_10 = 5,
            Course_02 = 6,
            Course_12 = 7,

            Data = 9,

            IdBook = 10,
        }

        private static string GetField(HtmlDocument htmlDocument, Field field, int currentLine)
        {
            string match = htmlDocument.DocumentNode.SelectSingleNode("//tbody//tr[" + currentLine + "]//td[1]//div//span//a").InnerHtml;
            switch (field)
            {
                case Field.IdBook:
                    {
                        try { return htmlDocument.DocumentNode.SelectSingleNode("//tbody//tr[" + currentLine + "]").Attributes["data-id"].Value; }
                        catch { return "-1"; }
                    }
                case Field.NameHomeTeam:
                    {
                        try { return match.Substring(0, match.IndexOf("-")).TrimEnd().TrimStart(); }
                        catch { return "-1"; }
                    }
                case Field.NameAwayTeam:
                    {
                        try { return match.Substring(match.IndexOf("-") + 1).TrimEnd().TrimStart(); }
                        catch { return "-1"; }
                    }
                case Field.Data:
                    {
                        try
                        {
                            string unformat = htmlDocument.DocumentNode.SelectSingleNode("//tbody//tr[" + currentLine + "]//td[9]//span").InnerText.Trim();
                            string[] split = unformat.Split('.');
                            string format = DateTime.Now.Year.ToString() + "-" + split[1].ToString() + "-" + split[0].ToString() + split[2].ToString() + ":00";
                            return format;
                        }
                        catch { return "1970-1-1, 0:0:0"; }
                    }
                default:
                    {
                        try { return htmlDocument.DocumentNode.SelectSingleNode("//tbody//tr[" + currentLine + "]//td[" + (int)field + "]//a").Attributes["data-rate"].Value.Replace('.', ','); }
                        catch { return "-1"; }
                    }
            }
        }

        public static List<Bet> GetDataFromWEB()
        {
            List<string> pathWebPages = new List<string>();

            //pathWebPages.Add("https://www.efortuna.pl/pl/strona_glowna/pilka-nozna/ekstraklasa");
            //pathWebPages.Add("https://www.efortuna.pl/pl/strona_glowna/pilka-nozna/premier-league-premiership");
            //pathWebPages.Add("https://www.efortuna.pl/pl/strona_glowna/pilka-nozna/ligue-1");
            //pathWebPages.Add("https://www.efortuna.pl/pl/strona_glowna/pilka-nozna/liga-mistrzow");
            //pathWebPages.Add("https://www.efortuna.pl/pl/strona_glowna/pilka-nozna/bundesliga");
            pathWebPages.Add("https://www.efortuna.pl/pl/strona_glowna/pilka-nozna/serie-a");

            HtmlWeb htmlWeb = new HtmlWeb();
            List<Bet> betList = new List<Bet>();
            string lig = "";

            foreach (string adresPage in pathWebPages)
            {
                lig = adresPage.Replace("https://www.efortuna.pl/pl/strona_glowna/pilka-nozna/", "");
                HtmlDocument htmlDocument = htmlWeb.Load(adresPage);
                int countBets = htmlDocument.DocumentNode.SelectNodes("//tbody//tr").Count();
                if (countBets < 100) //zabezpieczenie prze przekierowaniem
                {
                    for (int i = 1; i <= countBets; i++)
                    {
                        betList.Add(new Bet
                        {
                            Name = new Name
                            {
                                HomeTeam = GetField(htmlDocument, Field.NameHomeTeam, i),
                                AwayTeam = GetField(htmlDocument, Field.NameAwayTeam, i)
                            },

                            Course = new Course
                            {
                                T1 = decimal.Parse(GetField(htmlDocument, Field.Course_1, i)),
                                T0 = decimal.Parse(GetField(htmlDocument, Field.Course_0, i)),
                                T2 = decimal.Parse(GetField(htmlDocument, Field.Course_2, i)),

                                T10 = decimal.Parse(GetField(htmlDocument, Field.Course_10, i)),
                                T02 = decimal.Parse(GetField(htmlDocument, Field.Course_02, i)),
                                T12 = decimal.Parse(GetField(htmlDocument, Field.Course_12, i))
                            },

                            Data = DateTime.Parse(GetField(htmlDocument, Field.Data, i)),
                            idBook = GetField(htmlDocument, Field.IdBook, i),
                            isFinished = false,

                            Ligue = lig,

                            Result = new Result { GoalAwayTeam = 0, GoalHomeTeam = 0 },
                        });
                    }
                }
            }
            betList.RemoveAll(i => i.Data == DateTime.Parse("1970-1-1, 0:0:0"));
            return betList;
        }
    }
}