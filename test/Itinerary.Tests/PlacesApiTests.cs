﻿using Itinerary.Business.Api.Google.Places;
using Itinerary.Business.Api.Google.Places.Autocomplete.Entities;
using Itinerary.Business.Api.Google.Places.Autocomplete.ParameterBuilder;
using Itinerary.Business.Api.Google.Places.Autocomplete.Types;
using Itinerary.Business.Api.Google.Places.Search.Entities.Nearby;
using Itinerary.Business.Api.Google.Places.Search.Entities.Radar;
using Itinerary.Business.Api.Google.Places.Search.Entities.Text;
using Itinerary.Business.Api.Google.Places.Search.ParameterBuilder.Interfaces;
using Itinerary.Business.Api.Google.Places.Types;
using Xunit;

namespace Itinerary.Tests
{
  public class PlacesApiTests
  {
    [Fact]
    public async void NearbySearch()
    {
      INearbyHttpQueryBuilder searchQueryBuilder =
        PlacesBuilder.Create( GoogleClientSecretsStorage.Instance.ClientSecrets )
                     .NearbySearch()
                     .Radius( 1000 )
                     .Keyword( "bank" )
                     .Location( 42.201154, -85.580002 )
                     .Language( Languages.English );

      NearbyResult results = await PlacesClient.NearbySearch( searchQueryBuilder );

      Assert.NotNull( results );
      Assert.NotEmpty( results.Results );
    }

    [Fact]
    public async void TextSearch()
    {
      ITextHttpQueryBuilder textQueryBuilder =
        PlacesBuilder.Create( GoogleClientSecretsStorage.Instance.ClientSecrets )
                     .TextSearch()
                     .Radius( 100 )
                     .Query( "bank" )
                     .Location( 42.201154, -85.580002 );

      TextResult results = await PlacesClient.TextSearch( textQueryBuilder );

      Assert.NotNull( results );
      Assert.NotEmpty( results.Results );
    }

    [Fact]
    public async void RadarSearch()
    {
      IRadarHttpQueryBuilder radarQueryBuilder =
        PlacesBuilder.Create( GoogleClientSecretsStorage.Instance.ClientSecrets )
                     .RadarSearch()
                     .Radius( 1000 )
                     .Keyword( "bank" )
                     .Location( 42.201154, -85.580002 );

      RadarResult results = await PlacesClient.RadarSearch( radarQueryBuilder );

      Assert.NotNull( results );
      Assert.NotEmpty( results.Results );
    }

    [Fact]
    public async void Autocomplete()
    {
      IAutocompleteHttpQueryBuilder autocompleteQueryBuilder =
        PlacesBuilder.Create( GoogleClientSecretsStorage.Instance.ClientSecrets )
                     .Autocomplete()
                     .Radius( 1000 )
                     .Input( "kalamazoo" )
                     .Types( PlaceTypes.Cities )
                     .Location( 42.201154, -85.580002 );

      AutocompleteResult results = await PlacesClient.Autocomplete( autocompleteQueryBuilder );

      Assert.NotNull( results );
      Assert.NotEmpty( results.Predictions );
    }
  }
}