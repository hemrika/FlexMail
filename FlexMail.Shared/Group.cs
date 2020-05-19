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
    public class Group : IDisposable
    {
        private Client _client;

        internal Group()
        {
            _client = Client.Instance;
            FlexMail.Resources.Group.Culture = Client.CultureInfo;
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

        #region Groups

        private GetGroupsResp _groups = null;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<GroupType> Groups()
        {
            try
            {
                if (_groups == null)
                {
                    _groups = _client.API.GetGroups(new GetGroupsReq() { header = Client.RequestHeader });
                }

                if (_groups.errorCode == (int)errorCode.No_error)
                    return _groups.groupTypeItems.ToList<GroupType>();

                throw new FlexMailException(_groups.errorMessage, _groups.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Group.Groups" } });
                if (ex is FlexMailException)
                    throw (ex);
            }

            finally
            {
                _groups = null;
            }
            return new List<GroupType>();
        }

        #endregion

        #region Create

        private CreateGroupResp _create = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupType"></param>
        public void Create(GroupType groupType = null)
        {
            try
            {
                if (_create == null)
                {
                    var req = new CreateGroupReq() { header = Client.RequestHeader };

                    if (groupType != null)
                        req.groupType = groupType;

                    _create = _client.API.CreateGroup(req);
                }

                if (_create.errorCode == (int)errorCode.No_error)
                    return;

                throw new FlexMailException(_create.errorMessage, _create.errorCode);
            }
            catch (Exception ex )
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Group.Create" } });
                if (ex is FlexMailException)
                    throw (ex);
            }

            finally
            {
                _create = null;
            }
            return;
        }

        #endregion

        #region CreateGroup

        private CreateGroupSubscriptionResp _createGroup = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupSubscriptionType"></param>
        /// <returns></returns>
        public int Create(GroupSubscriptionType groupSubscriptionType = null)
        {
            try
            {
                if (_createGroup == null)
                {
                    var req = new CreateGroupSubscriptionReq() { header = Client.RequestHeader };

                    if (groupSubscriptionType != null)
                        req.groupSubscriptionType = groupSubscriptionType;

                    _createGroup = _client.API.CreateGroupSubscription(req);
                }

                if (_createGroup.errorCode == (int)errorCode.No_error)
                    return _createGroup.groupSubscriptionId;

                throw new FlexMailException(_createGroup.errorMessage, _create.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Group.Create" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _createGroup = null;
            }
            return -1;
        }

        #endregion

        #region Delete

        private DeleteGroupResp _delete = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupType"></param>
        public void Delete(GroupType groupType = null)
        {
            try
            {

                if (_delete == null)
                {
                    var req = new DeleteGroupReq() { header = Client.RequestHeader };

                    if (groupType != null)
                        req.groupType = groupType;

                    _delete = _client.API.DeleteGroup(req);
                }

                if (_delete.errorCode == (int)errorCode.No_error)
                    return;

                throw new FlexMailException(_delete.errorMessage, _delete.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Group.Delete" } });
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

        #region DeleteGroup

        private DeleteGroupSubscriptionResp _deleteGroup = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupSubscriptionType"></param>
        public void Delete(GroupSubscriptionType groupSubscriptionType = null)
        {
            try
            {
                if (_deleteGroup == null)
                {
                    var req = new DeleteGroupSubscriptionReq() { header = Client.RequestHeader };

                    if (groupSubscriptionType != null)
                        req.groupSubscriptionType = groupSubscriptionType;

                    _deleteGroup = _client.API.DeleteGroupSubscription(req);
                }

                if (_deleteGroup.errorCode == (int)errorCode.No_error)
                    return;

                throw new FlexMailException(_deleteGroup.errorMessage, _deleteGroup.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Group.Delete" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _deleteGroup = null;
            }
            return;
        }

        #endregion

        #region Update

        private UpdateGroupResp _update = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupType"></param>
        public void Update(GroupType groupType = null)
        {
            try
            {
                if (_update == null)
                {
                    var req = new UpdateGroupReq() { header = Client.RequestHeader };

                    if (groupType != null)
                        req.groupType = groupType;

                    _update = _client.API.UpdateGroup(req);
                }

                if (_update.errorCode == (int)errorCode.No_error)
                    return;

                throw new FlexMailException(_update.errorMessage, _update.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Group.Update" } });
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

                _create = null;
                _createGroup = null;
                _delete = null;
                _deleteGroup = null;
                _groups = null;
                _update = null;

                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~Group() { Dispose(false); }

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
