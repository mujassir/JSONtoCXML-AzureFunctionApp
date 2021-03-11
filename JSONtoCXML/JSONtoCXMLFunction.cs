using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using JsonToXMLParser.BL;
using JsonToXMLParser.BL.Xml;
using System.Xml.Serialization;
using System.Xml;

namespace JSONtoCXML
{
    public static class JSONtoCXMLFunction
    {
        [FunctionName("JSONtoCXML")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var jsonData = JsonConvert.DeserializeObject<Root>(requestBody);
            var cxml = ParseJson(jsonData);
            return new OkObjectResult(cxml);
        }

        private static string ParseJson(Root jsonData)
        {
            //var jsonData = JsonConvert.DeserializeObject<Root>(jsonInput);


            var mappedData = doMapping(jsonData);
            var xsSubmit = new XmlSerializer(typeof(CXML));
            var xml = "";
            using (var sww = new StringWriter())
            {
                var xmlWriterSetting = new XmlWriterSettings();
                xmlWriterSetting.Indent = true;
                xmlWriterSetting.NewLineHandling = NewLineHandling.Entitize;

                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, mappedData);
                    xml = sww.ToString(); // Your XML
                }
            }
            return xml;
        }

        private static CXML doMapping(Root data)
        {
            var mappedData = new CXML();
            foreach (var row in data.document.rows)
            {
                doMapping(row, mappedData);
            }
            return mappedData;
        }

        private static CXML doMapping(Rows row, CXML mappedData)
        {
            var data = row.row.data;

            mappedData.Request.OrderRequest.OrderRequestHeader.OrderID = data.PO_ID;
            mappedData.Header.Sender.UserAgent = data.BUYER_ID;
            mappedData.Header.To.Credential.Identity = data.VEND_ID;
            mappedData.Header.Sender.Credential.Identity = data.VEND_NAME;
            mappedData.Request.OrderRequest.OrderRequestHeader.OrderDate = data.ORD_DT;
            mappedData.Request.OrderRequest.OrderRequestHeader.Total.Money = new Money() { Text = data.TRN_PO_TOT_AMT, AlternateAmount = data.TRN_PO_TOT_AMT };
            //require discussion
            mappedData.Request.OrderRequest.OrderRequestHeader.ShipTo.Address = new Address();
            //new filed added
            mappedData.Request.OrderRequest.OrderRequestHeader.ShipTo.Address.Name.Text = data.DEL_TO_FLD;
            mappedData.Request.OrderRequest.OrderRequestHeader.BillTo.Address.AddressID = data.BILL_TO_LOC_ID;
            mappedData.Request.OrderRequest.OrderRequestHeader.BillTo.Address.Name.Text = data.BILL_TO_LOC_ID_NAME;
            mappedData.Request.OrderRequest.OrderRequestHeader.BillTo.Address.PostalAddress.DeliverTo = data.BILL_TO_LOC_ID_DESC;
            mappedData.Request.OrderRequest.OrderRequestHeader.BillTo.Address.PostalAddress.DeliverTo = data.BILL_TO_ADDR_DC;
            mappedData.Request.OrderRequest.ItemOut.ItemID.SupplierPartID = data.ITEM_ID;
            mappedData.Request.OrderRequest.ItemOut.ItemDetail.UnitOfMeasure = data.PO_LN_UM_CD;
            mappedData.Request.OrderRequest.ItemOut.Quantity = data.ORD_QTY;
            mappedData.Request.OrderRequest.ItemOut.ItemDetail.UnitPrice.Money = new Money() { Text = data.TRN_GR_UN_CST_AMT };
            mappedData.Request.OrderRequest.ItemOut.ItemDetail.Classification = new Classification() { Text = data.COMM_CD };
            mappedData.Request.OrderRequest.ItemOut.ItemID.SupplierPartID = data.VEND_PART_ID;
            mappedData.Request.OrderRequest.ItemOut.Distribution.Accounting = new Accounting() { Name = data.PO_POLNACCT_PROJ_ID };
            mappedData.Request.OrderRequest.ItemOut.Distribution.Accounting = new Accounting() { Name = data.PO_POLNACCT_ACCT_ID };
            mappedData.Request.OrderRequest.ItemOut.Distribution.Accounting = new Accounting() { Name = data.PO_POLNACCT_ORG_ID };
            mappedData.Request.OrderRequest.ItemOut.Distribution.Charge.Money = new Money() { Text = data.CST_AMT, AlternateAmount = data.CST_AMT };
            return mappedData;
        }
    }
}
