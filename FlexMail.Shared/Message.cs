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
    public class Message : IDisposable
    {
        private Client _client;

        internal Message()
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

        #region Messages

        private GetMessagesResp _messages = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archived"></param>
        /// <param name="metaDataOnly"></param>
        /// <param name="optin"></param>
        /// <returns></returns>
        public List<MessageType> Messages(bool archived = false, bool metaDataOnly = true, bool optin = false)
        {
            try
            {
                if (_messages == null)
                {
                    _messages = _client.API.GetMessages(new GetMessagesReq() { header = Client.RequestHeader, archived = archived, metaDataOnly = metaDataOnly, optin = optin });
                }

                if (_messages.errorCode == (int)errorCode.No_error)
                    return _messages.messageTypeItems.ToList<MessageType>();

                throw new FlexMailException(_messages.errorMessage, _messages.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Message.Messages" } });
                if (ex is FlexMailException)
                    throw (ex);
            }

            finally
            {
                _messages = null;
            }
            return new List<MessageType>();
        }

        #endregion

        #region Create

        private CreateMessageResp _create = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public int Create(MessageType messageType = null)
        {
            try
            {
                if (_create == null)
                {
                    var req = new CreateMessageReq() { header = Client.RequestHeader };

                    if (messageType != null)
                        req.messageType = messageType;

                    _create = _client.API.CreateMessage(req);
                }

                if (_create.errorCode == (int)errorCode.No_error)
                    return _create.messageId;

                throw new FlexMailException(_create.errorMessage, _create.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Message.Create" } });
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

        private DeleteMessageResp _delete = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageType"></param>
        public void Delete(MessageType messageType = null)
        {
            try
            {
                if (_delete == null)
                {
                    var req = new DeleteMessageReq() { header = Client.RequestHeader };

                    if (messageType != null)
                        req.messageType = messageType;

                    _delete = _client.API.DeleteMessage(req);
                }

                if (_delete.errorCode == (int)errorCode.No_error)
                    return;

                throw new FlexMailException(_delete.errorMessage, _delete.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Message.Delete" } });
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

        private UpdateMessageResp _update = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageType"></param>
        public void Update(MessageType messageType = null)
        {
            try
            {
                if (_update == null)
                {
                    var req = new UpdateMessageReq() { header = Client.RequestHeader };

                    if (messageType != null)
                        req.messageType = messageType;

                    _update = _client.API.UpdateMessage(req);
                }

                if (_update.errorCode == (int)errorCode.No_error)
                    return;

                throw new FlexMailException(_update.errorMessage, _update.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Message.Update" } });
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

                _messages = null;
                _create = null;
                _delete = null;
                _update = null;

                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~Message() { Dispose(false); }

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
