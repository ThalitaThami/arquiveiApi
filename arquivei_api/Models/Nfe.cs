using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace arquivei_api.Models
{
    public class Nfe
    {
        [Key]
        public string AccessKey { get; set; }
        public string Xml { get; set; }
        public decimal Total { get; set; }
        

        public void CalculateTotal()
        {
            var decodeXml = DecodeXmlNfe(Xml);
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(decodeXml);


            var vNFNode = xml.GetElementsByTagName("vNF")[0].ChildNodes[0];

            if(vNFNode != null)
                Total = Convert.ToDecimal(vNFNode.Value.Replace('.',','));
        }

        private string DecodeXmlNfe(string xmlEncoded)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(xmlEncoded);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
