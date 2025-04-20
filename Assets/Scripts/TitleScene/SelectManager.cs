using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    public string[] sceneNames;
    public int selectedIndex = 0;

    private AudioSource audioSource;

    public AudioClip selectSE;

    void Start()
    {
        selectedIndex = 0;
        audioSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (audioSource != null && selectSE != null)
            {
                audioSource.PlayOneShot(selectSE);
            }

            Invoke("LoadScene", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex--;
            if (selectedIndex < 0)
            {
                selectedIndex = sceneNames.Length - 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex++;
            if (selectedIndex >= sceneNames.Length)
            {
                selectedIndex = 0;
            }
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneNames[selectedIndex]);
    }
}
