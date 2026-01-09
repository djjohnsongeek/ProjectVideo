using ProjectVideo.Core.Interactors;
using ProjectVideo.Core.Interactors.DataObjects;
using ProjectVideo.Infrastructure.Data.Entities;
using ProjectVideo.Infrastructure.Services;

namespace ProjectVideo.Infrastructure.Interactors;

public class ProposalValidator
{
    private readonly LocalizationService _localizationService;

    public ProposalValidator(LocalizationService localizationService)
    {
        _localizationService = localizationService;
    }
    
    public List<InteractorError> Validate(CreateProposalInput inputData)
    {
        List<InteractorError> errors = [];

        if (string.IsNullOrWhiteSpace(inputData.ContactEmail))
        {
            string errorMessage = _localizationService.GetLocalizedText(
                "ErrorMsgContactEmailIsRequired",
                inputData.Language
            );
            
            errors.Add(new InteractorError( errorMessage, "Email"));
        }

        if (string.IsNullOrWhiteSpace(inputData.ContactPhoneNumber))
        {
            
            string errorMessage = _localizationService.GetLocalizedText(
                "ErrorMsgContactPhoneNumberIsRequired",
                inputData.Language
            );
            
            errors.Add(new InteractorError(errorMessage, "PhoneNumber"));
        }

        if (string.IsNullOrWhiteSpace((inputData.OrganizationName)))
        {
            string errorMessage = _localizationService.GetLocalizedText(
                "ErrorMsgOrganizationNameIsRequired",
                inputData.Language
            );
            
            errors.Add(new InteractorError(errorMessage, "OrganizationName"));
        }
        
        return errors;
    }
}