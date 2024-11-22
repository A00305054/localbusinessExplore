using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;

namespace localbusinessExplore.Services
{
    public static class FirebaseService
    {
        public const string ApiKey = "AIzaSyBOw_QvzSH1WqRyX86Bq1d7d7-p8BRTKBA\r\n";
        public static FirebaseAuthProvider AuthProvider => new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
    }
}
