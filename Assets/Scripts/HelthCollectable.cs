using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelthCollectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log("triggerと接触"+ other);
       RubyController rubyCon = other.GetComponent<RubyController>();
       if(rubyCon != null){
        if(rubyCon.health == rubyCon.maxHealth){return;}
        rubyCon.ChangeHealth(1);
        Destroy(gameObject);
       }
    }
}
