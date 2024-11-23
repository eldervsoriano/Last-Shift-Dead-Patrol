//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class MenuManager : MonoBehaviour
//{
//    public GameObject mainMenuPanel;     // Reference to the Main Menu Panel
//    public GameObject settingsPanel;    // Reference to the Settings Panel
//    public GameObject aboutPanel;       // Reference to the About Panel

//    private bool isGamePaused = false;  // Tracks whether the game is paused

//    void Start()
//    {
//        // Ensure all panels are initially hidden
//        mainMenuPanel.SetActive(false);
//        settingsPanel.SetActive(false);
//        aboutPanel.SetActive(false);
//    }

//    public void OpenMainMenu()
//    {
//        // Open the main menu panel and pause the game
//        mainMenuPanel.SetActive(true);
//        PauseGame();
//    }

//    public void ResumeGame()
//    {
//        // Resume the game and close the main menu panel
//        mainMenuPanel.SetActive(false);
//        settingsPanel.SetActive(false);
//        aboutPanel.SetActive(false);
//        ResumeGameLogic();
//    }

//    public void RestartGame()
//    {
//        // Restart the current scene
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//        ResumeGameLogic(); // Ensure the game is unpaused when restarting
//    }

//    public void OpenSettings()
//    {
//        // Open the settings panel and pause the game
//        settingsPanel.SetActive(true);
//        mainMenuPanel.SetActive(false);
//    }

//    public void OpenAbout()
//    {
//        // Open the about panel and pause the game
//        aboutPanel.SetActive(true);
//        mainMenuPanel.SetActive(false);
//    }

//    public void BackToMainMenuPanel()
//    {
//        // Close all sub-panels and return to the main menu panel
//        settingsPanel.SetActive(false);
//        aboutPanel.SetActive(false);
//        mainMenuPanel.SetActive(true);
//    }

//    public void GoToMainMenu()
//    {
//        // Load the main menu scene (assuming it's at index 0)
//        SceneManager.LoadScene(0);
//        ResumeGameLogic(); // Ensure the game is unpaused when going to the main menu
//    }

//    private void PauseGame()
//    {
//        Time.timeScale = 0f; // Stop the game
//        isGamePaused = true;
//    }

//    private void ResumeGameLogic()
//    {
//        Time.timeScale = 1f; // Resume the game
//        isGamePaused = false;
//    }
//}











//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class MenuManager : MonoBehaviour
//{
//    public GameObject mainMenuPanel;
//    public GameObject homePanel;
//    public GameObject settingsPanel;
//    public GameObject aboutPanel;
//    public GameObject shopPanel;
//    public GameObject quitConfirmationPanel;

//    private bool isGamePaused = false;

//    void Start()
//    {
//        mainMenuPanel.SetActive(false);
//        homePanel.SetActive(false);
//        settingsPanel.SetActive(false);
//        aboutPanel.SetActive(false);
//        shopPanel.SetActive(false);
//        quitConfirmationPanel.SetActive(false);
//        ResumeGameLogic(); // Ensure game starts running
//    }

//    public void OpenMainMenu()
//    {
//        Debug.Log("Opening Main Menu...");
//        mainMenuPanel.SetActive(true);

//        // Pause the game only if it's currently running
//        if (!isGamePaused)
//        {
//            PauseGame();
//        }
//    }

//    public void ResumeGame()
//    {
//        Debug.Log("Resuming game...");
//        mainMenuPanel.SetActive(false);
//        settingsPanel.SetActive(false);
//        aboutPanel.SetActive(false);
//        shopPanel.SetActive(false);
//        quitConfirmationPanel.SetActive(false);
//        homePanel.SetActive(false);
//        ResumeGameLogic();
//    }

//    public void RestartGame()
//    {
//        Debug.Log("Restarting game...");
//        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//        ResumeGameLogic();
//    }

//    public void OpenSettings()
//    {
//        Debug.Log("Opening Settings...");
//        settingsPanel.SetActive(true);
//        mainMenuPanel.SetActive(false);
//        homePanel.SetActive(false);
//        PauseGame();
//    }

//    public void OpenAbout()
//    {
//        Debug.Log("Opening About...");
//        aboutPanel.SetActive(true);
//        mainMenuPanel.SetActive(false);
//        homePanel.SetActive(false);
//        PauseGame();
//    }

//    public void OpenShop()
//    {
//        Debug.Log("Opening Shop...");
//        shopPanel.SetActive(true);
//        mainMenuPanel.SetActive(false);
//        homePanel.SetActive(false);
//        PauseGame();
//    }

//    public void BackToHomePanel()
//    {
//        Debug.Log("Opening Quit Confirmation...");
//        quitConfirmationPanel.SetActive(true);
//        mainMenuPanel.SetActive(false);
//        settingsPanel.SetActive(false);
//        aboutPanel.SetActive(false);
//        shopPanel.SetActive(false);
//        PauseGame();
//    }

