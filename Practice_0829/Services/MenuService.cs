namespace Practice_0829.Services;
internal class MenuService
{

    public async Task Menu()
    {

        while (true)
        {
            Console.Clear();
            CustomerService customerService = new CustomerService();
            TicketService ticketService = new TicketService();

            Console.WriteLine("################################################");
            Console.WriteLine("################################################");
            Console.WriteLine("########   Welcome To Ticket Creation   ########");
            Console.WriteLine("################################################");
            Console.WriteLine("################################################\n");







            Console.WriteLine("Please enter one of following 1-4:");
            Console.WriteLine("1: Create new customer");
            Console.WriteLine("2: Display all customers");
            Console.WriteLine("3: Create new ticket");
            Console.WriteLine("4: Show Specific Ticket");
            Console.WriteLine("5: Show all the tickets");
            Console.WriteLine("6: Change status of ticket");
            Console.WriteLine("7: Exit the application");


            Console.Write(""); int choice = int.Parse(Console.ReadLine() ?? "");

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    await customerService.CreateCustomerAsync();
                    break;
                case 2:
                    Console.Clear();
                    await customerService.DisplayAllCustomersAsync();
                    break;
                case 3:
                    Console.Clear();
                    await ticketService.CreateTicketAsync();
                    break;
                case 4:
                    Console.Clear();
                    await ticketService.ShowSpecificTicketAsync();
                    break;
                case 5:
                    Console.Clear();
                    await ticketService.ShowAllTicketsAsync();
                    break;
                case 6:
                    Console.Clear();
                    await ticketService.ChangeStatusTicketAsync();
                    break;

                case 7:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.ReadKey();

                    break;
            }

            Console.WriteLine();
        }

    }
}
