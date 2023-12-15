using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class control : MonoBehaviour
{

    public Vector3 dir;
    //public float force;
    [SerializeField] Rigidbody rb;
    public TextMeshProUGUI forceText;
    float force = 0f;
    int k = 0;
    float ky;
    bool throwO;
    [SerializeField] ParticleSystem powerEffect;
    [SerializeField] TrailRenderer speedTrail;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject box;
    bool ability;
    Vector3 objectPosition;
    public float bigForce;
    [SerializeField] Transform cannonTransform;
    public float maxForce = 20f;

    private void Awake()
    {
        float x = Random.Range(0f, 1f);
        float y = Random.Range(0f, 1f);
        float z = Random.Range(0f, 1f);
        objectPosition = new Vector3(x, y, z);
        ability = true;

    }
    private void Start()
    {
        ky = transform.position.y;
        throwO = true;
    }
    private void FixedUpdate()
    {
        if (throwO == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (dir.y <= 1)
                {
                    dir.y = dir.y + 1 * Time.deltaTime;
                    //cannonTransform.eulerAngles = new Vector3(-dir.y, 0, 0);
                    cannonTransform.Rotate(Vector3.left * dir.y);

                }
            }

            if (Input.GetKey(KeyCode.X))
            {
                if (dir.y >= 0)
                {
                    dir.y = dir.y - 1 * Time.deltaTime;
                    //cannonTransform.eulerAngles = new Vector3(-dir.y, 0, 0);
                    cannonTransform.Rotate(Vector3.left * -dir.y);
                }
            }


            if (Input.GetKey(KeyCode.W))
            {
                if (force <= maxForce)
                {
                    force += 10 * Time.deltaTime;
                    GameManager.Instance.forceSlider.value += force * Time.deltaTime / 15;
                    k = Mathf.FloorToInt(force);

                }

            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (force >= 0f)
                {
                    force -= 10 * Time.deltaTime;
                    GameManager.Instance.forceSlider.value -= force * Time.deltaTime / 10;
                    k = Mathf.FloorToInt(force);

                }

            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                rb.AddForce(dir * k, ForceMode.Impulse);
                throwO = false;
            }
            forceText.text = k.ToString("D2");
        }

        if (throwO == false && ability == true)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                abilityRed();
                ability = false;

            }
        }




    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "box")
        {
            Instantiate(powerEffect, col.collider.transform.position, Quaternion.identity);
            Destroy(col.collider);
            GameManager.Instance.touched = true;
        }

        if (GameManager.Instance.touched)
        {
            callNextBall();
            GameManager.Instance.touched = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("wall"))
        {
            GameManager.Instance.touched = true;
        }
    }

    private void abilityRed()
    {
        rb.AddForce(new Vector3(-box.transform.position.x, -box.transform.position.y, 0f) * bigForce);
        speedTrail.enabled = true;
    }

    private void callNextBall()
    {
        GameManager.Instance.nextBall();
    }

}
