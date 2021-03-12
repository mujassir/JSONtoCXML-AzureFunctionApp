using System;
using System.Collections.Generic;
using System.Text;

namespace JsonToXMLParser.BL
{
    class Document
    {
        public string id { get; set; } = string.Empty;
        public List<Rows> rows { get; set; }
    }
}
