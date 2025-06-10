using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]private GameObject pauseMenuUI;
    [SerializeField]private GameObject pauseMenuQuitUI;
    [SerializeField]private GameObject gameOverUI;
    public static bool isPaused = false;
    public static bool gameOver;
    public static GameObject prefabUI;
    public static Transform self;
    [SerializeField]private GameObject tmpUI;
    void Start()
    {
        isPaused = false;
        gameOver = false;
        prefabUI = tmpUI;
        self = transform;
    }
    void Update()
    {
        if(gameOver)
        {
            Cursor.lockState = CursorLockMode.None;
            isPaused = true;
            gameOverUI.SetActive(true);
        }
        UpdateOrderUI();
        Time.timeScale = isPaused ? 0f : 1f;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused) ResumeGame();
            else PauseGame();
        }
    
    }
    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
    void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }
    public void PauseMenuQuit()
    {
        bool tmp = !pauseMenuQuitUI.activeSelf;
        pauseMenuQuitUI.SetActive(tmp);
        pauseMenuUI.SetActive(!tmp);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public static GameObject CreateOrderUI(int ID)
    {
        GameObject UI = Instantiate(prefabUI, self);
        UI.GetComponent<OrderUI>().ID = ID;
        CustomerManager.orderUIList.Add(UI);
        Debug.Log("created UI");
        return UI;
    }
    private void UpdateOrderUI()
    {
        for(int i = 0; i < CustomerManager.orderUIList.Count; i++)
        {
            CustomerManager.orderUIList[i].GetComponent<RectTransform>().anchoredPosition = new Vector3((240 * i) - 840, -400, 0);
        }
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
