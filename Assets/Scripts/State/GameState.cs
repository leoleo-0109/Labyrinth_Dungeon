using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameState : MonoBehaviour
{
    [SerializeField] private FireParticleConfig[] fireParticleConfig;
    [SerializeField] private GameObject gameOverCanvas;
    private Subject<Unit> isGameOver = new Subject<Unit>();
    public IObservable<Unit> GameOverObserver => isGameOver;
    CompositeDisposable disposables = new CompositeDisposable();
    void Start()
    {
        foreach (FireParticleConfig fireParticleInstance in fireParticleConfig)
        {
            fireParticleInstance.playerDeadObserver.Subscribe(_ =>
            {
                GameOver();
            }).AddTo(disposables);
        }
    }
    private void GameOver()
    {
        // ゲームオーバー処理を行う
        Debug.Log("Game Over");
        gameOverCanvas.gameObject.SetActive(true);
        isGameOver.OnNext(Unit.Default);
        Invoke("LoadTitle", 10f);
    }
}