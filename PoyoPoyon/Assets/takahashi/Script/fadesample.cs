using UnityEngine;
using System.Collections;

public class fadesample : MonoBehaviour
{
    private float fadetime;
	public void FadeScene (float fadetime)
	{
        //"sample"に移行したいシーン名を入力
		FadeManager.Instance.LoadScene ("sample", fadetime);
        //移行するシーンがsampleのため"sample"
	}
}
