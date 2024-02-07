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
    [SerializeField] private StageTransition[] stageTransitions;
    [SerializeField] private FireParticleConfig[] fireParticleConfig;
    [SerializeField] private GameObject gameOverCanvas;
    private Subject<Unit> isGameClear = new Subject<Unit>();
    public IObservable<Unit> GameClearObserver => isGameClear;
    private Subject<Unit> isGameOver = new Subject<Unit>();
    public IObservable<Unit> GameOverObserver => isGameOver;
    CompositeDisposable disposables = new CompositeDisposable();
    void Start()
    {
        foreach (StageTransition stageTransition in stageTransitions)
        {
            stageTransition.PlayerClearObserver.Subscribe(_ =>
            {
                GameClear();
            }).AddTo(disposables);
        }
        foreach (FireParticleConfig fireParticleInstance in fireParticleConfig)
        {
            fireParticleInstance.PlayerDeadObserver.Subscribe(_ =>
            {
                GameOver();
            }).AddTo(disposables);
        }
    }
    private void GameClear()
    {
        // ゲームクリア処理を行う
        Debug.Log("Game Clear");
        isGameClear.OnNext(Unit.Default);
    }
    private void GameOver()
    {
        // ゲームオーバー処理を行う
        Debug.Log("Game Over");
        gameOverCanvas.gameObject.SetActive(true);
        isGameOver.OnNext(Unit.Default);
        Invoke("LoadTitleScene", 10f);
    }
    private void LoadTitleScene()
    {
        string titleSceneName = "TitleScene_" + DeviceModeManager.CurrentDeviceMode.ToString();
        SceneManager.LoadScene(titleSceneName);
    }
}