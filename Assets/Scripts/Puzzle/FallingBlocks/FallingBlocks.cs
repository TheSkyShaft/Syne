using UnityEngine;

public class FallingBlocks : MonoBehaviour
{
    public bool trigger;
    private Animator anim;
    public float delay = 2f, returnTime = 9;
    private float timer;

    [SerializeField] private AudioClip fallingForwardClip;
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (trigger)
        {
            timer += Time.deltaTime;
        }

        if (timer > delay)
        {
            GetComponent<Collider>().enabled = false;
            anim.SetBool("Fall", false);
        }

        if (timer > returnTime)
        {
            GetComponent<Collider>().enabled = true;
            trigger = false;
            timer = 0;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trigger = true;
            anim.SetBool("Fall", true);

            if (!audioSource.isPlaying)
            {
                audioSource.clip = fallingForwardClip;
                audioSource.Play();
            }
        }
    }
}