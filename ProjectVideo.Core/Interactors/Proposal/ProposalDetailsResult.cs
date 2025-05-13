using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVideo.Core.Interactors.Proposal
{
    public class ProposalDetailsResult : InteractorResult
    {
        public required ProposalDetails Details;
    }

    public class ProposalDetails
    {
        public int ProposalId;
        public DateTime DateSubmitted;
        public required string ContactEmail;
        public required string ContactPhoneNumber;
        public required string ContactName;
        public required string OrganizationName;
        public required string OrganizationHistory;
        public bool StaffArePaid;
        public required string ProjectTitle;
        public required string TargetAudience;
        public required string KeyObjectives;
        public required string ProjectTimeFrameInterval;
        public int ProjectTimeFrameTotal;
        public required string Methods;
        public required string PlannedVideos;
        public required string CurrentEquipment;
        public bool HasAudioSpace;
        public string? AudioSpaceDescription;
        public bool HasComputer;
        public string? ComputerDescription;
        public int EstimatedProjectCost;

        public List<VideoLink> Links = [];
        public List<ProposalMember> Members = [];

        public static ProposalDetails Empty()
        {
            return new ProposalDetails {
                ProposalId = 0,
                DateSubmitted = DateTime.MinValue,
                ContactEmail = "",
                ContactPhoneNumber = "",
                ContactName = "",
                OrganizationName = "",
                OrganizationHistory = "",
                StaffArePaid = false,
                ProjectTitle = "",
                TargetAudience = "",
                KeyObjectives = "",
                ProjectTimeFrameInterval = "",
                ProjectTimeFrameTotal = 0,
                Methods = "",
                PlannedVideos = "",
                CurrentEquipment = "",
                HasAudioSpace = false,
                AudioSpaceDescription = "",
                HasComputer = false,
                ComputerDescription = "",
                EstimatedProjectCost = 0,
            };
        }
    }

    public class VideoLink
    {
        public required string Name;
        public required string Url;
    }

    public class ProposalMember
    {
        public required string Name;
        public required string Role;
    }
}
