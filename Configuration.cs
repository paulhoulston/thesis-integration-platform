namespace thesis_integration_platform;

static class Configuration
{
    public static readonly string ServiceBusConnectionString = Environment.GetEnvironmentVariable("Elements-Service-Bus-Connection-String");
    public static readonly string TopicName = Environment.GetEnvironmentVariable("Elements-Service-Bus-Topic");
    public static readonly string Subscription = Environment.GetEnvironmentVariable("Elements-Service-Bus-Subscription");
    public static readonly string SmtpUser = Environment.GetEnvironmentVariable("Elements-SMTP-User");
    public static readonly string SmtpPassword = Environment.GetEnvironmentVariable("Elements-SMTP-Password");
}
