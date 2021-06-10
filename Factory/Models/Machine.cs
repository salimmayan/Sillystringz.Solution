using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    public string MachineName { get; set; }
    public int MachineYear { get; set; }
    public virtual ICollection<EngineerMachine> JoinEntities { get; set; }
    public Machine()
    {
     this.JoinEntities = new HashSet<EngineerMachine>();
    }
  }
}