﻿namespace SearchForKeywords
{
    public class Replace
    {
        public string[] _arrayWords { get; set; }

        public Replace(string code) => _arrayWords = code.ToStringArray();

        public string GetConvertedString() => _arrayWords.StringArrayToString();

        public void Cycles(string cycleFor, string cycleForeach, string cycleWhile, string cycleDoWhile)
        {
            if (cycleDoWhile == "on")
            {
                char[] charsToTrim = { '\r', '\n' };
                int indexOpen = 0, indexClose = 0, indexReplaceDo = 0;
                for (int i = 0; i < _arrayWords.Length; i++)
                {
                    bool open = false, close = false;
                    if (_arrayWords[i].Trim(charsToTrim) == "do")
                    {
                        _arrayWords[i] = "ДЕЛАТЬ\n";
                        indexReplaceDo++;
                        for (int j = ++i; j < _arrayWords.Length; j++)
                        {
                            if (_arrayWords[j].Contains("{") && !open)
                            {
                                _arrayWords[j] = "ЦИКЛ\n";
                                open = true;
                            }
                            else if (_arrayWords[j].Contains("}") && !close && indexClose == indexOpen)
                            {
                                _arrayWords[j] = "КЦИКЛ";
                                close = true;
                            }
                            else if (_arrayWords[j].Contains("while") && open && close)
                            {
                                _arrayWords[j] = "ПОКА";
                                break;
                            }
                            else if (_arrayWords[j].Contains("{"))
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
            if (cycleFor == "on" || cycleForeach == "on" || cycleWhile == "on")
            {
                int indexOpen = 0, indexClose = 0, indexReplaceCycle = 0;
                for (int i = 0; i < _arrayWords.Length; i++)
                {
                    if ((_arrayWords[i] == "for" && cycleFor == "on") || (_arrayWords[i] == "foreach" && cycleForeach == "on") || (_arrayWords[i] == "while" && cycleWhile == "on"))
                    {
                        _arrayWords[i] = "ДЛЯ";
                        indexReplaceCycle++;
                        for (int j = ++i; j < _arrayWords.Length; j++)
                        {
                            if (_arrayWords[j].Contains("{") && indexReplaceCycle == 1)
                            {
                                _arrayWords[j] = "ЦИКЛ\n";
                                indexReplaceCycle--;
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
                            else if (_arrayWords[j].Contains("{") && indexReplaceCycle == 0)
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
            

        }

        public void Conditions(string ifElse)
        {
            if (ifElse != "on") return;
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

        public void OtherKeywords(string returns, string continues, string breaks)
        {
            for (int i = 0; i < _arrayWords.Length; i++)
            {
                if (returns == "on" && _arrayWords[i] == "return")
                {
                    _arrayWords[i] = "ВОЗВРАТ";
                }
                else if (continues == "on" && _arrayWords[i] == "continue")
                {
                    _arrayWords[i] = "ПРОДОЛЖЕНИЕ";
                }
                else if (breaks == "on" && _arrayWords[i] == "break")
                {
                    _arrayWords[i] = "ВЫХОД";
                }
            }
        }

        public void StartAndEndFunctions()
        {
            int indexOpen = 0, indexClose = 0;
            bool open = false, close = false, isBegin = false;
            for (int i = 0; i < _arrayWords.Length; i++)
            {
                if (_arrayWords[i].Contains("{") && !isBegin)
                {
                    for (int j = i; j >= 0; j--)
                    {
                        if (_arrayWords[j].Contains(")") && !open)
                        {
                            open = true;
                        }
                        else if (_arrayWords[j].Contains("(") && !close)
                        {
                            close = true;
                        }
                        if (open && close)
                        {
                            _arrayWords[i] = "НАЧАЛО\n";
                            isBegin = true;
                            break;
                        }
                    }
                }
                else if (_arrayWords[i].Contains("}") && open && close && isBegin && indexClose == indexOpen)
                {
                    _arrayWords[i] = "КОНЕЦ\n\n";
                    open = false;
                    close = false;
                    isBegin = false;
                }
                else if (_arrayWords[i].Contains("{"))
                {
                    indexOpen++;
                }
                else if (_arrayWords[i].Contains("}"))
                {
                    indexClose++;
                }
            }
        }
        }
}
