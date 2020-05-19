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
    public class EmailAddress : IDisposable
    {
        private Client _client;

        internal EmailAddress()
        {
            _client = Client.Instance;
            FlexMail.Resources.EmailAddress.Culture = Client.CultureInfo;
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

        #region EmailAddresses

        private GetEmailAddressesResp _emailaddresses = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddressTypeItems"></param>
        /// <param name="groupIds"></param>
        /// <param name="limit"></param>
        /// <param name="mailingListIds"></param>
        /// <param name="order"></param>
        /// <param name="states"></param>
        /// <returns></returns>
        public List<EmailAddressType> EmailAddresses(EmailAddressType[] emailAddressTypeItems = null, int[] groupIds = null, Pagination limit= null,  int[] mailingListIds = null, Ordening order = null, EmailAddresState[] states = null)
        {
            try
            {
                if (_emailaddresses == null)
                {
                    var req = new GetEmailAddressesReq() { header = Client.RequestHeader };

                    if (emailAddressTypeItems != null)
                        req.emailAddressTypeItems = emailAddressTypeItems; 

                    if (groupIds != null)
                        req.groupIds = groupIds;

                    if (limit != null)
                        req.limit = limit;

                    if (mailingListIds != null)
                        req.mailingListIds = mailingListIds;

                    if (order != null)
                        req.order = order;

                    if (states != null)
                        req.states = states;

                    _emailaddresses = _client.API.GetEmailAddresses(req);
                }

                if (_emailaddresses.errorCode == (int)errorCode.No_error)
                    return _emailaddresses.emailAddressTypeItems.ToList<EmailAddressType>();

                throw new FlexMailException(_emailaddresses.errorMessage, _emailaddresses.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "EmailAddress.EmailAddresses" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _emailaddresses = null;
            }
            return new List<EmailAddressType>();
        }

        #endregion

        #region Create

        private CreateEmailAddressResp _create = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddressType"></param>
        /// <param name="mailingListId"></param>
        /// <param name="optInType"></param>
        /// <returns></returns>
        public int Create(EmailAddressType emailAddressType = null, string mailingListId = null, OptInType optInType = null)
        {
            try
            {
                if (_create == null)
                {
                    var req = new CreateEmailAddressReq() { header = Client.RequestHeader };

                    if (emailAddressType != null)
                        req.emailAddressType = emailAddressType;

                    if (!string.IsNullOrWhiteSpace(mailingListId))
                        req.mailingListId = int.Parse(mailingListId); req.mailingListIdSpecified = true;

                    if (optInType != null)
                        req.optInType = optInType;

                    _create = _client.API.CreateEmailAddress(req);
                }

                if(_create.errorCode == (int)errorCode.No_error)
                    return _create.emailAddressId;

                throw new FlexMailException(_create.errorMessage, _create.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "EmailAddress.Create" } });
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

        private DeleteEmailAddressResp _delete = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddressType"></param>
        /// <param name="mailingListId"></param>
        public void Delete(EmailAddressType emailAddressType = null, string mailingListId = null)
        {
            try
            {
                if (_delete == null)
                {
                    var req = new DeleteEmailAddressReq() { header = Client.RequestHeader };

                    if (emailAddressType != null)
                        req.emailAddressType = emailAddressType;

                    if (!string.IsNullOrWhiteSpace(mailingListId))
                        req.mailingListId = int.Parse(mailingListId);

                    _delete = _client.API.DeleteEmailAddress(req);
                }

                if(_delete.errorCode == (int)errorCode.No_error)
                    return;

                throw new FlexMailException(_delete.errorMessage, _delete.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "EmailAddress.Delete" } });
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

        #region Update

        private UpdateEmailAddressResp _update = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddressType"></param>
        /// <param name="mailingListId"></param>
        /// <returns></returns>
        public int Update(EmailAddressType emailAddressType = null, string mailingListId = null)
        {
            try
            {
                if (_update == null)
                {
                    var req = new UpdateEmailAddressReq() { header = Client.RequestHeader };

                    if (emailAddressType != null)
                        req.emailAddressType = emailAddressType;

                    if (!string.IsNullOrWhiteSpace(mailingListId))
                        req.mailingListId = int.Parse(mailingListId);

                    _update = _client.API.UpdateEmailAddress(req);
                }

                if (_update.errorCode == (int)errorCode.No_error)
                    return _update.emailAddressId;

                throw new FlexMailException(_update.errorMessage, _update.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "EmailAddress.Update" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _update = null;
            }
            return -1;
        }

        #endregion

        #region History

        private GetEmailAddressHistoryResp _history = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="emailAddressHistoryOptionsType"></param>
        /// <param name="sort"></param>
        /// <param name="timestampFrom"></param>
        /// <param name="timestampTill"></param>
        /// <returns></returns>
        public EmailAddressHistoryType History(string emailAddress = null, EmailAddressHistoryOptionsType emailAddressHistoryOptionsType = null, string sort = null, string timestampFrom = null, string timestampTill = null)
        {
            try
            {

                if (_history == null)
                {
                    var req = new GetEmailAddressHistoryReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(emailAddress))
                        req.emailAddress = emailAddress;

                    if (emailAddressHistoryOptionsType != null)
                        req.emailAddressHistoryOptionsType = emailAddressHistoryOptionsType;

                    if (!string.IsNullOrWhiteSpace(sort))
                        req.sort = sort;

                    if (!string.IsNullOrWhiteSpace(timestampFrom))
                        req.timestampFrom = timestampFrom;

                    if (!string.IsNullOrWhiteSpace(timestampTill))
                        req.timestampTill = timestampTill;

                    _history = _client.API.GetEmailAddressHistory(req);
                }

                if (_history.errorCode == (int)errorCode.No_error)
                    return _history.emailAddressHistoryType;

                throw new FlexMailException(_history.errorMessage, _history.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "EmailAddress.History" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _history = null;
            }
            return new EmailAddressHistoryType();
        }

        #endregion

        #region Import

        private ImportEmailAddressesResp _import = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailingListId"></param>
        /// <param name="emailAddressTypeItems"></param>
        /// <param name="allowDuplicates"></param>
        /// <param name="overwrite"></param>
        /// <param name="synchronise"></param>
        /// <param name="referenceField"></param>
        /// <param name="allowBouncedOut"></param>
        /// <returns></returns>
        internal List<ImportEmailAddressRespType> Import(string mailingListId = null, EmailAddressType[] emailAddressTypeItems = null, bool allowDuplicates = false, bool overwrite = false, bool synchronise = false, ReferenceFieldType referenceField = ReferenceFieldType.email, bool allowBouncedOut = true)
        {
            try
            {
                if (_import == null)
                {
                    var req = new ImportEmailAddressesReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(mailingListId))
                        req.mailingListId = int.Parse(mailingListId); req.mailingListIdSpecified = true;

                    if (emailAddressTypeItems != null)
                        req.emailAddressTypeItems = emailAddressTypeItems;

                    req.allowBouncedOut = allowBouncedOut;
                    req.allowBouncedOutSpecified = true;
                    req.allowDuplicates = allowDuplicates;
                    req.allowDuplicatesSpecified = true;
                    req.overwrite = overwrite;
                    req.overwriteSpecified = true;
                    req.synchronise = synchronise;
                    req.synchroniseSpecified = true;
                    req.referenceField = referenceField;
                    req.referenceFieldSpecified = true;

                    _import = _client.API.ImportEmailAddresses(req);
                }

                if (_import.errorCode == (int)errorCode.No_error)
                    return _import.importEmailAddressRespTypeItems.ToList<ImportEmailAddressRespType>();

                throw new FlexMailException(_import.errorMessage, _import.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "EmailAddress.Import" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _import = null;
            }
            return new List<ImportEmailAddressRespType>();
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

                _create = null;
                _delete = null;
                _emailaddresses = null;
                _update = null;
                _history = null;
                _import = null;

                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~EmailAddress() { Dispose(false); }

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
