namespace Practice_0829.Models.Entities;
internal class TicketEntity
{


    public int Id { get; set; }

    public DateTime DateTime { get; set; }
    public string Comments { get; set; } = null!;

    public TicketStatus Status { get; set; }

    public enum TicketStatus
    {
        NotStarted,
        Started,
        Finished
    }





}
