namespace Practice_0829.Models.Entities;
internal class CustomerEntity
{

    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

    public int? TicketId { get; set; }
    public TicketEntity Ticket { get; set; } = null!;





}
