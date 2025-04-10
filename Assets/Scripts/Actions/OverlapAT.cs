using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class OverlapAT : ActionTask {

        public float radius;
        Vector3 sphereRadius;
        public BBParameter<bool> sensedPlayer;
		public Transform guardTransform;
		
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			sphereRadius = new Vector3(radius, radius, radius) + guardTransform.position;
			Debug.DrawLine(guardTransform.position, sphereRadius);
			if (Physics.OverlapSphere(guardTransform.position, radius).Length > 0)
			{
				Debug.Log("Player in sphere");

				sensedPlayer.value = true;
			}
			else { Debug.Log("player out of sphere"); sensedPlayer.value = false; }
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}