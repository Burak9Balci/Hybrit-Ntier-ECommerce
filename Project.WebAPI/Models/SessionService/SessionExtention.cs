using Newtonsoft.Json;

namespace Project.WebAPI.Models.SessionService
{
    public static class SessionExtention
    {
        public static void SetObject(this ISession session,string key,object value)
        {
            string jsonValue = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonValue);
        }

        public static T GetObject<T>(ISession session,string key) where T : class 
        {
            string jsonObject = session.GetString(key);
            if (!string.IsNullOrEmpty(jsonObject))
            {
                T obje = JsonConvert.DeserializeObject<T>(jsonObject);
                return obje;
            }
            return null;
        }
    }
}
