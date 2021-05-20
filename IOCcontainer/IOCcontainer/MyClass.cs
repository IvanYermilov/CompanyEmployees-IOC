using System;
using System.Collections.Generic;
using System.Text;

namespace IOCcontainer
{
    class MyClass : IDependency
    {
        private int a, b;

        public MyClass()
        {
            a = 2;
            b = 3;
        }

        public MyClass(int a = 10, int b = 15)
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
