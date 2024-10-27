using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bounce : MonoBehaviour
{
    public PhysicsMaterial2D physMat2D;
    public float time = 0.0f;
    Rigidbody2D rb2D;
    [SerializeField][Range(0,2)] float bouncePower = 0f;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] GameObject WonScreen;
    bool won = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        physMat2D.bounciness = bouncePower;
        rb2D.sharedMaterial = physMat2D;

    }

    void Update()
    {
        if (!won)
        {
            time += Time.deltaTime;
            timer.text = ""+time;
        }
        if (Input.GetButtonDown("Jump"))
        {
            transform.position = new Vector3(0,0,0);
            transform.rotation = Quaternion.Euler(0,0,0);
            rb2D.velocity = new Vector3(0,0,0);
            rb2D.angularVelocity = 0;
            won = false;
            time = 0;
            WonScreen.SetActive(false);

        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Finish"))
        {
            Debug.Log("WON!");
            won = true;
            WonScreen.SetActive(true);
        }
    }

    public void SetBouncePower()
    {
        bouncePower = slider.value;
    }
}
