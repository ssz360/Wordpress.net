namespace DigitalParadox.Wordpress.Utilities
{
    using System.Dynamic;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using RestSharp;
    using RestSharp.Deserializers;
    using RestSharp.Serializers;

    public class JsonNetSerializer : IDeserializer, ISerializer
    {

        public JsonNetSerializer() : this(new JsonSerializerSettings(), new JsonLoadSettings()){}
        public JsonNetSerializer(JsonLoadSettings loadSettings):this(new JsonSerializerSettings(), loadSettings){}
        public JsonNetSerializer(JsonSerializerSettings serializerSettings):this(serializerSettings,new JsonLoadSettings()){}
        public JsonNetSerializer(JsonSerializerSettings serializerSettings, JsonLoadSettings loadSettings)
        {
            SerializerSettings = serializerSettings;
            this.DynamicParserSettings = loadSettings;
        }
        
        public T Deserialize<T>(IRestResponse response)
        {
            if (!typeof(T).IsAssignableFrom(typeof(IDynamicMetaObjectProvider)))
            {
                return JsonConvert.DeserializeObject<T>(response.Content, SerializerSettings);
            }

            //special case for dynamics to deserialize to properties instead of dictionary 
            dynamic obj = JObject.Parse(response.Content, this.DynamicParserSettings);
            return obj;
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public string RootElement { get; set; }

        public string Namespace { get; set; }

        public string DateFormat { get; set; }

        public string ContentType { get; set; }

        public JsonSerializerSettings SerializerSettings { get; set; }

        public JsonLoadSettings DynamicParserSettings { get; set; }
    }
}