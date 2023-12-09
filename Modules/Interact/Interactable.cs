using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private string InteractText;
    [SerializeField]
    private bool Glow;
    [SerializeField]
    private float GlowAmmount;
    [SerializeField]
    private Color HoverColor;
    [Space]
    [Header("Events")]
    public UnityEvent OnInteractedWith;

    /// <summary>
    /// Returns weather Glow is enabled for this Interactable.
    /// </summary>
    /// <returns></returns>
    public bool GetGlow()
    {
        return Glow;
    }

    /// <summary>
    /// Returns the Glow Ammount for this Interactable.
    /// </summary>
    /// <returns></returns>
    public float GetGlowAmmount()
    {
        return GlowAmmount;
    }

    /// <summary>
    /// Returns the hover color for this Interactable.
    /// </summary>
    /// <returns></returns>
    public Color GetHoverColor()
    {
        return HoverColor;
    }

    public void Interact()
    {
        OnInteractedWith.Invoke();
    }

    /// <summary>
    /// returns the Interact Text for the current Interactable.
    /// </summary>
    /// <returns></returns>
    public string GetInteractText()
    {
        return InteractText;
    }

    /// <summary>
    /// "Glows" (or resizes) the crossair.
    /// </summary>
    /// <param name="Crossair"></param>
    public void StartGlow(GameObject Crossair)
    {
        Crossair.GetComponent<RectTransform>().sizeDelta = new Vector2(GlowAmmount, GlowAmmount);
    }
    /// <summary>
    /// "Glows" (or resizes) the corssair to a custom size.
    /// </summary>
    /// <param name="Crossair"></param>
    /// <param name="Size"></param>
    public void GlowToCustomSize(GameObject Crossair, float Size)
    {
        Crossair.GetComponent<RectTransform>().sizeDelta = new Vector2(Size, Size);
    }

}
