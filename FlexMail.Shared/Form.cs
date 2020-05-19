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
    public class Form : IDisposable
    {
        private Client _client;

        internal Form()
        {
            _client = Client.Instance;
            FlexMail.Resources.Form.Culture = Client.CultureInfo;
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

        #region Forms

        private GetFormsResp _forms = null;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FormType> Forms()
        {
            try
            {
                if (_forms == null)
                {
                    _forms = _client.API.GetForms(new GetFormsReq() { header = Client.RequestHeader });
                }

                if (_forms.errorCode == (int)errorCode.No_error)
                    return _forms.formTypeItems.ToList<FormType>();

                throw new FlexMailException(_forms.errorMessage, _forms.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Form.Forms" } });
                if (ex is FlexMailException)
                    throw (ex);
            }

            finally
            {
                _forms = null;
            }
            return new List<FormType>(); ;
        }

        #endregion

        #region Results

        private GetFormResultsResp _results = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="campaignId"></param>
        /// <param name="timestampSince"></param>
        /// <returns></returns>
        public List<FormResultType> Results(string formId = null, string campaignId = null, string timestampSince = null)
        {
            try
            {
                if (_results == null)
                {
                    var req = new GetFormResultsReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(formId))
                        req.formId = formId;

                    if (!string.IsNullOrWhiteSpace(campaignId))
                        req.campaignId = campaignId;

                    if (!string.IsNullOrWhiteSpace(timestampSince))
                        req.timestampSince = timestampSince;

                    _results = _client.API.GetFormResults(req);
                }

                if (_results.errorCode == (int)errorCode.No_error)
                    return _results.formResultTypeItems.ToList<FormResultType>();

                throw new FlexMailException(_results.errorMessage, _results.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Form.Results" } });
                if (ex is FlexMailException)
                    throw (ex);
            }

            finally
            {
                _results = null;
            }
            return new List<FormResultType>();
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

                _forms = null;
                _results = null;

                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~Form() { Dispose(false); }

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
