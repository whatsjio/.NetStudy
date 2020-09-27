using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study委托事件
{
    struct Currency
    {
        public uint Dollars;
        public ushort Cents;
        public Currency(uint dollars,ushort cents)
        {
            Dollars = dollars;
            Cents = cents;
        }
        public override string ToString() => $"${Dollars}.{Cents,2:00}";
        public static string GetCurrencyUnit() => "Dollars";
        public static explicit operator Currency(float value) {
            checked
            {
                uint dollars = (uint)value;
                ushort cents = (ushort)((value - dollars) * 100);
                return new Currency(dollars, cents);
            }

        }

      
    }
}
