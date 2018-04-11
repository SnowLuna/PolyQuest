using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

    NavMeshAgent agent;
    Transform target;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }
	
    //Move to coordinates
	public void MoveToPoint (Vector3 point)
    {
        agent.SetDestination(point);
    }

    //Follows target if he moves, once the right mouse button is clicked
    public void FollowTarget (Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;
        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }

    //When target is moving, player will still face the target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;  //Get a direction towards target
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));   //Find how to rotate ourselves to look at that direction
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);   //Smoothen the rotation
    }
}
