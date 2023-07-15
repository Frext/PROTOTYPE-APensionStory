using UnityEngine;

namespace _Project.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float rangeX, rangeY;

        
        float minX, maxX, minY, maxY;
        Vector2 lastMousePosition;
        bool isLeftMouseButtonPressed;
        
        private float smoothTime = 0.05f;
        private Vector3 velocity = Vector3.zero;
        
        void Start()
        {
            var position = gameObject.transform.position;
            
            minX = position.x - rangeX;
            maxX = position.x + rangeX;
            minY = position.y - rangeY;
            maxY = position.y + rangeY;
            
            lastMousePosition = Input.mousePosition;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isLeftMouseButtonPressed = true;
                lastMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isLeftMouseButtonPressed = false;
            }

            if (isLeftMouseButtonPressed)
            {
                Vector2 currentMousePosition = Input.mousePosition;
                Vector2 mouseDelta = currentMousePosition - lastMousePosition;
                mouseDelta /= 8;

                Vector3 constrainedPos = gameObject.transform.position;
                constrainedPos.x = Mathf.Clamp(gameObject.transform.position.x + mouseDelta.x, minX, maxX);
                constrainedPos.y = Mathf.Clamp(gameObject.transform.position.y - mouseDelta.y, minY, maxY);
                
                transform.position = Vector3.SmoothDamp(transform.position, constrainedPos, ref velocity, smoothTime);

                lastMousePosition = currentMousePosition;
            }
        }
    }
}
