using System.Web;
using System.Web.Mvc;

namespace ASPMVCSE310.P12
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
