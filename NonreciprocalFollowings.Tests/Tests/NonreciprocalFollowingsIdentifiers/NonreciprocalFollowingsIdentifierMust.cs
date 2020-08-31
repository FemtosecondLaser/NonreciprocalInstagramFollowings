using NonreciprocalFollowings.NonreciprocalFollowingsIdentifiers;
using NUnit.Framework;
using System.Collections.Generic;

namespace NonreciprocalFollowings.Tests.Tests.NonreciprocalFollowingsIdentifiers
{
    [TestFixture]
    public class NonreciprocalFollowingsIdentifierMust
    {
        [Test]
        public void FilterFollowingsWhichDoNotFollow()
        {
            var followers =
                @"tarja9's profile picture
tarja9
Susanna Holopainen
ne_otvorachivaysa's profile picture
ne_otvorachivaysa
эльф
tradenneusagresem1982's profile picture
tradenneusagresem1982
Burke Mederios
grossfamilien_managerin_debby's profile picture
grossfamilien_managerin_debby
Deborah Poll
xan_vill's profile picture
xan_vill
🖤𝒜𝓁𝑒𝓍 𝒩 𝒱𝒾𝓁𝓁𝒶𝓇𝓇𝑒𝒶𝓁 🖤
_.araxycrk._'s profile picture
_.araxycrk._
Araxy Roccaro Kruk";
            var following =
                @"tradenneusagresem1982's profile picture
tradenneusagresem1982
Burke Mederios
grossfamilien_managerin_debby's profile picture
grossfamilien_managerin_debby
Deborah Poll
xan_vill's profile picture
xan_vill
🖤𝒜𝓁𝑒𝓍 𝒩 𝒱𝒾𝓁𝓁𝒶𝓇𝓇𝑒𝒶𝓁 🖤
_.araxycrk._'s profile picture
_.araxycrk._
Araxy Roccaro Kruk
ludmila_rybchenko's profile picture
ludmila_rybchenko
Fine Art & Beaty photographer
rafah_melo1's profile picture
rafah_melo1
Rafaela Melo
mollystewhom's profile picture
mollystewhom
Molly Stewhom";
            var expectedNonreciprocalFollowings =
                new HashSet<string>() 
                {
                "ludmila_rybchenko",
                "rafah_melo1",
                "mollystewhom"
                };

            var sut = new NonreciprocalFollowingsIdentifier();

            var actualNonreciprocalFollowings = sut.Identify(followers, following);

            CollectionAssert.AreEquivalent(expectedNonreciprocalFollowings, actualNonreciprocalFollowings);
        }
    }
}
