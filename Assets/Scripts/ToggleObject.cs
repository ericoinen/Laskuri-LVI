using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public List<GameObject> objectsToToggle;  // List of objects to toggle
    private int activeIndex = -1;             // Index of the active object (-1 means no object is active)
    public AudioSource audioSource;  // Audio source
    public AudioClip toggleSound;    // Sound for toggling

    void Start()
    {
        // Enable the object at index 9 on start
        ToggleObjectByIndex(9);
        // Initialize audio source
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
    // Method to toggle the first object
    public void ToggleSP1()
    {
        ToggleObjectByIndex(0);
    }
    // Method to toggle the second object
    public void ToggleSP2()
    {
        ToggleObjectByIndex(1);
    }
    // Method to toggle the third object
    public void ToggleSP3()
    {
        ToggleObjectByIndex(2);
    }
    public void ToggleAV1()
    {
        ToggleObjectByIndex(3);
    }
    public void ToggleAV2()
    {
        ToggleObjectByIndex(4);
    }
    public void ToggleAV3()
    {
        ToggleObjectByIndex(5);
    }
    public void ToggleAV4()
    {
        ToggleObjectByIndex(6);
    }
    public void ToggleTu()
    {
        ToggleObjectByIndex(7);
    }
    public void ToggleT1()
    {
        ToggleObjectByIndex(8);
    }
    public void ToggleT2()
    {
        ToggleObjectByIndex(10);
    }
    public void ToggleT3()
    {
        ToggleObjectByIndex(11);
    }
    public void ToggleT4()
    {
        ToggleObjectByIndex(12);
    }
    public void ToggleT5()
    {
        ToggleObjectByIndex(13);
    }
    public void ToggleT6()
    {
        ToggleObjectByIndex(14);
    }
    public void ToggleT7()
    {
        ToggleObjectByIndex(15);
    }
    public void ToggleT7w()
    {
        ToggleObjectByIndex(16);
    }
    public void ToggleT8()
    {
        ToggleObjectByIndex(17);
    }
    public void ToggleT9()
    {
        ToggleObjectByIndex(18);
    }
    public void ToggleT10()
    {
        ToggleObjectByIndex(19);
    }
    public void ToggleT11()
    {
        ToggleObjectByIndex(20);
    }
    public void ToggleELP()
    {
        ToggleObjectByIndex(21);
    }
    public void ToggleStulo()
    {
        ToggleObjectByIndex(22);
    }
    public void ToggleSpoisto()
    {
        ToggleObjectByIndex(23);
    }
    public void ToggleMenu()
    {
        ToggleObjectByIndex(24);
    }
    public void ToggleLP()
    {
        ToggleObjectByIndex(25);
    }
    public void ToggleJP()
    {
        ToggleObjectByIndex(26);
    }
    public void ToggleLTO()
    {
        ToggleObjectByIndex(27);
    }
    public void ToggleTF()
    {
        ToggleObjectByIndex(28);
    }
    public void TogglePF()
    {
        ToggleObjectByIndex(29);
    }
    // General method to toggle object by index
    private void ToggleObjectByIndex(int index)
    {
        if (objectsToToggle == null || index >= objectsToToggle.Count || objectsToToggle[index] == null)
        {
            Debug.LogWarning("Object to toggle is not assigned or index is out of range.");
            return;
        }
        // Play the toggle sound
        if (audioSource && toggleSound)
        {
            audioSource.PlayOneShot(toggleSound);
        }
        // Disable the object at index 9 if any other is enabled
        if (activeIndex == 9 && index != 9)
        {
            objectsToToggle[9].SetActive(false);
        }
        // If the current object is already active, disable it
        if (activeIndex == index)
        {
            objectsToToggle[index].SetActive(false);
            activeIndex = -1;
        }
        else
        {
            // Disable the previous active object, if it exists
            if (activeIndex >= 0 && activeIndex < objectsToToggle.Count)
            {
                objectsToToggle[activeIndex].SetActive(false);
            }

            // Enable the new active object
            objectsToToggle[index].SetActive(true);
            activeIndex = index;
        }
    }
}
