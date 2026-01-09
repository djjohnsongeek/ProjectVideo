using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectVideo.Core.Interactors;
using ProjectVideo.Core.Interactors.DataObjects;
using ProjectVideo.Infrastructure.Data.Entities;
using ProjectVideo.Infrastructure.Services;

namespace ProjectVideo.Infrastructure.Interactors;

public class ProposalValidator
{
    private readonly LocalizationService _localizationService;

    private List<PropertyToValidate> _createProperties =
    [
        new PropertyToValidate("Email", "ErrorMsgContactMailRequired"),
        new PropertyToValidate("ContactPhoneNumber", "ErrorMsgContactPhoneNumberRequired"),
        new PropertyToValidate("ContactName", "ErrorMsgContactNameRequired"),
        new PropertyToValidate("OrganizationName", "ErrorMsgOrganizationNameRequired"),
        new PropertyToValidate("OrganizationHistory", "ErrorMsgOrganizationHistoryRequired"),
        new PropertyToValidate("ProjectTitle", "ErrorMsgProjectTitleRequired"),
        new PropertyToValidate("TargetAudience", "ErrorMsgTargetAudienceRequired"),
        new PropertyToValidate("KeyObjectives", "ErrorMsgKeyObjectivesRequired"),
        new PropertyToValidate("ProjectTimeFrameInterval", "ErrorMsgProjectTimeFrameIntervalRequired"),
        new PropertyToValidate("ProjectTimeFrameNumber", "ErrorMsgProjectTimeFrameNumberRequired"),
        new PropertyToValidate("MainMethods", "ErrorMsgMainMethodsRequired"),
        new PropertyToValidate("PlannedVideos", "ErrorMsgPlannedVideosRequired"),
        new PropertyToValidate("CurrentEquipment", "ErrorMsgCurrentEquipmentRequired"),
        new PropertyToValidate("EstimatedProjectCost", "ErrorMsgEstimatedProjectCostRequired")
    ];

    public ProposalValidator(LocalizationService localizationService)
    {
        _localizationService = localizationService;
    }
    
    public List<InteractorError> Validate(CreateProposalInput inputData)
    {
        List<InteractorError> errors = [];


        // Email
        if (string.IsNullOrWhiteSpace(inputData.ContactEmail))
        {
            string errorMessage = _localizationService.GetLocalizedText(
                "ErrorMsgContactEmailIsRequired",
                inputData.Language
            );
            
            errors.Add(new InteractorError( errorMessage, "Email"));
        }

        // PhoneNumber
        if (string.IsNullOrWhiteSpace(inputData.ContactPhoneNumber))
        {
            
            string errorMessage = _localizationService.GetLocalizedText(
                "ErrorMsgContactPhoneNumberIsRequired",
                inputData.Language
            );
            
            errors.Add(new InteractorError(errorMessage, "PhoneNumber"));
        }
        
        // ContactName
        if (string.IsNullOrEmpty(inputData.ContactName))
        {
            
        }

        // OrganizationName
        if (string.IsNullOrWhiteSpace(inputData.OrganizationName))
        {
            string errorMessage = _localizationService.GetLocalizedText(
                "ErrorMsgOrganizationNameIsRequired",
                inputData.Language
            );
            
            errors.Add(new InteractorError(errorMessage, "OrganizationName"));
        }
        
        // OrganizationHistory
        if (string.IsNullOrWhiteSpace(inputData.OrganizationHistory))
        {
            
        }

        // ProjectTitle
        if (string.IsNullOrWhiteSpace(inputData.ProjectTitle))
        {
            
        }
        
        // TargetAudience
        // KeyObjectives
        // ProjectTimeFrameNumber
        // ProjectTimeFrameInterval
        // MainMethods
        // PlannedVideos
        // CurrentEquipment
        // EstimatedProjectCost
        
        return errors;
    }
}