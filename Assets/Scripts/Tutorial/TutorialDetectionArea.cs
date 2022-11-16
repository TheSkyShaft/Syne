using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDetectionArea : MonoBehaviour
{
    public string textLine1, textLine2, textLine3, textLine4;
    private Text tutorialCanvas;
    private void Start() {
        tutorialCanvas = transform.parent.parent.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>();
    }
    private void OnTriggerEnter(Collider other) {
        tutorialCanvas.transform.parent.gameObject.SetActive(true);
        tutorialCanvas.text = textLine1 + "\n" + textLine2 + "\n" + textLine3 + "\n" + textLine4;
    }
    private void OnTriggerExit(Collider other) {
        tutorialCanvas.transform.parent.gameObject.SetActive(false);
    }
}
