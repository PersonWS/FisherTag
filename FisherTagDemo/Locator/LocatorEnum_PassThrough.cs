using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    internal class LocatorEnum_PassThrough
    {
        public static string GenerateGetModeCommand()
        {
            return $"PASSTHROUGH&param={Locator_ModeEntity.GenerateGetModeCommand()}";
        }
        public static string GenerateSetModeCommand(Locator_ModeEntity entity)
        {
            return $"PASSTHROUGH&param={Locator_ModeEntity.GenerateSetModeCommand(entity)}";
        }
    }


}
