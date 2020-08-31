using System.Collections.Generic;

namespace NonreciprocalFollowings.NonreciprocalFollowingsIdentifiers
{
    public interface INonreciprocalFollowingsIdentifier
    {
        HashSet<string> Identify(string followers, string following);
    }
}
