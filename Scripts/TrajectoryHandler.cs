using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryHandler : MonoBehaviour
{
    public Vector3 velocity;
    public int points;
    public Transform exitPoint;
    public Transform dotPrefab;
    private LineRenderer lineRenderer;
    private Vector3 position;
    
    private List<Transform> trajectoryDots = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = points;
        position = exitPoint.position;
        // for (int i = 0; i < points; ++i)
        // {
        //     Transform dot = Instantiate(dotPrefab, transform.position, Quaternion.identity);
        //     dot.gameObject.SetActive(false);
        //     trajectoryDots.Add(dot);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        DrawTrajectory(velocity);
    }

    void DrawTrajectory(Vector3 velocity)
    {   
        Vector3 position = exitPoint.position;
        float xpos = position.x;
        float ypos = position.y;
        float time = Time.fixedDeltaTime;

        for ( int i = 0; i < points; ++i )
        {
            time = Time.fixedDeltaTime;
            lineRenderer.SetPosition(i, position);
            velocity = velocity + Physics.gravity * time;
            xpos = xpos + velocity.x * time;
            ypos = ypos + velocity.y * time + 0.5f * Physics.gravity.y * Mathf.Pow(time, 2);
            position = new Vector3(xpos, ypos, 0);
        }
        
    }


}
