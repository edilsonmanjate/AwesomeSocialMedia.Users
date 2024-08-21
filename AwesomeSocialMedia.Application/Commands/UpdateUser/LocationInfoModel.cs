using AwesomeSocialMedia.Users.Core.ValueObject;

namespace AwesomeSocialMedia.Application.Commands.UpdateUser
{
    public class LocationInfoModel
    {
        public string City { get; set; }
        public string State  { get; set; }
        public string Country  { get; set; }

        public LocationInfo ToValueObject() => new LocationInfo( City, State, Country);
    }
}
