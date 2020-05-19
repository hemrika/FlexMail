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
    public class AccountTests : FlexMailTest
    {
        [ClassInitialize]
        public static void AccountTestsInitialize(TestContext testContext)
        {
        }

        [TestMethod()]
        public void Account_BouncesTest()
        {
            try
            {
                try
                {
                    List<BounceType> bounces = Client.Account.Bounces();
                }
                catch (FlexMailException flex)
                {
                    Assert.AreEqual(222, flex.Code);
                }

                try
                {
                    List<BounceType> bounces = Client.Account.Bounces(campaignId);
                }
                catch (FlexMailException flex)
                {
                    Assert.AreEqual(222, flex.Code);
                }

                try
                {
                    List<BounceType> bounces = Client.Account.Bounces(campaignId, mailingListId);
                }
                catch (FlexMailException flex)
                {
                    Assert.AreEqual(223, flex.Code);
                }

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void Account_ProfileUpdatesTest()
        {
            try
            {
                try
                {
                    List<ProfileUpdateType> updates = Client.Account.ProfileUpdates();
                }
                catch (FlexMailException flex)
                {
                    Assert.AreEqual(222, flex.Code);
                }

                try
                {
                    List<ProfileUpdateType> updates = Client.Account.ProfileUpdates(campaignId);
                }
                catch (FlexMailException flex)
                {
                    Assert.AreEqual(222, flex.Code);
                }

                try
                {
                    List<ProfileUpdateType> updates = Client.Account.ProfileUpdates(campaignId, mailingListId);
                }
                catch (FlexMailException flex)
                {
                    Assert.AreEqual(223, flex.Code);
                }

                try
                {
                    List<ProfileUpdateType> updates = Client.Account.ProfileUpdates(null, mailingListId);
                }
                catch (FlexMailException flex)
                {
                    Assert.AreEqual(223, flex.Code);
                }

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void Account_SubscriptionsTest()
        {
            try
            {
                try
                {
                    List<SubscriptionType> subscriptions = Client.Account.Subscriptions();

                    foreach (SubscriptionType subscriptionType in subscriptions)
                    {
                        Console.WriteLine(subscriptionType.emailAddressMailingListId);
                    }
                }
                catch (FlexMailException flex)
                {
                    Assert.AreEqual(223, flex.Code);
                }

                try
                {
                    List<SubscriptionType> subscriptions = Client.Account.Subscriptions(mailingListId);

                    foreach (SubscriptionType subscriptionType in subscriptions)
                    {
                        Console.WriteLine(subscriptionType.emailAddressMailingListId);
                    }
                }
                catch (FlexMailException flex)
                {
                    Assert.AreEqual(223, flex.Code);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public async Task Account_SubscriptionsAsyncTest()
        {
            try
            {
                try
                {
                    List<SubscriptionType> subscriptions = await Client.Account.SubscriptionsAsync();

                    foreach (SubscriptionType subscriptionType in subscriptions)
                    {
                        Console.WriteLine(subscriptionType.emailAddressMailingListId);
                    }
                }
                catch (FlexMailException flex)
                {
                    Assert.AreEqual(223, flex.Code);
                }

                try
                {
                    List<SubscriptionType> subscriptions = await Client.Account.SubscriptionsAsync(mailingListId);

                    foreach (SubscriptionType subscriptionType in subscriptions)
                    {
                        Console.WriteLine(subscriptionType.emailAddressMailingListId);
                    }
                }
                catch (FlexMailException flex)
                {
                    Assert.AreEqual(223, flex.Code);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void Account_UnsubscriptionsTest()
        {
            try
            {
                List<UnsubscriptionType> unsubscriptions = Client.Account.Unsubscriptions();

                unsubscriptions = Client.Account.Unsubscriptions(campaignId);

                unsubscriptions = Client.Account.Unsubscriptions(campaignId, mailingListId);

                unsubscriptions = Client.Account.Unsubscriptions(campaignId, mailingListId, true);

                unsubscriptions = Client.Account.Unsubscriptions(campaignId, null, true);

                unsubscriptions = Client.Account.Unsubscriptions(null, mailingListId, true);

                unsubscriptions = Client.Account.Unsubscriptions(null, null, true);

                foreach (UnsubscriptionType unsubscription in unsubscriptions)
                {
                    int emailAddressFlexmailId = unsubscription.emailAddressFlexmailId;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void Account_DisposeTest()
        {
            //Client.Account.Dispose();
        }
    }
}