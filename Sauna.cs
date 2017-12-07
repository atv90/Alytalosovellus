using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlytalosovellusAnneVaittinen2
{
    public class Sauna
    {
        public Boolean Switched { get; set; }
        public float SaunaLampotila { get; set; }
        public void Paalla()
        {
            Switched = true;

        }
        public void EiPaalla()
        {
            Switched = false;
        }

        public void SaunaLampotilanAsetus(int SaunaLampotilanAsetus)
        {

        }
    }
}
