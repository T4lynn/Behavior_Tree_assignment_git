using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class Timer : ConditionTask {

		public BBParameter<bool> arrivedAtPoint;
		float timer;
		public float timerFinished;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			timer = 0;
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if (arrivedAtPoint.value)
			{
				//Debug.Log("Timer Running");
				if (timer > timerFinished)
				{
					arrivedAtPoint.value = false;
					return true;
				} else { timer += Time.deltaTime; return false; }
			} else { return true; }

		}
	}
}