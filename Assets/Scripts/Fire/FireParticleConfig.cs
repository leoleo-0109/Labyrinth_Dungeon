using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using System.Collections;
using System.Collections.Generic;

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

    private bool rotateRight = true; // 右回転フラグ

    private bool continuousRotation = false; // 連続回転フラグ
    private Dictionary<string, Action> fireTrapDataMethods = new Dictionary<string, Action>();
    [SerializeField] private string fireTrapDataAddress; // データアドレス

    private async void Start()
    {
        // ディクショナリにメソッドを登録する
        fireTrapDataMethods["stg1firetrap1"] = RotateObject;
        fireTrapDataMethods["stg1firetrap2"] = RotateObject;
        fireTrapDataMethods["stg1firetrap3"] = SpinAround;
        fireTrapDataMethods["stg2firetrap1"] = RotateObject;
        fireTrapDataMethods["stg2firetrap2"] = RotateObject;
        fireTrapDataMethods["stg2firetrap3"] = SpinAround;
        fireTrapDataMethods["stg3firetrap1"] = RotateObject;
        fireTrapDataMethods["stg3firetrap2"] = RotateObject;
        fireTrapDataMethods["stg3firetrap3"] = SpinAround;

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
            .Subscribe(_ =>
            {
                // fireTrapDataAddressの値に応じて対応するメソッドを呼び出す
                if (fireTrapDataMethods.ContainsKey(fireTrapDataAddress))
                {
                    fireTrapDataMethods[fireTrapDataAddress].Invoke();
                }
            })
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
        // オブジェクトを回転させる
        if (rotateRight)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        // 90度回転したら回転方向を切り替える
        if (Mathf.Abs(transform.rotation.eulerAngles.y) >= 90f)
        {
            rotateRight = !rotateRight;
        }
    }

    private void SpinAround()
    {
        // オブジェクトを回転させる
        if (continuousRotation)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else
        {
            if (rotateRight)
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            }

            // 90度回転したら回転方向を切り替える
            if (Mathf.Abs(transform.rotation.eulerAngles.y) >= 90f)
            {
                rotateRight = !rotateRight;
            }
        }
    }
}