using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OOP_Project.Repository.Interface;
using OOP_Project.Entities;
namespace OOP_Project.Repository.Implementation 
{
    public class AdminRepository: IAdminRepository
    {
        private readonly List<Admin> Admin_DB = new List<Admin>();

        public bool Add(Admin admin)
        {
            if(admin is not null){
                Admin_DB.Add(admin);
                return true;
            }
            return false;
            
        }

    
        public bool Delete(Admin admin)
        {
            if(admin is not null)
            {
                Admin_DB.Remove(admin);
                return true;
            }
            return false;
        }

     
    }
}
