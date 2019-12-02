using Library.Base;
using NaughtyAttributes;
using UnityEngine;

namespace Library.Data.Missions
{
    [CreateAssetMenu(menuName = "Mission", fileName = "New Mission")]
    public class Mission : BaseScriptableObject
    {
        public string missionDescription;
        public int missionGoal;
        public ushort reward;
        public bool active;

        [Dropdown("MissionType")]public MissionType missionType;
        public enum MissionType
        {
            Kill,
            Collect
        }
    }
}
