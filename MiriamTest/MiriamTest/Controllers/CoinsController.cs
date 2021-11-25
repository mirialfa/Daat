using MiriamTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Serialization;

namespace MiriamTest.Controllers
{
    [RoutePrefix("api/Coins")]
    public class CoinsController : ApiController
    {
        private static readonly HttpClient client = new HttpClient();

        [Route("GetExchangeRate/")]
        [HttpGet]
        public async Task<Dictionary<int, List<DateCurrenctRate>>> Get(int kind)
        {
            try
            {
               
                var currencyArr = new int[] { 01, 02, 03, 05, 06 };
                var dic = new Dictionary<int, List<DateCurrenctRate>>();
                for (int i = 0; i < 5; i++)
                {
                    dic.Add(i, new List<DateCurrenctRate>());
                    if (kind == 1)
                    {
                        var startDate = DateTime.Today.AddDays(-6);
                        for (var currDate = startDate; currDate < DateTime.Today; currDate = currDate.AddDays(1))
                        {
                            var rDate = currDate.ToString("yyyyMMdd");
                            if (currDate.DayOfWeek == DayOfWeek.Saturday)
                                rDate = currDate.AddDays(2).ToString("yyyyMMdd");
                            if (currDate.DayOfWeek == DayOfWeek.Sunday)
                                rDate = currDate.AddDays(1).ToString("yyyyMMdd");
                            var curr = currencyArr[i].ToString().PadLeft(2, '0');
                            var url = $"https://www.boi.org.il/currency.xml?rdate={rDate}&curr={curr}";
                            var response = await client.GetAsync(url);
                            var responseString = await response.Content.ReadAsStringAsync();
                            var buffer = Encoding.UTF8.GetBytes(responseString);
                            using (var stream = new MemoryStream(buffer))
                            {
                                var serializer = new XmlSerializer(typeof(Currencies));
                                var currencies = (Currencies)serializer.Deserialize(stream);

                                dic[i].Add(new DateCurrenctRate()
                                {
                                    Currency = currencies.Currency[0],
                                    Date = currDate
                                }

                            );
                            }
                        }
                    }
                    if (kind == 2)
                    {
                        var startDate = DateTime.Today.AddMonths(-5);
                        for (var currDate = startDate; currDate < DateTime.Today; currDate = currDate.AddMonths(1))
                        {
                            var rDate = currDate.ToString("yyyyMMdd");
                            if (currDate.DayOfWeek == DayOfWeek.Saturday)
                                rDate = currDate.AddDays(2).ToString("yyyyMMdd");
                            if (currDate.DayOfWeek == DayOfWeek.Sunday)
                                rDate = currDate.AddDays(1).ToString("yyyyMMdd");
                            var curr = currencyArr[i].ToString().PadLeft(2, '0');
                            var url = $"https://www.boi.org.il/currency.xml?rdate={rDate}&curr={curr}";
                            var response = await client.GetAsync(url);
                            var responseString = await response.Content.ReadAsStringAsync();
                            var buffer = Encoding.UTF8.GetBytes(responseString);
                            using (var stream = new MemoryStream(buffer))
                            {
                                var serializer = new XmlSerializer(typeof(Currencies));
                                var currencies = (Currencies)serializer.Deserialize(stream);
                                dic[i].Add(new DateCurrenctRate()
                                {
                                    Currency = currencies.Currency[0],
                                    Date = currDate
                                }

);
                            }
                        }
                    }

                }


                return dic;

            }
            catch (Exception e)
            {
                throw;
            }


        }
    }
}