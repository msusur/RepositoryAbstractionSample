using System;
using Contracts.Models;

namespace Contracts
{
    public interface IDataRepository
    {
        DataModel GetDataById(Guid i);
        DataModel InsertData(DataModel dataModel);
    }
}