using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    public enum LocatorEnum_SendCommand : int
    {
        GETVERSION,
        [Description("设防cmd")]
        SAFEON,
        [Description("撤防cmd")]
        SAFEOFF,
        [Description("透传cmd")]
        PASSTHROUGHA
    }
}
