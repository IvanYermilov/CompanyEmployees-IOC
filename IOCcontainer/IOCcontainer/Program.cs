using System;

namespace IOCcontainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Container.Add<IDependency, MyClass>();
            var inst =  Container.GetInterfaceImplementation<IDependency>();

        }
    }
}
