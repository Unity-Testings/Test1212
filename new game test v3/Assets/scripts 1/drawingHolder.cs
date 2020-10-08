using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class drawingHolder : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public GameObject panel;
    public cardSpawner _spawner;
    public audioManager _audioManager;
    public AudioClip clickSound;
    public AudioSource asd;
    private float pitchHolder = 1f;
    public float originalPitch = 1f;
    public float pitchAmplifierConstant = .05f;

    public drawingCubes[] _cubes;
    public incomingCard cardToDeleteToContinue;
    public incomingCard temp;

    void Start()
    {
        pitchHolder = originalPitch;
        score = 0;
        panel.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("showing info:");
            foreach (drawingCubes i in _cubes)
            {
                Debug.Log(i.isOn);
            }
        }
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                drawingCubes rig = hit.collider.GetComponent<drawingCubes>();
                if (rig != null)
                {

                    if (rig.previousState == -1)
                    {
                        rig.isOn = !rig.isOn;
                        _audioManager.clickSound.pitch = pitchHolder;
                        pitchHolder += pitchAmplifierConstant;
                        asd.PlayOneShot(clickSound);
                    }
                    if (rig.isOn)
                        rig.GetComponent<Renderer>().material.color = Color.red;
                    else
                        rig.GetComponent<Renderer>().material.color = Color.white;
                    rig.previousState = rig.isOn ? 0 : 1;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            resetPreviousState();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        temp = other.GetComponent<incomingCard>();
       
        
        if (temp != null)
        {
            bool flag = false;
            for (int i = 0; i < temp.theCard.Length; i++)
            {
                int tempInt = _cubes[i].isOn ? 1 : 0;

                if (tempInt != temp.theCard[i]) // if the card was incorrect
                {
                    cardToDeleteToContinue = temp;
                    _audioManager.gameOverSound.Play();
                    temp.anim.Play();

                    //temp.transform.position = new Vector3(temp.transform.position.x, temp.transform.position.y + 3.5f, temp.transform.position.z);
                    pitchHolder = originalPitch;
                    flag = true;
                    temp.speed = 0;
                    Destroy(other.gameObject, .5f);
                    Time.timeScale = .1f;
                    panel.SetActive(true);
                    break;
                }
            }
            if (flag == false)// else the card was correct
            {
                pitchHolder = originalPitch;

                score++;
                scoreText.text = score.ToString();
                if (score % 10 == 0)
                {
                    _audioManager.tenWinScoreSound.Play();
                }

                _audioManager.winSound.Play();


                Destroy(temp, .5f);
                Destroy(other.gameObject, .5f);
                StartCoroutine(resetHolder());


            }


        }
    }
    public void deleteLastCardContinnue()
    {
        if(temp!=null)
            Destroy(temp.gameObject);

    }

    public IEnumerator resetHolder()
    {
        yield return new WaitForSeconds(.1f);

        resHolderAndButton();
    }
    public void resHolderAndButton()
    {
        for (int i = 0; i < _cubes.Length; i++)
        {
            _cubes[i].resetCube();
        }
    }

    public void restartGame()
    {
        StartCoroutine(resetHolder());

        Time.timeScale = 1f;
        _spawner.fireRate = .2f;
        panel.SetActive(false);
        SceneManager.LoadScene("test scene");


    }

    public void resetPreviousState()
    {
        for (int i = 0; i < _cubes.Length; i++)
        {
            _cubes[i].previousState = -1;
        }
    }
}
