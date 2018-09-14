using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AddressAPI3.AzureData
{
    public class TableAccessProvider<T> : ITableAccessProvider<T> where T : TableEntity, new()
    {
        private CloudTable _table { get; set; }

        public TableAccessProvider(string cnnString)
        {
            var storageAccount = CloudStorageAccount.Parse(cnnString);

            var tableClient = storageAccount.CreateCloudTableClient();

            _table = tableClient.GetTableReference(typeof(T).Name);

            CreatePeopleTableAsync();
        }

        async void CreatePeopleTableAsync()
        {
            await _table.CreateIfNotExistsAsync();
        }

        public async Task<T> GetByPartitionKeyAndRowKey(string partitionKey, string rowKey)
        {
            TableOperation tableOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);

            TableResult tableResult = await _table.ExecuteAsync(tableOperation);

            return (T)tableResult.Result;
        }

        public async Task<IEnumerable<T>> GetAllStartsWith(string searchTerm)
        {
            var list = new List<T>();

            var lastChar = searchTerm[searchTerm.Length - 1];
            var nextLastChar = (char)((int)lastChar + 1);
            var nextSearchStr = searchTerm.Substring(0, searchTerm.Length - 1) + nextLastChar;

            var prefixCondition = TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.GreaterThanOrEqual, searchTerm),
                TableOperators.And,
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.LessThan, nextSearchStr)
            );

            var filterString = TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, searchTerm),
                TableOperators.Or,
                prefixCondition
            );

            var query = new TableQuery<T>().Where(filterString);

            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<T> resultSegment = await _table.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;
                list.AddRange(resultSegment.Results);
            } while (token != null);

            return list;
        }

        public async Task<IEnumerable<T>> GetAll(string partitionKey)
        {
            List<T> list = new List<T>();

            TableQuery<T> query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));

            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<T> resultSegment = await _table.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;
                list.AddRange(resultSegment.Results);
            } while (token != null);

            return list;
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
