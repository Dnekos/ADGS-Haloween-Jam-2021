using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject resume;
    [SerializeField] private GameObject mainMenu;

    private Button resumeBtn;
    private Button mainMenuBtn;
    void Start()
    {
        resumeBtn = resume.GetComponent<Button>();
        resumeBtn.onClick.AddListener(OnResumeClick);
        mainMenuBtn = mainMenu.GetComponent<Button>();
        mainMenuBtn.onClick.AddListener(OnMenuClick);
    }

    public void OnResumeClick()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().TogglePause();
    }

    public void OnMenuClick()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().TogglePause();
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
}
