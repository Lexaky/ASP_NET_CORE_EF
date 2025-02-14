// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
namespace ASP_NET_CORE_EF.Security
{
    public class CacheTokenHelper : ICacheTokenHelper
    {
        public TimeSpan CacheTimeCalc(DateTime validTo)
        {
            return TimeSpan.FromMinutes((validTo - DateTime.UtcNow).Minutes + 1);
        }
    }
}