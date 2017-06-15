using System.Collections;
using UnityEngine;

public class stageSelect : MonoBehaviour
{
    public int stageNo;

    public void SceneLoad()
    {
        switch (stageNo)
        {
            case 1:
                Application.LoadLevel("main");
                break;

            case 2:
                Application.LoadLevel("main");
                break;

            case 3:
                Application.LoadLevel("main");
                break;

            case 4:
                Application.LoadLevel("main");
                break;

            case 5:
                Application.LoadLevel("main");
                break;

            case 6:
                Application.LoadLevel("main");
                break;
        }
    }
}