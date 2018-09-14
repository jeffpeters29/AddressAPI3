using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressAPI3.AzureData
{
    public interface ITableAccessProvider<T>
    {
        Task<T> GetByPartitionKeyAndRowKey(string partitionKey, string rowKey);
        Task<IEnumerable<T>> GetAllStartsWith(string searchTerm);
        Task<IEnumerable<T>> GetAll(string partitionKey);
        IQueryable<T> GetAll();
    }
}
