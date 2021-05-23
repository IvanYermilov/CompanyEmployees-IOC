using System;
using System.Collections.Generic;
using System.Text;

namespace IOCcontainer
{
    class MyAnotherClass
    {
        public IDependency I;

        public MyAnotherClass(IDependency iDependency)
        {
            I = iDependency;
        }
    }
}
