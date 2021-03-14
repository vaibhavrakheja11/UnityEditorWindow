using UnityEngine;

namespace EditorWindowAssignment
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
    public class ObjectManager : ScriptableObject
    {
        public GameObject[] sharedObjects;

        public GameObject[] testingTimelineAndInfractions;

        public GameObject[] HazardTimelines;
    }
}