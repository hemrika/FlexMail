using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexMail.Service;
////using Microsoft.ApplicationInsights;

namespace FlexMail
{
    /// <summary>
    /// 
    /// </summary>
    public class Account : IDisposable
    {
        private Client _client;

        internal Account()
        {
            _client = Client.Instance;
            FlexMail.Resources.Message.Culture = Client.CultureInfo;
        }

        /*
        #region Insights Telemetry

        /// <summary>
        /// 
        /// </summary>
        protected TelemetryClient _telemetry = null;

        /// <summary>
        /// 
        /// </summary>
        internal TelemetryClient telemetry
        {
            get
            {
                if (_telemetry == null)
                     _telemetry = Client.telemetry ?? new TelemetryClient();

                return _telemetry;
            }
            set
            {
                if (_telemetry == null)
                    _telemetry = Client.telemetry ?? new TelemetryClient();

                _telemetry = value;
            }
        }

        #endregion
        */

        #region Balance

        private GetBalanceResp _balance = null;

        /// <summary>
        /// 
        /// </summary>
        internal GetBalanceResp Balance
        {
            get
            {
                try
                {
                    if (_balance == null)
                    {
                        _balance = _client.API.GetBalance(new GetBalanceReq() { header = Client.RequestHeader });
                    }

                    if (_balance.header.errorCode == (int)errorCode.No_error)
                        return _balance;

                    throw new FlexMailException(_balance.header.errorMessage, _balance.header.errorCode);
                }
                catch (Exception ex)
                {
                    ////telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Account.Balance" } });
                    if (ex is FlexMailException)
                        throw (ex);
                }
                finally
                {
                    _balance = null;
                }
                return new GetBalanceResp();
            }
        }

        /// <summary>
        /// Email credits available
        /// </summary>
        public int Email
        {
            get
            {
                return Balance.email;
            }
        }

        /// <summary>
        /// Fax credits available
        /// </summary>
        public int Fax
        {
            get
            {
                return Balance.fax;
            }
        }

        /// <summary>
        /// SMS credits available
        /// </summary>
        public int SMS
        {
            get
            {
                return Balance.sms;
            }
        }

        #endregion

        #region Bounces

        private GetBouncesResp _bounces = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="mailingListId"></param>
        /// <param name="timestampSince"></param>
        /// <returns></returns>
        public List<BounceType> Bounces(string campaignId = null, string mailingListId = null, string timestampSince = null)
        {
            try
            {
                if (_bounces == null)
                {
                    var req = new GetBouncesReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(campaignId))
                        req.campaignId = int.Parse(campaignId); req.campaignIdSpecified = true;

                    if (!string.IsNullOrWhiteSpace(mailingListId))
                        req.mailingListId = int.Parse(mailingListId); req.mailingListIdSpecified = true;

                    if (!string.IsNullOrWhiteSpace(timestampSince))
                        req.timestampSince = timestampSince;

                    _bounces = _client.API.GetBounces(req);
                }

                if (_bounces.errorCode == (int)errorCode.No_error)
                    return _bounces.bounceTypeItems.ToList<BounceType>();

                throw new FlexMailException(_bounces.errorMessage, _bounces.errorCode);
            }
            catch (Exception ex)
            {
                ////telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Account.Bounces" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _bounces = null;
            }
            return new List<BounceType>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="mailingListId"></param>
        /// <param name="timestampSince"></param>
        /// <returns></returns>
        public async Task<List<BounceType>> BouncesAsync(string campaignId = null, string mailingListId = null, string timestampSince = null)
        {
            try
            {
                if (_bounces == null)
                {
                    var req = new GetBouncesReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(campaignId))
                        req.campaignId = int.Parse(campaignId); req.campaignIdSpecified = true;

                    if (!string.IsNullOrWhiteSpace(mailingListId))
                        req.mailingListId = int.Parse(mailingListId); req.mailingListIdSpecified = true;

                    if (!string.IsNullOrWhiteSpace(timestampSince))
                        req.timestampSince = timestampSince;

                    GetBouncesResponse response = await _client.API.GetBouncesAsync(req);
                    _bounces = response.GetBouncesResp;
                }

                if (_bounces.errorCode == (int)errorCode.No_error)
                    return _bounces.bounceTypeItems.ToList<BounceType>();

                throw new FlexMailException(_bounces.errorMessage, _bounces.errorCode);
            }
            catch (Exception ex)
            {
                ////telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Account.Bounces" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _bounces = null;
            }
            return new List<BounceType>();
        }
        #endregion

