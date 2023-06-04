using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void MainGameTransition()
    {
        SceneManager.LoadScene(TagName.MainGame);
    }
    public void ResultTransition()
    {
        SceneManager.LoadScene(TagName.Result);
    }
}
