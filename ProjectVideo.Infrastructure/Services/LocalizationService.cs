using ProjectVideo.Core;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Infrastructure.Data.Entities;

namespace ProjectVideo.Infrastructure.Services;

public class LocalizationService
{
    private readonly List<Localization> _localizations;
    
    public LocalizationService(ProjectVideoDbContext dbContext)
    {
        try
        {
            _localizations = dbContext.Localizations.ToList();
        }
        catch (Exception)
        {
            _localizations = [];
        }
    }

    public bool FetchFailed => _localizations.Count == 0;
    
    public string GetLocalizedText(string controlName, AppLanguage lang)
    {
        var loc = _localizations.FirstOrDefault(l => l.ControlName == controlName);
        return GetLocalizedText(loc?.Id, lang);
    }
    
    public string GetLocalizedText(int? localizationId, AppLanguage lang)
    {
        var loc = _localizations.FirstOrDefault(l => l.Id == localizationId);
        if (loc == null)
        {
            return "Translation Missing";
        }

        return lang switch
        {
            AppLanguage.English => loc.English,
            AppLanguage.Thai => loc.Thai,
            _ => "Translation Missing",
        };
    }
}