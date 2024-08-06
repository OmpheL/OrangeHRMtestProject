namespace OrangeHRMtestProject.Utilities
{
    public static class TestData
    {
        // Private fields
        private static string UserName { get; } = "Admin";
        private static string Password { get; } = "admin123";

        // Static methods to access private fields
        public static string GetUserName() { return UserName; }
        public static string GetPassword() { return Password; }
    }
}
