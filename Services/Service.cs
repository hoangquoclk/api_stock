using API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excel.FinancialFunctions;

namespace API.Services
{
    public class Service
    {
   
        public ChiSo cs = new ChiSo();
        public List<string[]> lisst = new List<string[]>();
        public List<List<string>> list1 = new List<List<string>>();
        public List<List<string>> list2 = new List<List<string>>();
        public List<List<string>> list3 = new List<List<string>>();
        public List<List<string>> list4 = new List<List<string>>();
        public List<List<string>> list5 = new List<List<string>>();
        public List<List<string>> list6 = new List<List<string>>();
        public Service()
        {
            DocFile();
           
        }
        public void DocFile()
        {
            using (StreamReader sr = new StreamReader("DL.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var a = line.Split(",");
                    lisst.Add(a);


                }
            }

        }
        public async Task<List<List<string>>> GetDateKQKD(string name, string tencongty, int year)
        {
            var url = $"https://s.cafef.vn/bao-cao-tai-chinh/{name}/IncSta/{year}/0/0/0/ket-qua-hoat-dong-kinh-doanh-{tencongty}.chn";

            var httpClinet = new HttpClient();

            var html = await httpClinet.GetStringAsync(url);
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);
            var x = htmlDocument.DocumentNode.Descendants("table")
                .Where(node => node.GetAttributeValue("id", "").Equals("tableContent")).ToList();
            if (x.Count == 0)
            {
                return null;

            }
            else
            {
                var y = x[0].Descendants("tr").ToList();
                foreach (var item in y)
                {
                    var z = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:#014377;font-weight:bold;")).ToList();
                    List<string> list = new List<string>();
                    if (z.Count != 0)
                    {
                        var k1 = z[0].InnerText.Trim().Remove(0, 25).Trim();
                        list.Add(k1);
                    }
                    else
                    {
                        var n = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:#014377;")).ToList();
                        if (n.Count != 0)
                        {
                            var k2 = n[0].InnerText.Trim().Remove(0, 25).Trim();
                            list.Add(k2);
                        }
                    }


                    var m = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:#014377;font-weight:bold;")).ToList();
                    if (m.Count != 0)
                    {
                        var k2 = m[3].InnerText;

                        list.Add(k2);
                    }
                    else
                    {
                        var n = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:#014377;")).ToList();
                        if (n.Count != 0)
                        {
                            var k2 = n[3].InnerText;

                            list.Add(k2);
                        }
                    }

                    if (list.Count != 0)
                    {
                        this.list1.Add(list);
                       
                    }

                }

                

                
                return this.list1;
            }

            

        }

        public async Task<List<List<string>>> GetDateCDKT(string name, string tencongty, int year)
        {
            var url = $"https://s.cafef.vn/bao-cao-tai-chinh/{name}/BSheet/{year}/0/0/0/bao-cao-tai-chinh-{tencongty}.chn";

            var httpClinet1 = new HttpClient();

            var html1 = await httpClinet1.GetStringAsync(url);
            var htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
            htmlDocument1.LoadHtml(html1);
            var x = htmlDocument1.DocumentNode.Descendants("table")
                .Where(node => node.GetAttributeValue("id", "").Equals("tableContent")).ToList();
            if (x.Count == 0)
            {
                return null;

            }
            else
            {
                var y = x[0].Descendants("tr").ToList();
                foreach (var item in y)
                {
                    var z = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:#333333;font-weight:bold;font-size:13px")).ToList();
                    List<string> list = new List<string>();
                    if (z.Count != 0)
                    {
                        var k1 = z[0].InnerText.Trim().Remove(0, 25).Trim();
                        list.Add(k1);
                    }
                    else 
                    {
                        var n = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:#014377;font-weight:bold;")).ToList();
                        if (n.Count != 0)
                        {
                            var k2 = n[0].InnerText.Trim();
                            list.Add(k2);
                        }
                        else
                        {
                            var g = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:#014377;")).ToList();
                            if (g.Count != 0)
                            {
                                var k2 = g[0].InnerText.Trim().Remove(0, 25).Trim();
                                list.Add(k2);
                            }
                            else
                            {
                                var h = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:black;font-weight:bold;font-size:13px;text-align:center;")).ToList();
                                if (h.Count != 0)
                                {
                                    var k2 = h[0].InnerText.Trim().Remove(0,25).Trim(); 
                                    list.Add(k2);
                                }
                            }
                        }
                    }


                    var m = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:#333333;font-weight:bold;font-size:13px")).ToList();
                    if (m.Count != 0)
                    {
                        var k2 = m[3].InnerText;

                        list.Add(k2);
                    }
                    else
                    {
                        var n = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:#014377;font-weight:bold;")).ToList();
                        if (n.Count != 0)
                        {
                            var k2 = n[3].InnerText;

                            list.Add(k2);
                        }
                        else
                        {
                            var g = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:#014377;")).ToList();
                            if (g.Count != 0)
                            {
                                var k2 = g[3].InnerText;

                                list.Add(k2);
                            }
                            else
                            {
                                var h = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:black;font-weight:bold;font-size:13px;text-align:center;")).ToList();
                                if (h.Count != 0)
                                {
                                    var k2 = h[3].InnerText;

                                    list.Add(k2);
                                }
                            }
                        }
                    }

                    if (list.Count != 0)
                    {
                        this.list2.Add(list);

                    }

                }




                return this.list2;
            }

        }

