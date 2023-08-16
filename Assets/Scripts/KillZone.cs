using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CharacterScriptController controller =
                collision.GetComponent<CharacterScriptController>();
            controller.Die();
        }
    }
}
