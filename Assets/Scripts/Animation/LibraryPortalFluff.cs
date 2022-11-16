using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryPortalFluff : MonoBehaviour
{
    public List<GameObject> objectsToActivate;
    public Material materialToChangeTo;
    public GameObject particleSystemMaterialChange;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Level2Complete", 0) == 1){
            foreach (GameObject item in objectsToActivate)
            {
                item.SetActive(true);
            }
            particleSystemMaterialChange.GetComponent<ParticleSystemRenderer>().material = materialToChangeTo;
        }
    }
}
