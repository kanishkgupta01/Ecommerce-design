namespace Ecom_RajasthanRoyals.Services
{

    public interface ICategoryService
    {
        string GetNameById(int categoryId);
    }
    public class CategoryService : ICategoryService
    {
        private static readonly Dictionary<int, string> _categoryNames = new()
    {
        { 1, "Jersey" },
        { 2, "Cap" },
        { 3, "Flag" },
        { 4, "Autographed Photo" },
        { 5, "Accessories" }
    };

        public string GetNameById(int categoryId)
        {
            return _categoryNames.TryGetValue(categoryId, out var name)
                ? name
                : "Unknown";
        }
    }
}
