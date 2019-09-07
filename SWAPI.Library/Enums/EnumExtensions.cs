namespace SWAPI.Library.Enums
{
    public static class EnumExtensions
    {
        public static string GetName(this Resource resource)
        {
            return resource.ToString().ToLower();
        }
    }
}
