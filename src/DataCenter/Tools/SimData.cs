using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityGERunner;
using UnityGERunner.UnityApplication;

namespace AIPProvider.src.DataCenter.Tools
{
    internal class SimData
    {
        public OutboundState raw { get; }
        public SimData(OutboundState state)
        {
            raw = state;
            transform = new Transform();
            transform.position = raw.kinematics.position;
            transform.rotation = raw.kinematics.rotation;
        }
        public Transform transform { get; }
        public Vector3 position => transform.position;
        public Quaternion rotation => transform.rotation;
        public Vector3 velocity => raw.kinematics.velocity;


        //---------------------------------------------------
        // Default values, exposed for compatibility
        //---------------------------------------------------
        public Kinematics kinematics => raw.kinematics;
        public RadarState radar => raw.radar;
        public StateRWRContact[] rwrContacts => raw.rwrContacts;
        public VisuallySpottedTarget[] visualTargets => raw.visualTargets;
        public IRWeaponState ir => raw.ir;
        public DatalinkState datalink => raw.datalink;
        public KillFeedEntry[] killFeed => raw.killFeed;

        public string[] weapons => raw.weapons;
        public int selectedWeapon => raw.selectedWeapon;

        public int flareCount => raw.flareCount;
        public int chaffCount => raw.chaffCount;
        public int gunAmmo => raw.gunAmmo;

        public float fuel => raw.fuel;
        public float time => raw.time;
    }
}
