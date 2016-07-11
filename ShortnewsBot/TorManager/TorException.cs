using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TorManager {
    class TorException : ApplicationException {
        public enum ExceptionType {
            PortInUse,
            NoServerAvaliable
        }

        public TorException() { }
        public TorException(string message) : base(message) { }
        public TorException(ExceptionType type, string message) : base(message) { }
    }
}
