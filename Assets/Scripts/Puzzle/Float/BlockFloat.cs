using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFloat : MonoBehaviour
{
    private UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter thirdPers;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            if(thirdPers == null){
                thirdPers = other.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>();
            }
            thirdPers.DisableFloating();
        }
    }
}
