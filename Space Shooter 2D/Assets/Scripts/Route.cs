/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: For visualizing the Bezier Curve path (Easier to then set path).
*/

using UnityEngine;

public class Route : MonoBehaviour
{

    public Transform[] controlPoints;	// Bezier Curve controlPoints

    private Vector2 gizmosPosition;
	
	// Method to Visualize Bezier Curve 
    private void OnDrawGizmos()
    {
        for(float t = 0; t <= 1; t+= 0.05f)
        {
			// Using Cubic Bezier curve formula
			// B(t) = (1-t)^3 * P0 + 3(1-t)^2 * tP1 + 3(1-t)^1 * t^2P2 + t^3P3
			// Where t is value from 0 to 1
			
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
                3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
                Mathf.Pow(t, 3) * controlPoints[3].position;
			
			// DrawSphere(position-centre, radius) 
            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }
		
		// Drawing line from controlPoint 0 to 1
        Gizmos.DrawLine(new Vector2(controlPoints[0].position.x, controlPoints[0].position.y),
            new Vector2(controlPoints[1].position.x, controlPoints[1].position.y));
		// Drawing line from controlPoint 1 to 2
        Gizmos.DrawLine(new Vector2(controlPoints[1].position.x, controlPoints[1].position.y),
            new Vector2(controlPoints[2].position.x, controlPoints[2].position.y));	
		// Drawing line from controlPoint 2 to 3
        Gizmos.DrawLine(new Vector2(controlPoints[2].position.x, controlPoints[2].position.y),
            new Vector2(controlPoints[3].position.x, controlPoints[3].position.y));
    }
}
