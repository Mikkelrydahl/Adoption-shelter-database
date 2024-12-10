using AnimalAdoptionAPI.Models;


namespace AnimalAdoptionAPI.Interfaces
{
    public interface IEmployeeService
    {
        List<Employees> GetAllEmployees();
        Employees GetEmployeeById(int id);
        Employees AddEmployee(Employees employee);
        Employees UpdateEmployee(Employees employee);
        void DeleteEmployee(int id);
    }
}