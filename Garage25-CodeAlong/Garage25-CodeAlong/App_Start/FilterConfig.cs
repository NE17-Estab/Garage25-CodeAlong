using System.Web;
using System.Web.Mvc;

namespace Garage25_CodeAlong
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
