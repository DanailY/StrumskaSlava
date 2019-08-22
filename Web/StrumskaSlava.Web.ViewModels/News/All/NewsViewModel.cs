namespace StrumskaSlava.Web.ViewModels.News.All
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using X.PagedList;

    public class NewsViewModel
    {
        public IPagedList<NewsAllViewModel> NewsAllIndexViewModel { get; set; }

        public IList<NewsAllViewModel> NewsAllViewModel { get; set; }

        public int? PageNumber { get; set; }

    }
}
