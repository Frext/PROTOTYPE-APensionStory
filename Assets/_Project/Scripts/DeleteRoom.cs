using UnityEngine;

namespace _Project.Scripts
{
    public class DeleteRoom : MonoBehaviour
    {
        [SerializeField] private GameObject roomGo;

        public void Delete()
        {
            Destroy(roomGo);
        }
    }
}
