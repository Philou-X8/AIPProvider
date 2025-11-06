using AIPProvider.src.Cores;
using AIPProvider.src.DataCenter.Tools;
using AIPProvider.src.Utilities;
using Recorder;
using System.Runtime.Loader;
using UnityGERunner;
using UnityGERunner.UnityApplication;

namespace AIPLoader
{
    class AIPProvider : IAIPProvider
    {
        Utils? utils;
        GroundUtils? gUtils;

        MasterCore? core;

        public override SetupActions Start(SetupInfo info)
        {
            utils = new Utils(info, Log, DebugShape, DebugShape, RemoveDebugShape, Graph);
            gUtils = new GroundUtils(Linecast, HeightAt);
            core = new MasterCore(utils, gUtils);

            return core.Start(info);
        }

        public override InboundState Update(OutboundState state)
        {
            
            return core?.Update(state) ?? new InboundState();
        }
    }
}
