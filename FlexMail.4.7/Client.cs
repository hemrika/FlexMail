using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Channels;
using System.ServiceModel;
using FlexMail.Service;
using System.Security;
using System.Globalization;
//using Microsoft.ApplicationInsights;

namespace FlexMail
{
    /// <summary>
    /// 
    /// </summary>
    public class Client : IDisposable, IFlexMail
    {
        /*
        #region Insights Telemetry

        /// <summary>
        /// 
        /// </summary>
        protected  static TelemetryClient _telemetry = null;

        /// <summary>
        /// 
        /// </summary>
        internal static  TelemetryClient telemetry
        {
            get
            {
                if (_telemetry == null)
                    _telemetry = new TelemetryClient();

                return _telemetry;
            }
            set
            {
                if (_telemetry == null)
                    _telemetry = new TelemetryClient();

                _telemetry = value;
            }
        }


        #endregion
        */
        #region Singleton

        private static readonly Lazy<Client> client = new Lazy<Client>(() => new Client());
        public static Client Instance { get { return client.Value; } }

        //private static volatile Client client;
        //private static object syncClient = new Object();

        private Client() { }

        /*
        public static Client Instance
        {
            get
            {
                if (client == null)
                {
                    lock (syncClient)
                    {
                        if (client == null)
                            client = new Client();
                    }
                }

                return client;
            }
        }
        */

        #endregion

        #region Globalization

        private static CultureInfo _cultureInfo;

        /// <summary>
        /// 
        /// </summary>
        public static CultureInfo CultureInfo { get => _cultureInfo; set => _cultureInfo = value; }

        #endregion

        #region Security

        /// <summary>
        /// 
        /// </summary>
        private static string _clientId;

        /// <summary>
        /// 
        /// </summary>
        public static string ClientId { get => _clientId; set => _clientId = value; }

        /// <summary>
        /// 
        /// </summary>
        private static int _userId;

        /// <summary>
        /// 
        /// </summary>
        public static int UserId { get => _userId; set => _userId = value; }

        /// <summary>
        /// 
        /// </summary>
        private static string _userToken;

        /// <summary>
        /// 
        /// </summary>
        public static string UserToken { get => _userToken; set => _userToken = value; }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userToken"></param>
        /// <param name="messageSize"></param>
        /// <param name="cultureInfo"></param>
        public Client(int userId = 0000, string userToken = "00000000-00000000-00000000-00000000-00000000000000000", long messageSize = 65536 *100, CultureInfo cultureInfo = null)
        {
            _userId = userId;
            _userToken = userToken;
            _messageSize = messageSize;

            if (cultureInfo == null)
                CultureInfo = CultureInfo.CurrentCulture;
            else
                CultureInfo = cultureInfo;
        }
        */

        #endregion

        #region Binding

        /// <summary>
        /// 
        /// </summary>
        private static long _messageSize = 65536 * 100;

        /// <summary>
        /// Gets or sets the maximum size, in bytes, for a message that can be received on a channel configured with this binding.
        /// </summary>
        public static long MessageSize { get => _messageSize; set => _messageSize = value; }

        private static BasicHttpsSecurity security = new BasicHttpsSecurity { Mode = BasicHttpsSecurityMode.Transport, Transport = new HttpTransportSecurity { ClientCredentialType = HttpClientCredentialType.None, Realm = "soap.flexmail.eu" } };

        private static Binding _binding = null;

        /// <summary>
        /// 
        /// </summary>
        internal static Binding Binding
        {
            get
            {
                if (_binding == null)
                    _binding = new BasicHttpsBinding() { Security = security, AllowCookies = true, HostNameComparisonMode = HostNameComparisonMode.WeakWildcard, MaxReceivedMessageSize = _messageSize};

                return _binding;
            }
            set
            {
                _binding = value;
            }
        }
        #endregion

        #region Address

        private static Uri serverUri = new Uri("https://soap.flexmail.eu/3.0.0/flexmail.php");

        private static EndpointAddress _address = null;

        /// <summary>
        /// 
        /// </summary>
        internal static EndpointAddress Address
        {
            get
            {
                if (_address == null)
                    _address = new EndpointAddress(serverUri);

                return _address;
            }
            set
            {
                _address = value;
            }
        }

