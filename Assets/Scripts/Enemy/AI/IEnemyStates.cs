using UnityEngine;
using System.Collections;

namespace UnityActionRPG.AI
{
    public interface IEnemyStates
    {
        void UpdateState();

        void OnTriggerEnter(Collider other);

        void ToPatrolState();

        void ToChaseState();

        void ToIdleState();
    }
}