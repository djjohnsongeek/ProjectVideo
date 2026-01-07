using ProjectVideo.Core.Interactors;
using ProjectVideo.Core.Interactors.DataObjects;

namespace ProjectVideo.Infrastructure.Interactors;

public class ProposalValidator
{
    public List<InteractorError> Validate(CreateProposalInput inputData)
    {
        // TODO: grab localizations
        List<InteractorError> errors = [];

        if (string.IsNullOrWhiteSpace(inputData.ContactEmail))
        {
            errors.Add(new InteractorError("ContactEmail is required", "Email"));
        }

        if (string.IsNullOrWhiteSpace(inputData.ContactPhoneNumber))
        {
            errors.Add(new InteractorError("ContactPhoneNumber is required", "PhoneNumber"));
        }

        if (string.IsNullOrWhiteSpace((inputData.OrganizationName)))
        {
            errors.Add(new InteractorError("OrganizationName is required", "OrganizationName"));
        }
        
        return errors;
    }
}