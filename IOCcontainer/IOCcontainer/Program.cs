using System;

namespace IOCcontainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Container.Add<IDependency3, MyClass3>();
            Container.Add<IDependency1, MyClass1>();
            //Container.Add<MyClass2, MyClass2>();
            Container.Add<MyClass4, MyClass4>();
            var inst1 = Container.GetImplementation<IDependency3>();
            var inst2 = Container.GetImplementation<IDependency1>();
            var inst3 = Container.GetImplementation<MyClass2>();
            var inst4 = Container.GetImplementation<MyClass4>();
        }
    }
}
