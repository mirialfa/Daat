using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MiriamTest.Models
{
    [XmlRoot("CURRENCIES")]
    public class Currencies
    {
        [XmlElement("CURRENCY")]
        public Currency[] Currency { get; set; }
    }

    public class Currency
    {
        [XmlElement("NAME")]
        public string Name { get; set; }
        [XmlElement("UNIT")]
        public string Unit { get; set; }
        [XmlElement("CURRENCYCODE")]
        public string CurrencyCode { get; set; }
        [XmlElement("COUNTRY")]
        public string Country { get; set; }
        [XmlElement("RATE")]
        public string Rate { get; set; }
        [XmlElement("CHANGE")]
        public string Change { get; set; }
    }

    public class DateCurrenctRate
    {

        public DateTime Date { get; set; }
        public Currency Currency { get; set; }
    }
}