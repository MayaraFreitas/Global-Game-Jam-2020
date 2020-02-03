using System;
using System.Linq;
using UnityEngine;

namespace Assets.NewScripts
{
    public class MonsterMovement : MonoBehaviour
    {

        public GameObject[] positions;
        public float speed;
        public Animator animachar;

        private int vectorPosition;
        private Transform player;
        private Vector3 dir;
        public VisionCone visionCone;
        void Start()
        {
            transform.position = positions.First().transform.position;
            vectorPosition = 0;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            //visionCone = GetComponentInChildren<VisionCone>();
        }

        private void Update()
        {
           float step = speed * Time.deltaTime;
            
            Vector3 nextPosition = visionCone.FollowThePlayer() ? player.position : positions[vectorPosition].transform.position;

            transform.position = Vector2.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
            if (transform.position == nextPosition)
            {
                vectorPosition = vectorPosition == positions.Length - 1 ? 0 : vectorPosition + 1;

            }

            var heading = transform.position - nextPosition;
            var distance = heading.magnitude;
            var direction = heading / distance;

            if (GameObject.FindWithTag("pushable")!= null) {
                //print("andando");
                animation(direction);
            }
            

            visionCone.SetAimDirection(direction * -1);
            visionCone.SetOrigin(transform.position);
        }

        private void animation(Vector3 direction)
        {
            if (direction.y == -1)
            {
                animachar.Play("Enemy_move_up");
            }
            else if (direction.x == -1)
            {
                animachar.Play("Enemy_move_right");
            }
            else if (direction.y == 1)
            {
                animachar.Play("Enemy_move_down");
            }
            else if (direction.x == 1)
            {
                animachar.Play("Enemy_move_left");
            }
            else if(direction.x != 0 && direction.y != 0)
            {
                if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    if (direction.x < 0)
                    {
                        animachar.Play("Enemy_move_right");
                    }
                    else
                    {
                        animachar.Play("Enemy_move_left");
                    }
                }
                else
                {
                    if (direction.y < 0)
                    {
                        animachar.Play("Enemy_move_up");
                    }
                    else
                    {
                        animachar.Play("Enemy_move_down");
                    }
                }   
            }
        }
    }
}
