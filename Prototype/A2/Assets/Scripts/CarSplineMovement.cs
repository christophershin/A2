using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.Splines.Interpolators;
using UnityEngine.Serialization;
using Interpolators = UnityEngine.Splines.Interpolators;
using Quaternion = UnityEngine.Quaternion;

namespace Unity.Splines.Examples
{
    public class CameraFollowCar : MonoBehaviour
    {

        public bool isPlayer = false;
        public Camera _cam;
        public GameObject camholder;

        public bool thirdPersonCam = false;



        private void Update()
        {

            if(isPlayer)
            {
                if (thirdPersonCam)
                {
                    float posx = transform.position.x;
                    float posy = transform.position.y;
                    float posZ = transform.position.z;



                    _cam.transform.position = camholder.transform.position;
                    _cam.transform.LookAt(new Vector3(posx, posy, posZ));

                }
            }


        }

       }
}
