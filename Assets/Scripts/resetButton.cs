using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetButton : MonoBehaviour
{
    private void Reset()
    {
        SceneManager.LoadScene("MiniGame");
    }
}
