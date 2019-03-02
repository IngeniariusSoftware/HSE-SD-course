
namespace SerializationXPath
{
    using System.Collections.Generic;
    using System.Linq;

    public class Customer
    {
        public string FullName;

        public string INN;

        public string KPP;

        public List<Position> Positions = new List<Position>();

        public Customer()
        {
        }

        public Customer(string fullName, string inn, string kpp)
        {
            FullName = fullName;
            INN = inn;
            KPP = kpp;
        }

        public int PositionCount;

        public double Average(string prefix)
        {
            int positionCount = Positions.Count(x => x.Code != null && x.Code.StartsWith(prefix));
            if (positionCount != 0)
            {
                return Positions.Where(x => x.Code != null && x.Code.StartsWith(prefix)).Sum(x => x.Cost)
                       / positionCount;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}