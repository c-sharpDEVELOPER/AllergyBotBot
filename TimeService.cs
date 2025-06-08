using NodaTime;
using NodaTime.Text;
using System;
using System.Globalization;

public class TimeService
{
    private readonly DateTimeZone _moscowZone = DateTimeZoneProviders.Tzdb["Europe/Moscow"];

    public string GetMoscowTime()
    {
        var now = SystemClock.Instance.GetCurrentInstant();
        var moscowTime = now.InZone(_moscowZone);
        return moscowTime.ToString("HH:mm:ss dd.MM.yyyy", CultureInfo.InvariantCulture);
    }
}