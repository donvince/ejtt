using System;

namespace Interview
{
    internal class DataItem : IStoreable
    {
        public IComparable Id { get; set; }

        public string Name { get; set; }

        public DataItem(IComparable id)
        {
            Id = id;
        }
    }
}