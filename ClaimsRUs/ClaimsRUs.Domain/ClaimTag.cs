using System;

namespace ClaimsRUs.Domain
{
    public class ClaimTag : IClaimTag
    {
        private readonly string name;
        public string Name
        {
            get { return name; }
        }

        private readonly DateTime appliedOn;
        public DateTime AppliedOn
        {
            get { return appliedOn; }
        }

        public ClaimTag(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
            this.name = name;
            appliedOn = DateTime.Today;
        }
    }
}