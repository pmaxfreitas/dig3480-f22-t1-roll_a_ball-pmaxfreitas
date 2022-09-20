using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class resetButton : MonoBehaviour
{
    public Button reset;

    private void Reset()
    {
        SceneManager.LoadScene("MiniGame");
    }
}
