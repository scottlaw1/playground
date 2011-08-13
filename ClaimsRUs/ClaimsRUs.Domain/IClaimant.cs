using System;

namespace ClaimsRUs.Domain
{
    public interface IClaimant
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        int Age { get; }
        string Street { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
        string SSN { get; set; }
    }
}
