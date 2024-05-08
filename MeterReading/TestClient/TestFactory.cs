using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using TestClient.Properties;

namespace TestClient
{
    public static class TestFactory
    {
        public static ITest? CreateTest(char test)
        {
            switch (test)
            {
                case '1':
                    return new AccountTest();
                default:
                    return null;
            }
        }
    }
}
