using Microsoft.EntityFrameworkCore;
using Practice_0829.Contexts;
using Practice_0829.Models.Entities;

namespace Practice_0829.Services;
internal class CustomerService
{

    private readonly Context _context = new Context();


    public async Task CreateCustomerAsync()
    {
        CustomerEntity customer = new CustomerEntity();

        Console.WriteLine("################################################");
        Console.WriteLine("################################################");
        Console.WriteLine("######## Please Enter your Information ########");
        Console.WriteLine("################################################");
        Console.WriteLine("################################################\n");

        Console.Write("First Name:");
        customer.FirstName = Console.ReadLine() ?? "";
        Console.Write("Last Name:");
        customer.LastName = Console.ReadLine() ?? "";
        Console.Write("Email:");
        customer.Email = Console.ReadLine() ?? "";
        Console.Write("Phone number:");
        customer.PhoneNumber = Console.ReadLine() ?? "";

        if (string.IsNullOrEmpty(customer.FirstName) || string.IsNullOrEmpty(customer.LastName))
        {
            Console.WriteLine("First Name and Last Name are required.");
            return;
        }

        _context.Add(customer);
        await _context.SaveChangesAsync();


        Console.WriteLine("\n\nPress Any Key To Continue..."); Console.ReadKey();
    }



    public async Task DisplayAllCustomersAsync()
    {

        Console.WriteLine("################################################");
        Console.WriteLine("################################################");
        Console.WriteLine("########     All Current Customers      ########");
        Console.WriteLine("################################################");
        Console.WriteLine("################################################\n\n");



        var customers = await _context.Customers.ToListAsync();

        if (customers.Count > 0)
        {
            Console.WriteLine("All Customers:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer ID: {customer.Id}");
                Console.WriteLine($"First Name: {customer.FirstName}");
                Console.WriteLine($"Last Name: {customer.LastName}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
                Console.WriteLine("----------------------------");
                Console.WriteLine("----------------------------");

            }
        }
        else
        {
            Console.WriteLine("No customers found in the database.");
        }

        Console.WriteLine("\n\nPress Any Key To Continue..."); Console.ReadKey();


    }





}
