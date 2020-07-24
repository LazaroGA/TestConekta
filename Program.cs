using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConekta
{
    class Program
    {
        static void Main(string[] args)
        {
            Imager imager = new Imager();

            do
            {
                imager.GetCommand();
                if (imager.Command.IsValid)
                {
                    imager.ExecuteCommand();
                }
            } while (true);
        }
    }
}
