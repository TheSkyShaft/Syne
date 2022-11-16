using UnityEngine;

public class InteractableButton : MonoBehaviour
{
    public GameObject risingPlatforms;
    private bool canPressButton;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.F) && canPressButton){
            
            var colorChange = gameObject.GetComponent<Renderer>();
            risingPlatforms.GetComponent<Animator>().SetBool("Interacted", true);

            Debug.Log("Anim should be played");

            colorChange.material.SetColor("_EmissionColor", Color.green);
        }    
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            canPressButton = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
        {
            canPressButton = false;
        }
    }
}
