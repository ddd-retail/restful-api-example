using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using public_api_tutorial.Models;

namespace public_api_tutorial
{
    class Program
    {

        //see documentation http://publicapi.dddretail.com/


        private const string baseUrl = "http://publicapi.dddretail.com/api/";
        private const string service = "transactions/";
        public const int shopId = 996005;
        private const string token = "your token";
        
        static void Main(string[] args) 
        {
            GetTransactions();
        }

        private static void GetTransactions()
        {
            using (var client = new WebClient())
            {
                client.Headers = new WebHeaderCollection
                {
                    { HttpRequestHeader.ContentType,"application/json" },
                    { HttpRequestHeader.Authorization, $"ddd_token {token}"}
                };
                var timeOfTransactions = new DateTime(2015,1,1);
                var requestUrl = baseUrl + service + shopId + $"/{timeOfTransactions.ToString("yyyy-MM-dd")}"; // see documentation http://publicapi.dddretail.com/Help/Api/GET-api-transactions-shopId-from
                var jsonResult = client.DownloadString(requestUrl);

                //using dynamics for fast deserializion
                var myDynamicResult = JsonConvert.DeserializeObject<dynamic>(jsonResult);
                var dynamicSales = myDynamicResult.sales.saleItems;
                foreach (var sale in dynamicSales)
                {
                    //notice the property name costPrice, this is due to the deserializion of the dynamic type
                    var price = sale.costPrice;
                }

                //using typed deserializion IMPORTENT:: The viewmodel is not fully implemented, only needed properties for this project is implemented.
                var myTypedResult = JsonConvert.DeserializeObject<TransactionContainerViewModel>(jsonResult);
                var typedSales = myTypedResult.Sales.SaleItems;
                foreach (var sale in typedSales)
                {

                    var price = sale.CostPrice;
                }

                while (true)
                {
                    Thread.Sleep(1000);
                }
            }
        }
        

    }

}
