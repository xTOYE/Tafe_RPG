using UnityEngine;

namespace RPG.Player
{
    [AddComponentMenu("RPG/Player/Mouse Look")]

    public class MouseLook : MonoBehaviour
    {
        //allows to create types eg.weapon types
        public enum RotationalAxis
        {
            MouseX,
            MouseY
        }
        
        [Header("Rotations Variables")]
        //referance enum
        public RotationalAxis axis = RotationalAxis.MouseX;
        //sensitivity slider
        [Range(0,500)]
        public float sensitivity = 15;
        //how far can look up and down
        public float minY = -60, maxY = 60;

        private float _rotY;

        private void Start()
        {
            //debug so this script can be used with a rigidbody
            if(GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().freezeRotation = true;
            }
            //locks cursor so u can't move it
            Cursor.lockState = CursorLockMode.Locked;
            //so you can not see the cursor
            Cursor.visible = false;

            //checking if has camera component so can rotate on Y axis
            if(GetComponent<Camera>())
            {
                axis = RotationalAxis.MouseY;
            }
        }
        private void Update()
        {
            if(!PlayerHandler.isDead)//if we are alive rotate camera and player
            { 
            //moves camera on the X axis where ever the camera is facing is the orientation of the player
            if (axis == RotationalAxis.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime, 0);
            }
            else
            {
                _rotY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
                _rotY = Mathf.Clamp(_rotY, minY, maxY);
                transform.localEulerAngles = new Vector3(-_rotY,0,0);
            }
            }
        }
    }
}