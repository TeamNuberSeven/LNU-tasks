using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Task4_ADO.NET_
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\MSSQLSERVER01; Initial Catalog=Northwind; Integrated Security=True";
            SqlConnection connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                PrintInfo(connection);
                //1
                CommandReader("select * from employees where EmployeeId = 8", connection,1);
                //2
                CommandReader("select LastName, FirstName from Employees where City = 'London'", connection, 2);
                //3
                CommandReader("select LastName, FirstName from Employees  where FirstName LIKE 'A%'", connection, 3);
                //4
                CommandReader("SELECT DATEDIFF(yy,BirthDate,getdate()) AS 'Age In Years', LastName, FirstName" +
                                    " FROM Employees where DATEDIFF(yy,BirthDate,getdate())  > 55 Order by LastName", connection, 4);
                //5
                CommandReader("select count(EmployeeID) as 'Live in London' from Employees where City='London'", connection, 5);
                //6
                CommandReader("select Min( DATEDIFF(yy,BirthDate,getdate())) as 'min age', Max( DATEDIFF(yy,BirthDate,getdate())) as 'max age', " +
                                    "avg( DATEDIFF(yy,BirthDate,getdate())) as 'avg age' from Employees where city='London'", connection, 6);
                //7
                CommandReader("select Min( DATEDIFF(yy,BirthDate,getdate())) as 'min age', Max( DATEDIFF(yy,BirthDate,getdate())) as 'max age', " +
                                    "avg( DATEDIFF(yy,BirthDate,getdate())) as 'avg age', City from Employees group by City", connection, 7);
                //8
                CommandReader("select avg( DATEDIFF(yy,BirthDate,getdate())) as 'avg age', City from Employees" +
                                    " group by City having avg( DATEDIFF(yy,BirthDate,getdate())) > 60 ", connection, 8);
                //9
                CommandReader("Select LastName, FirstName from Employees" +
                                    " where  DATEDIFF(yy,BirthDate,getdate()) = (select Max( DATEDIFF(yy,BirthDate,getdate())) from Employees)", connection, 9);
                //10
                CommandReader("Select top 3 LastName,  FirstName,  DATEDIFF(yy,BirthDate,getdate()) as 'age' from Employees " +
                                    "order by DATEDIFF(yy,BirthDate,getdate()) desc ", connection, 10);
                //11          
                CommandReader("select distinct City from Employees", connection, 11);
                //12
                CommandReader("select FirstName, LastName, BirthDate from Employees" +
                                    " where Month(BirthDate) =  Month(getdate())", connection, 12); //1", connection);
                //13                                                                              
                CommandReader("select distinct FirstName, LastName from Employees " +
                                    "inner join Orders on Employees.EmployeeID = Orders.EmployeeID where ShipCity = 'Madrid'", connection, 13);
                //14
                CommandReader("select distinct  FirstName, LastName, count(OrderID) as 'Number of orders' from Employees " +
                                    "left join  Orders on Employees.EmployeeID = Orders.EmployeeID where  YEAR(ShippedDate) = 1997 group by FirstName, LastName", connection, 14);

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                connection.Close();
            }
            Console.ReadKey();
        }
        static void PrintInfo(SqlConnection connection)
        {
            Console.WriteLine("Connection to: ");
            Console.WriteLine("Data source: " + connection.DataSource);
            Console.WriteLine("Data base: " + connection.Database);
            Console.WriteLine("State: " + connection.State);

        }
      
        static void CommandReader(string commandStr, SqlConnection connection,int task)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = commandStr;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            string dividation = "========= " + task + " =========";
            Console.WriteLine();
          while( reader.Read())
            {
                for(int i=0;i<reader.FieldCount;i++)
                {
                    Console.Write(reader.GetName(i) + ": ");
                    Console.WriteLine(reader.GetValue(i));
                }
                Console.WriteLine(dividation);
            }
            reader.Close();
        }
    }
}

