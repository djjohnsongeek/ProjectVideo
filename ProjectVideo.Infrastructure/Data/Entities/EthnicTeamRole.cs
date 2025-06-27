using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVideo.Infrastructure.Data.Entities
{
    public class EthnicTeamRole
    {
        public int EthnicTeamRoleId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
