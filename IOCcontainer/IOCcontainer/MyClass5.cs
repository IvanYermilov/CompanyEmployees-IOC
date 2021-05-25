using System;
using System.Collections.Generic;
using System.Text;

namespace IOCcontainer
{
    class MyClass5
    {
        IDependency1 I1;
        IDependency3 I2;

        public MyClass5(IDependency1 ID1, IDependency3 ID2)
        {
            I1 = ID1;
            I2 = ID2;
        }
    }
}
