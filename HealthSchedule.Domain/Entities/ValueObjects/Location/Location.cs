namespace HealthSchedule.Domain.Entities.ValueObjects.Location;

public class Location : ValueObject
{

    public Location(
        String city, 
        EState state,
        String street,
        String neighborhood,
        int zipCode,
        int number) 
    {
        City = city;
        State = state;
        Street = street;
        Neighborhood = neighborhood;
        ZipCode = zipCode;
        Number = number;
    }

    public String City { get; set; }
    public EState State { get; set; }
    public String Street { get; set; }
    public String Neighborhood { get; set; }
    public int ZipCode { get; set; }
    public int Number { get; set; }
}
