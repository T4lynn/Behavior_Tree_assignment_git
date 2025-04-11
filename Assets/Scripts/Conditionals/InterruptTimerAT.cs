using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class InterruptTimerAT : ConditionTask {

		float timer = 0;
		float timer2 = 0;
		public float timerFinished;
		public float timerfinished2;
		public BBParameter<bool> sensedPlayer;
		
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
			
			if (timer > timerFinished )
			{
				//Debug.Log("Timer finished");

				

				if (timer2 > timerfinished2 )
				{
					timer = 0;
					timer2 = 0;
					//Debug.Log("timer2 finished");
					return true;
				} else
				{
					timer2 += Time.deltaTime;
				}
				return true; 
				
			}
			else
			{
				
				timer = timer + Time.deltaTime;
				
				return false;
			}
			
		}
	}
}