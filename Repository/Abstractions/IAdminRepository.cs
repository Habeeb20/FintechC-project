using Entity;

namespace Repository.Abstractions
{
    public interface IAdminRepository
    {
        bool Add(Admin admin);

        bool Delete(Admin admin);
         
    }
}