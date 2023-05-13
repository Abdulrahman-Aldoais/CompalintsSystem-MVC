namespace CompalintsSystem.Core.ViewModels.Data
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public static OperationResult NotFond(string msg = " لم يتم العثور على نتائج")
        {
            return new OperationResult
            {
                Success = false,
                Message = msg

            };
        }

        public static OperationResult Successeded(string msg = "تمت العميلة بنجاح ")
        {
            return new OperationResult
            {
                Success = true,
                Message = msg

            };
        }
        public static OperationResult Existing(string msg = "القيمة المدخلة موجودة بالفعل")
        {
            return new OperationResult
            {
                Success = false,
                Message = msg,
            };
        }

    }
}
