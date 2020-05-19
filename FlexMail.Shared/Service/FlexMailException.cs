using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FlexMail.Service
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class FlexMailException : Exception
    {
        private int _code;

        /// <summary>
        /// 
        /// </summary>
        public virtual int Code
        {
            get
            {
                return this._code;
            }
            internal set
            {
                this._code = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public FlexMailException() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public FlexMailException(string message) : base(message) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        public FlexMailException(string message, int code) : base(message)
        {
            Code = code;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public FlexMailException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected FlexMailException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) {
            if (info != null)
            {
                this.Code = info.GetInt32("_code");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue("_code", this.Code);
            }
        }
    }
}