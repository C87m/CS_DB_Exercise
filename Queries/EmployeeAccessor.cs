using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Contexts;

namespace CS_DB_Exercise.Infrastructures.Queries;

public class EmployeeAccessor
{
    private readonly AppDbContext _context;

    public EmployeeAccessor(AppDbContext context)
    {
        _context = context;
    }

    public List<EmployeeEntity> FindByDeptId(int deptId)
    {
        var employee = _context.Employees.Where(i => i.DeptId == deptId).ToList();
        return employee;
    }


    public List<EmployeeEntity> FindByContainsName(string keyword)
    {
        var employee = _context.Employees
            .Where(i => i.Name!.Contains(keyword))
            .ToList();
        return employee;
    }

    public EmployeeEntity? Create(EmployeeEntity Entity)
    {
        var result = _context.Employees.Add(Entity);
        _context.SaveChanges();
        return result.Entity;
    }

    public EmployeeEntity? UpdateById(EmployeeEntity employee)
    {
        var result = _context.Employees.Find(employee.Id);
        if(result == null)
        {
            return null;
        }
        result!.Name = employee.Name;
        _context.SaveChanges();
        return result;
    }

    public EmployeeEntity? DeleteById(int id)
    {
        var result = _context.Employees.Find(id);
        if(result == null)
        {
            return null;
        }
        var delResult = _context.Employees.Remove(result);
        _context.SaveChanges();
        return delResult.Entity;
    }
}
