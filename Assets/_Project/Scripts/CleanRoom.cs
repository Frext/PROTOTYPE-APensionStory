using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    [RequireComponent(typeof(Image))]
    public class CleanRoom : MonoBehaviour
    {
        [SerializeField] private Transform roomTransform;

        private RoomKeeper roomKeeper;
        private Image image;

        void Start()
        {
            roomKeeper = GameObject.FindGameObjectWithTag("RoomKeeper").GetComponent<RoomKeeper>();
            image = GetComponent<Image>();

            StartCoroutine(ToggleButton());
        }

        public void Clean()
        {
            roomKeeper.CleanRoom(roomTransform);
        }

        private IEnumerator ToggleButton()
        {
            while (true)
            {
                image.enabled = roomKeeper.IsClean(roomTransform);

                yield return new WaitForSeconds(0.25f);
            }
        }
    }
}
