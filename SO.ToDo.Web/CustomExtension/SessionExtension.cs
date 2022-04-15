using Newtonsoft.Json;

namespace SO.ToDo.Web.CustomExtension
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string incomingData = JsonConvert.SerializeObject(value);
            session.SetString(key, incomingData);
        }

        public static T GetObject<T>(this ISession session, string key) where T : class, new()
        {
            string incomingData = session.GetString(key);
            if (incomingData != null)
            {
                return JsonConvert.DeserializeObject<T>(incomingData);
            }

            return null;
        }
    }
}
