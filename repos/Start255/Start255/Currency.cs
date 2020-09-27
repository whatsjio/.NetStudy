using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start255
{
    public struct Currency
    {
        public uint Dollars { get; }
        public ushort Cents { get; }
        public Currency(uint dollars,ushort cents)
        {
            Dollars = dollars;
            Cents = cents;
        }
        public override string ToString()
        {
            return $"{Dollars}.{Cents,-2:00}";
        }
        public static implicit operator float(Currency currency) {
            return currency.Dollars + (currency.Cents / 100.0f);
        }
    }
}
