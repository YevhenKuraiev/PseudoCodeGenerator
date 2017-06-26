using SearchForKeywords;
using System.Web.Mvc;

namespace PseudoCodeGenerator.Controllers
{
    public class GenerateController : Controller
    {
        [HttpGet]
        public ActionResult Pseudocode()
        {
            return View("GetDataFromTheUser");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ConvertData(string code)
        {
            Replace replace = new Replace(code);
            replace.Cycles(true, true, true);
            replace.Conditions();
            replace.OtherKeywords(true, true, true);
            ViewData["PseudoCode"] = replace.GetConvertedString();
            return PartialView();
        }

    }
}