        #endregion

        #region Client

        public FlexmailAPIPortTypeClient API => api;

        private static FlexmailAPIPortTypeClient _api = null;

        /// <summary>
        /// 
        /// </summary>
        private static FlexmailAPIPortTypeClient api
        {
            get
            {
                if (_api == null)
                    _api = new FlexmailAPIPortTypeClient(Binding, Address);

                return _api;
            }
            set
            {
                _api = value;
            }
        }

        #endregion

        #region Header

        private static APIRequestHeader _requestHeader = null;

        /// <summary>
        /// 
        /// </summary>
        internal static APIRequestHeader RequestHeader
        {
            get
            {
                if (_requestHeader == null)
                    _requestHeader = new APIRequestHeader() { userId = _userId, userToken = _userToken };

                return _requestHeader;
            }
            set
            {
                _requestHeader = value;
            }
        }

        private static APIResponseHeader _responseHeader = null;

        /// <summary>
        /// 
        /// </summary>
        internal static APIResponseHeader ResponseHeader
        {
            get
            {
                if (_responseHeader == null)
                    _responseHeader = new APIResponseHeader() { errorCode = (int)errorCode.No_error, errorMessage = string.Empty, timestamp = DateTime.Now.ToString() };

                return _responseHeader;
            }
            set
            {
                _responseHeader = value;
            }
        }

        #endregion

        #region Objects

        private static Account _account = null;

        /// <summary>
        /// 
        /// </summary>
        public static Account Account
        {
            get
            {
                if (_account == null)
                    _account = new Account();
                return _account;
            }
        }

        private static Agency _agency = null;

        /// <summary>
        /// 
        /// </summary>
        public static Agency Agency
        {
            get
            {
                if (_agency == null)
                    _agency = new Agency();
                return _agency;
            }
        }

        private static Blacklist _blacklist = null;

        /// <summary>
        /// 
        /// </summary>
        public static Blacklist Blacklist
        {
            get
            {
                if (_blacklist == null)
                    _blacklist = new Blacklist();
                return _blacklist;
            }
        }

        private static Campaign _campaign = null;

        /// <summary>
        /// 
        /// </summary>
        public static Campaign Campaign
        {
            get
            {
                if (_campaign == null)
                    _campaign = new Campaign();
                return _campaign;
            }
        }

        private static Category _category = null;

        /// <summary>
        /// 
        /// </summary>
        public static Category Category
        {
            get
            {
                if (_category == null)
                    _category = new Category();
                return _category;
            }
        }

        private static EmailAddress _emailAddress = null;

        /// <summary>
        /// 
        /// </summary>
        public static EmailAddress EmailAddress
        {
            get
            {
                if (_emailAddress == null)
                    _emailAddress = new EmailAddress();
                return _emailAddress;
            }
        }

        private static Form _form = null;

        /// <summary>
        /// 
        /// </summary>
        public static Form Form
        {
            get
            {
                if (_form == null)
                    _form = new Form();
                return _form;
            }
        }

        private static Group _group = null;

        /// <summary>
        /// 
        /// </summary>
        public static Group Group
        {
            get
            {
                if (_group == null)
                    _group = new Group();
                return _group;
            }
        }

        private static MailingList _mailingList = null;

        /// <summary>
        /// 
        /// </summary>
        public static MailingList MailingList
        {
            get
            {
                if (_mailingList == null)
                    _mailingList = new MailingList();
                return _mailingList;
            }
        }

        private static Message _message = null;

        /// <summary>
        /// 
        /// </summary>
        public static Message Message
        {
            get
            {
                if (_message == null)
                    _message = new Message();
                return _message;
            }
        }

        //internal TelemetryClient Telemetry { get => telemetry; set => telemetry = value; }

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

                _account = null;
                _address = null;
                _agency = null;
                _api = null;
                _binding = null;
                _blacklist = null;
                _campaign = null;
                _category = null;
                _clientId = null;
                _emailAddress = null;
                _form = null;
                _group = null;
                _mailingList = null;
                _message = null;
                _requestHeader = null;
                _responseHeader = null;
                //_userId = null;
                //_userToken = null;
                //_messageSize = null;
                //_cultureInfo = null

                disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~Client() { Dispose(false); }

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