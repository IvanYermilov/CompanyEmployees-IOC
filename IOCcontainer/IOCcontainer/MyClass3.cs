using System;
using System.Collections.Generic;
using System.Text;

namespace IOCcontainer
{
    class MyClass3:IDependency3
    {
        public int Mul(int a, int b)
        {
            return a*b;
        }
    }
}
