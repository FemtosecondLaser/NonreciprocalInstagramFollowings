using System;
using System.Collections.Generic;
using System.IO;

namespace NonreciprocalFollowings.NonreciprocalFollowingsIdentifiers
{
    public class NonreciprocalFollowingsIdentifier : INonreciprocalFollowingsIdentifier
    {
        public HashSet<string> Identify(string followers, string following)
        {
            if (followers == null)
                throw new ArgumentNullException(nameof(followers));

            if (following == null)
                throw new ArgumentNullException(nameof(followers));

            var followersCollection = GetUserIDs(followers);
            var followingCollection = GetUserIDs(following);

            followingCollection.ExceptWith(followersCollection);
            return followingCollection; /* followings that do not follow back */
        }

        private HashSet<string> GetUserIDs(string followList)
        {
            if (followList == null)
                throw new ArgumentNullException(nameof(followList));

            var userIDs = new HashSet<string>();

            using (var reader = new StringReader(followList))
            {
                string line;
                bool nextLineIsID = false;
                for (int i = 0; (line = reader.ReadLine()) != null; i++)
                {
                    if (nextLineIsID)
                    {
                        userIDs.Add(line);
                        nextLineIsID = false;
                        continue;
                    }

                    if (line.EndsWith(" profile picture")) /* probably different for non-English Instagram */
                        nextLineIsID = true;
                }
            }

            return userIDs;
        }
    }
}
