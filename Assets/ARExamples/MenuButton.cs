using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log(name + " Button clicked.");
        SceneManager.LoadScene(name);
    }
}
