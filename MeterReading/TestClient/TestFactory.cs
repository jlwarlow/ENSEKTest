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
                case '2':
                    return new ReadingTest();
                default:
                    return null;
            }
        }
    }
}
