using ProjectVideo.Core.Interactors.Proposal;
using System.ComponentModel.DataAnnotations;

namespace ProjectVideo.Web.Models.Proposals
{
    public class ProposalDetailsViewModel
    {
        public int ProposalId;
        [Display(Name = "Date Submitted")]
        public required string DateSubmitted { get; set; }

        [Display(Name = "Contact Email")]
        public required string ContactEmail { get; set;}
        [Display(Name = "Contact Phone")]
        public required string ContactPhoneNumber { get; set;}
        [Display(Name = "Contact Name")]
        public required string ContactName { get; set;}
        [Display(Name = "Organization Name")]
        public required string OrganizationName { get; set;}
        [Display(Name = "Organization History")]
        public required string OrganizationHistory { get; set;}
        [Display(Name = "Are the Staff Paid?")]
        public required string StaffArePaid { get; set;}
        [Display(Name = "Project Title")]
        public required string ProjectTitle { get; set;}
        [Display(Name = "Target Audience")]
        public required string TargetAudience { get; set;}
        [Display(Name = "Key Objectives")]
        public required string KeyObjectives { get; set;}
        [Display(Name = "")]
        public required string ProjectTimeFrameInterval { get; set;}
        [Display(Name = "")]
        public int ProjectTimeFrameTotal { get; set;}
        [Display(Name = "Methods")]
        public required string Methods { get; set;}
        [Display(Name = "Planned Videos")]
        public required string PlannedVideos { get; set;}
        [Display(Name = "Current Equipment")]
        public required string CurrentEquipment { get; set;}
        [Display(Name = "Has Recording Space")]
        public required string HasAudioSpace { get; set;}
        [Display(Name = "Recording Space Description")]
        public string? AudioSpaceDescription { get; set;}
        [Display(Name = "Has a Computer")]
        public required string HasComputer { get; set;}
        [Display(Name = "Computer Discription")]
        public string? ComputerDescription { get; set;}
        [Display(Name = "Estimated Project Cost")]
        public int EstimatedProjectCost { get; set;}

        public List<VideoLink> Links = [];
        public List<ProposalMember> Members = [];

        // cooridnator notes
        // status
    }
}
