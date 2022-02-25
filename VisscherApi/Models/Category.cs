using System;
using System.Collections.Generic;

namespace VisscherApi.Models;

public class Category
{
  public virtual ICollection<MappableEvent> Events { get; set; }
  public int CategoryId { get; set; }

  public Category()
  {
    Events = new HashSet<MappableEvent>();
  }
}