using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper_Exercise
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        void InsertDepartment(string newDepartmentName);
    }
}
