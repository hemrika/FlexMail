using System;
using System.Collections.Generic;
using System.Text;

namespace FlexMail.Service
{
    public interface IFlexMail
    {
        FlexmailAPIPortTypeClient API { get; }
    }
}
