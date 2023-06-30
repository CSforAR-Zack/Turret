using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoControls : MonoBehaviour
{
    public float invTime = 0.1f;
    public float lifeAfterCollision = 5f;
    public ParticleSystem explosionPrefab = null;
    public AudioClip boom = null;
    
    float lifeTime = 0f;
    bool collided = false;
    AudioSource audioSource = null;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        explosionPrefab.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (collided && lifeTime > lifeAfterCollision)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(lifeTime > invTime)
        {
            explosionPrefab.Play();
            audioSource.PlayOneShot(boom);
            lifeTime = 0f;
            collided = true;
            transform.GetComponent<MeshRenderer>().enabled = false;
            transform.GetComponent<Collider>().enabled = false;
        }
    }
}
