using UnityEngine;
using UnityEngine.AI;

namespace Ai
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class PreyAi : MonoBehaviour {

        [SerializeField]private Animator stateMachine;
        [SerializeField]private NavMeshAgent agent;
        public GameObject player;
        public GameObject[] wayPoints;
        public int currentWayPoint;
        
        
        private static readonly int Distance = Animator.StringToHash("Distance");
        private static readonly int Captured = Animator.StringToHash("Captured");

        private void Awake()
        {
            this.player = GameObject.FindGameObjectWithTag("Player");
            this.stateMachine = this.GetComponent<Animator>();
            //this.stateMachine.runtimeAnimatorController = Resources.Load("Assets/Scripts/StateMachine/FiniteStateMachine") as RuntimeAnimatorController;
            this.agent = GetComponent<NavMeshAgent>();
            
        }

        // Use this for initialization
        void Start () {
            this.player = GameObject.FindGameObjectWithTag("Player");
            this.stateMachine = this.GetComponent<Animator>();
            //this.stateMachine.runtimeAnimatorController = Resources.Load("Assets/Scripts/StateMachine/FiniteStateMachine") as RuntimeAnimatorController;
        
        }

        public GameObject GetPlayer()
        {
            return player;
        }

        public GameObject[] GetWayPoints()
        {
            return wayPoints;
        }

        public NavMeshAgent GetNavMeshAgent()
        {
            return agent;
        }
        
        // Update is called once per frame
        void Update () {
            this.stateMachine.SetFloat(Distance,Vector3.Distance(transform.position,player.transform.position));
        }

        public void Respawn()
        {
            this.stateMachine.SetTrigger(Captured);
        }
    }
}
