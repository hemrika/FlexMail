using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexMail.Service;

using System.Globalization;
using System.Resources;
//using Microsoft.ApplicationInsights;

namespace FlexMail
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Blacklist : IDisposable
    {
        private Client _client;

        internal Blacklist()
        {
            _client = Client.Instance;
            FlexMail.Resources.Blacklist.Culture = Client.CultureInfo;
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

        #region Import

        private ImportBlacklistResp _import = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddressTypeItems"></param>
        /// <param name="mailingListTypeItems"></param>
        /// <returns></returns>
        public List<ImportBlacklistRespType> Import(EmailAddressType[] emailAddressTypeItems = null, MailingListType[] mailingListTypeItems = null)
        {
            try
            {
                if (_import == null)
                {
                    var req = new ImportBlacklistReq() { header = Client.RequestHeader };

                    if (emailAddressTypeItems != null)
                        req.emailAddressTypeItems = emailAddressTypeItems;

                    if (mailingListTypeItems != null)
                        req.mailingListTypeItems = mailingListTypeItems;

                    _import = _client.API.ImportBlacklist(req);
                }

                if (_import != null && _import.errorCode == (int)errorCode.No_error)
                    return _import.importBlacklistRespTypeItems.ToList<ImportBlacklistRespType>();
                else
                    if (_import != null) throw new FlexMailException(FlexMail.Resources.Blacklist.ResourceManager.GetString("Import_" + _import.errorCode), _import.errorCode);

            }
            catch (Exception ex)
            {
                ////telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Blacklist.Import" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _import = null;
            }

            return new List<ImportBlacklistRespType>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddressTypeItems"></param>
        /// <param name="mailingListTypeItems"></param>
        /// <returns></returns>
        public async Task<List<ImportBlacklistRespType>> ImportAsync(EmailAddressType[] emailAddressTypeItems = null, MailingListType[] mailingListTypeItems = null)
        {
            try
            {
                if (_import == null)
                {
                    var req = new ImportBlacklistReq() { header = Client.RequestHeader };

                    if (emailAddressTypeItems != null)
                        req.emailAddressTypeItems = emailAddressTypeItems;

                    if (mailingListTypeItems != null)
                        req.mailingListTypeItems = mailingListTypeItems;

                    ImportBlacklistResponse response = await _client.API.ImportBlacklistAsync(req);
                    _import = response.ImportBlacklistResp;
                }

                if (_import != null && _import.errorCode == (int)errorCode.No_error)
                    return _import.importBlacklistRespTypeItems.ToList<ImportBlacklistRespType>();
                else
                    if (_import != null) throw new FlexMailException(FlexMail.Resources.Blacklist.ResourceManager.GetString("Import_" + _import.errorCode), _import.errorCode);

            }
            catch (Exception ex)
            {
                ////telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Blacklist.Import" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _import = null;
            }

            return new List<ImportBlacklistRespType>();
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

                _import = null;

                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~Blacklist() { Dispose(false); }

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
