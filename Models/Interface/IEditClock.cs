using System;
namespace API.Models.Interface
{
    public interface IEditClock
    {
         void UpdateClock(int id, DateTime timein, DateTime timeout);
    }
}