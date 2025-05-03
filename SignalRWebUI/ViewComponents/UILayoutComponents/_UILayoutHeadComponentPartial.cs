using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
