using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts
{
    [Serializable]
    public class Room
    {
        public Transform transform;
        public bool isBusy;
    }
    
    public class RoomKeeper : MonoBehaviour
    {
        public List<Room> roomsList = new ();

        void Start()
        {
            StartCoroutine(UpdateRooms());
        }

        private IEnumerator UpdateRooms()
        {
            while (true)
            {
                for (int i = 0; i < roomsList.Count; i++)
                {
                    if (roomsList[i].transform == null)
                    {
                        roomsList.RemoveAt(i);
                    }
                }
                
                foreach (var go in GameObject.FindGameObjectsWithTag("Room"))
                {
                    if (roomsList.All(room => room.transform != go.transform))
                        roomsList.Add(new Room { transform = go.transform });
                }
                
                yield return new WaitForSeconds(1);
            }
        }

        public Room GetRoom()
        {
            foreach (var room in roomsList)
            {
                if (!room.isBusy)
                {
                    room.isBusy = true;
                    
                    return room;
                }
            }

            return null;
        }

        public void LeaveRoom(Room room)
        {
            room.isBusy = false;
        }
        
        public bool IsThereAvailableRoom()
        {
            foreach (var room in roomsList)
            {
                if (!room.isBusy)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
