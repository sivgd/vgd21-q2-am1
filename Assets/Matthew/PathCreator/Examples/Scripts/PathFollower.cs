﻿using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;
        private SpriteRenderer sr;
        private float lastPosition;
        private float currentPosition;
        public Transform transformPos;

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
            sr = GetComponent<SpriteRenderer>();

            lastPosition = transformPos.position.x;
        }

        void Update()
        {
            //Log current position
            currentPosition = transformPos.position.x;
            

            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                // Check to see if object is moving left or right
                //To see if sprite should be flipped
                if (currentPosition < lastPosition)
                {
                    sr.flipX = true;
                    
                }
                else if(currentPosition > lastPosition)
                {
                    sr.flipX = false;
                }
                else
                {
                    
                    sr.flipX = false;
                }
                if (gameObject.GetComponent<EnemyHealth>().isTank)
                {
                    sr.flipX = !sr.flipX;
                }
            }
            //Log position of "last frame"
            lastPosition = currentPosition;
            
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}