using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Threading.Tasks;

namespace localbusinessExplore.Helpers
{
    public class FirebaseHelper
    {
        private readonly FirebaseClient _firebaseClient;

        public FirebaseHelper()
        {
            _firebaseClient = new FirebaseClient("https://local-business-explorer-default-rtdb.firebaseio.com/");
        }

        public async Task SaveProfileData(string name, string email, string address, string age, string nationality, string skills)
        {
            await _firebaseClient
                .Child("Users")
                .Child("Profile")
                .PutAsync(new
                {
                    Name = name,
                    Email = email,
                    Address = address,
                    Age = age,
                    Nationality = nationality,
                    Skills = skills
                });
        }

        public async Task<dynamic> GetProfileData()
        {
            return await _firebaseClient
                .Child("Users")
                .Child("Profile")
                .OnceSingleAsync<dynamic>();
        }
    }
}
