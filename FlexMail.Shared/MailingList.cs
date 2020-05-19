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
    public class MailingList : IDisposable
    {
        private Client _client;

        internal MailingList()
        {
            _client = Client.Instance;
            FlexMail.Resources.MailingList.Culture = Client.CultureInfo;
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

        #region MailingLists

        private GetMailingListsResp _mailingLists = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<MailingListType> MailingLists(string categoryId = null)
        {
            try
            {
                if (_mailingLists == null)
                {
                    var req = new GetMailingListsReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(categoryId))
                        req.categoryId = int.Parse(categoryId);

                    _mailingLists = _client.API.GetMailingLists(req);
                }

                if (_mailingLists.errorCode == (int)errorCode.No_error)
                    return _mailingLists.mailingListTypeItems.ToList<MailingListType>();

                throw new FlexMailException(_mailingLists.errorMessage, _mailingLists.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "MailingList.MailingLists" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _mailingLists = null;
            }
            return new List<MailingListType>();
        }

        #endregion

        #region Create

        private CreateMailingListResp _create = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="mailingListName"></param>
        /// <param name="useblackList"></param>
        /// <param name="mailingListLanguage"></param>
        /// <returns></returns>
        public int Create(string categoryId = null, string mailingListName = null, bool useblackList = true, string mailingListLanguage = "NL")
        {
            try
            {
                if (_create == null)
                {
                    var req = new CreateMailingListReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(categoryId))
                        req.categoryId = int.Parse(categoryId);

                    if (!string.IsNullOrWhiteSpace(mailingListName))
                        req.mailingListName = mailingListName;

                    req.addUnsubscriptionsToBlacklist = useblackList;
                    req.addUnsubscriptionsToBlacklistSpecified = true;

                    req.mailingListLanguage = mailingListLanguage;

                    _create = _client.API.CreateMailingList(req);
                }

                if (_create.errorCode == (int)errorCode.No_error)
                    return _create.mailingListId;

                throw new FlexMailException(_create.errorMessage, _create.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "MailingList.Create" } });
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

        private DeleteMailingListResp _delete = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailingListId"></param>
        public void Delete(string mailingListId = null)
        {
            try
            {

                if (_delete == null)
                {
                    var req = new DeleteMailingListReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(mailingListId))
                        req.mailingListId = int.Parse(mailingListId);

                    _delete = _client.API.DeleteMailingList(req);
                }

                if (_delete.errorCode == (int)errorCode.No_error)
                    return;

                throw new FlexMailException(_delete.errorMessage, _delete.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "MailingList.Delete" } });
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

        private UpdateMailingListResp _update = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailingListId"></param>
        /// <param name="mailingListName"></param>
        /// <param name="mailingListLanguage"></param>
        public void Update(string mailingListId = null, string mailingListName = null, string mailingListLanguage = "NL")
        {
            try
            {
                if (_update == null)
                {
                    var req = new UpdateMailingListReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(mailingListId))
                        req.mailingListId = int.Parse(mailingListId);

                    if (!string.IsNullOrWhiteSpace(mailingListName))
                        req.mailingListName = mailingListName;

                    req.mailingListLanguage = mailingListLanguage;

                    _update = _client.API.UpdateMailingList(req);
                }

                if (_update.errorCode == (int)errorCode.No_error)
                    return;

                throw new FlexMailException(_update.errorMessage, _update.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "MailingList.Update" } });
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

        #region Truncate

        private TruncateMailingListResp _truncate = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailingListId"></param>
        public void Truncate(string mailingListId = null)
        {
            try
            {
                if (_truncate == null)
                {
                    var req = new TruncateMailingListReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(mailingListId))
                        req.mailingListId = int.Parse(mailingListId);

                    _truncate = _client.API.TruncateMailingList(req);
                }

                if (_truncate.errorCode == (int)errorCode.No_error)
                    return;

                throw new FlexMailException(_truncate.errorMessage, _truncate.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "MailingList.Truncate" } });
                if (ex is FlexMailException)
                    throw (ex);
            }

            finally
            {
                _truncate = null;
            }
            return;
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
                _mailingLists = null;
                _truncate = null;
                _update = null;

                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~MailingList() { Dispose(false); }

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
