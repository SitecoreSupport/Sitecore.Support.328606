namespace Sitecore.Support.EDS.Providers.SparkPost.Dispatch
{
  using Sitecore.EDS.Core.Dispatch;
  using Sitecore.EDS.Core.Reporting;
  using Sitecore.EDS.Providers.SparkPost.Configuration;
  using Sitecore.EDS.Providers.SparkPost.Dispatch;
  using Sitecore.StringExtensions;
  public class DispatchProvider : Sitecore.EDS.Providers.SparkPost.Dispatch.DispatchProvider
  {
    public DispatchProvider(ConnectionPoolManager connectionPoolManager, IEnvironmentId environmentIdentifier, IConfigurationStore configurationStore, string returnPath) : base(connectionPoolManager, environmentIdentifier, configurationStore, returnPath)
    {
    }
    protected override void SetMessageHeaders(EmailMessage message)
    {
      base.SetMessageHeaders(message);

      if (!message.FromAddress.IsNullOrEmpty()&&!message.FromName.IsNullOrEmpty())
      {
        message.Headers.Set("Sender", message.FromName + "<"+message.FromAddress+">");
      }
    }
  }
}