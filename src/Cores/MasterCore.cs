using AIPProvider.src.DataCenter.Tools;
using AIPProvider.src.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using UnityGERunner;
using UnityGERunner.UnityApplication;

namespace AIPProvider.src.Cores
{
    internal struct SimActions
    {
        public List<int> actions;
        public float throttle;
        public Vector3 pyr;
        public Vector3 lookDir;

        public SimActions()
        {
            actions = new List<int>();
            throttle = 100;
            pyr = Vector3.zero;
            lookDir = Vector3.zero;
        }

        public InboundState Convert()
        {
            return new InboundState
            {
                pyr = this.pyr,
                throttle = this.throttle,
                irLookDir = this.lookDir,
                events = actions.ToArray()
            };
        }
    }

    internal class MasterCore
    {
        private Utils utils;
        private GroundUtils gUtils;
        SetupInfo simInfo;
        SimData simData;

        CoreDefault coreDefault;

        public MasterCore(Utils utilities, GroundUtils groundUtils) 
        {
            utils = utilities;
            gUtils = groundUtils;
            simData = new SimData(new OutboundState());

            coreDefault = new CoreDefault(utils);
        }

        public SetupActions Start(SetupInfo info)
        {
            simInfo = info;

            return new SetupActions
            {
                hardpoints = utils.hardpoint.MakeHardpointList(),
                name = "id_" + info.id.ToString(),
            };
        }

        public InboundState Update(OutboundState state)
        {
            simData = new SimData(state);


            return new InboundState
            {
                pyr = new NetVector { x = 0, y = 0, z = 0 },
                throttle = 100,
            };
        }
    }
}
