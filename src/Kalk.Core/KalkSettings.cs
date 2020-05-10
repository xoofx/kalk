using System;

namespace Kalk.Core
{
    public class KalkSettings
    {
        public static void Initialize()
        {
            var userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }
    }
}