using System.Collections.Generic;
namespace API.Models.Interface
{
    public interface IGetAllAccounts
    {
         List<Accounts> GetAllAccounts();
    }
}