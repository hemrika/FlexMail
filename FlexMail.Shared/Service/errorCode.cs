using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexMail.Service
{
    enum errorCode : int
    {
        No_error = 0,
        User_ID_is_mandatory = 201,
        User_ID_is_invalid = 202,
        User_Token_is_mandatory = 203,
        IP_Address_is_not_connectable = 204,
        Invalid_token = 205,

        /*
        #region  Account

        /// <summary>
        /// Authentication error, see header object for detailed information
        /// </summary>
        Authentication = 220,
        /// <summary>
        /// Mailing list id or campaign id is mandatory
        /// </summary>
        Mailinglistid_or_campaignid_is_mandatory = 221,
        /// <summary>
        /// Mailing list id is invalid
        /// </summary>
        Mailinglistid_is_invalid = 222,
        /// <summary>
        /// Campaign id is invalid
        /// </summary>
        Campaignid_is_invalid = 223,
        /// <summary>
        /// Invalid timestamp YYYY-MM-DDTHH:II:SS
        /// </summary>
        Invalid_timestamp = 224

        #endregion
        */
        
    }
}
