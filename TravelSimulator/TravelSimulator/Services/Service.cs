using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data;

namespace TravelSimulator.Services
{
    class Service
    {
        private TravelSimulatorContext context;

        public Service()
        {
            this.context = new TravelSimulatorContext();
        }
    }
}
