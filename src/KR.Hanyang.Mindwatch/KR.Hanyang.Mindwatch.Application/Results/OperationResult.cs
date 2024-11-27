namespace KR.Hanyang.Mindwatch.Application.Results
{
    public class OperationResult<T>
    {
        public T? ResultValue { get; }
        public OperationResultType Type { get; }
        public IEnumerable<string> ValidationErrors { get; }

        public OperationResult(T? resultValue, OperationResultType type, IEnumerable<string> validationErrors)
        {
            ResultValue = resultValue;
            Type = type;
            ValidationErrors = validationErrors;
        }

        public static OperationResult<T> Success(T result) => new OperationResult<T>(result, OperationResultType.Success, []);
        public static OperationResult<T> NotFound() => new OperationResult<T>(default, OperationResultType.NotFound, []);
        public static OperationResult<T> Invalid(IEnumerable<string> validationErrors) => new OperationResult<T>(default, OperationResultType.Invalid, validationErrors);
    }
}
