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
using System.Text;

namespace POVoucherExport
{
    public static class POVoucherExport
    {
        [FunctionName("POVoucherExport")]
        public static async Task<IActionResult> ExportCXMLVoucher(
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
            var mappedData = MapCXMLData(jsonData);
            var xsSubmit = new XmlSerializer(typeof(CXML));
            var xml = "";
            using (var sww = new StringWriter())
            {
                using XmlWriter writer = XmlWriter.Create(sww);

                xsSubmit.Serialize(writer, mappedData);
                xml = sww.ToString(); // Your XML
            }
            return FormatXML(xml);
        }


        private static CXML MapCXMLData(Root data)
        {
            var cxml = new CXML();

            // Header
            cxml.Header.To.Credential.Identity = GetFieldValue(data, "VEND_ID");
            cxml.Header.Sender.Credential.Identity = GetFieldValue(data, "BUYER_ID");
            cxml.Header.Sender.UserAgent = GetFieldValue(data, "VEND_NAME");

            // OrderRequestHeader - Request\OrderRequest\OrderRequestHeader
            cxml.Request.OrderRequest.OrderRequestHeader.OrderID = GetFieldValue(data, "PO_ID");
            cxml.Request.OrderRequest.OrderRequestHeader.OrderDate = GetFieldValue(data, "ORD_DT");
            if (string.IsNullOrWhiteSpace(cxml.Request.OrderRequest.OrderRequestHeader.OrderDate))
                cxml.Request.OrderRequest.OrderRequestHeader.OrderDate = GetFieldValue(data, "INVC_DT");
            cxml.Request.OrderRequest.OrderRequestHeader.Total.Money.Text = GetFieldValue(data, "TRN_PO_LN_TOT_AMT");
            cxml.Request.OrderRequest.OrderRequestHeader.Total.Money.Currency = GetFieldValue(data, "TRNS___CRNCY___CD");

            // Ship To
            cxml.Request.OrderRequest.OrderRequestHeader.ShipTo.Address.AddressID = GetFieldValue(data, "SHIP_TO_LOC_ID");
            cxml.Request.OrderRequest.OrderRequestHeader.ShipTo.Address.Name.Text = GetFieldValue(data, "DEL_TO_FLD");
            cxml.Request.OrderRequest.OrderRequestHeader.ShipTo.Address.PostalAddress.PostalCode = GetFieldValue(data, "SHIP_TO_POSTAL_CD");
            cxml.Request.OrderRequest.OrderRequestHeader.ShipTo.Address.PostalAddress.State = GetFieldValue(data, "SHIP_TO_MAIL_STATE_DC");
            cxml.Request.OrderRequest.OrderRequestHeader.ShipTo.Address.PostalAddress.Country.IsoCountryCode = GetFieldValue(data, "SHIP_TO_COUNTRY_CD");
            cxml.Request.OrderRequest.OrderRequestHeader.ShipTo.Address.PostalAddress.Country.Text = GetFieldValue(data, "SHIP_TO_COUNTRY_CD");
            cxml.Request.OrderRequest.OrderRequestHeader.ShipTo.Address.PostalAddress.City = GetFieldValue(data, "SHIP_TO_CITY_NAME");
            if (!string.IsNullOrWhiteSpace(GetFieldValue(data, "SHIP_TO_LN_1_ADDR")))
                cxml.Request.OrderRequest.OrderRequestHeader.ShipTo.Address.PostalAddress.Street.Add(GetFieldValue(data, "SHIP_TO_LN_1_ADDR"));

            if (!string.IsNullOrWhiteSpace(GetFieldValue(data, "SHIP_TO_LN_2_ADDR")))
                cxml.Request.OrderRequest.OrderRequestHeader.ShipTo.Address.PostalAddress.Street.Add(GetFieldValue(data, "SHIP_TO_LN_2_ADDR"));
            if (!string.IsNullOrWhiteSpace(GetFieldValue(data, "SHIP_TO_LN_3_ADDR")))
                cxml.Request.OrderRequest.OrderRequestHeader.ShipTo.Address.PostalAddress.Street.Add(GetFieldValue(data, "SHIP_TO_LN_3_ADDR"));


            // Bill To
            cxml.Request.OrderRequest.OrderRequestHeader.BillTo.Address.AddressID = GetFieldValue(data, "BILL_TO_LOC_ID");
            cxml.Request.OrderRequest.OrderRequestHeader.BillTo.Address.Name.Text = GetFieldValue(data, "BILL_TO_LOC_ID_NAME");
            cxml.Request.OrderRequest.OrderRequestHeader.BillTo.Address.PostalAddress.PostalCode = GetFieldValue(data, "SUBK_BILL_POSTAL_ADDR");
            cxml.Request.OrderRequest.OrderRequestHeader.BillTo.Address.PostalAddress.State = GetFieldValue(data, "SUBK_BILL_STATE_ADDR");
            cxml.Request.OrderRequest.OrderRequestHeader.BillTo.Address.PostalAddress.Country.IsoCountryCode = GetFieldValue(data, "SUBK_BILL_COUNTRY_ADDR");
            cxml.Request.OrderRequest.OrderRequestHeader.BillTo.Address.PostalAddress.Country.Text = GetFieldValue(data, "SUBK_BILL_COUNTRY_ADDR");
            cxml.Request.OrderRequest.OrderRequestHeader.BillTo.Address.PostalAddress.City = GetFieldValue(data, "SUBK_BILL_CITY_ADDR");
            if (!string.IsNullOrWhiteSpace(GetFieldValue(data, "SUBK_BILL_LINE1_ADDR")))
                cxml.Request.OrderRequest.OrderRequestHeader.BillTo.Address.PostalAddress.Street.Add(GetFieldValue(data, "SUBK_BILL_LINE1_ADDR"));

            if (!string.IsNullOrWhiteSpace(GetFieldValue(data, "SUBK_BILL_LINE2_ADDR")))
                cxml.Request.OrderRequest.OrderRequestHeader.BillTo.Address.PostalAddress.Street.Add(GetFieldValue(data, "SUBK_BILL_LINE2_ADDR"));
            if (!string.IsNullOrWhiteSpace(GetFieldValue(data, "SUBK_BILL_LINE3_ADDR")))
                cxml.Request.OrderRequest.OrderRequestHeader.BillTo.Address.PostalAddress.Street.Add(GetFieldValue(data, "SUBK_BILL_LINE3_ADDR"));

            // ItemOut - Request\OrderRequest\ItemOut

            if (data.document.rows != null && data.document.rows.Count > 0 
                && data.document.rows[0].row.children != null && data.document.rows[0].row.children.Count > 0)
            {
                foreach (var child in data.document.rows[0].row.children)
                {
                    if (GetFieldValue(child, "PO_LN_NO") == null) continue;
                    var itemOut = new ItemOut
                    {
                        LineNumber = GetFieldValue(child, "PO_LN_NO")
                    };
                    itemOut.ItemDetail.Description.Text = GetFieldValue(child, "PO_LN_DESC");
                    if (string.IsNullOrWhiteSpace(itemOut.ItemDetail.Description.Text))
                        itemOut.ItemDetail.Description.Text = GetFieldValue(child, "VCHR_LN_DESC");

                    itemOut.ItemDetail.UnitOfMeasure = GetFieldValue(child, "PO_LN_UM_CD");
                    if (string.IsNullOrWhiteSpace(itemOut.ItemDetail.UnitOfMeasure))
                        itemOut.ItemDetail.UnitOfMeasure = GetFieldValue(child, "UM_CD");

                    itemOut.Quantity = GetFieldValue(child, "ORD_QTY");

                    itemOut.ItemDetail.UnitPrice.Money.Text = GetFieldValue(child, "TRN_NET_UN_CST_AMT");
                    itemOut.ItemDetail.UnitPrice.Money.Currency = GetFieldValue(data, "PAY_CRNCY_CD");
                    itemOut.ItemDetail.Classification.Text = GetFieldValue(child, "COMM_CD");

                    itemOut.ItemID.SupplierPartID = GetFieldValue(child, "VEND_PART_ID");
                    if (string.IsNullOrWhiteSpace(itemOut.ItemID.SupplierPartID))
                        itemOut.ItemID.SupplierPartID = GetFieldValue(child, "ITEM_ID");

                    itemOut.Distribution.Accounting.Project = GetFieldValue(child, "POMPOVCH_VCHRLNACCT_PROJ_ID");
                    itemOut.Distribution.Accounting.Department = GetFieldValue(child, "POMPOVCH_VCHRLNACCT_ACCT_ID");
                    itemOut.Distribution.Accounting.Organization = GetFieldValue(child, "POMPOVCH_VCHRLNACCT_ORG_ID");

                    itemOut.Distribution.Charge.Money.Text = GetFieldValue(child, "POMPOVCH_POLN_TRN_LN_CHG_CST_AMT");

                    cxml.Request.OrderRequest.ItemOut.Add(itemOut);
                }

            }


            return cxml;
        }

