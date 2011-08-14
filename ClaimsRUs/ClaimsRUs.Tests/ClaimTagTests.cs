using System;
using ClaimsRUs.Domain;
using NUnit.Framework;

namespace ClaimsRUs.Tests
{
    [TestFixture]
    public class ClaimTagTests
    {
        private IClaimTag claimTag;

        [SetUp]
        public void Setup()
        {
            claimTag = new ClaimTag("testTag");
        }

        [Test]
        public void ClaimTagHasAppliedOnDateOfToday()
        {
            DateTime today = DateTime.Today;
            Assert.That(claimTag.AppliedOn,Is.EqualTo(today));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClaimTagMustHaveNonNullName()
        {
            IClaimTag badTag = new ClaimTag(null);
        }
        
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClaimTagMustHaveNonEmptyName()
        {
            IClaimTag badTag = new ClaimTag(null);
        }
        
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClaimTagMustHaveNonWhitespaceName()
        {
            IClaimTag badTag = new ClaimTag(" ");
        }


    }
}
