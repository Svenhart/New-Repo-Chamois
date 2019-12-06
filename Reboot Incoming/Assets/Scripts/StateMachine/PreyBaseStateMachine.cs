using Ai;
using UnityEngine;
using UnityEngine.AI;

namespace StateMachine
{
    public class PreyBaseStateMachine : UnityEngine.StateMachineBehaviour
    {
        public GameObject prey;
        public GameObject player;
        public PreyAi preyAi;
        public GameObject[] wayPoints;
        public int currentWayPoint;
        public NavMeshAgent agent;    

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            this.prey = animator.gameObject;
            this.preyAi = prey.GetComponent<PreyAi>();
            this.player = preyAi.player;
            this.wayPoints = preyAi.wayPoints;
            this.currentWayPoint = preyAi.currentWayPoint;
            this.agent = preyAi.GetNavMeshAgent();
        }
    }
}