        private static string GetFieldValue(Root data, string fieldName)
        {
            foreach (var item in data.document.rows)
            {
                if (item.row.data.ContainsKey(fieldName))
                {
                    var value = item.row.data[fieldName];
                    if (!string.IsNullOrWhiteSpace(value)) return value;
                }
                if (item.row.children != null && item.row.children.Count > 0)
                {
                    return GetFieldValue(item, fieldName);
                }
            }
            return null;
        }

        private static string GetFieldValue(Rows rows, string fieldName)
        {

            if (rows.row.data.ContainsKey(fieldName))
            {
                var value = rows.row.data[fieldName];
                if (!string.IsNullOrWhiteSpace(value)) return value;
            }
            if (rows.row.children != null && rows.row.children.Count > 0)
            {
                foreach (var item in rows.row.children)
                {
                    if (item.row.data.ContainsKey(fieldName))
                    {
                        var fieldValue = item.row.data[fieldName];
                        if (!string.IsNullOrWhiteSpace(fieldValue)) return fieldValue;
                    }
                    if (item.row.children != null && item.row.children.Count > 0)
                    {
                        return GetFieldValue(item, fieldName);
                    }
                }
            }

            return null;

        }

        private static string FormatXML(string xml)
        {
            string result = "";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            XmlDocument document = new XmlDocument();

            try
            {
                // Load the XmlDocument with the XML.
                document.LoadXml(xml);

                writer.Formatting = System.Xml.Formatting.Indented;

                // Write the XML into a formatting XmlTextWriter
                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                // Have to rewind the MemoryStream in order to read
                // its contents.
                mStream.Position = 0;

                // Read MemoryStream contents into a StreamReader.
                StreamReader sReader = new StreamReader(mStream);

                // Extract the text from the StreamReader.
                string formattedXml = sReader.ReadToEnd();

                result = formattedXml;
            }
            catch (XmlException)
            {
                // Handle the exception
            }

            mStream.Close();
            writer.Close();

            return result;
        }

    }
}
