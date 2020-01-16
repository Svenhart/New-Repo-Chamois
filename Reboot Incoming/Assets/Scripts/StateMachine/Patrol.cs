using System;
using Ai;
using UnityEngine;
using UnityEngine.AI;

namespace StateMachine
{
	public class Patrol : PreyBaseStateMachine {
		
		private static readonly int Paused = Animator.StringToHash("Paused");

		// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			base.OnStateEnter(animator,stateInfo,layerIndex);

			if (agent.hasPath && agent.isStopped==true)
			{
				agent.isStopped = false;
				Debug.Log(prey.name+" Resuming Patrol");
			}
			else
			{
				float distance = Vector3.Distance(player.transform.position, wayPoints[0].transform.position);
	
				for (int i = 0; i < wayPoints.Length; i++)
				{
					if (Vector3.Distance(player.transform.position,wayPoints[i].transform.position)<distance)
					{
						distance = Vector3.Distance(player.transform.position, wayPoints[i].transform.position);
						currentWayPoint = i;
					}
				}

				preyAi.currentWayPoint = this.currentWayPoint;
				agent.SetDestination(this.wayPoints[this.currentWayPoint].transform.position);		
				Debug.Log(prey.name+" Going to WayPoint "+currentWayPoint);
			}

			
		}

		// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
		public override void  OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		
			if(Math.Abs(prey.transform.position.x - wayPoints[currentWayPoint].transform.position.x) < 1.5f && Math.Abs(prey.transform.position.z - wayPoints[currentWayPoint].transform.position.z) < 1.5f)
			{
				currentWayPoint++;
				currentWayPoint %= wayPoints.Length;
				preyAi.currentWayPoint = this.currentWayPoint;
				agent.SetDestination(this.wayPoints[this.currentWayPoint].transform.position);
				Debug.Log(prey.name+" Going to WayPoint "+currentWayPoint);
				animator.SetTrigger(Paused);
			}
		}

		// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
		}

		// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
		//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//
		//}

		// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
		//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//
		//}
	}
}
