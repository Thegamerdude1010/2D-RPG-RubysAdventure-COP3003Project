using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All C# scripts are subclasses of the MonoBehaviour class.
public class DamageZone : MonoBehaviour
{

    // The OnTriggerStay2D function allows for continuous damage.
    // When Ruby enters the gameobjects collider box, she will continue to take
    // damage until she is moved outside of the collider (Unity Learn).
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            // This calls the RubyController class' change health function
            controller.ChangeHealth(-1);
        }
    }
}
