using static Employee;

// Create delegate
public delegate void EmployeeDelegate(string methodName);
public class Employee
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string DepartmentName { get; set; }

    // create event
    public event EmployeeDelegate EmployeeEvent;

    /// <summary>
    /// set id, name and department name
    /// </summary>
    /// <param name="Id">id</param>
    /// <param name="Name">name</param>
    /// <param name="DepartmentName">department name</param>
    public Employee(string Id, string Name, string DepartmentName)
    {

        EmployeeEvent?.Invoke("Constructor()");
        this.Id = Id;
        this.Name = Name;
        this.DepartmentName = DepartmentName;
    }

    /// <summary>
    /// get id
    /// </summary>
    /// <returns>id</returns>
    public string GetId()
    {
        EmployeeEvent?.Invoke("GetId()");
        return this.Id;
    }

    /// <summary>
    /// get name
    /// </summary>
    /// <returns>name</returns>
    public string GetName()
    {
        EmployeeEvent?.Invoke("GetName()");
        return this.Name;
    }

    /// <summary>
    /// get department name
    /// </summary>
    /// <returns>department name</returns>
    public string GetDepartmentName()
    {
        EmployeeEvent?.Invoke("GetDepartmentName()");
        return this.DepartmentName;
    }

    /// <summary>
    /// update id
    /// </summary>
    /// <param name="newId">new id</param>
    public void UpdateId(string newId)
    {
        EmployeeEvent?.Invoke("UpdateId()");
        Id = newId;
    }

    /// <summary>
    /// Update name
    /// </summary>
    /// <param name="newName">new name</param>
    public void UpdateName(string newName)
    {
        EmployeeEvent?.Invoke("UpdateName()");
        Name = newName;   
    }

    /// <summary>
    /// Update department name
    /// </summary>
    /// <param name="newDepartmentName">new department name</param>
    public void UpdateDepartmentName(string newDepartmentName)
    {
        EmployeeEvent?.Invoke("UpdateDepartmentName()");
        DepartmentName = newDepartmentName;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        while (true) {
            Console.WriteLine("Press q for quit");
            var UserInput=Console.ReadLine();
            if (UserInput == "q")
            {
                break;
            }

            Console.WriteLine("Enter User Id");
            var Id = Console.ReadLine();
            Console.WriteLine("Enter User Name");
            var Name = Console.ReadLine();
            Console.WriteLine("Enter User Department Name");
            var DepartmentName = Console.ReadLine();
            Employee ep1=new Employee(Id, Name, DepartmentName);
            // subscribe the event
            ep1.EmployeeEvent += OnMethodCalled ;
            Console.WriteLine($"User Id is: {ep1.GetId()}");
            Console.WriteLine($"User Name is: {ep1.GetName()}");
            Console.WriteLine($"Department Name is: {ep1.GetDepartmentName()}");
            // unsubscribe the event
            ep1.EmployeeEvent -= OnMethodCalled;
        }
    }

    /// <summary>
    /// event handler method
    /// </summary>
    /// <param name="methodName">method called name</param>
    private static void OnMethodCalled(string methodName)
    {
        Console.WriteLine($"{methodName} method called");
    }
}