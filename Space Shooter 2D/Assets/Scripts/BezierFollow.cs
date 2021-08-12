/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: Used by gameobject to follow Bezier curve path set using the Route class 
*/

using System.Collections;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{

    public Transform[] routes;
    public float speedModifier; // speed at which the gameobject moves on the Bezier curve path
    private float tParam;		// t value between 0 to 1 (from Bezier Curve formula)
    private int routeToGo;		// index of the routes array
    private bool coroutineAllowed; // for running one coroutine at a time
    private Vector2 bossPosition;



    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0; // First Bezier Curve
        tParam = 0f;
        speedModifier = 0.5f;
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false; // To run only one coroutine at a time
		
        // Variables to hold control points' positions
		Vector2 p0 = routes[routeNumber].GetChild(0).position;
        Vector2 p1 = routes[routeNumber].GetChild(1).position;
        Vector2 p2 = routes[routeNumber].GetChild(2).position;
        Vector2 p3 = routes[routeNumber].GetChild(3).position;

        // This loop calculates the Bezier Curve path and assign the position to Boss enemy 
		while(tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            bossPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;

            transform.position = bossPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;

        routeToGo += 1;

        // On reaching the last route continue from first route
		if(routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }

        coroutineAllowed = true; // To indicate first coroutine finished so next can run
    }
}