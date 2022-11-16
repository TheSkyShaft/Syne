using UnityEngine;

public class Fredrikprograms_ParticleTrigger : MonoBehaviour
{

    public GameObject librarianMesh;
    public ParticleSystem deathParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            deathParticle.Play();
            librarianMesh.SetActive(false);
        }
    }
}
