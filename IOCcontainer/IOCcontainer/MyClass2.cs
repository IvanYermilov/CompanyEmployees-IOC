using System;
using System.Collections.Generic;
using System.Text;

namespace IOCcontainer
{
    class MyClass2
    {
        public IDependency1 I;

        public MyClass2(IDependency1 iDependency)
        {
            I = iDependency;
        }
    }
}
