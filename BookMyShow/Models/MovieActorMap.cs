using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Models;

public partial class MovieActorMap
{
    public int Id { get; set; }

    public int MovieId {get; set; }

    public int ActorId { get; set; }
}
