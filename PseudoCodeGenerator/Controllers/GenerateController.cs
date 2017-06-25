using SearchForKeywords;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PseudoCodeGenerator.Controllers
{
    public class GenerateController : Controller
    {
        public ActionResult GetDataFromTheUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ConvertedData(string code)
        {
            Replace replace = new Replace(code);
            replace.Cycles(true, true, true);
            replace.Conditions();
            replace.OtherKeywords(true, true, true);
            ViewData["PseudoCode"] = replace.GetConvertedString();
            return View();
        }

    }
}