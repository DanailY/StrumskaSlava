namespace StrumskaSlava.Data.Models
{
    using StrumskaSlava.Data.Common.Models;

    public class OrderStatus : BaseModel<string>
    {
        public string Name { get; set; }
    }
}
