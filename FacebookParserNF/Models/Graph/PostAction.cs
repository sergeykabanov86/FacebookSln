using System.Collections.Generic;

namespace FacebookParserNF.Models.Graph
{
    using System.Runtime.Serialization;

    [DataContract]
    public class PostAction
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "link")]
        public string Link { get; set; }
    }

    public class PostActionCollection : List<PostAction>
    {

    }
}