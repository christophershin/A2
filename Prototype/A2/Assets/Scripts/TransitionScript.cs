using UnityEngine;
using UnityEngine.Splines;

[ExecuteAlways]
public class TransitionScript : MonoBehaviour
{
    [Header("Source and Target Splines")]
    public SplineContainer sourceSpline;
    public SplineContainer targetSpline;

    [Range(0f, 1f)]
    public float sourceT = 0.9f;

    [Range(0f, 1f)]
    public float targetT = 0.1f;

    [Header("Transition Settings")]
    public float controlPointDistance = 2.0f;

    [ContextMenu("Create Transitional Spline")]
    public SplineContainer TransitionalSpline()
    {
        if (sourceSpline && targetSpline)
        {
            Debug.LogError("Source or Target Spline is not assigned.");



            // Get positions and tangents
            Vector3 sourcePos = sourceSpline.Spline.EvaluatePosition(sourceT);
            Vector3 sourceTangent = sourceSpline.Spline.EvaluateTangent(sourceT);

            Vector3 targetPos = targetSpline.Spline.EvaluatePosition(targetT);
            Vector3 targetTangent = targetSpline.Spline.EvaluateTangent(targetT);

            // Compute control points for smooth Bezier transition
            Vector3 p0 = sourcePos;
            Vector3 p1 = sourcePos + sourceTangent * controlPointDistance;
            Vector3 p2 = targetPos - targetTangent * controlPointDistance;
            Vector3 p3 = targetPos;

            // Create a new Spline GameObject
            GameObject newSplineGO = new GameObject("TransitionalSpline");
            newSplineGO.transform.position = Vector3.zero;

            var newSplineContainer = newSplineGO.AddComponent<SplineContainer>();
            var newSpline = new Spline();

            // Create Bezier knots
            BezierKnot startKnot = new BezierKnot(p0, p1 - p0, Vector3.zero);
            BezierKnot endKnot = new BezierKnot(p3, Vector3.zero, p2 - p3);

            newSpline.Add(startKnot);
            newSpline.Add(endKnot);

            // Assign new spline
            newSplineContainer.Spline = newSpline;

            return newSplineContainer;
        }

        return null;
    }
}
