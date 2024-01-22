using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using System.Collections;

public class FireParticleConfig : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private bool isParticleVisible = true;
    private float particleDisplayTime;
    private float particleHideTime;
    private float particleToggleTime;
    private float rotationSpeed;
    private float stopAngle;
    private float timer = 0f; // 時間保持用使い捨て変数

    [SerializeField] private string fireTrapDataAddress; // データアドレス

    private async void Start()
    {
        // 指定されたアドレスのFireTrapDataを非同期でロード
        FireTrapData data = await AddressLoader.AddressLoad<FireTrapData>(fireTrapDataAddress);

        // ロードしたデータからパラメータを設定
        particleDisplayTime = data.particleDisplayTime;
        particleHideTime = data.particleHideTime;
        particleToggleTime = data.particleToggleTime;
        rotationSpeed = data.rotationSpeed;
        stopAngle = data.stopAngle;

        ShowParticle();

        // 定期的に回転させる
        Observable.Interval(TimeSpan.FromSeconds(particleToggleTime))
            .Subscribe(_ => RotateObject())
            .AddTo(this);
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

    private void RotateObject()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        if (Mathf.Abs(transform.rotation.eulerAngles.y - stopAngle) < 0.1f)
        {
            // 角度に応じて回転速度の方向を変更
            rotationSpeed *= -1;
        }
    }
}