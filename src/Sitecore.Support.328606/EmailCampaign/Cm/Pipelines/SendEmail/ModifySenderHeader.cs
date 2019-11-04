namespace Sitecore.Support.EmailCampaign.Cm.Pipelines.SendEmail
{
    using Sitecore.Diagnostics;
    using Sitecore.EDS.Core.Dispatch;
    using Sitecore.EmailCampaign.Cm.Pipelines.SendEmail;
    public class ModifySenderHeader
    {
        public void Process(SendMessageArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            EmailMessage emailMessage = args.CustomData["EmailMessage"] as EmailMessage;
            if (emailMessage.FromName.Length > 0)
            {
                emailMessage.Headers.Set("Sender", emailMessage.FromName + "<" + emailMessage.FromAddress + " > ");
            }
            else
            {
                emailMessage.Headers.Remove("Sender");
            }
        }
    }
}