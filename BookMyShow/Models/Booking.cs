using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Booking
{
    public int Id { get; set; }

    public int NoOfTickets { get; set; }

    public int TotalCost { get; set; }

    public int ShowId { get; set; }

    public int PaymentId { get; set; }

    public int NonRegisteredUserId { get; set; }

    public int UsersId { get; set; }

    public virtual NonRegisteredUser NonRegisteredUser { get; set; } = null!;

    public virtual Payment Payment { get; set; } = null!;

    public virtual Show Show { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();

    public virtual User Users { get; set; } = null!;
}
