using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] List<GameObject> balls;
    GameObject currentBall;
    GameObject previousBall;
    int i = 0;
    public bool touched;

    [SerializeField] Transform spawnTransform;
    [SerializeField] ParticleSystem cannonSmoke;
    public Slider forceSlider;
    private void Awake()
    {
        // Ensure there's only one GameManager instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // it ensures that gameManager does not get destroyed on start
        }
        else
        {
            Destroy(gameObject);  // this ensures that if more than one gameManager then it will destroy extra one
            return;
        }
        
        currentBall = balls[i];
        currentBall.SetActive(true);
        i++;
        Debug.Log(i);
    }


    public void nextBall()
    {
        if (i < balls.Count)
        {

            currentBall = balls[i];
            currentBall.SetActive(true);
            //Instantiate(currentBall, spawnTransform.position, Quaternion.identity);
            previousBall = balls[i - 1];
            //DestroyImmediate(previousBall);
            previousBall.SetActive(false);
            i++;
            Debug.Log(i);

        }



    }



    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            cannonSmoke.Play();
        }
        if (Input.GetKey(KeyCode.W))
        {
            forceSlider.value += 2f * Time.deltaTime / 100;
        }

    }

    private void cannon()
    {

    }
}
