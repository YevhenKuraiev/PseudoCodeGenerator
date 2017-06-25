namespace SearchForKeywords
{
    public class Replace
    {
        private string[] _arrayWords { get; set; }

        public Replace(string code) => _arrayWords = code.ToStringArray();

        public string GetConvertedString() => _arrayWords.StringArrayToString();

        public void Cycles(bool cycleFor, bool cycleForeach, bool cycleWhile)
        {
            int indexOpen = 0, indexClose = 0, indexReplaceFor = 0;
            for (int i = 0; i < _arrayWords.Length; i++)
            {
                if ((_arrayWords[i] == "for" && cycleFor) || (_arrayWords[i] == "foreach" && cycleForeach) || (_arrayWords[i] == "while" && cycleWhile))
                {
                    _arrayWords[i] = "ДЛЯ";
                    indexReplaceFor++;
                    for (int j = ++i; j < _arrayWords.Length; j++)
                    {
                        if (_arrayWords[j].Contains("{") && indexReplaceFor == 1)
                        {
                            _arrayWords[j] = "ЦИКЛ\n";
                            indexReplaceFor--;
                            continue;
                        }
                        else if (_arrayWords[j].Contains("}") && indexClose == indexOpen)
                        {
                            indexOpen--;
                            indexClose--;
                            _arrayWords[j] = "КЦИКЛ\n";
                            i++;
                            break;
                        }
                        else if (_arrayWords[j].Contains("{") && indexReplaceFor == 0)
                        {
                            indexOpen++;
                        }
                        else if (_arrayWords[j].Contains("}"))
                        {
                            indexClose++;
                        }
                    }
                }
            }
        }

        public void Conditions()
        {
            int indexOpen = 0, indexClose = 0, indexReplaceIf = 0;
            for (int i = 0; i < _arrayWords.Length; i++)
            {
                if (_arrayWords[i] == "else")
                {
                    _arrayWords[i] = "ИНАЧЕ";
                }
                else if (_arrayWords[i] == "if")
                {
                    _arrayWords[i] = "ЕСЛИ";
                    indexReplaceIf++;
                    for (int j = ++i; j < _arrayWords.Length; j++)
                    {
                        if (_arrayWords[j].Contains("{") && indexReplaceIf == 1)
                        {
                            _arrayWords[j] = "ТО\n";
                            indexReplaceIf--;
                            continue;
                        }
                        else if (_arrayWords[j].Contains("}") && indexClose == indexOpen)
                        {
                            indexOpen--;
                            indexClose--;
                            _arrayWords[j] = "КЕСЛИ\n";
                            i++;
                            break;
                        }
                        else if (_arrayWords[j].Contains("{") && indexReplaceIf == 0)
                        {
                            indexOpen++;
                        }
                        else if (_arrayWords[j].Contains("}"))
                        {
                            indexClose++;
                        }
                    }
                }
            }
        }

        public void OtherKeywords(bool returns, bool continues, bool breaks)
        {
            for (int i = 0; i < _arrayWords.Length; i++)
            {
                if (returns && _arrayWords[i] == "return")
                {
                    _arrayWords[i] = "ВОЗВРАТ";
                }
                else if (continues && _arrayWords[i] == "continue")
                {
                    _arrayWords[i] = "ПРОДОЛЖЕНИЕ";
                }
                else if (breaks && _arrayWords[i] == "break")
                {
                    _arrayWords[i] = "ВЫХОД";
                }
            }
        }
    }
}
