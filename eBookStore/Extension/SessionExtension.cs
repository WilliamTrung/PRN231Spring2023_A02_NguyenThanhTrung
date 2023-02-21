using ClientRepository.Models;
using NuGet.Protocol;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace eBookStore.Extension
{
    public static class SessionExtension
    {
        public static void SetLoginUser(this ISession session, User member)
        {
            session.SetString("login-user", member.ToJson());
        }
        public static User? GetLoginUser(this ISession session)
        {
            var member_json = session.GetString("login-user");
            if (member_json == null)
            {
                return null;
            }
            else
            {
                var member = JsonSerializer.Deserialize<User>(member_json);
                return member;
            }
        }

    }
}
