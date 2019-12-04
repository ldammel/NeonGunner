using Library.Base;
using NaughtyAttributes;
using UnityEngine;

namespace Library.Data.Missions
{
    [CreateAssetMenu(menuName = "Mission", fileName = "New Mission")]
    public class Mission : BaseScriptableObject
    {
        public int index;
        public string missionDescription;
        public int missionGoal;
        public ushort reward;

        [Dropdown("MissionType")]public MissionType missionType;
        public enum MissionType
        {
            Kill,
            Collect
        }
    }
}
