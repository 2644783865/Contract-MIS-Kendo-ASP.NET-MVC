using System;
using System.Runtime.Serialization;
using Misi.Common.Lib.Util;

namespace Tester
{
    public class MapperTest
    {
        public static void Main(string[] args)
        {
            var hello = "Hello @name";

            var baru = hello.Replace("@name", "bromo");
            System.Diagnostics.Debug.WriteLine(baru);
            /*
            var src = new Source
            {
                TESTER1 = "Bromo Kunto Adji",
                TESTER2 = "Wargandi",
                TESTER3 = "bromokun",
                TESTER4 = "20140412",
                TESTER5 = "00012"
            };

            var des = new Destination();
            SAPDataMapper.Instance.MapFields(src, des);
            System.Diagnostics.Debug.WriteLine(des.FirstName + " - " + des.LastName + " - " + des.UserName + " - " + des.Birthdate.ToString("dd/MM/yyyy") + " - " + des.Integer);
             */
        }
    }

    [DataContract]
    public class Source
    {
        [DataMember]
        public string TESTER1 { get; set; }
        
        [DataMember]
        public string TESTER2 { get; set; }

        [DataMember]
        public string TESTER3 { get; set; }

        [DataMember]
        public string TESTER4 { get; set; }

        [DataMember]
        public string TESTER5 { get; set; }
    }

    [DataContract]
    public class Destination
    {
        
        [SAPDataField("TESTER1")]
        [DataMember]
        public string FirstName { get; set; }
        
        [SAPDataField("TESTER2")]
        [DataMember]
        public string LastName { get; set; }

        [SAPDataField("TESTER3")]
        [DataMember]
        public string UserName { get; set; }

        [SAPDataField("TESTER4")]
        [DataMember]
        public DateTime Birthdate { get; set; }

        [SAPDataField("TESTER5")]
        [DataMember]
        public int Integer { get; set; }
    }
}
