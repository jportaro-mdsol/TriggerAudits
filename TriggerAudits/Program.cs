using Npgsql.Replication;
using TriggerAudits.Domain;

namespace TriggerAudits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Heather", "Joe", "Jack", "Mike", "Jenn", "Jill" };
            string response = string.Empty;
            var rand = new Random();

            while (response.ToLower().Trim() != "exit")
            {
                Console.Write("Who is this with? ");
                response = Console.ReadLine();

                using (var dbCtx = new AuditingContext())
                {
                    var employee = new Employee()
                    {
                        Name = names[rand.Next() % names.Length],
                        Salary = 1000
                    };

                    dbCtx.Employees.Add(employee);
                    try
                    {
                        dbCtx.SaveChanges(response);
                    }
                    catch (Exception ex) 
                    { 
                        Console.WriteLine(ex.ToString());
                    }
                    
                }
            }
           
        }
    }
}
