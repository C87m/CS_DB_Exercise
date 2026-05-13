using CS_DB_Exercise.Infrastructures;
using CS_DB_Exercise.Infrastructures.Queries;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;

namespace CS_DB_Exercise;
class Program
{
    static void Main(string[] args)
    {
        var accessor = new DepartmentAccessor(new AppDbContext());
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

        /*
        var departmentAccessor = new DepartementAccessor(new AppDbContext());
        Console.Write("部署Idを入力してください->");
        var deptId = int.Parse(Console.ReadLine());
        var employee = departmentAccessor.FindByJoinEmployee(deptId);
        if(employee != null)
        {
            Console.WriteLine(employee);
            foreach(var e in employee.Employees)
            {
            Console.WriteLine(e);
            }
        }
        else
        {
            Console.WriteLine($"{deptId}の部署は存在しませんでした");
        }
        */

        /*
        var context = new AppDbContext();
        var departmentAccessor = new DepartmentAccessor(context);

        using var transaction = context.Database.BeginTransaction();
        Console.WriteLine("トランザクションを開始しました。");

        Console.Write("新しい部署名を入力してください->");
        var name = Console.ReadLine();
        var entity = new DepartmentEntity
        {
            Id = 0, // Idは自動採番されるため、0を指定する
            Name = name
        };
        // Create()メソッドを使用して、departmentテーブルに新しい部署を登録する
        var result = departmentAccessor.Create(entity);
        Console.WriteLine($"新しい部署を登録しました: 部署Id={result.Id} , 部署名={result.Name}");

        Console.Write("トランザクションをコミットしますか？ (y/n)->");
        var input = Console.ReadLine();
        if (input?.ToLower() == "y")
        {
            // トランザクションをコミットする
            transaction.Commit();
            Console.WriteLine("トランザクションをコミットしました。");
        }
        else
        {
            // トランザクションをロールバックする
            transaction.Rollback();
            Console.WriteLine("トランザクションをロールバックしました。");
        }

        // 登録した部署を含むすべての部署を取得して表示する
        var departments = departmentAccessor.FindAll();
        foreach (var department in departments)
        {
            Console.WriteLine($"部署Id={department.Id} , 部署名={department.Name}");
        }
        */

        var employeeAccessor = new EmployeeAccessor(new AppDbContext());
        Console.Write("社員名を入力してください->");
        var name = Console.ReadLine();
        // 入力された社員名を含む社員とその所属部署を取得する
        var results = employeeAccessor.FindByNameContainsJoinDepartment(name!);
        // 取得した結果がnullの場合は、該当する社員が存在しない旨を表示する
        if (results == null)
        {
            Console.WriteLine($"{name}さんは、存在しません。");
        }
        else
        {
            // 取得した結果をループで回して、社員名と所属部署名を表示する
            foreach (var result in results)
            {
                Console.WriteLine($"{name}さんは、{result.Department!.Name}に所属する社員です。");
            }
        }
    }
}