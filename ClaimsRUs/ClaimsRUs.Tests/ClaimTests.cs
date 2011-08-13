using System;
using ClaimsRUs.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace ClaimsRUs.Tests
{
    [TestFixture]
    public class ClaimTests
    {
        private IClaim claim;
        private IClaimTag testClaimTag;
        private DateTime now;

        [SetUp]
        public void Setup()
        {
            now = DateTime.Now;
            claim = GetTestClaim();
            testClaimTag = GetTestTag();
        }

        [Test]
        public void ApplyTagAddsTagToClaim()
        {
            Assert.That(claim.GetTags().Count == 0,"The claim should not have any tags.");
            var claimTag = new ClaimTag("testTag");
            claim.ApplyTag(claimTag);
            Assert.That(claim.GetTags().Count == 1,"The claim should have one tag.");
        }

        [Test]
        public void HasTagReturnsTrueIfTagExists()
        {
            claim.ApplyTag(testClaimTag);
            Assert.That(claim.HasClaimTag(testClaimTag), Is.True);
        }

        [Test]
        public void HasTagReturnsFalseIfClaimDoesNotExist()
        {
            Assert.That(claim.HasClaimTag(testClaimTag), Is.False);
        }

        private IClaim GetTestClaim()
        {
            claim = new Claim();
            var claimant = MockRepository.GenerateStub<IClaimant>();
            claim.Claimant = claimant;
            return claim;
        }

        private IClaimTag GetTestTag()
        {
            var claimTag = MockRepository.GenerateStub<IClaimTag>();
            claimTag.Stub(dct => dct.Name).Return("testTag");
            claimTag.Stub(dct => dct.AppliedOn).Return(now);

            return claimTag;
        }
    }
}
