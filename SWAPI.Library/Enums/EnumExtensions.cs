namespace SWAPI.Library.Enums
{
    public static class Extensions
    {
        public static string GetName(this Resource resource)
        {
            return resource.ToString().ToLower();
        }
    }
}
