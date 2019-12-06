using System.Collections;
using System.Collections.Generic;
using Ai;
using UnityEngine;

public class Capture : MonoBehaviour
{
    private PreyAi preyAi;
    
    public Animator popUpAnimator;
    private static readonly int Captured = Animator.StringToHash("Captured");

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.GetComponent<PreyAi>()!= null )
        {
            this.preyAi = other.GetComponent<PreyAi>();
            this.preyAi.Respawn();
            this.preyAi = null;
            popUpAnimator.SetTrigger(Captured);
        }
    }
}
