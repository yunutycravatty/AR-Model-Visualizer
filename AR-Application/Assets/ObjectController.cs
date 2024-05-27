using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float rotationSpeed = 150.0f;
    public float translationSpeed = 40.0f;

    public bool isWalking = false;

    public GameObject magicCircle;
    public GameObject moleRat;

    // Update is called once per frame
    void Update()
    {
        // if the user presses the 'W' key, translate the object forward and rotate it
        if (Input.GetKey(KeyCode.W))
        {
            isWalking = true;
        }

        if (isWalking)
        {
            TranslateObject();
            RotateObject();

            // Start the animation
            GetComponent<Animator>().SetBool("isWalking", true);
        }

        // if the user presses the 'SPACE' key, start the cast animation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animator>().SetBool("isCasting", true);

            // activate the "magic" circle object
            magicCircle.SetActive(true);

            // after 6 second, remove the magic circle object and display the molerat instead of the mage
            StartCoroutine(RemoveMagicCircle(magicCircle));
        }
    }

    IEnumerator RemoveMagicCircle(GameObject magicCircle)
    {
        isWalking = false;
        yield return new WaitForSeconds(6);

        // hide the mage and display the mole rat at the same position (y += 0.18)
        
        moleRat.SetActive(true);
        moleRat.transform.position = gameObject.transform.position + new Vector3(0, 0.18f, 0);
        moleRat.transform.rotation = gameObject.transform.rotation;
        magicCircle.SetActive(false);
    
        // deactivate this GameObject
        gameObject.SetActive(false);
    }

    public void RotateObject()
    {
        // Rotate the object
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void TranslateObject()
    {
        // Translate the object forward
        transform.Translate(Vector3.forward * translationSpeed * Time.deltaTime);
    }


}
