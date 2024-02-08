using UnityEngine;

namespace ThrillTrail.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float corridorWidth = 2f; // Adjust based on your corridor width
        private int currentCorridor = 1; // Initial corridor index

        private bool activated = false;
        void Update()
        {
            if (activated && Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    MovePlayer(touch.position);
                }
            }
        }

        void MovePlayer(Vector2 touchPosition)
        {
            float screenCenterX = Screen.width / 2f;

            if (touchPosition.x < screenCenterX - corridorWidth && currentCorridor > 0)
            {
                // Move player to the left corridor
                MoveToCorridor(currentCorridor - 1);
            }
            else if (touchPosition.x > screenCenterX + corridorWidth && currentCorridor < 2)
            {
                // Move player to the right corridor
                MoveToCorridor(currentCorridor + 1);
            }
        }

        void MoveToCorridor(int targetCorridor)
        {
            // Adjust the position based on the target corridor
            float targetX = (targetCorridor - 1) * corridorWidth;
            transform.position = new Vector3(targetX, transform.position.y, transform.position.z);

            currentCorridor = targetCorridor;
        }
        
        public void Activate(bool value)
        {
            activated = value;
        }
    }
}