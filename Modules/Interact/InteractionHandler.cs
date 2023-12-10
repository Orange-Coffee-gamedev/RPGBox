using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
public class InteractionHandler : MonoBehaviour
{
    [SerializeField]
    private float distance;
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private TMP_Text InteractText;
    [SerializeField]
    private GameObject InteractGUI;

    [SerializeField]
    private string InteractTextString;

    [SerializeField]
    private KeyCode InteractKey;

    [SerializeField]
    private Image Crossair;

    [SerializeField]
    private float DefaultCrosairSize;

    [SerializeField]
    private Color defaultCrossairColor;

    [SerializeField]
    private string InteractMultiTag = "Interactable";

    [Space]

    [Header("Events")]
    public UnityEvent OnFindInteractableFailed;
    public UnityEvent OnInteractStart;
    public UnityEvent OnInteractFinish;
    public UnityEvent OnInteractKeyChange;


    private Interactable Interactable_Object;

    /// <summary>
    /// Called when RPGBox failes to locate a Interactable.
    /// </summary>
    public void FailedToFindInteractable()
    {
        anim.SetTrigger("Deactivate");
        OnFindInteractableFailed.Invoke();
    }

    public string GetInteractMultiTag()
    {
        return InteractMultiTag;
    }

    /// <summary>
    /// Returns the current InteractKey that RPGBox will use.
    /// </summary>
    /// <returns></returns>
    public KeyCode GetInteractKey()
    {
        return InteractKey;
    }

    /// <summary>
    /// Sets the Interact Key RPGBox will rely on
    /// </summary>
    /// <param name="NewKeyCode"></param>
    public void SetInteractKey(KeyCode NewKeyCode)
    {
        InteractKey = NewKeyCode;
        OnInteractKeyChange.Invoke();
    }

    /// <summary>
    /// RPGBox Interact Event
    /// </summary>
    /// <param name="HitGameobject"></param>
    public void Interact(GameObject HitGameobject)
    {
        anim.SetTrigger("Activate");
        OnInteractStart.Invoke();
        InteractGUI.gameObject.SetActive(true);
        InteractText.gameObject.SetActive(true);
        InteractTextString = HitGameobject.GetComponent<Interactable>().GetInteractText();
        InteractTextString = InteractTextString.Replace("[KEY]", InteractKey.ToString());
        InteractTextString = InteractTextString.Replace("[NAME]", HitGameobject.name);
        InteractText.text = InteractTextString;

        if (Interactable_Object.GetGlow())
        {
            Interactable_Object.StartGlow(Crossair.gameObject);
        }
        else
        {
            Interactable_Object.GlowToCustomSize(Crossair.gameObject, DefaultCrosairSize);
        }

        Crossair.color = Interactable_Object.GetHoverColor();


        if (Input.GetKeyDown(InteractKey))
        {
            HitGameobject.GetComponent<Interactable>().Interact();
        }
        InteractFinish();
    }

    /// <summary>
    /// Called when Interact() has finished
    /// </summary>
    public void InteractFinish()
    {
        OnInteractFinish.Invoke();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
        {
            Interactable_Object = hit.collider.GetComponent<Interactable>();
            if (hit.collider.GetComponent<MultiTag>() && hit.collider.GetComponent<MultiTag>().HasTag(InteractMultiTag))
            {
                anim.SetTrigger("Activate");
                Interact(hit.collider.gameObject);
                return;
            }
            else
            {
                if(anim != null) { anim.SetTrigger("Deactivate"); }
                if (InteractGUI != null) { InteractGUI.gameObject.SetActive(false); }
                if (Crossair != null) { Crossair.GetComponent<RectTransform>().sizeDelta = new Vector2(DefaultCrosairSize, DefaultCrosairSize); Crossair.color = defaultCrossairColor; }
                FailedToFindInteractable();
                return;
            }
        }
        else
        {
            if (anim != null) { anim.SetTrigger("Deactivate"); }
            if (InteractGUI != null) { InteractGUI.gameObject.SetActive(false); }
            if (Crossair != null) { Crossair.GetComponent<RectTransform>().sizeDelta = new Vector2(DefaultCrosairSize, DefaultCrosairSize); Crossair.color = defaultCrossairColor; }
            FailedToFindInteractable();
            return;
        }
    }
}
