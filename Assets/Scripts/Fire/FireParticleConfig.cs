using UnityEngine;

public class FireParticleConfig : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private bool isParticleVisible = true;
    [SerializeField] private float particleDisplayTime = 3f;
    [SerializeField] private float particleHideTime = 3f;
    private float particleToggleTime = 1f;
    private float timer = 0f;

    private void Start()
    {
        // パーティクルの表示をオンにする
        ShowParticle();
    }

    private void Update()
    {
        // タイマーを更新する
        timer += Time.deltaTime;

        // パーティクルの表示を切り替える
        if (isParticleVisible && timer >= particleDisplayTime)
        {
            HideParticle();
            timer = 0f;
        }
        else if (!isParticleVisible && timer >= particleHideTime)
        {
            ShowParticle();
            timer = 0f;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        // プレイヤーに当たった場合はゲームオーバー処理を行う
        if (other.CompareTag(TagName.Player))
        {
            GameOver();
        }
    }

    private void ShowParticle()
    {
        particleSystem.Play();
        isParticleVisible = true;
    }

    private void HideParticle()
    {
        particleSystem.Stop();
        isParticleVisible = false;
    }

    private void GameOver()
    {
        // ゲームオーバー処理を行う
        Debug.Log("Game Over");
        Application.Quit();
    }
}