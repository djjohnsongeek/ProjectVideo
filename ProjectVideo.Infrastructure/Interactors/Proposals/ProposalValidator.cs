using ProjectVideo.Core.Interactors.DataObjects;

namespace ProjectVideo.Infrastructure.Interactors;

public class ProposalValidator
{
    List<string> Validate(CreateProposalInput inputData)
    {
        List<string> errors = [];

        if (string.IsNullOrWhiteSpace(inputData.ContactEmail))
        {
            errors.Add("ContactEmail is required.");
        }

        if (string.IsNullOrWhiteSpace(inputData.ContactPhoneNumber))
        {
            errors.Add("ContactPhoneNumber is required.");
        }

        if (string.IsNullOrWhiteSpace((inputData.OrganizationName)))
        {
            errors.Add("OrganizationName is required.");
        }
        
        return errors;
    }
}