namespace web_api.Middleware
{
    [AttributeUsage(AttributeTargets.Method)]
    public class LoginRequiredAttribute:Attribute
    {
        public string MetadataProperty { get; set; }

        public LoginRequiredAttribute(string metadataProperty)
        {
            MetadataProperty = metadataProperty;
        }
    }
}
