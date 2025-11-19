namespace Karify.Api.Utils
{
    public static class Constants
    {
        public const string JsonFilePath = "appsettings.json";
        public const string JsonEnviromentFilePath = "appsettings.{0}.json";
        public const string EnviromentVariable = "ASPNETCORE_ENVIRONMENT";
        public const string StarAppMessage = "*************** START APPLICATION ***************";
        public const string ConfigAppMessge = "Configuring application...";
        public const string StartingAppMesage = "Starting application...";
        public const string EndingAppMessage = "Application terminated unexpectedly!";
        public const string EndAppMessage = "*************** END APPLICATION ***************";
        public const string ContentTypeJson = "application/json";
        public const string ContentTypeTextHtml = "text/html";
        public const string CorsPolicyName = "CorsPolicy";
        public const string WelcomePath = "/";
        public const string HealthPath = "/health";
        public const string ExternalHealthPath = "/api/v1/health";
        public const string WelcomeAPI = "<div style=\"display:flex;flex-direction:column;justify-content:center;align-items:center;padding:20px;height:140px;background:linear-gradient(90deg,#FD620F,#FF8A3D);color:#fff;font-family:'Segoe UI',Tahoma,Geneva,Verdana,sans-serif;border-radius:12px;box-shadow:0 4px 12px rgba(0,0,0,0.2);\"><h1 style=\"margin:0;font-size:2.2rem;font-weight:600;\">{0}</h1><span style=\"margin-top:8px;font-size:1rem;font-weight:400;opacity:0.9;\">Alfiery Dev</span></div>\r\n";
        public const string ConnectionString = "Karify";
        public const string JwtSettings = "JwtSettings";
        public const string ExternalServicesSettings = "ExternalServices";
        public const string GlobalOAuthPolicyName = "GlobalOAuthPolicy";
    }
}
