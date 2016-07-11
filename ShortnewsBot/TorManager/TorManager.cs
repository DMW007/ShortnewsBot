using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TorManager {
    class TorManager {
        List<TorInstance> instances = new List<TorInstance>();
        int _instanceBuffer = 0;
        int _port = 10000;
    }
}
