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
    public class HighwayExample : MonoBehaviour
    {
        public SplineContainer container;
        public SplineContainer container2;

        public Camera _cam;
        public GameObject camholder;

        [SerializeField]
        float speed = 0.1f;
        [SerializeField]
        int _time = 3;

        public bool useTime;


        SplinePath[] paths = new SplinePath[8];
        float t = 0f;

        SplinePath path;
        SplinePath nextPath;

        public bool thirdPersonCam = false;

        float splineLength;



        private void Update()
        {

            if (thirdPersonCam)
            {
                float posx = transform.position.x;
                float posy = transform.position.y;
                float posZ = transform.position.z;



                _cam.transform.position = camholder.transform.position;
                _cam.transform.LookAt(new Vector3(posx, posy, posZ));

            }

            //t += speed * Time.deltaTime / splineLength;

            //Vector3 currentPos = path.EvaluatePosition(t);
            //transform.position = currentPos;

            //if(t>1f)
            //{
            //    t = 0;
            //}

            //Vector3 nextPos = path.EvaluatePosition(t + 0.05f);
            //Vector3 dir = nextPos - currentPos;
            //transform.rotation = Quaternion.LookRotation(dir, transform.up);



        }





        IEnumerator CarPathCoroutine()
        {


            for (int n = 0; ; ++n)
            {
                t = 0f;



                path = paths[n % 1];

                while (t <= 1f)
                {

                    var localToWorldMatrix = container.transform.localToWorldMatrix;


                    var pos = path.EvaluatePosition(t);

                    var direction = path.EvaluateTangent(t);


                    transform.position = pos;

                    Vector3 val = Vector3.Lerp(pos, pos + direction, Time.deltaTime);

                    transform.LookAt(val);

                    if (useTime)
                    {
                        float speedtime = splineLength / _time;

                        t += speedtime * Time.deltaTime;
                        Debug.Log(t);
                    }
                    else
                    {

                        t += speed * Time.deltaTime;
                    }
                    yield return null;





                    if (Input.anyKeyDown)
                    {
                        t = 0f;

                        int rand = UnityEngine.Random.Range(0, paths.Count() - 1);

                        path = paths[rand];

                        Debug.Log(UnityEngine.Random.Range(0, 3));
                    }
                }
            }
        }



        void transition()
        {

            var localToWorldMatrix = container.transform.localToWorldMatrix;

            GetComponent<TransitionScript>().sourceSpline = container;
            GetComponent<TransitionScript>().targetSpline = container2;

            var splineContainer = GetComponent<TransitionScript>().TransitionalSpline();


        }





 //       void Start()
 //       {

 //           _time *= 60;

 //           splineLength = container.CalculateLength();
 //           //path = paths[0];
 //           var localToWorldMatrix = container.transform.localToWorldMatrix;
 //           paths[3] = new SplinePath(new[]
 //           {
 //               new SplineSlice<Spline>(container.Splines[0], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container.Splines[1], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container.Splines[2], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container.Splines[3], new SplineRange(0, _time), localToWorldMatrix)


 //           });

 //           paths[2] = new SplinePath(new[]
 //           {
 //               new SplineSlice<Spline>(container.Splines[1], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container.Splines[2], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container.Splines[3], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container.Splines[0], new SplineRange(0, _time), localToWorldMatrix)


 //           });

 //           paths[1] = new SplinePath(new[]
 //           {
 //               new SplineSlice<Spline>(container.Splines[2], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container.Splines[3], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container.Splines[0], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container.Splines[1], new SplineRange(0, _time), localToWorldMatrix)


 //           });

 //           paths[0] = new SplinePath(new[]
 //           {
 //               new SplineSlice<Spline>(container.Splines[3], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container.Splines[0], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container.Splines[1], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container.Splines[2], new SplineRange(0, _time), localToWorldMatrix)


 //           });

 //           paths[7] = new SplinePath(new[]
 //{
 //               new SplineSlice<Spline>(container2.Splines[0], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container2.Splines[1], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container2.Splines[2], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container2.Splines[3], new SplineRange(0, _time), localToWorldMatrix)


 //           });

 //           paths[6] = new SplinePath(new[]
 //           {
 //               new SplineSlice<Spline>(container2.Splines[1], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container2.Splines[2], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container2.Splines[3], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container2.Splines[0], new SplineRange(0, _time), localToWorldMatrix)


 //           });

 //           paths[5] = new SplinePath(new[]
 //           {
 //               new SplineSlice<Spline>(container2.Splines[2], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container2.Splines[3], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container2.Splines[0], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container2.Splines[1], new SplineRange(0, _time), localToWorldMatrix)


 //           });

 //           paths[4] = new SplinePath(new[]
 //           {
 //               new SplineSlice<Spline>(container2.Splines[3], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container2.Splines[0], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container2.Splines[1], new SplineRange(0, _time), localToWorldMatrix),
 //               new SplineSlice<Spline>(container2.Splines[2], new SplineRange(0, _time), localToWorldMatrix)


 //           });

 //           StartCoroutine(CarPathCoroutine());
 //       }
       }
}
