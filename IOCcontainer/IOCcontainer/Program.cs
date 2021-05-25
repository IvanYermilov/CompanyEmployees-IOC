using System;

namespace IOCcontainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Container.Add<IDependency3, MyClass3>();
            Container.Add<IDependency1, MyClass1>();
            Container.Add<MyClass2, MyClass2>();
            Container.Add<MyClass4, MyClass4>();
            Container.Add<MyClass5, MyClass5>();
            var inst1 = Container.GetImplementation<IDependency3>();
            var inst2 = Container.GetImplementation<IDependency1>();
            var inst3 = Container.GetImplementation<MyClass2>();
            var inst4 = Container.GetImplementation<MyClass4>();
            var inst5 = Container.GetImplementation<MyClass5>();
            Console.WriteLine(inst1.Mul(2,5));
            Console.WriteLine(inst3.I.Sum());
            Console.ReadKey();
        }
    }
}
