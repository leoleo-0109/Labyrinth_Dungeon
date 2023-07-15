using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void ESP32MainGame()
    {
        SceneManager.LoadScene(TagName.ESP32MainGame);
    }
    public void NanoMainGame()
    {
        SceneManager.LoadScene(TagName.NanoMainGame);
    }
    public void KeyBoardMainGame()
    {
        SceneManager.LoadScene(TagName.KeyBoardMainGame);
    }
    public void Title()
    {
        SceneManager.LoadScene(TagName.Title);
    }
    public void ResultTransition()
    {
        SceneManager.LoadScene(TagName.Result);
    }
    public void Stage1()
    {
        SceneManager.LoadScene(TagName.Stage1);
    }
    public void Stage2()
    {
        SceneManager.LoadScene(TagName.Stage2);

    }
    public void Stage3()
    {
        SceneManager.LoadScene(TagName.Stage3);
    }

}
