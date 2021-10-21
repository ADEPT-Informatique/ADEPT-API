using ADEPT_API.DATACONTRACTS.Dto.Queries;
using System;

namespace ADEPT_API.LIBRARY.Utilities
{
    public static class EpochUtility
    {
        public static TimestampQueryDto ObtainTimestampQueryForApplicationCreation()
        {
            var result = new TimestampQueryDto
            {
                MaxTimestampUtc = GetTimestampUtcSeconds()
            };

            if (DateTime.UtcNow.Month < 7) // 6 = July
            {
                result.MinTimestampUtc = ConvertDateTimeToTimestamp(new DateTime(DateTime.UtcNow.Year, 1, 1));
            }
            else
            {
                result.MinTimestampUtc = ConvertDateTimeToTimestamp(new DateTime(DateTime.UtcNow.Year, 7, 1));
            }

            return result;
        }

        public static long ConvertDateTimeToTimestamp(DateTime dateTime)
        {
            var timestamp = new DateTimeOffset(dateTime.ToUniversalTime()).ToUnixTimeSeconds();
            return timestamp;
        }

        public static long GetTimestampUtcSeconds()
        {
            var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            return timestamp;
        }
    }
}
