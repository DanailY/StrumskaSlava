namespace StrumskaSlava.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using StrumskaSlava.Services.Data;

    public interface IReceiptService
    {
        Task<string> CreateReceipt(string recepientId);

        IQueryable<ReceiptServiceModel> GetAll();

        IQueryable<ReceiptServiceModel> GetAllByRecepientId(string recepientId);
    }
}
