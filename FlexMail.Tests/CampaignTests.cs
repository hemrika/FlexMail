using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlexMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexMail.Service;

namespace FlexMail.Tests
{
    [TestClass()]
    public class CampaignTests : FlexMailTest
    {
        private static Message message = null;
        private static MailingList mailingList = null;
        private static Category category = null;
        private static Campaign campaign = null;

        [ClassInitialize]
        public static void CampaignTestsInitialize(TestContext testContext)
        {
            message = new Message();
            mailingList = new MailingList();
            category = new Category();
            campaign = new Campaign();
        }

        [TestMethod()]
        public void Campaign_CampaignsTest()
        {
            List<CampaignType> campaigns = campaign.Campaigns();// Client.Campaign.Campaigns();

            foreach (CampaignType campaign in campaigns)
            {
                    int campaignId = campaign.campaignId;
            }
        }

        [TestMethod()]
        public async void Campaign_CampaignsAsyncTest()
        {
            List<CampaignType> campaigns = await campaign.CampaignsAsync();// Client.Campaign.Campaigns();

            foreach (CampaignType campaign in campaigns)
            {
                int campaignId = campaign.campaignId;
            }
        }

        [TestMethod()]
        public void Campaign_SendTest()
        {

        }

        [TestMethod()]
        public void Campaign_SendTestTest()
        {
            //new Client().Campaign.SendTest(new TestCampaignType() { testCampaignMessageId = 0, testCampaignName = "Test", testCampaignReplyEmailAddress = "rutger@hemrika.nl", testCampaignSenderEmailAddress = "rutger@hemrika.nl", testCampaignSenderName = "Rutger Hemrika", testCampaignSendToEmailAddress = "rutger@hemrika.nl", testCampaignSubject = "Test Send Campaign" });
        }

        [TestMethod()]
        public void Campaign_UpdateTest()
        {

        }

        [TestMethod()]
        public void Campaign_CreateTest()
        {
            /*
            try
            {
                int campaignMessageId = message.Messages(false, true, false).FirstOrDefault().messageId;
                int categoryId = category.Categories().FirstOrDefault().categoryId;
                int[] campaignMailingIds = mailingList.MailingLists(categoryId.ToString()).Select(ml => ml.mailingListId).Take(10).ToArray();
                int campaignId = campaign.Create(new CampaignType() { campaignName = "Test Campaign", campaignSubject = "Test Subject", campaignSenderEmailAddress = "info@vilans.nl", campaignSenderName = "Vilans", campaignReplyEmailAddress = "no-reply@vilans.nl", campaignMessageId = campaignMessageId, campaignMessageIdSpecified = true, campaignMailingIds = campaignMailingIds });
                campaign.Delete(new CampaignType() { campaignId = campaignId, campaignIdSpecified = true });
            }
            catch (FlexMail.Service.FlexMailException flex)
            {
                int code = flex.Code;
                string message = flex.Message;
                //throw;
            }
            */
        }

        [TestMethod()]
        public void Campaign_DeleteTest()
        {
            //campaign.Delete(new CampaignType() { campaignId = 1935409, campaignIdSpecified = true });
        }

        [TestMethod()]
        public void Campaign_HistoryTest()
        {
            CampaignHistoryType history = Client.Campaign.History(campaignId);

            foreach (EmailAddressHistoryType item in history.emailAddressHistoryTypeItems)
            {
            }
        }

        [TestMethod()]
        public void Campaign_ReportTest()
        {
            try
            {
                CampaignReportType report = Client.Campaign.Report(campaignId);
            }
            catch (FlexMail.Service.FlexMailException flex)
            {
                int code = flex.Code;
                string message = flex.Message;
                //throw;
            }

        }

        [TestMethod()]
        public void Campaign_SummaryTest()
        {
            CampaignSummaryType sumary = Client.Campaign.Summary(campaignId);
        }

        [TestMethod()]
        public void Campaign_DisposeTest()
        {
            //Client.Campaign.Dispose();
        }
    }
}