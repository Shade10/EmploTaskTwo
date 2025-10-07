using EmploTaskTwo.Core.Interfaces;
using System;

namespace EmploTaskTwo.Core.Providers
{
    public class SystemDateProvider : IDateProvider
    {
        public DateTime Now => DateTime.Now;
        public int CurrentYear => DateTime.Now.Year;
    }
}