        public async Task<List<List<string>>> GetDateLCTT(string name, string tencongty, int year)
        {
            var url = $"https://s.cafef.vn/bao-cao-tai-chinh/{name}/CashFlow/{year}/0/0/0/0/luu-chuyen-tien-te-gian-tiep-{tencongty}.chn";

            var httpClinet1 = new HttpClient();

            var html1 = await httpClinet1.GetStringAsync(url);
            var htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
            htmlDocument1.LoadHtml(html1);
            var x = htmlDocument1.DocumentNode.Descendants("table")
                .Where(node => node.GetAttributeValue("id", "").Equals("tableContent")).ToList();
            if (x.Count == 0)
            {
                return null;

            }
            else
            {
                var y = x[0].Descendants("tr").ToList();
                foreach (var item in y)
                {
                    var z = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:#014377;padding-left:10px;")).ToList();
                    List<string> list = new List<string>();
                    if (z.Count != 0)
                    {
                        var k1 = z[0].InnerText.Trim();
                        list.Add(k1);
                    }
                    else 
                    {
                        var n = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:#014377;font-weight:bold;font-size:13px;padding-left:5px;")).ToList();
                        if (n.Count != 0)
                        {
                            var k2 = n[0].InnerText.Trim();
                            list.Add(k2);
                        }
                      
                    }


                    var m = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:#014377;padding-left:10px;")).ToList();
                    if (m.Count != 0)
                    {
                        var k2 = m[3].InnerText;

                        list.Add(k2);
                    }
                    else
                    {
                        var n = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:#014377;font-weight:bold;font-size:13px;padding-left:5px;")).ToList();
                        if (n.Count != 0)
                        {
                            var k2 = n[3].InnerText;

                            list.Add(k2);
                        }
                      
                    }

                    if (list.Count != 0)
                    {
                        this.list3.Add(list);

                    }

                }




                return this.list3;
            }

        }
     
        public string ChangeTen(string name)
        {
            name = name.Replace(" ", "-");
            return RemoveVietnameseTone(name);
        }

        public string RemoveVietnameseTone(string text)
        {
            string result = text.ToLower();
            result = Regex.Replace(result, "à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|/g", "a");
            result = Regex.Replace(result, "è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|/g", "e");
            result = Regex.Replace(result, "ì|í|ị|ỉ|ĩ|/g", "i");
            result = Regex.Replace(result, "ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|/g", "o");
            result = Regex.Replace(result, "ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|/g", "u");
            result = Regex.Replace(result, "ỳ|ý|ỵ|ỷ|ỹ|/g", "y");
            result = Regex.Replace(result, "đ", "d");
            return result;
        }

        public double RATE(int nper, int pmt, int pv, int fv, PaymentDue pd, int guess)
        {

            return Financial.Rate(nper, pmt, pv, fv, pd, guess) * 100;            
            
            
        }


