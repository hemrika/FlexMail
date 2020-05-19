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
    public class Category : IDisposable
    {
        private Client _client;

        internal Category()
        {
            _client = Client.Instance;
            FlexMail.Resources.Category.Culture = Client.CultureInfo;
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

        #region Categories

        private GetCategoriesResp _categories = null;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CategoryType> Categories()
        {
            try
            {
                if (_categories == null)
                {
                    _categories = _client.API.GetCategories(new GetCategoriesReq() { header = Client.RequestHeader });
                }

                if (_categories.errorCode == (int)errorCode.No_error)
                    return _categories.categoryTypeItems.ToList<CategoryType>();

                throw new FlexMailException(_categories.errorMessage, _categories.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Category.Categories" } });
                if (ex is FlexMailException)
                    throw (ex);
            }
            finally
            {
                _categories = null;
            }
            return new List<CategoryType>();
        }

        #endregion

        #region Create

        private CreateCategoryResp _create = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public int Create(string categoryName = null)
        {
            try
            {
                if (_create == null)
                {
                    var req = new CreateCategoryReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(categoryName))
                        req.categoryName = categoryName;

                    _create = _client.API.CreateCategory(req);
                }

                if (_create.errorCode == (int)errorCode.No_error)
                    return _create.categoryId;

                throw new FlexMailException(_create.errorMessage, _create.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Category.Create" } });
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

        private DeleteCategoryResp _delete = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        public void Delete(string categoryId = null)
        {
            try
            {

                if (_delete == null)
                {
                    var req = new DeleteCategoryReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(categoryId))
                        req.categoryId = int.Parse(categoryId);

                    _delete = _client.API.DeleteCategory(req);
                }

                if (_delete.errorCode == (int)errorCode.No_error)
                    return;

                throw new FlexMailException(_delete.errorMessage, _delete.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Category.Create" } });
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

        private UpdateCategoryResp _update = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="categoryName"></param>
        public void Update(string categoryId = null, string categoryName = null)
        {
            try
            {
                if (_update == null)
                {
                    var req = new UpdateCategoryReq() { header = Client.RequestHeader };

                    if (!string.IsNullOrWhiteSpace(categoryId))
                        req.categoryId = int.Parse(categoryId);

                    if (!string.IsNullOrWhiteSpace(categoryName))
                        req.categoryName = categoryName;

                    _update = _client.API.UpdateCategory(req);
                }

                if (_update.errorCode == (int)errorCode.No_error)
                    return;

                throw new FlexMailException(_update.errorMessage, _update.errorCode);
            }
            catch (Exception ex)
            {
                //telemetry.TrackException(ex, new Dictionary<string, string> { { "Flexmail", "Category.Update" } });
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

                _categories = null;
                _create = null;
                _delete = null;
                _update = null;

                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~Category() { Dispose(false); }

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
