using UnityEngine;

public class StepController : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] rightSteps;

    [SerializeField]
    private AudioClip[] leftSteps;

    [SerializeField]
    private AudioSource jumpsAudioSource;

    private bool _isCurrentLegRight;

    public void PlayStepSound()
    {
        jumpsAudioSource.PlayOneShot(_isCurrentLegRight
            ? rightSteps[Random.Range(0, rightSteps.Length)]
            : leftSteps[Random.Range(0, leftSteps.Length)]);
        
        _isCurrentLegRight = !_isCurrentLegRight;
    }
}