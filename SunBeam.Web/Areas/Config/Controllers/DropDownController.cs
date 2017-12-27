
using SunBeam.Service.Interfaces;
using System.Web.Mvc;

namespace SunBeam.Web.Areas.Config.Controllers
{
    public class DropDownController : Controller
    {
        private readonly IEnumCountryBL EnumCountryrepo;
        private readonly IPurcheaseDetailsBL PurcheaseDetailsrepo;

        public DropDownController(IEnumCountryBL _EnumCountryrepo, IPurcheaseDetailsBL _PurcheaseDetailsrepo)
        {
            this.EnumCountryrepo = _EnumCountryrepo;
            this.PurcheaseDetailsrepo = _PurcheaseDetailsrepo;
        }
        // GET: Config/DropDown
        public ActionResult Index()
        {
            return View();
        }
    }
}