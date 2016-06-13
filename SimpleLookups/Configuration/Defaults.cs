namespace SimpleLookups.Configuration
{
    internal class Defaults
    {
        public const string IdColumnSuffix = "Id";
        public const string NameColumnSuffix = "Name";
        public const string DescriptionColumnSuffix = "Description";
        public const string CodeColumnSuffix = "Code";
        public const string ActiveColumnName = "Active";
        public const bool PrefixColumnsWithTableName = true;

        public const bool EnableCaching = true;
        public const int CacheRefreshPeriod = 1800;
    }
}
