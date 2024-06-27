namespace Taxes.Api
{
    public static class ApiEndPoints
    {
        private const string ApiBase = "/api";
        public static class Taxes
        {
            private const string Base = $"{ApiBase}/taxe";
            public const string Create = Base;
            public const string Get = $"{Base}/{{id}}";
            public const string GetAll = Base;
        }
    }
}
