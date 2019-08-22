namespace StrumskaSlava.Web.ViewModels.Product.All
{
    using X.PagedList;

    public class ProductViewModel
    {
        public IPagedList<ProductAllViewModel> ProductAllIndexViewModel { get; set; }

        public int? PageNumber { get; set; }
    }
}
