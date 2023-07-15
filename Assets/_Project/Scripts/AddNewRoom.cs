using UnityEngine;

namespace _Project.Scripts
{
    public class AddNewRoom : MonoBehaviour
    {
        [SerializeField] private GameObject roomPrefab;
        [SerializeField] private Vector3 spawnPoint;
        [SerializeField] private GameObject toggleDeleteButton;

        int count;
        
        public void Add()
        {
            Instantiate(roomPrefab, spawnPoint, Quaternion.identity);

            spawnPoint += new Vector3(-1.5f, 0, 0);

            count++;
            
            if (count > 2)
            {
                toggleDeleteButton.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
