using UnityEngine;
using UnityEngine.Events;

public class PauseHandler : MonoBehaviour
{
    [SerializeField]
    private bool HideMouse;
    [SerializeField]
    private GameObject PauseMenu;
    [SerializeField]
    private bool Paused;
    [SerializeField]
    private BasicPlayerMovement Player_Controller;
    [Space]
    [Header("Events")]
    public UnityEvent OnPaused;
    public UnityEvent OnUnPaused;
    public UnityEvent OnTogglePause;

    /// <summary>
    /// Returns weather the mouse is currently hidden.
    /// </summary>
    /// <returns></returns>
    public bool GetMouseHidden()
    {
        return HideMouse;
    }
    /// <summary>
    /// Returns weather the game is currently paused or not.
    /// </summary>
    /// <returns></returns>
    public bool GetPaused()
    {
        return Paused;
    }

    private void Awake()
    {
        UpdateMouse();
    }
    private void Pause()
    {
        OnPaused.Invoke();
        Player_Controller.enabled = false;
        Time.timeScale = 0f;
        HideMouse = false;
    }
    private void UnPause()
    {
        OnUnPaused.Invoke();
        Player_Controller.enabled = true;
        Time.timeScale = 1f;
        HideMouse = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseToggle();
        }

        if (Paused)
        {
            Pause();
        }
        else
        {
            UnPause();
        }
        UpdateMouse();
    }

    private void UpdateMouse()
    {
        if (HideMouse == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    /// <summary>
    /// Toggles weather or not the game is Paused.
    /// </summary>
    public void PauseToggle()
    {
        OnTogglePause.Invoke();
        Paused = !Paused;
    }
}
