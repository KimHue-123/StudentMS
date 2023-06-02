using Microsoft.AspNetCore.Mvc;
using StudentMS.ViewModel.Catalog.Students;
using StudentMS.ViewModel.Common;
using System.Threading.Tasks;

namespace StudentMS.WebApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PageResultBase<StudentVM> result)
        {
            return Task.FromResult<IViewComponentResult>(View("Default", result));
        }
    }
}
