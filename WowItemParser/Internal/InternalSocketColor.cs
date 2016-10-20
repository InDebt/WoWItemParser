using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowItemParser.Internal
{
    [Flags]
    internal enum InternalSocketColor
    {
        SocketColorMeta = 1,
        SocketColorRed = 2,
        SocketColorYellow = 4,
        SocketColorBlue = 8
    };
}
