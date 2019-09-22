using System.Collections.Generic;
using System.Linq;

namespace OZON.Test.Domain.Entities.Abstractions
{
    public class DreamTeam : ITeam
    {
        private DreamTeam(IEmployee lead)
        {
            Members = new HashSet<IEmployee>();
            Lead = lead;
        }

        public DreamTeam(IEmployee lead, IEnumerable<IEmployee> members) : this(lead) =>
            Members = members.ToHashSet();
        
        public IEmployee Lead { get; }
        public IEnumerable<IEmployee> Members { get; }
    }
}