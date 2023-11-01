using UnityEngine;
using TMPro;
using System.Collections;

// This class is responsible for resizing the caret within a TextMeshPro InputField.
public class CaretResizer : MonoBehaviour
{
    public Vector2 newSize = new Vector2(4, 3);  // Specifies the new size for the caret.
    public float delay = 0.1f;  // Specifies a delay of 0.1 seconds.

    // The Start method is called on the frame when the script is enabled.
    void Start()
    {
        // Starts a coroutine to resize the caret after a specified delay.
        StartCoroutine(ResizeCaretWithDelay());
    }

    // This coroutine waits for a specified delay before resizing the caret.
    IEnumerator ResizeCaretWithDelay()
    {
        // Waits for the specified delay.
        yield return new WaitForSeconds(delay);

        // Attempts to find a TMP_InputField component on this GameObject.
        TMP_InputField inputField = GetComponent<TMP_InputField>();
        if (inputField != null)
        {
            // Attempts to find a child GameObject named "Text Area" within the TMP_InputField.
            Transform textAreaTransform = inputField.transform.Find("Text Area");
            if (textAreaTransform != null)
            {
                // Attempts to find a child GameObject named "Caret" within the "Text Area".
                Transform caretTransform = textAreaTransform.Find("Caret");
                if (caretTransform != null)
                {
                    // Attempts to find a RectTransform component on the "Caret" GameObject.
                    RectTransform caretRectTransform = caretTransform.GetComponent<RectTransform>();
                    if (caretRectTransform != null)
                    {
                        // Sets the size of the caret to the specified newSize.
                        caretRectTransform.sizeDelta = newSize;
                    }
                    else
                    {
                        // Logs an error if no RectTransform is found on the "Caret" GameObject.
                        Debug.LogError("No RectTransform attached to the Caret GameObject.");
                    }
                }
                else
                {
                    // Logs an error if no "Caret" GameObject is found.
                    Debug.LogError("No Caret GameObject found.");
                }
            }
            else
            {
                // Logs an error if no "Text Area" GameObject is found.
                Debug.LogError("No Text Area GameObject found.");
            }
        }
        else
        {
            // Logs an error if no TMP_InputField component is found.
            Debug.LogError("No TMP_InputField component found.");
        }
    }
}
