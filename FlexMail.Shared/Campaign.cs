using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexMail.Service;
//using Microsoft.ApplicationInsights;

namespace FlexMail
{
    /// <summary>
    /// 
    /// </summary>
    public class Campaign : IDisposable
    {
        private Client _client;

        internal Campaign()
        {
            _client = Client.Instance;
            FlexMail.Resources.Campaign.Culture = Client.CultureInfo;
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
        protected TelemetryClient telemetry
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

        #region Campaigns

        private GetCampaignsResp _campaigns = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<CampaignType> Campaigns(campaignTypeType type = campaignTypeType.Campaign)
        {
            try
            {
                if (_campaigns == null)
                {
                    var req = new GetCampaignsReq() { header = Client.RequestHeader };

                    req.type = type;
                    req.typeSpecified = true;

                    _campaigns = _client.API.GetCampaigns(req);
                }

                if (_campaigns != null && _campaigns.errorCode == (int)errorCode.No_error)
                    return _campaigns.campaignTypeItems.ToList<CampaignType>();
                else
                    if (_campaigns != null) throw new FlexMailException(FlexMail.Resources.Campaign.ResourceManager.GetString("Campaigns_" + _campaigns.errorCode), _campaigns.errorCode);

                throw new FlexMailException(FlexMail.Resources.Campaign.ResourceManager.GetString("Campaigns_" + _campaigns.errorCode), _campaigns.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Campaign.Campaigns" } });
                if (ex is FlexMailException)
                    throw (ex);
            }

            finally
            {
                _campaigns = null;
            }
            return new List<CampaignType>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<List<CampaignType>> CampaignsAsync(campaignTypeType type = campaignTypeType.Campaign)
        {
            try
            {
                if (_campaigns == null)
                {
                    var req = new GetCampaignsReq() { header = Client.RequestHeader };

                    req.type = type;
                    req.typeSpecified = true;

                    GetCampaignsResponse response = await _client.API.GetCampaignsAsync(req);
                    _campaigns = response.GetCampaignsResp;
                }

                if (_campaigns != null && _campaigns.errorCode == (int)errorCode.No_error)
                    return _campaigns.campaignTypeItems.ToList<CampaignType>();
                else
                    if (_campaigns != null) throw new FlexMailException(FlexMail.Resources.Campaign.ResourceManager.GetString("Campaigns_" + _campaigns.errorCode), _campaigns.errorCode);

                throw new FlexMailException(FlexMail.Resources.Campaign.ResourceManager.GetString("Campaigns_" + _campaigns.errorCode), _campaigns.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Campaign.Campaigns" } });
                if (ex is FlexMailException)
                    throw (ex);
            }

            finally
            {
                _campaigns = null;
            }
            return new List<CampaignType>();
        }
        #endregion

        #region Send



        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="campaignSendTimestamp"></param>
        public void Send(string campaignId = null, string campaignSendTimestamp = null)
        {
            SendCampaignResp _send = null;
            try
            {
                if (_send == null)
                {
                    var req = new SendCampaignReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(campaignId))
                        req.campaignId = int.Parse(campaignId);

                    if (!string.IsNullOrWhiteSpace(campaignSendTimestamp))
                        req.campaignSendTimestamp = campaignSendTimestamp;

                    _send = _client.API.SendCampaign(req);
                }

                if (_send != null && _send.errorCode == (int)errorCode.No_error)
                    return;
                else
                    if (_send != null) throw new FlexMailException(FlexMail.Resources.Campaign.ResourceManager.GetString("Send_" + _send.errorCode), _send.errorCode);

                throw new FlexMailException(FlexMail.Resources.Blacklist.ResourceManager.GetString("Send_" + _send.errorCode), _send.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Campaign.Send" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _send = null;
            }
            return;
        }

        #endregion

        #region SendTest



        /// <summary>
        /// 
        /// </summary>
        /// <param name="testCampaignType"></param>
        public void SendTest(TestCampaignType testCampaignType = null)
        {
            SendTestCampaignResp _sendTest = null;

            try
            {
                if (_sendTest == null)
                {
                    var req = new SendTestCampaignReq() { header = Client.RequestHeader };

                    if (testCampaignType != null)
                        req.testCampaignType = testCampaignType;

                    _sendTest = _client.API.SendTestCampaign(req);
                }
                if (_sendTest != null && _sendTest.errorCode == (int)errorCode.No_error)
                    return;
                else
                    if (_sendTest != null) throw new FlexMailException(FlexMail.Resources.Campaign.ResourceManager.GetString("SendTest_" + _sendTest.errorCode), _sendTest.errorCode);

                throw new FlexMailException(FlexMail.Resources.Blacklist.ResourceManager.GetString("SendTest_" + _sendTest.errorCode), _sendTest.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Campaign.SendTest" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _sendTest = null;
            }
            return;
        }

        #endregion

        #region Update



        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignType"></param>
        public void Update(CampaignType campaignType = null)
        {
            UpdateCampaignResp _update = null;

            try
            {
                if (_update == null)
                {
                    var req = new UpdateCampaignReq() { header = Client.RequestHeader };

                    if (campaignType != null)
                        req.campaignType = campaignType;

                    _update = _client.API.UpdateCampaign(req);
                }

                if (_update != null && _update.errorCode == (int)errorCode.No_error)
                    return;
                else
                    if (_update != null) throw new FlexMailException(FlexMail.Resources.Campaign.ResourceManager.GetString("Update_" + _update.errorCode), _update.errorCode);

                throw new FlexMailException(FlexMail.Resources.Blacklist.ResourceManager.GetString("Update_" + _update.errorCode), _update.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Campaign.Update" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _update = null;
            }
            return;
        }

        #endregion

        #region Create



        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignType"></param>
        /// <returns></returns>
        public int Create(CampaignType campaignType = null)
        {
            CreateCampaignResp _create = null;

            try
            {
                if (_create == null)
                {
                    var req = new CreateCampaignReq() { header = Client.RequestHeader };

                    if (campaignType != null)
                        req.campaignType = campaignType;

                    _create = _client.API.CreateCampaign(req);
                }

                if (_create != null && _create.errorCode == (int)errorCode.No_error)
                    return _create.campaignId;
                else
                    if (_create != null) throw new FlexMailException(FlexMail.Resources.Campaign.ResourceManager.GetString("Update_" + _create.errorCode), _create.errorCode);

                throw new FlexMailException(FlexMail.Resources.Blacklist.ResourceManager.GetString("Update_" + _create.errorCode), _create.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Campaign.Create" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _create = null;
            }
            return -1;
        }

        #endregion

        #region Delete

        private DeleteCampaignResp _delete = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignType"></param>
        public void Delete(CampaignType campaignType = null)
        {
            try
            {

                if (_delete == null)
                {
                    var req = new DeleteCampaignReq() { header = Client.RequestHeader };

                    if (campaignType != null)
                        req.campaignType = campaignType;

                    _delete = _client.API.DeleteCampaign(req);
                }

                if (_delete != null && _delete.errorCode == (int)errorCode.No_error)
                    return;
                else
                    if (_delete != null) throw new FlexMailException(FlexMail.Resources.Campaign.ResourceManager.GetString("Delete_" + _delete.errorCode), _delete.errorCode);

                throw new FlexMailException(FlexMail.Resources.Blacklist.ResourceManager.GetString("Delete_" + _delete.errorCode), _delete.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Campaign.Delete" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _delete = null;
            }
            return;
        }

        #endregion

        #region History

        private GetCampaignHistoryResp _history = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="sort"></param>
        /// <param name="timestampFrom"></param>
        /// <param name="timestampTill"></param>
        /// <param name="campaignHistoryOptionsType"></param>
        /// <returns></returns>
        public CampaignHistoryType History(string campaignId = null, string sort = null, string timestampFrom = null, string timestampTill = null, CampaignHistoryOptionsType campaignHistoryOptionsType = null)
        {
            try
            {
                if (_history == null)
                {
                    var req = new GetCampaignHistoryReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(campaignId))
                        req.campaignId = campaignId;

                    if (!string.IsNullOrWhiteSpace(sort))
                        req.sort = sort;

                    if (!string.IsNullOrWhiteSpace(timestampFrom))
                        req.timestampFrom = timestampFrom;

                    if (!string.IsNullOrWhiteSpace(timestampTill))
                        req.timestampTill = timestampTill;

                    if (campaignHistoryOptionsType != null)
                        req.campaignHistoryOptionsType = campaignHistoryOptionsType;

                    _history = _client.API.GetCampaignHistory(req);
                }

                if (_history != null && _history.errorCode == (int)errorCode.No_error)
                    return _history.campaignHistoryType;
                else
                    if (_history != null) throw new FlexMailException(FlexMail.Resources.Campaign.ResourceManager.GetString("History_" + _history.errorCode), _history.errorCode);

                throw new FlexMailException(FlexMail.Resources.Blacklist.ResourceManager.GetString("History_" + _history.errorCode), _history.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Campaign.History" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _history = null;
            }
            return new CampaignHistoryType();
        }

        #endregion

        #region Report

        private GetCampaignReportResp _report = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public CampaignReportType Report(string campaignId = null, string language = "NL")
        {
            try
            {

                if (_report == null)
                {
                    var req = new GetCampaignReportReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(campaignId))
                        req.campaignId = int.Parse(campaignId); req.campaignIdSpecified = true;

                    req.language = language;

                    _report = _client.API.GetCampaignReport(req);
                }

                if (_report != null && _report.errorCode == (int)errorCode.No_error)
                    return _report.campaignReportType;
                else
                    if (_report != null) throw new FlexMailException(FlexMail.Resources.Campaign.ResourceManager.GetString("Report_" + _report.errorCode), _report.errorCode);

                throw new FlexMailException(FlexMail.Resources.Blacklist.ResourceManager.GetString("Report_" + _report.errorCode), _report.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Campaign.Report" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _report = null;
            }
            return new CampaignReportType();
        }

        #endregion

        #region Summary

        private GetCampaignSummaryResp _summary = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public CampaignSummaryType Summary(string campaignId = null)
        {
            try
            {

                if (_summary == null)
                {
                    var req = new GetCampaignSummaryReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(campaignId))
                        req.campaignId = campaignId;

                    _summary = _client.API.GetCampaignSummary(req);
                }

                if (_summary != null && _summary.header.errorCode == (int)errorCode.No_error)
                    return _summary.campaignSummaryType;
                else
                    if (_summary != null) throw new FlexMailException(FlexMail.Resources.Campaign.ResourceManager.GetString("Summary_" + _summary.header.errorCode), _summary.header.errorCode);

                throw new FlexMailException(FlexMail.Resources.Blacklist.ResourceManager.GetString("Summary_" + _summary.header.errorCode), _summary.header.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Campaign.Summary" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _summary = null;
            }
            return new CampaignSummaryType();
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

                _campaigns = null;
                _delete = null;
                _history = null;
                _report = null;
                _summary = null;
                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~Campaign() { Dispose(false); }

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
