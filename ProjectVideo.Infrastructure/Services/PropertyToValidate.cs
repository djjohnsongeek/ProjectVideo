namespace ProjectVideo.Infrastructure.Services;

public readonly struct PropertyToValidate(string propertyName, string localizationControlName)
{
    public string PropertyName { get; init; } = propertyName;
    public string LocalizationControlName { get; init; } = localizationControlName;
}