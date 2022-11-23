using GeoLocalizationBlazorMaui.Interfaces;
using GeoLocalNet.CountryLookup;
using GeoLocalNet.CountryLookup.Domain;

namespace GeoLocalizationBlazorMaui.Services;

internal class Localization : ILocalization
{
    public async Task<string> GetCountryCodeAsync()
    {
        var country = await GetCountryAsync();
        return country.Code;
    }

    public async Task<string> GetCountryNameAsync()
    {
        var country = await GetCountryAsync();
        return country.Name;
    }

    private async Task<GeoLocalNet.CountryLookup.Domain.Region> GetCountryAsync()
    {
        var reverseLookup = new ReverseLookup();
        var location = await Geolocation.Default.GetLastKnownLocationAsync();
        return  reverseLookup.Lookup((float)location.Latitude, (float)location.Longitude, new[] { RegionType.Country });
    }
}
