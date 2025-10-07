using System;

namespace EmploTaskTwo.Core.Interfaces
{
    public interface IDateProvider
    {
        DateTime Now { get; }
        int CurrentYear { get; }
    }
}
