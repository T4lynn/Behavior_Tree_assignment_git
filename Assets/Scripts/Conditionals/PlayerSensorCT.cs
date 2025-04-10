using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class PlayerSensorCT : ConditionTask {

        public float radius;
        Vector3 sphereRadius;
        public BBParameter<bool> sensedPlayer;
		public Transform guardTransform;
		public Collider[] hitColliders;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled. 
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
            sphereRadius = new Vector3(guardTransform.position.x + radius, guardTransform.position.y + radius, guardTransform.position.z + radius);
			hitColliders = Physics.OverlapSphere(guardTransform.position, radius);
            Debug.DrawLine(guardTransform.position, sphereRadius, Color.red);

            if ( hitColliders.Length > 0)
            {
                Debug.Log("Player in sphere");

                sensedPlayer.value = true;
				return true;
            }
            else 
			{ 
				Debug.Log("player out of sphere");
				sensedPlayer.value = false;
                return false;
            }
			
		}
	}
}