//    public void ConfirmQuit()
//    {
//        Debug.Log("Returning to Home...");
//        homePanel.SetActive(true);
//        mainMenuPanel.SetActive(false);
//        quitConfirmationPanel.SetActive(false);
//        settingsPanel.SetActive(false);
//        aboutPanel.SetActive(false);
//        shopPanel.SetActive(false);
//        PauseGame();
//    }

//    public void CancelQuit()
//    {
//        Debug.Log("Canceling Quit...");
//        quitConfirmationPanel.SetActive(false);
//        mainMenuPanel.SetActive(true);
//    }

//    //public void CloseCurrentPanel(GameObject currentPanel)
//    //{
//    //    Debug.Log("Closing Panel: " + currentPanel.name);
//    //    if (currentPanel != null)
//    //    {
//    //        currentPanel.SetActive(false);
//    //    }
//    //}

//    public void CloseCurrentPanel(GameObject currentPanel, GameObject panelToKeepOpen = null)
//    {
//        Debug.Log("Attempting to close panel: " + currentPanel.name);

//        // Close the specified panel
//        if (currentPanel != null)
//        {
//            currentPanel.SetActive(false);
//            Debug.Log("Closed panel: " + currentPanel.name);
//        }

//        // Reopen the specified panel (if any)
//        if (panelToKeepOpen != null)
//        {
//            panelToKeepOpen.SetActive(true);
//            Debug.Log("Reopened panel: " + panelToKeepOpen.name);
//        }
//    }


//    private void PauseGame()
//    {
//        Debug.Log("Pausing game...");
//        Time.timeScale = 0f;
//        isGamePaused = true;
//    }

//    private void ResumeGameLogic()
//    {
//        Debug.Log("Resuming game logic...");
//        Time.timeScale = 1f;
//        isGamePaused = false;
//    }
//}


using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic; // Import for Stack

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject homePanel;
    public GameObject settingsPanel;
    public GameObject aboutPanel;
    public GameObject shopPanel;
    public GameObject quitConfirmationPanel;

    private bool isGamePaused = false;

    // Stack to track the order of opened panels
    private Stack<GameObject> panelStack = new Stack<GameObject>();

    void Start()
    {
        // Ensure all panels are initially hidden except the Home Panel
        mainMenuPanel.SetActive(false);
        homePanel.SetActive(false);
        settingsPanel.SetActive(false);
        aboutPanel.SetActive(false);
        shopPanel.SetActive(false);
        quitConfirmationPanel.SetActive(false);
        ResumeGameLogic(); // Ensure game starts running
    }

    public void OpenMainMenu()
    {
        Debug.Log("Opening Main Menu...");
        OpenPanel(mainMenuPanel);
        PauseGame();
    }

    public void ResumeGame()
    {
        Debug.Log("Resuming game...");
        CloseAllPanels();
        ResumeGameLogic();
    }

    public void RestartGame()
    {
        Debug.Log("Restarting game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResumeGameLogic();
    }

    public void OpenSettings()
    {
        Debug.Log("Opening Settings...");
        OpenPanel(settingsPanel);
    }

    public void OpenAbout()
    {
        Debug.Log("Opening About...");
        OpenPanel(aboutPanel);
    }

    public void OpenShop()
    {
        Debug.Log("Opening Shop...");
        OpenPanel(shopPanel);
    }

    public void BackToHomePanel()
    {
        Debug.Log("Opening Quit Confirmation...");
        OpenPanel(quitConfirmationPanel);
    }

    public void ConfirmQuit()
    {
        Debug.Log("Returning to Home...");
        CloseAllPanels();
        homePanel.SetActive(true);
        PauseGame();
    }

    public void CancelQuit()
    {
        Debug.Log("Canceling Quit...");
        CloseCurrentPanel();
    }

    /// <summary>
    /// Opens a panel and adds it to the stack.
    /// </summary>
    /// <param name="panel">The panel to open.</param>
    public void OpenPanel(GameObject panel)
    {
        if (panel == null) return;

        Debug.Log("Opening panel: " + panel.name);
        panel.SetActive(true);
        panelStack.Push(panel); // Track the panel in the stack
        PauseGame();
    }

    /// <summary>
    /// Closes the most recently opened panel without affecting the rest.
    /// </summary>
    public void CloseCurrentPanel()
    {
        if (panelStack.Count > 0)
        {
            GameObject currentPanel = panelStack.Pop();
            currentPanel.SetActive(false);
            Debug.Log("Closed panel: " + currentPanel.name);

            // Resume the game if no panels are left open
            if (panelStack.Count == 0)
            {
                ResumeGameLogic();
            }
        }
        else
        {
            Debug.Log("No panels to close.");
        }
    }

    /// <summary>
    /// Closes all open panels and clears the stack.
    /// </summary>
    public void CloseAllPanels()
    {
        while (panelStack.Count > 0)
        {
            GameObject panel = panelStack.Pop();
            panel.SetActive(false);
            Debug.Log("Closed panel: " + panel.name);
        }
        ResumeGameLogic();
    }

    private void PauseGame()
    {
        Debug.Log("Pausing game...");
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    private void ResumeGameLogic()
    {
        Debug.Log("Resuming game logic...");
        Time.timeScale = 1f;
        isGamePaused = false;
    }
}





