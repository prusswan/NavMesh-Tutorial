using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
	public Transform target;
	
	public Camera cam;
	public NavMeshAgent agent;

	private LineRenderer line;


	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer>(); //get the line renderer
		agent = GetComponent<NavMeshAgent>(); //get the agent
		getPath();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				line.SetPosition(0, transform.position); //set the line's origin

				// MOVE OUR AGENT
				agent.SetDestination(hit.point);

				DrawPath(agent.path);
			}
		}
		
	}

	void getPath(){
		line.SetPosition(0, transform.position); //set the line's origin

		agent.SetDestination(target.position); //create the path
		//yield WaitForEndOfFrame(); //wait for the path to generate


		DrawPath(agent.path);

		//agent.Stop();//add this if you don't want to move the agent
	}

	void DrawPath(NavMeshPath path){
		if(path.corners.Length < 2) //if the path has 1 or no corners, there is no need
			return;

		line.positionCount = path.corners.Length; //set the array of positions to the amount of corners

		// for(var i = 1; i < path.corners.Length; i++){
			// line.SetPosition(i, path.corners[i]); //go through each corner and set that to the line renderer's position
		//}
		line.SetPositions(path.corners);
	}
}
