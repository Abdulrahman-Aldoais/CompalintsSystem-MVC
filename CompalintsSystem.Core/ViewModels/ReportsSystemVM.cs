using CompalintsSystem.Core.Statistics;
using System.Collections.Generic;

namespace CompalintsSystem.Core.ViewModels
{
    public class ReportsSystemVM
    {
        public IEnumerable<StutusCompalintStatistic> StutusCompalintStatistics { get; set; }
        public IEnumerable<TotalCommunicationStatistic> TypeCommunicationStatistics { get; set; }
        public IEnumerable<TypeCompalintStatistic> TypeCompalintStatistics { get; set; }
        public IEnumerable<UserByRolesStatistic> UserByRolesStatistics { get; set; }
        public IEnumerable<UsersInStatistic> UsersInStatistics { get; set; }
    }
}
