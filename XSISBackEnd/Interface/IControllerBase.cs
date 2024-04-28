using Microsoft.AspNetCore.Mvc;
using XSISDataAccess.ViewModel;

namespace XSISBackEnd.Interface
{
    public interface IControllerBase<ViewModel> where ViewModel : class
    {
        public Task<ActionResult<ResultResponse<List<ViewModel>>>> RetrieveList();
        public Task<ActionResult<ResultResponse<ViewModel>>> Retrieve([FromBody] int id);
        public Task<ActionResult<ResultResponse<ViewModel>>> Create([FromBody] ViewModel parameter);
        public Task<ActionResult<ResultResponse<ViewModel>>> Update([FromBody] ViewModel parameter);
        public Task<ActionResult<ResultResponse<ViewModel>>> Delete([FromBody] int id);
    }
}
