namespace API.Models.Interface
{
    public interface IInsertClock
    {
         void InsertClockIn(Clocks value);
         void InsertClockOut(Clocks value);
    }
}