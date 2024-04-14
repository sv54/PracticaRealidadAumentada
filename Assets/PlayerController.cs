using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    public UnityEngine.AI.NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        // Check for mouse input (for PC)
        if (Input.GetMouseButtonDown(0))
        {
            MovePlayerToMousePosition();
        }

        // Check for touch input (for Android)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            MovePlayerToTouchPosition();
        }
    }

    void MovePlayerToMousePosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }

    void MovePlayerToTouchPosition()
    {
        // Convert touch position to a ray
        Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }
}