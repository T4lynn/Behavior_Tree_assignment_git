using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
using System.Threading;

namespace NodeCanvas.Tasks.Actions {

	public class PatrolAT : ActionTask {
		public List<Transform> patrolPoints;
		public BBParameter<Vector3> acceleration;
		public float accelerationStrength;
		public float arrivalDistance;
		public BBParameter<bool> arrivedAtPoint;


		private int currentPatrolPointIndex = 0;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			if (!arrivedAtPoint.value)
			{
				float distanceToTarget = Vector3.Distance(patrolPoints[currentPatrolPointIndex].position, agent.transform.position);
				//Debug.Log("treasure position" + patrolPoints[currentPatrolPointIndex].position);
				//Debug.Log("distance to target" +  distanceToTarget);

				if (distanceToTarget < arrivalDistance)
				{
					arrivedAtPoint.value = true;
					//Debug.Log("Arrived = " + arrivedAtPoint.value);

					currentPatrolPointIndex++;
					if (currentPatrolPointIndex >= patrolPoints.Count)
					{
						currentPatrolPointIndex = 0;
					}




				}
				Vector3 moveDirection = patrolPoints[currentPatrolPointIndex].position - agent.transform.position;
				moveDirection = new Vector3(moveDirection.x, 0f, moveDirection.z);
				acceleration.value += moveDirection.normalized * accelerationStrength * Time.deltaTime;
			}
			EndAction(true);
            //Debug.Log("Ending Action");
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}