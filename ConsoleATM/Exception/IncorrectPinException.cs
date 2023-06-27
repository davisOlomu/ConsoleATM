using System;

namespace ConsoleATM
{
    // Custom exception for an incorrect PIN
    [Serializable]
    public class IncorrectPinException : Exception
    {
        public IncorrectPinException() { }
        public IncorrectPinException(string message) : base(message) { }
        public IncorrectPinException(string message, Exception inner) : base(message, inner) { }
        protected IncorrectPinException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
