namespace API.Models.Interface
{
    public interface IEditAccount
    {
         void UpdateAccount(int id, string empfname, string lastname, string dept);
    }
}