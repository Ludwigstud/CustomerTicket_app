using Microsoft.EntityFrameworkCore;
using Practice_0829.Contexts;
using Practice_0829.Models.Entities;

namespace Practice_0829.Services;
internal class TicketService
{
    private readonly Context _context = new Context();


    public async Task CreateTicketAsync()
    {



        Console.WriteLine("################################################");
        Console.WriteLine("################################################");
        Console.WriteLine("########      Enter Ticket Details      ########");
        Console.WriteLine("################################################");
        Console.WriteLine("################################################\n");

        DateTime dateTime = DateTime.Now;

        Console.WriteLine($"Date and Time: {dateTime.ToString("yyyy-MM-dd HH:mm:ss")}");

        Console.Write("\nTicket Comment:");
        string comments = Console.ReadLine() ?? "";

        Console.Write("\nSelect Ticket Status (0: NotStarted, 1: Started, 2: Finished):");
        if (!Enum.TryParse(Console.ReadLine(), out TicketEntity.TicketStatus status))
        {
            Console.WriteLine("Invalid input for Ticket Status.");
            return;
        }

        var newTicket = new TicketEntity
        {
            DateTime = dateTime,
            Comments = comments,
            Status = status
        };

        Console.Write("\nPlease enter your Customer ID:"); int customerId = Convert.ToInt32(Console.ReadLine());

        var customer = await _context.Customers.FindAsync(customerId);


        if (customer != null)
        {
            customer.Ticket = newTicket;
            _context.Tickets.Add(newTicket);
            await _context.SaveChangesAsync();

            Console.WriteLine("Ticket created and associated with the customer!");
        }
        else
        {
            Console.WriteLine("\n\nCustomer not found.");
        }


        Console.WriteLine("\n\nPress Any Key To Continue..."); Console.ReadKey();





    }


    public async Task ShowSpecificTicketAsync()
    {

        Console.Write("Please enter the TicketId: "); int ticketId = Convert.ToInt32(Console.ReadLine());

        Console.Clear();

        var ticket = await _context.Tickets.FindAsync(ticketId);

        if (ticket != null)
        {
            Console.WriteLine($"Ticket ID: {ticket.Id}");
            Console.WriteLine($"Date and Time: {ticket.DateTime}");
            Console.WriteLine($"Comments: {ticket.Comments}");
            Console.WriteLine($"Status: {ticket.Status}");
        }
        else
        {
            Console.WriteLine("Ticket not found.");
        }

        Console.WriteLine("\n\nPress Any Key To Continue..."); Console.ReadKey();
    }

    public async Task ShowAllTicketsAsync()
    {
        var tickets = await _context.Tickets.ToListAsync();

        if (tickets.Count > 0)
        {
            Console.WriteLine("################################################");
            Console.WriteLine("################################################");
            Console.WriteLine("########      All Current Tickets       ########");
            Console.WriteLine("################################################");
            Console.WriteLine("################################################\n\n");
            foreach (var ticket in tickets)
            {
                Console.WriteLine($"Ticket ID: {ticket.Id}");
                Console.WriteLine($"Date and Time: {ticket.DateTime}");
                Console.WriteLine($"Comments: {ticket.Comments}");
                Console.WriteLine($"Status: {ticket.Status}");
                Console.WriteLine("----------------------------");
                Console.WriteLine("----------------------------");
            }
        }
        else
        {
            Console.WriteLine("No tickets found in the database.");
        }

        Console.WriteLine("\n\nPress Any Key To Continue..."); Console.ReadKey();


    }

    public async Task ChangeStatusTicketAsync()
    {

        Console.WriteLine("################################################");
        Console.WriteLine("################################################");
        Console.WriteLine("########      Update Ticket Status      ########");
        Console.WriteLine("################################################");
        Console.WriteLine("################################################\n");

        Console.WriteLine("Enter Ticket ID:");
        if (!int.TryParse(Console.ReadLine(), out int ticketId))
        {
            Console.WriteLine("Invalid input for Ticket ID.");
            return;
        }

        var ticket = await _context.Tickets.FindAsync(ticketId);

        if (ticket != null)
        {
            Console.WriteLine($"Current Ticket Status: {ticket.Status}");

            Console.WriteLine("\nSelect New Ticket Status (0: NotStarted, 1: Started, 2: Finished):");
            if (!Enum.TryParse(Console.ReadLine(), out TicketEntity.TicketStatus newStatus))
            {
                Console.WriteLine("Invalid input for New Ticket Status.");
                return;
            }


            if (ticket != null)
            {
                ticket.Status = newStatus;
                await _context.SaveChangesAsync();

                Console.WriteLine("Ticket status updated successfully!");
            }
            else
            {
                Console.WriteLine("Ticket not found.");
            }

            Console.WriteLine("\n\nPress Any Key To Continue..."); Console.ReadKey();


        }

    }
}
