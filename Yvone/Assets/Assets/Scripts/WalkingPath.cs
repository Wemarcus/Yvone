using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class WalkingPath : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform[] MultipleTarget;                                    // target to aim for
        public Transform Currtarget;
        public int i;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updateRotation = false;
            agent.updatePosition = true;
        }


        private void Update()
        {
            if (Currtarget != null)
            {
                agent.SetDestination(Currtarget.position);
            }

            if (agent.remainingDistance > agent.stoppingDistance)
            {
                character.Move(agent.desiredVelocity, false, false);
            }
            else if (!agent.pathPending)
            {
                character.Move(Vector3.zero, false, false);
                //Debug.Log("Posizione raggiunta..." + i);

                if (i < (MultipleTarget.Length-1))
                {
                    i = i + 1;
                    SetTarget(MultipleTarget[i]);
                }
                else
                {
                    i = 0;
                    SetTarget(MultipleTarget[i]);
                }
            }
        }


        public void SetTarget(Transform Currtarget)
        {
            this.Currtarget = Currtarget;
            //Debug.Log("Nuova posizione settata: " + i);
        }
    }
}
