using CRUDApplication.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApplication.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Employee Create()
        {
            throw new NotImplementedException();
        }

        public Employee Create(Employee obj)
        {
            if (_db != null)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
            }
            return obj;
        }

        public Employee Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return null;
            }
            var obj = _db.Employees.Find(id);
            if (obj == null)
            {
                return null;
            }

            return obj;
        }

        public Employee DeletePost(int? id)
        {
            var obj = _db.Employees.Find(id);
            if (obj == null)
            {
                return null;
            }

            _db.Employees.Remove(obj);
            _db.SaveChanges();
            return obj;
        }

        public IEnumerable<Employee> Index()
        {
            IEnumerable<Employee> objList = _db.Employees;
            return objList;
        }

        public Employee Update(int? id)
        {
            if (id == null || id == 0)
            {
                return null;
            }
            var obj = _db.Employees.Find(id);
            if (obj == null)
            {
                return null;
            }

            return obj;
        }

        public Employee Update(Employee obj)
        {
            if (_db != null)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                return obj;
            }
            return null;
        }
    }
}
