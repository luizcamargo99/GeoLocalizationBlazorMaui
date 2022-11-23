namespace GeoLocalizationBlazorMaui.Interfaces;

internal interface ILocalization
{
    Task<string> GetCountryCodeAsync();
    Task<string> GetCountryNameAsync();
}
