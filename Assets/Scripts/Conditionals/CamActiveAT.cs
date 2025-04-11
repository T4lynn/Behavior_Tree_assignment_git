using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class CamActiveAT : ActionTask {

		public GameObject camActive;
		public  GameObject camInactive;
		public Collider[] hitCollidier;
		public Vector3 center;
		public Vector3 halfExtents;
        public BBParameter<GameObject> securityGuard;
        Blackboard guardBlackboard;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
           
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			//camActive.SetActive(true);
			//camInactive.SetActive(false);


            guardBlackboard = securityGuard.value.GetComponent<Blackboard>();

            hitCollidier = Physics.OverlapBox(center, halfExtents);

			Debug.DrawLine(center, halfExtents);
            if (hitCollidier.Length > 0)
            {
                Debug.Log("Player visible");

				guardBlackboard.SetVariableValue("sensedPlayer", true);
               
                
            }
            else
            {
                Debug.Log("player not visible");
               guardBlackboard.SetVariableValue("sensedPlayer", false);
                
            }


        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

	}
}