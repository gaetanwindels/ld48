using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject canvas;

    [SerializeField] CinemachineVirtualCamera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPlayer());
        HideWinScreen();
    }

    IEnumerator FollowPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        var player = FindObjectOfType<PlayerController>();
        player.Activate();
        playerCamera.Priority = 30;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideWinScreen()
    {
        canvas.SetActive(false);
    }

    public void DisplayWinScreen()
    {
        canvas.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
