using AIPProvider.src.SituationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityGERunner;

namespace AIPProvider.src.SituationData.TrackFiles
{

    // carries data needed for conversion between 
    internal struct ActivePassiveCarrier
    {
        public int id;
        public float updateTime;
        public PassiveTrackState passiveState;
        public Transform trail; // past positions and rotations in absolute, index 0 most recent
        public Vector3 trailVel; // velocity history
        // angular
    }


    internal struct VisualPassiveCarrier
    {
        public int id;
        public float updateTime;
        //public PassiveTrackState passiveState;
        public Transform position; // position
        public Vector3 velocity; // 
        // angular
    }

    internal class DataCarrier
    {
    }
}
