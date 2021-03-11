using System;
using System.Collections.Generic;
using System.Text;

namespace JsonToXMLParser.BL
{
    class Row
    {
        public string rsId { get; set; }
        public Data data { get; set; } = new Data();

        public List<Rows> children { get; set; }

    }
}
