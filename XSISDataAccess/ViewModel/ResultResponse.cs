namespace XSISDataAccess.ViewModel
{
    public class ResultResponse<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public T? Result { get; set; } = null;
        public int Total { get; set; } = 0;
        public List<ErrorMessage> Errors { get; set; } = [];
    }
}
