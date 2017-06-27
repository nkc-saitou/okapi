using UnityEngine;
using System.Collections;

public class stageSelectmain : MonoBehaviour
{
    private float fadetime;
	public void FadeScene (float fadetime)
	{
        //"sample"に移行したいシーン名を入力
		FadeManager.Instance.LoadScene ("main", fadetime);
        //移行するシーンがsampleのため"sample"
	}
}
