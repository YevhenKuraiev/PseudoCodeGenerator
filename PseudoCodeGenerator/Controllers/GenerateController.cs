using SearchForKeywords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PseudoCodeGenerator.Controllers
{
    public class GenerateController : Controller
    {
        List<string> list = new List<string>() { "Вставить код (до 250 строк)", "Считать код из файла" };

        public ActionResult SelectingInputData()
        {
            SelectList selectList = new SelectList(list);
            ViewData["list"] = selectList;
            return View();
        }

        public ActionResult GetDataFromTheUser(string select)
        {
            return View();
        }

        public ActionResult ConvertedData(string code)
        {
            Replace replace = new Replace(code);
            replace.For();
            ViewData["PseudoCode"] = replace._arrayWords.StringArrayToString();
            return View();
        }

    }
}