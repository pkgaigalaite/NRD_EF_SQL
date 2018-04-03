using NrdAkademija.Ef.entities;
using System.Collections.Generic;

namespace NrdAkademija.Ef.repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
    }
}