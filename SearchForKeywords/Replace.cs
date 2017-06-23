using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchForKeywords
{
    public class Replace : IReplace
    {
        //public string PseudoCode { get; set; }
        public string[] _arrayWords { get; set; }
        private string _code { get; }
        public Replace(string code)
        {
            _code = code;
            _arrayWords = _code.ToStringArray();
        }


        public void For()
        {
            _arrayWords = _arrayWords.ReplaceFor("for");
        }

        public void Foreach()
        {

        }

        public void If()
        {
        }

        public void While()
        {
        }
    }
}
