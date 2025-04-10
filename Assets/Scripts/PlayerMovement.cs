using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
        Vector3 moveto;
        float speed = 3f;
        public int coin;
        public Rigidbody rb;
        Vector3 motion;
        float timer;

 
        void Start()
        {
  


        }
        void Update()
        {
            //when the left mousebutton is pressed, it sets the vector2 moveto to whereever
            //was clicked. 
            if (Input.GetMouseButton(0))
            {
    
            Vector3 targetPosition = Input.mousePosition;
            targetPosition.z = Camera.main.transform.position.y;
                moveto = Camera.main.ScreenToWorldPoint(targetPosition);
              //  Debug.Log(moveto);

            }
        }
        private void FixedUpdate()
        {
            //the vector 'motion' is set to the destination minus its current position,
            //giving the direction and distance the player has to move
            motion = moveto - (Vector3)transform.position;
            //stops the player of the length of the vector is less than 0.2.
            if (motion.magnitude < 0.1)
            {
                motion = Vector3.zero;
            }
            //sets the speed the player moves at
            rb.MovePosition(rb.position + motion.normalized * speed * Time.deltaTime);
            // Debug.Log(motion);
        }
        // when the player collides with the edges of the screen, it resets the moveto vector
        //to the player's current position, stopping them.S

}
