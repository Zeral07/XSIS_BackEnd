

using XSISDataAccess.ViewModel;

namespace XSISFacade.Interface
{
    public interface IFacadeBase<ViewModel> where ViewModel : class
    {
        public Task<ResultResponse<List<ViewModel>>> RetrieveList();
        public Task<ResultResponse<ViewModel>> Retrieve(int id);
        public Task<ResultResponse<ViewModel>> Create(ViewModel modelDto);
        public Task<ResultResponse<ViewModel>> Update(ViewModel modelDto);
        public Task<ResultResponse<ViewModel>> Delete(int id);
    }
}
