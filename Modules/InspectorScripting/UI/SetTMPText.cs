using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
public class SetTMPText : MonoBehaviour
{
    public TMP_Text tmp_text;
    public UnityEvent onUIChanged;

    public void ChangeUI(string text){
        tmp_text.text = text;
        onUIChanged.Invoke();
    }
}
