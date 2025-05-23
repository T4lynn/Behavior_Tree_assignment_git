using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class DeathAT : ActionTask {

		public GameObject player;
		public GameObject deathScreen;
		public GameObject securityGuard;
		public BBParameter<bool> isDead;
		public Collider[] hitColliders;
		public float radius;
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
			hitColliders = Physics.OverlapSphere(securityGuard.transform.position, radius);

            if (hitColliders.Length > 0)
            {
               // Debug.Log("Player in dead");

                isDead.value = true; 
				deathScreen.SetActive(true);
            }
            else
            {
               // Debug.Log("player is alive");
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