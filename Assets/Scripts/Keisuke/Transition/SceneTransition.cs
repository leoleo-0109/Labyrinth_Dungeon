using UnityEngine.SceneManagement;

public static class SceneTransition
{
    public static void MainGameTransition()
    {
        SceneManager.LoadScene(TagName.MainGame);
    }
    public static void ResultTransition()
    {
        SceneManager.LoadScene(TagName.Result);
    }
    public static void Stage1()
    {
        SceneManager.LoadScene(TagName.Stage1);
    }
    public static void Stage2()
    {
        SceneManager.LoadScene(TagName.Stage2);

    }
    public static void Stage3()
    {
        SceneManager.LoadScene(TagName.Stage3);
    }

}
