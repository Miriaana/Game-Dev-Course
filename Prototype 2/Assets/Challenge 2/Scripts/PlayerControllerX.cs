using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float fullCooldown = 0.5f;
    private float currentCooldown = 0.0f;


    // Update is called once per frame
    void Update()
    {
        currentCooldown += Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && currentCooldown >= fullCooldown)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            currentCooldown = 0.0f;
        }
    }
}
