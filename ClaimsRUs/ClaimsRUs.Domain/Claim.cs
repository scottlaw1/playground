using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClaimsRUs.Domain
{
    public class Claim : IClaim
    {
        private IList<IClaimTag> tags;

        public IClaimant Claimant { get; set; }

        public IList<IClaimTag> GetTags()
        {
            return tags;
        }

        public void ApplyTag(IClaimTag claimTag)
        {
            if (claimTag == null) throw new ArgumentNullException("claimTag");
            tags.Add(claimTag);
        }

        public bool HasClaimTag(IClaimTag claimTag)
        {
            return tags.Contains(claimTag);
        }

        public Claim():this(null){}

        public Claim(IClaimant claimant)
        {
            Claimant = claimant;
            tags = new ObservableCollection<IClaimTag>();
        }
    }
}