using System.Collections.Generic;
namespace API.Models.Interface
{
    public interface IGetAllEmployers
    {
         List<Employers> GetAllEmployers();
    }
}