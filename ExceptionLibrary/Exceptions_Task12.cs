namespace Exception_Library
{
    public class Exceptions_Task12
    {
        public class InsufficientFundException : Exception
        {
            public InsufficientFundException() : base("Insufficient funds in account") { }
            public InsufficientFundException(string message) : base(message) { }
        }

        public class InvalidAccountException : Exception
        {
            public InvalidAccountException() : base("Invalid account number") { }
            public InvalidAccountException(string message) : base(message) { }
        }

        public class OverDraftLimitExcededException : Exception
        {
            public OverDraftLimitExcededException() : base("Overdraft limit exceeded") { }
            public OverDraftLimitExcededException(string message) : base(message) { }
        }

        public class NullReferenceExceptionBank : Exception
        {
            public NullReferenceExceptionBank() : base("Customer object is null") { }
            public NullReferenceExceptionBank(string message) : base(message) { }
        }

    }
}
