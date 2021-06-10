using System.Collections.Generic;
using System;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }

    public string EngineerName { get; set; }

    public string EngineerTitle { get; set; }

    public virtual ICollection<EngineerMachine> JoinEntities { get; set; }

    public Engineer()
    {
       this.JoinEntities = new HashSet<EngineerMachine>();
    }
  }
}