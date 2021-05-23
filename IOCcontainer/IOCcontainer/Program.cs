using System;

namespace IOCcontainer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Container.Add<IDependency, MyClass>();
                Container.Add<MyAnotherClass, MyAnotherClass>();
                var inst1 = Container.GetImplementation<IDependency>();
                var inst2 = Container.GetImplementation<MyAnotherClass>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
