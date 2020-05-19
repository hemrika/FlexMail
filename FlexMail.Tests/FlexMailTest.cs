using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlexMail.Tests
{
    [TestClass]
    public class FlexMailTest
    {
        internal static int userId = 1250;
        internal static string userToken = "F4177F8A-71649067-7C7D905B-0307A6EA-32173054530353231";
        internal static string cultureInfo = "nl-nl";
        internal static string campaignId = "1935409";
        internal static string messageId = "914859";
        internal static string categoryId = "40664";
        internal static string mailingListId = "186569";

        public TestContext TestContext { get; set; }

        [TestInitialize]
        [TestProperty("UserId", "1250")]
        [TestProperty("UserToken", "F4177F8A-71649067-7C7D905B-0307A6EA-32173054530353231")]
        [TestProperty("CultureInfo", "nl-nl")]
        [TestProperty("CampaignId", "1935409")]
        [TestProperty("MessageId", "914859")]
        [TestProperty("CategoryId", "40664")]
        [TestProperty("MailingListId", "186569")]
        public void FlexMailTestInitialize()
        {
            TestContext.Properties["UserId"] = userId;
            TestContext.Properties["UserToken"] = userToken;
            TestContext.Properties["CultureInfo"] = cultureInfo;
            TestContext.Properties["CampaignId"] = campaignId;
            TestContext.Properties["MessageId"] = messageId;
            TestContext.Properties["CategoryId"] = categoryId;
            TestContext.Properties["mailingListId"] = mailingListId;

            Client.UserId = userId;
            Client.UserToken = userToken;
            Client.CultureInfo = new System.Globalization.CultureInfo(cultureInfo);
            Client.MessageSize = 65536 * 400;
        }

        [TestCleanup]
        public void FlexMailTestCleanup()
        {
        }
    }
}
