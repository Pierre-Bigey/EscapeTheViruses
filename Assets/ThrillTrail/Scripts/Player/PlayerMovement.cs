using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThrillTrail.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float corridorWidth = 2f; // Adjust based on your corridor width
        private int currentCorridor = 1; // Initial corridor index

        [SerializeField] private GameObject LittleBoy;
        //The distance needed to reach a new corridor
        [SerializeField] private float turnDistance = 10f;

        private float TargetX;
        private bool TurningLeft = false;
        private bool TurningRight = false;

        public void MovePlayer(Vector2 touchPosition, float speed)
        {
            float screenCenterX = Screen.width / 2f;

            if (touchPosition.x < screenCenterX - corridorWidth && currentCorridor > 0)
            {
                // Move player to the left corridor
                TargetX = (currentCorridor - 2) * corridorWidth;
                currentCorridor = currentCorridor - 1;
                if (!TurningLeft)
                {
                    TurningRight = false;
                    TurningLeft = true;
                    StartCoroutine(MoveToLeft(speed));
                }
            }
            
            if (touchPosition.x > screenCenterX + corridorWidth && currentCorridor < 2)
            {
                // Move player to the right corridor
                TargetX = currentCorridor * corridorWidth;
                currentCorridor = currentCorridor + 1;
                if (!TurningRight)
                {
                    TurningLeft = false;
                    TurningRight = true;
                    StartCoroutine(MoveToRight(speed));
                }
            }
        }
        
        private IEnumerator MoveToLeft(float speed)
        {
            Vector3 targetPos = new Vector3(TargetX,0,transform.position.z + turnDistance/speed);
            LittleBoy.transform.LookAt(targetPos, Vector3.up);
            //Will stop when the player will reach the target x value
            yield return new WaitWhile(() => transform.position.x > TargetX && TurningLeft);
            
            if(!TurningLeft) yield break;
            
            TurningLeft = false;
            LittleBoy.transform.localEulerAngles = new Vector3(0,0,0);
        }
        
        private IEnumerator MoveToRight(float speed)
        {
            Vector3 targetPos = new Vector3(TargetX,0,transform.position.z + turnDistance/speed);
            LittleBoy.transform.LookAt(targetPos, Vector3.up);
            //Will stop when the player will reach the target x value
            yield return new WaitWhile(() => transform.position.x < TargetX && TurningRight);

            if (!TurningRight) yield break;
            
            TurningRight = false;
            LittleBoy.transform.localEulerAngles = new Vector3(0,0,0);
        }

        
    }
}