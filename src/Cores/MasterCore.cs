using AIPProvider.src.SituationData;
using AIPProvider.src.SituationData.Tools;
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
        private SetupInfo simInfo;
        private SimData simData;

        private SimActions simActions;

        private CoreDefault coreDefault;

        private DataCenter dataCenter;

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
            simActions = new SimActions();

            return simActions.Convert();
        }

        private void PhaseScan()
        {
            // run all the passive updates of the DataCenter
        }
        private void PhaseNetwork()
        {
            // potential feature:
            // send and recieve commands from a websocket
        }

        private void PhaseProtocol()
        {

        }
        private void PhaseCombat()
        {

        }
        private void PhaseNavigation()
        {

        }
        private void PhaseDefence()
        {

        }
    }
}
