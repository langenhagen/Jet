using UnityEngine;
using System.Collections;

public class RestartButton : BarnBehaviour {

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Restart();
        }
    }

    void OnClick()
    {
        Restart();
    }

    public void Restart()
    {
        Application.LoadLevel(0);
    }


}
