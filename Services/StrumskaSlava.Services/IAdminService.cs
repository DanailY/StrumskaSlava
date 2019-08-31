namespace StrumskaSlava.Services
{
    using System.Threading.Tasks;

    using StrumskaSlava.Web.BindingModels.AdminPanel;

    public interface IAdminService
    {
        Task<bool> Create(AdminCreateBindingModel adminCreateBindingModel);
    }
}
