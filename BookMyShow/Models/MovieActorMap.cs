using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Models;

public partial class MovieActorMap
{
    public int Id { get; set; }

    [ForeignKey("Movie"),Column("movie_id")]
    public int MovieId {get; set; }

    [ForeignKey("Actor"), Column("actor_id")]
    public int ActorId { get; set; }

    public virtual Actor Actor { get; set; }

    public virtual Movie Movie { get; set; }
}
