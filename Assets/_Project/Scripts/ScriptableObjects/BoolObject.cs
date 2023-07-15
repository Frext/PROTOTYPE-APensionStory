using UnityEngine;

namespace _Project.Scripts.ScriptableObjects
{
    [CreateAssetMenu]
    public class BoolObject : ScriptableObject
    {
        public bool value;

        public void ToggleState()
        {
            value = !value;
        }
    }
}