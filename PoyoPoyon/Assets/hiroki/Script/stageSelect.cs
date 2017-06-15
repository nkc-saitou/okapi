using System.Collections;
using UnityEngine;

public class stageSelect : MonoBehaviour
{
<<<<<<< HEAD
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
=======

    public void SceneLoad()
    {
        Application.LoadLevel("main");
>>>>>>> c6b3ecf3a18186c2553fa675abdcb3d194e08ec8
    }
}