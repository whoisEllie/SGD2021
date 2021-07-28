using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScreen : ScreenBase
{
    public override void Show()
    {
        base.Show();
        App.playerManager.SetJoining(true);
    }

    public override void Hide()
    {
        base.Hide();
        App.playerManager.SetJoining(false);
    }

    public void BackButtonClicked()
    {
        App.gameManager.SetGameState(GameState.menu);
        App.screenManager.Show<MenuScreen>();
        Hide();
    }

    public void PlayButtonClicked()
    {
        if (!(App.playerManager.GetPlayerCount() == 2 || App.playerManager.GetPlayerCount() == 4))
            return;

        Time.timeScale = 1;
        App.gameManager.StartSceneLoading(App.gameManager.GetLevelScene());
        App.gameManager.SetGameState(GameState.game);
        App.screenManager.Show<InGameScreen>();
        App.playerManager.InitPlayers();
        App.playerManager.SetupCameras();
        Hide();
    }
}