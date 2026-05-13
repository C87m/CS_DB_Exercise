using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CS_DB_Exercise.Infrastructures.Queries;
/// <summary>
/// departmentテーブルにアクセスするクラス
/// </summary>
/// <author>Fullness,Inc.</author>
/// <date>2025-11-16</date>
/// <version>1.0.0</version>
public class DepartmentAccessor
{
    //  アプリケーション用DbContext
    private readonly AppDbContext _context;
    
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">アプリケーション用DbContext</param>
    public DepartmentAccessor(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    public List<DepartmentEntity> FindAll()
    {
        // ToList()メソッドを使用して、すべての部署を取得する
        var departments = _context.Departments.ToList();
        return departments;
    }

    /// <summary>
    /// 指定した部署Idの部署を取得する
    /// </summary>
    /// <param name="departmentId">部署Id(主キー)</param>
    public DepartmentEntity? FindById(int departmentId)
    {
        // Find()メソッドを使用して、指定した部署Idの部署を取得する
        var department = _context.Departments.Find(departmentId);
        return department;
    }

    public DepartmentEntity? FindByJoinEmployee(int id)
    {
        var result = _context.Departments.Find(id);
        if(result == null)
        {
            return null;
        }
        var employee = _context.Departments
            .Include(i => i.Employees)
            .Where(i => i.Id == id)
            .SingleOrDefault();
        return employee;
    }

    public DepartmentEntity Create(DepartmentEntity department)
    {
        var result = _context.Departments.Add(department);
        _context.SaveChanges();
        return result.Entity;
    }
}