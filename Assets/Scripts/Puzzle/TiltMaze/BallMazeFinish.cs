using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMazeFinish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        print("Congratulations, you got a more creeps and weirdos' achivement!");
        transform.parent.GetComponent<BallMazeController>().Finished();
    }
}
