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
    private float rotationSpeed;
    private float rotationPauseTime; // 回転を停止する時間
    private float timer = 0f; // 時間保持用使い捨て変数

    private bool rotateRight = true; // 右回転フラグ
    private float initialYRotation; // 初期のY軸回転角度
    private bool initialRotationRecorded = false; // 初期角度が記録されたかどうかのフラグ
    private float rotationPauseTimer = 0f; // 回転が停止してからの経過時間
    private bool isRotating = true; // オブジェクトが現在回転しているかどうか
    private bool continuousRotation = false; // 連続回転フラグ
    private Dictionary<string, Action> fireTrapDataMethods = new Dictionary<string, Action>();
    [SerializeField] private string fireTrapDataAddress; // データアドレス

    private async void Start()
    {
        // ディクショナリにメソッドを登録する
        //fireTrapDataMethods["stg1firetrap1"] = RotateObjectContinuous;
        //fireTrapDataMethods["stg1firetrap2"] = RotateObject;
        //fireTrapDataMethods["stg1firetrap3"] = RotateObjectContinuous;
        //fireTrapDataMethods["stg1firetrap4"] = RotateObject;
        //fireTrapDataMethods["stg1firetrap5"] = RotateObjectContinuous;

        //fireTrapDataMethods["stg2firetrap1"] = RotateObject;
        //fireTrapDataMethods["stg2firetrap2"] = RotateObject;
        fireTrapDataMethods["stg2firetrap3"] = RotateObjectContinuous;
        //fireTrapDataMethods["stg2firetrap4"] = RotateObject;
        fireTrapDataMethods["stg2firetrap5"] = RotateObjectInverse;

        //fireTrapDataMethods["stg3firetrap1"] = RotateObject;
        //fireTrapDataMethods["stg3firetrap2"] = RotateObject;
        fireTrapDataMethods["stg3firetrap3"] = RotateObjectInverse;
        //fireTrapDataMethods["stg3firetrap4"] = RotateObject;
        //fireTrapDataMethods["stg3firetrap5"] = RotateObjectContinuous;

        // 指定されたアドレスのFireTrapDataを非同期でロード
        FireTrapData data = await AddressLoader.AddressLoad<FireTrapData>(fireTrapDataAddress);

        // ロードしたデータからパラメータを設定
        particleDisplayTime = data.particleDisplayTime;
        particleHideTime = data.particleHideTime;
        rotationSpeed = data.rotationSpeed;
        rotationPauseTime = data.rotationPauseTime;

        ShowParticle();
        Observable.EveryUpdate().Subscribe(_ =>
        {
            // fireTrapDataAddressの値に応じて対応するメソッドを呼び出す
            if (fireTrapDataMethods.ContainsKey(fireTrapDataAddress))
            {
                fireTrapDataMethods[fireTrapDataAddress].Invoke();
            }
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
        }).AddTo(this);

        Observable.EveryUpdate()
            .Where(_ => fireTrapDataMethods.ContainsKey(fireTrapDataAddress))
            .Subscribe(_ =>
            {
                fireTrapDataMethods[fireTrapDataAddress].Invoke();
            })
            .AddTo(this);
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
        Transform parentTransform = transform.parent;
        if (parentTransform == null) return;

        // 初期のY軸回転角度を記録
        if (!initialRotationRecorded)
        {
            initialYRotation = parentTransform.eulerAngles.y;
            initialRotationRecorded = true;
        }

        // 現在のY軸の角度を取得して初期角度からの差分を計算
        float currentAngle = Mathf.DeltaAngle(initialYRotation, parentTransform.eulerAngles.y);

        // 角度を正規化
        if (rotateRight && currentAngle <= -90f)
        {
            rotateRight = false;
            isRotating = false;
            rotationPauseTimer = 0f;
        }
        else if (!rotateRight && currentAngle >= 0f)
        {
            rotateRight = true;
            isRotating = false;
            rotationPauseTimer = 0f;
        }

        // 回転停止時間が経過したら再度回転を開始
        if (!isRotating && rotationPauseTimer >= rotationPauseTime)
        {
            isRotating = true;
        }

        // 回転方向に基づいて親オブジェクトを回転させる
        if (isRotating)
        {
            float rotationDirection = rotateRight ? -1f : 1f;
            parentTransform.Rotate(Vector3.up, rotationSpeed * rotationDirection * Time.deltaTime);
        }
        else
        {
            rotationPauseTimer += Time.deltaTime;
        }
    }
    // RotateObjectの逆回転版
    private void RotateObjectInverse()
    {
        Transform parentTransform = transform.parent;
        if (parentTransform == null) return;

        // 初期のY軸回転角度を記録
        if (!initialRotationRecorded)
        {
            initialYRotation = parentTransform.eulerAngles.y;
            initialRotationRecorded = true;
        }

        // 現在のY軸の角度を取得し、初期角度からの差分を計算
        float currentAngle = Mathf.DeltaAngle(initialYRotation, parentTransform.eulerAngles.y);

        // 角度を正規化
        if (rotateRight && currentAngle >= 90f)
        {
            rotateRight = false;
            isRotating = false;
            rotationPauseTimer = 0f;
        }
        else if (!rotateRight && currentAngle <= 0f)
        {
            rotateRight = true;
            isRotating = false;
            rotationPauseTimer = 0f;
        }

        // 回転停止時間が経過したら再度回転を開始
        if (!isRotating && rotationPauseTimer >= rotationPauseTime)
        {
            isRotating = true;
        }

        // 回転方向に基づいて親オブジェクトを回転させる
        if (isRotating)
        {
            float rotationDirection = rotateRight ? 1f : -1f;
            parentTransform.Rotate(Vector3.up, rotationSpeed * rotationDirection * Time.deltaTime);
        }
        else
        {
            rotationPauseTimer += Time.deltaTime;
        }
    }

    private void RotateObjectContinuous()
    {
        Transform parentTransform = transform.parent;
        if (parentTransform == null) return;

        // 親オブジェクトを一定の速度で永遠に回転させる
        parentTransform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}