using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class resetButton : MonoBehaviour
{
    public Button reset;

    public void Reset()
    {
        SceneManager.LoadScene("MiniGame");
    }
}
