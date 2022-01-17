using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public void RetryClicked()
    {
        //Fader.Instance.ChangeScene(EScene.GAME);
        GameController.Instance.SwitchScreen(EGameScreens.GAME);
    }
}
