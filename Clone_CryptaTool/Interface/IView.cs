using System;
using System.Collections.Generic;
using System.Text;

namespace Clone_CryptaTool.Interface
{
    interface IView
    {
         string beforeText { get; set; }
         string afterText { get; set; }
        string  keyWord { get; set; }
        byte currentOperation { get; }

    }
}
