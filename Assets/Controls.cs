using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float turnSpeed = 10f;
    public float launchForce = 10f;
    public GameObject ammoPrefab = null;
    public Transform ammoSpawn = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TurnControl();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ammo = Instantiate(ammoPrefab, ammoSpawn.position, Quaternion.identity);
            ammo.GetComponent<Rigidbody>().AddForce(ammoSpawn.up * launchForce, ForceMode.Impulse);

        }
    }

    private void TurnControl()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, -movement * turnSpeed * Time.deltaTime);
    }
}
