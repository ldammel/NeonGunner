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
        public string currentMissionStatus;
        public ushort reward;

        [Dropdown("Rarity")]public MissionType missionType;
        public enum MissionType
        {
            Kill,
            Collect
        }
    }
}
