using UnityEngine;

namespace RPG.Player
{
    [AddComponentMenu("RPG/Player/Movement")]
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [Header("Speed Vars")]
        //value variables 
        public float moveSpeed;
        public float walkSpeed, runSpeed, crouchSpeed, jumpSpeed;

        private float _gravity = 20;
        //Struct - Contains Multiple Variables (3 floats)
        private Vector3 _moveDir;
        //referance Varable
        private CharacterController _charC;

        private void Start()
        {
            _charC = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (!PlayerHandler.isDead)//if we are alive rotate camera and player
            {
                if (_charC.isGrounded)
                {
                    //set speed
                    if (Input.GetButton("Sprint"))
                    {
                        moveSpeed = runSpeed;
                    }

                    else if (Input.GetButton("Crouch"))
                    {
                        moveSpeed = crouchSpeed;
                    }

                    else
                    {
                        moveSpeed = walkSpeed;
                    }

                    //calculate move this direction based off inputs
                    _moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed);
                    if (Input.GetButton("Jump"))
                    {
                        _moveDir.y = jumpSpeed;
                    }
                }
            }
            if(PlayerHandler.isDead)
            {
                _moveDir = Vector3.zero;
            }
            //regardless if we are grounded or not
            //apply gravity
            _moveDir.y -= _gravity * Time.deltaTime;
            //apply movement
            _charC.Move(_moveDir * Time.deltaTime);
        }
    }

}