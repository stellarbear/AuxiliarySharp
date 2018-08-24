using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuxiliarySharp
{
    public class AuxiliarySharp
    {
        public static Version Version => Assembly.GetExecutingAssembly().GetName().Version;
    }
}
