using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApplication.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Index();
        Employee Create();
        Employee Create(Employee obj);
        Employee Delete(int? id);
        Employee DeletePost(int? id);
        Employee Update(int? id);
        Employee Update(Employee obj);
    }
}
