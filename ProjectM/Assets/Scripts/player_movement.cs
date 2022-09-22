using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player_movement : MonoBehaviour
{

    NavMeshAgent agent;

    public float rotateSpeed = 0.1f;
    float rotateVelocity;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            //Check if the raycast from the camera hits the navmesh from the map
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                //Have the player move to raycast point
                agent.SetDestination(hit.point);

                //Rotate
                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(
                transform.eulerAngles.y,
                rotationToLookAt.eulerAngles.y, 
                ref rotateVelocity, 
                rotateSpeed * (Time.deltaTime *5)
                );

                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }
        }
    }
}
