using AIPProvider.src.DataCenter.Tools;
using AIPProvider.src.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityGERunner.UnityApplication;

namespace AIPProvider.src.Cores
{
    internal class CoreDefault
    {
        private Utils utils;
        private SetupInfo simInfo;
        private SimData simData;

        public CoreDefault(Utils utilities)
        {
            utils = utilities;
        }

        public SetupActions Start(SetupInfo info)
        {
            simInfo = info;

            return new SetupActions();
        }

        public InboundState Update(SimData data)
        {
            simData = data;

            return new InboundState();
        }
    }
}