        public async Task<List<List<string>>> GetDateKQKD_Quy(string name, string tencongty, int quy,int year)
        {
            var url = $"https://s.cafef.vn/bao-cao-tai-chinh/{name}/IncSta/{year}/{quy}/0/0/1/ket-qua-hoat-dong-kinh-doanh-{tencongty}.chn";

            var httpClinet = new HttpClient();

            var html = await httpClinet.GetStringAsync(url);
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);
            var x = htmlDocument.DocumentNode.Descendants("table")
                .Where(node => node.GetAttributeValue("id", "").Equals("tableContent")).ToList();
            if (x.Count == 0)
            {
                return null;

            }
            else
            {
                var y = x[0].Descendants("tr").ToList();
                foreach (var item in y)
                {
                    var z = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:#014377;font-weight:bold;")).ToList();
                    List<string> list = new List<string>();
                    if (z.Count != 0)
                    {
                        var k1 = z[0].InnerText.Trim().Remove(0, 25).Trim();
                        list.Add(k1);
                    }
                    else
                    {
                        var n = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:#014377;")).ToList();
                        if (n.Count != 0)
                        {
                            var k2 = n[0].InnerText.Trim().Remove(0, 25).Trim();
                            list.Add(k2);
                        }
                    }


                    var m = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:#014377;font-weight:bold;")).ToList();
                    if (m.Count != 0)
                    {
                        var k2 = m[3].InnerText;

                        list.Add(k2);
                    }
                    else
                    {
                        var n = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:#014377;")).ToList();
                        if (n.Count != 0)
                        {
                            var k2 = n[3].InnerText;

                            list.Add(k2);
                        }
                    }

                    if (list.Count != 0)
                    {
                        this.list4.Add(list);

                    }

                }




                return this.list4;
            }



        }

        public async Task<List<List<string>>> GetDateCDKT_Quy(string name, string tencongty, int quy, int year)
        {
            var url = $"https://s.cafef.vn/bao-cao-tai-chinh/{name}/BSheet/{year}/{quy}/0/0/1/bao-cao-tai-chinh-{tencongty}.chn";

            var httpClinet1 = new HttpClient();

            var html1 = await httpClinet1.GetStringAsync(url);
            var htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
            htmlDocument1.LoadHtml(html1);
            var x = htmlDocument1.DocumentNode.Descendants("table")
                .Where(node => node.GetAttributeValue("id", "").Equals("tableContent")).ToList();
            if (x.Count == 0)
            {
                return null;

            }
            else
            {
                var y = x[0].Descendants("tr").ToList();
                foreach (var item in y)
                {
                    var z = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:#333333;font-weight:bold;font-size:13px")).ToList();
                    List<string> list = new List<string>();
                    if (z.Count != 0)
                    {
                        var k1 = z[0].InnerText.Trim().Remove(0, 25).Trim();
                        list.Add(k1);
                    }
                    else
                    {
                        var n = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:#014377;font-weight:bold;")).ToList();
                        if (n.Count != 0)
                        {
                            var k2 = n[0].InnerText.Trim();
                            list.Add(k2);
                        }
                        else
                        {
                            var g = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:#014377;")).ToList();
                            if (g.Count != 0)
                            {
                                var k2 = g[0].InnerText.Trim().Remove(0, 25).Trim();
                                list.Add(k2);
                            }
                            else
                            {
                                var h = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:black;font-weight:bold;font-size:13px;text-align:center;")).ToList();
                                if (h.Count != 0)
                                {
                                    var k2 = h[0].InnerText.Trim().Remove(0, 25).Trim();
                                    list.Add(k2);
                                }
                            }
                        }
                    }


                    var m = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:#333333;font-weight:bold;font-size:13px")).ToList();
                    if (m.Count != 0)
                    {
                        var k2 = m[3].InnerText;

                        list.Add(k2);
                    }
                    else
                    {
                        var n = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:#014377;font-weight:bold;")).ToList();
                        if (n.Count != 0)
                        {
                            var k2 = n[3].InnerText;

                            list.Add(k2);
                        }
                        else
                        {
                            var g = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:#014377;")).ToList();
                            if (g.Count != 0)
                            {
                                var k2 = g[3].InnerText;

                                list.Add(k2);
                            }
                            else
                            {
                                var h = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:black;font-weight:bold;font-size:13px;text-align:center;")).ToList();
                                if (h.Count != 0)
                                {
                                    var k2 = h[3].InnerText;

                                    list.Add(k2);
                                }
                            }
                        }
                    }

                    if (list.Count != 0)
                    {
                        this.list2.Add(list);

                    }

                }




                return this.list2;
            }

        }

        public async Task<List<List<string>>> GetDateLCTT_Quy(string name, string tencongty, int quy,int year)
        {
            var url = $"https://s.cafef.vn/bao-cao-tai-chinh/{name}/CashFlow/{year}/{quy}/0/0/1/luu-chuyen-tien-te-gian-tiep-{tencongty}.chn";

            var httpClinet1 = new HttpClient();

            var html1 = await httpClinet1.GetStringAsync(url);
            var htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
            htmlDocument1.LoadHtml(html1);
            var x = htmlDocument1.DocumentNode.Descendants("table")
                .Where(node => node.GetAttributeValue("id", "").Equals("tableContent")).ToList();
            if (x.Count == 0)
            {
                return null;

            }
            else
            {
                var y = x[0].Descendants("tr").ToList();
                foreach (var item in y)
                {
                    var z = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:#014377;padding-left:10px;")).ToList();
                    List<string> list = new List<string>();
                    if (z.Count != 0)
                    {
                        var k1 = z[0].InnerText.Trim();
                        list.Add(k1);
                    }
                    else
                    {
                        var n = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:32%;color:#014377;font-weight:bold;font-size:13px;padding-left:5px;")).ToList();
                        if (n.Count != 0)
                        {
                            var k2 = n[0].InnerText.Trim();
                            list.Add(k2);
                        }

                    }


                    var m = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:#014377;padding-left:10px;")).ToList();
                    if (m.Count != 0)
                    {
                        var k2 = m[3].InnerText;

                        list.Add(k2);
                    }
                    else
                    {
                        var n = item.Descendants("td").Where(node => node.GetAttributeValue("style", "").Equals("width:15%;padding:4px;color:#014377;font-weight:bold;font-size:13px;padding-left:5px;")).ToList();
                        if (n.Count != 0)
                        {
                            var k2 = n[3].InnerText;

                            list.Add(k2);
                        }

                    }

                    if (list.Count != 0)
                    {
                        this.list6.Add(list);

                    }

                }




                return this.list6;
            }

        }
    }
}
