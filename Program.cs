using CS_DB_Exercise.Infrastructures;
using CS_DB_Exercise.Infrastructures.Queries;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;

namespace CS_DB_Exercise;
class Program
{
    static void Main(string[] args)
    {
        var accessor = new DepartementAccessor(new AppDbContext());
        // すべての部署を取得する
        /*
        var departments = accessor.FindAll();
        Console.WriteLine("すべての部署を取得する");
        foreach (var d in departments)
        {
            Console.WriteLine(d);
        }
        */

        // 指定した部署Idの部署を取得する(存在する部署Id)
        /*
        var department = accessor.FindById(1);
        Console.WriteLine($"存在する部署Id:{department!.ToString()}");
        
        // 指定した部署Idの部署を取得する(存在しない部署Id)
        department = accessor.FindById(101);
        if (department == null)
        {
            Console.WriteLine($"部署Id:101の部署は存在しません。");
        }
        */

        /*
        var employeeAccessor = new EmployeeAccessor(new AppDbContext());
        Console.Write("部署IDを入力してください->");
        var deptId = int.Parse(Console.ReadLine()!);
        var employee = employeeAccessor.FindByDeptId(deptId);
        if (employee.Any())
        {
          foreach(var e in employee)
           {
                Console.WriteLine(e);   
           }    
        }
        else
        {
           Console.WriteLine($"{deptId}の部署に所属する社員は存在しません");
        }
        */

        /*
        Console.Write("キーワードを入力してください->");
        var keyword = Console.ReadLine()!;
        var employee = employeeAccessor.FindByContainsName(keyword);

        if(employee.Any())
        {
            foreach(var e in employee)
            {
                Console.WriteLine(e);
            }
        }
        else
        {
            Console.WriteLine($"{keyword}が含まれる社員は存在しません");
        }
        */

        /*
        var employeeAccessor = new EmployeeAccessor(new AppDbContext());
        Console.Write("社員名を入力してください->");
        var name = Console.ReadLine()!;
        Console.Write("部署Idを入力してください->");
        var deptId = int.Parse(Console.ReadLine()!);

        var deptIdIsExist = employeeAccessor.FindByDeptId(deptId).Any();
        if (deptIdIsExist)
        {
            var employee = new EmployeeEntity {Name = name, DeptId = deptId};
            var result = employeeAccessor.Create(employee);
            Console.WriteLine($"{result}の社員を登録しました");
        }
        else
        {
            Console.WriteLine($"{deptId}は存在しないため、社員登録できません");
        }
        */

        /*
        var employeeAccessor = new EmployeeAccessor(new AppDbContext());
        Console.Write("社員Idを入力してください->");
        var id = int.Parse(Console.ReadLine()!);
        Console.Write("社員名を入力してください->");
        var name = Console.ReadLine()!;

        var employee = new EmployeeEntity { Id = id, Name = name};
        var nameWasCanChanged = employeeAccessor.UpdateById(employee);
        if (nameWasCanChanged != null)
        {
            Console.WriteLine($"社員名を{name}に変更しました");
        }
        else
        {
            Console.WriteLine($"{id}の社員は存在しないため変更できませんでした");
        }
        */

        /*
        var employeeAccessor = new EmployeeAccessor(new AppDbContext());
        Console.Write("社員Idを入力してください->");
        var id = int.Parse(Console.ReadLine()!);
        var nameWasCanDeleted = employeeAccessor.DeleteById(id);
        if (nameWasCanDeleted != null)
        {
            Console.WriteLine($"id:{id}の社員を削除しました");
        }
        else
        {
            Console.WriteLine($"{id}の社員は存在しないため削除できませんでした");
        }
        */

        /*
        var employeeAccessor = new EmployeeAccessor(new AppDbContext());
        Console.Write("社員名を入力してください->");
        var name = Console.ReadLine()!;

        var employee = employeeAccessor.FindByNameJoinDepartment(name);
        if(employee != null)
        {
            Console.WriteLine(employee);
            Console.WriteLine(employee.Department);
        }
        else
        {
            Console.WriteLine($"{name}の社員は存在しませんでした");
        }
        */

        var departmentAccessor = new DepartementAccessor(new AppDbContext());
        Console.Write("部署Idを入力してください->");
        var deptId = int.Parse(Console.ReadLine());
        var employee = departmentAccessor.FindByJoinEmployee(deptId);
        if(employee != null)
        {
            Console.WriteLine(employee);
            foreach(var e in employee.Employees)
            {
            Console.WriteLine($"社員Id={e.Id} , 社員名={e.Name} , 部署Id={employee.Id}");
            }
        }
        else
        {
            Console.WriteLine($"{deptId}の部署は存在しませんでした");
        }


    }
}