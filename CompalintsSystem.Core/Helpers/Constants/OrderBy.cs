using CompalintsSystem.Core.Interfaces;

namespace CompalintsSystem
{
    public class OrderBy : IEntityBase
    {
        public int Id { get; set; }
        public const string Ascending = "ASC";
        public const string Descending = "DESC";
    }
}
