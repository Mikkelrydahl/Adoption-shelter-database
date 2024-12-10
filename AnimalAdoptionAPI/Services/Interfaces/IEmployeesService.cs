using AnimalAdoptionAPI.Models;


namespace AnimalAdoptionAPI.Interfaces
{
    public interface IEmployeeService
{
    List<Employees> GetAllEmployees(); // Asynchronous method returning a task of List<Employees>
    Employees GetEmployeeById(int id);
    Employees AddEmployee(Employees employee);
    Employees UpdateEmployee(Employees employee);
    void DeleteEmployee(int id);
}
}