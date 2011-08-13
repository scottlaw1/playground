using System.Collections.Generic;

namespace ClaimsRUs.Domain
{
    public interface IClaim
    {
        IClaimant Claimant { get; set; }
        IList<IClaimTag> GetTags();
        void ApplyTag(IClaimTag claimTag);
        bool HasClaimTag(IClaimTag claimTag);
    }
}
