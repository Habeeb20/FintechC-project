using OOP_Project.Entity;
namespace FintechC_project.Repository.Abstractions
{
    public interface IAdminRepository
    {
        bool Add(Admin admin);

        bool Delete(Admin admin);
         
    }
}