        #region ProfileUpdates

        private GetProfileUpdatesResp _profileUpdates = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="mailingListId"></param>
        /// <param name="timestampSince"></param>
        /// <returns></returns>
        public List<ProfileUpdateType> ProfileUpdates(string campaignId = null, string mailingListId = null, string timestampSince = null)
        {
            try
            {
                if (_profileUpdates == null)
                {
                    var req = new GetProfileUpdatesReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(campaignId))
                        req.campaignId = int.Parse(campaignId);req.campaignIdSpecified = true;

                    if (!string.IsNullOrWhiteSpace(mailingListId))
                        req.mailingListId = int.Parse(mailingListId);req.mailingListIdSpecified = true;

                    if (!string.IsNullOrWhiteSpace(timestampSince))
                        req.timestampSince = timestampSince;

                    _profileUpdates = _client.API.GetProfileUpdates(req);
                }

                if (_profileUpdates.errorCode == (int)errorCode.No_error)
                    return _profileUpdates.profileUpdateTypeItems.ToList<ProfileUpdateType>();

                throw new FlexMailException(_profileUpdates.errorMessage, _profileUpdates.errorCode);
            }
            catch (Exception ex)
            {
                ////telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Account.ProfileUpdates" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _profileUpdates = null;
            }
            return new List<ProfileUpdateType>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="mailingListId"></param>
        /// <param name="timestampSince"></param>
        /// <returns></returns>
        public async Task<List<ProfileUpdateType>> ProfileUpdatesAsync(string campaignId = null, string mailingListId = null, string timestampSince = null)
        {
            try
            {
                if (_profileUpdates == null)
                {
                    var req = new GetProfileUpdatesReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(campaignId))
                        req.campaignId = int.Parse(campaignId); req.campaignIdSpecified = true;

                    if (!string.IsNullOrWhiteSpace(mailingListId))
                        req.mailingListId = int.Parse(mailingListId); req.mailingListIdSpecified = true;

                    if (!string.IsNullOrWhiteSpace(timestampSince))
                        req.timestampSince = timestampSince;

                    GetProfileUpdatesResponse response = await _client.API.GetProfileUpdatesAsync(req);
                    _profileUpdates = response.GetProfileUpdatesResp;
                }

                if (_profileUpdates.errorCode == (int)errorCode.No_error)
                    return _profileUpdates.profileUpdateTypeItems.ToList<ProfileUpdateType>();

                throw new FlexMailException(_profileUpdates.errorMessage, _profileUpdates.errorCode);
            }
            catch (Exception ex)
            {
                ////telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Account.ProfileUpdates" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _profileUpdates = null;
            }
            return new List<ProfileUpdateType>();
        }
        #endregion

        #region Subscriptions

        private GetSubscriptionsResp _subscriptions = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailingListId"></param>
        /// <param name="timestampSince"></param>
        /// <returns></returns>
        public List<SubscriptionType> Subscriptions(string mailingListId = null, string timestampSince = null)
        {
            try
            {
                if (_subscriptions == null)
                {
                    var req = new GetSubscriptionsReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(mailingListId))
                        req.mailingListId = int.Parse(mailingListId); req.mailingListIdSpecified = true;

                    if (!string.IsNullOrWhiteSpace(timestampSince))
                        req.timestampSince = timestampSince;

                    _subscriptions = _client.API.GetSubscriptions(req);
                }

                if (_subscriptions.errorCode == (int)errorCode.No_error)
                    return _subscriptions.subscriptionTypeItems.ToList<SubscriptionType>();

                throw new FlexMailException(_subscriptions.errorMessage, _subscriptions.errorCode);
            }
            catch (Exception ex)
            {
                ////telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Account.Subscriptions" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _subscriptions = null;
            }
            return new List<SubscriptionType>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailingListId"></param>
        /// <param name="timestampSince"></param>
        /// <returns></returns>
        public async Task<List<SubscriptionType>> SubscriptionsAsync(string mailingListId = null, string timestampSince = null)
        {
            try
            {
                if (_subscriptions == null)
                {
                    var req = new GetSubscriptionsReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(mailingListId))
                        req.mailingListId = int.Parse(mailingListId); req.mailingListIdSpecified = true;

                    if (!string.IsNullOrWhiteSpace(timestampSince))
                        req.timestampSince = timestampSince;

                    GetSubscriptionsResponse response = await _client.API.GetSubscriptionsAsync(req);
                    _subscriptions = response.GetSubscriptionsResp;
                }

                if (_subscriptions.errorCode == (int)errorCode.No_error)
                    return _subscriptions.subscriptionTypeItems.ToList<SubscriptionType>();

                throw new FlexMailException(_subscriptions.errorMessage, _subscriptions.errorCode);
            }
            catch (Exception ex)
            {
                ////telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Account.Subscriptions" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _subscriptions = null;
            }
            return new List<SubscriptionType>();
        }
        #endregion

        #region Unsubscriptions

        private GetUnsubscriptionsResp _unsubscriptions = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="mailingListId"></param>
        /// <param name="subListUnsubscriptions"></param>
        /// <param name="timestampSince"></param>
        /// <returns></returns>
        public List<UnsubscriptionType> Unsubscriptions(string campaignId = null, string mailingListId = null, bool subListUnsubscriptions = false, string timestampSince = null)
        {
            try
            {

                if (_unsubscriptions == null)
                {
                    var req = new GetUnsubscriptionsReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(campaignId))
                        req.campaignId = int.Parse(campaignId); req.campaignIdSpecified = true;

                    if (!string.IsNullOrWhiteSpace(mailingListId))
                        req.mailingListId = int.Parse(mailingListId); req.mailingListIdSpecified = true;

                    req.subListUnsubscriptions = subListUnsubscriptions;
                    req.subListUnsubscriptionsSpecified = true;

                    if (!string.IsNullOrWhiteSpace(timestampSince))
                        req.timestampSince = timestampSince;

                    _unsubscriptions = _client.API.GetUnsubscriptions(req);
                }

                if (_unsubscriptions.errorCode == (int)errorCode.No_error)
                    return _unsubscriptions.unsubscriptionTypeItems.ToList<UnsubscriptionType>();

                throw new FlexMailException(_subscriptions.errorMessage, _subscriptions.errorCode);
            }
            catch (Exception ex)
            {
                ////telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Account.Unsubscriptions" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _unsubscriptions = null;
            }
            return new List<UnsubscriptionType>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="mailingListId"></param>
        /// <param name="subListUnsubscriptions"></param>
        /// <param name="timestampSince"></param>
        /// <returns></returns>
        public async Task<List<UnsubscriptionType>> UnsubscriptionsAsync(string campaignId = null, string mailingListId = null, bool subListUnsubscriptions = false, string timestampSince = null)
        {
            try
            {

                if (_unsubscriptions == null)
                {
                    var req = new GetUnsubscriptionsReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(campaignId))
                        req.campaignId = int.Parse(campaignId); req.campaignIdSpecified = true;

                    if (!string.IsNullOrWhiteSpace(mailingListId))
                        req.mailingListId = int.Parse(mailingListId); req.mailingListIdSpecified = true;

                    req.subListUnsubscriptions = subListUnsubscriptions;
                    req.subListUnsubscriptionsSpecified = true;

                    if (!string.IsNullOrWhiteSpace(timestampSince))
                        req.timestampSince = timestampSince;

                    GetUnsubscriptionsResponse response = await _client.API.GetUnsubscriptionsAsync(req);
                    _unsubscriptions = response.GetUnsubscriptionsResp;
                }

                if (_unsubscriptions.errorCode == (int)errorCode.No_error)
                    return _unsubscriptions.unsubscriptionTypeItems.ToList<UnsubscriptionType>();

                throw new FlexMailException(_subscriptions.errorMessage, _subscriptions.errorCode);
            }
            catch (Exception ex)
            {
                ////telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Account.Unsubscriptions" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _unsubscriptions = null;
            }
            return new List<UnsubscriptionType>();
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                _balance = null;
                _bounces = null;
                _profileUpdates = null;
                _subscriptions = null;
                _unsubscriptions = null;

                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~Account() { Dispose(false); }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
