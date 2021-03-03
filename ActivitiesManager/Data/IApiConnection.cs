using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ActivitiesManager.Data
{
    public interface IApiConnection
    {
        Task<object> Post(object obj);
        Task<object> Get(int? id);
        Task<object> Get();
        Task Put(int id, HttpContent obj);
        int Patch(object obj);
        Task DeleteAsync(int id);
    }
}