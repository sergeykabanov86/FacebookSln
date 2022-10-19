
namespace FacebookParserNF.Models.Graph
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Metadata
    {
        [DataMember(Name = "connections")]
        public Connections Connections { get; set; }
    }
}