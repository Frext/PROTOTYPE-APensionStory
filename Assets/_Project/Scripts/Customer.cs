using System.Collections;
using _Project.Scripts.ScriptableObjects;
using UnityEngine;

namespace _Project.Scripts
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] private RoomKeeper roomKeeperScript;
        [SerializeField] private IntObject moneySO;
        [SerializeField] private CompanyObject companyObjectSO;
        [Space]
        
        [SerializeField] private float stayDuration = 15; 
        [SerializeField] private Vector3 waitPos;
        [SerializeField] private Vector3 outPos;
        
        private Vector3 target;
        private Room selectedRoom;

        
        void Start()
        {
            target = waitPos;

            StartCoroutine(MoveInOrder());
        }

        private IEnumerator MoveInOrder()
        {
            while (true)
            {
                if (MoveTo(target))
                {
                    if (target == waitPos)
                    {
                        if (roomKeeperScript.IsThereAvailableRoom())
                        {
                            selectedRoom = roomKeeperScript.GetRoom();

                            target = selectedRoom.transform.position;
                        }
                        else
                        {
                            target = outPos;
                        }
                        
                        yield return new WaitForSeconds(1f);
                    }
                    else if (target != outPos)
                    {
                        yield return new WaitForSeconds(stayDuration);

                        roomKeeperScript.LeaveRoom(selectedRoom);
                        moneySO.value += (int)stayDuration * 2;
                        companyObjectSO.companyValue += (int)stayDuration * 2 / 5;
                        
                        target = outPos;
                    }
                    else if (target == outPos)
                    {
                        Destroy(gameObject);
                    }
                }

                yield return new WaitForSeconds(Time.deltaTime);
            }
        }

        private bool MoveTo(Vector3 target)
        {
            if (Vector3.Distance(transform.position, target) > 0.001f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
                return false;
            }

            return true;
        }
    }
}
