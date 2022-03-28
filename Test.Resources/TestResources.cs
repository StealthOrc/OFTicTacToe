using System.Reflection;

namespace Test.Resources
{
    public static class TestResources
    {
        public static Assembly ResourceAssembly => typeof(TestResources).Assembly;
    }
}
