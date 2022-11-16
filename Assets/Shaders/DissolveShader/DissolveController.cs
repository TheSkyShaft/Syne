using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{

    public GameObject particleFX;
    private float dissolveTimer = 1;
    public bool dissolve;
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    private bool hasSpawnedParticle;
    private GameObject prtFX;
    
    // Start is called before the first frame update
    void Start()
    {
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();

        _renderer.GetPropertyBlock(_propBlock);
        _propBlock.SetFloat("_DissolveProg", 1);
        _renderer.SetPropertyBlock(_propBlock);
    }

    // Update is called once per frame
    void Update()
    {
        if(dissolve){
            dissolveTimer -= Time.deltaTime * 0.33f;

            // Material Property Block
            _renderer.GetPropertyBlock(_propBlock);
            _propBlock.SetFloat("_DissolveProg", dissolveTimer);
            _renderer.SetPropertyBlock(_propBlock);

            if(!hasSpawnedParticle){
                prtFX = Instantiate(particleFX, transform.position, Quaternion.identity);
                hasSpawnedParticle = true;
            }
            if(dissolveTimer < 0){
                Destroy(prtFX, 3);
                Destroy(gameObject);
            }
        }
    }
    
    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag == "Player"){
            dissolve = true;
            GetComponent<Rigidbody>().useGravity = true;
            
        }
    }
}
