using AnimalAdoptionAPI.Models;


namespace AnimalAdoptionAPI.Interfaces
{
    public interface IEmployeeService
    {
        List<Employees> GetAllEmployees(); // Asynchronous method returning a task of List<Employees>
        Employees GetEmployeeById(int id);
        Employees AddEmployee(AddEmployeesDto employeeDto);
        Employees UpdateEmployee(int id, UpdateEmployeesDto updateEmployee);
        bool DeleteEmployee(int id);
    }
}