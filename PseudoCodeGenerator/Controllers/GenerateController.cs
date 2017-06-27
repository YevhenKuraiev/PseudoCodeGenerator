using PseudoCodeGenerator.Models;
using SearchForKeywords;
using System;
using System.Web.Mvc;

namespace PseudoCodeGenerator.Controllers
{
    public class GenerateController : Controller
    {
        [HttpGet]
        public ActionResult Pseudocode()
        {
            Keywords keywords = new Keywords();
            return View("GetDataFromTheUser", keywords);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ConvertData(string code, Keywords keywords)
        {
            Replace replace = new Replace(code);
            replace.Cycles(keywords.CycleFor, keywords.CycleForeach, keywords.CycleWhile, keywords.CycleDoWhile);
            replace.Conditions(keywords.IfElse);
            replace.OtherKeywords(keywords.Return, keywords.Continue, keywords.Break);
            replace.StartAndEndFunctions();
            ViewData["PseudoCode"] = replace.GetConvertedString();
            return PartialView();
        }

    }
}