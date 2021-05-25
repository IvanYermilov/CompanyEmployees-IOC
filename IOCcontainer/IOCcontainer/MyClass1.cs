using System;
using System.Collections.Generic;
using System.Text;

namespace IOCcontainer
{
    class MyClass1 : IDependency1
    {
        private int a, b;

        public MyClass1()
        {
            a = 2;
            b = 3;
        }

        public MyClass1(int a = 10, int b = 15)
        {
            this.a = a;
            this.b = b;
        }

        public int Sum()
        {
            return a + b;
        }
    }
}
