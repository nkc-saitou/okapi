using UnityEngine;
using System.Collections;

public class fadesample2 : MonoBehaviour
{
    private float fadetime;
	public void FadeScene (float fadetime)
	{
        //"sample"に移行したいシーン名を入力
		FadeManager.Instance.LoadScene ("sample2", fadetime);
        //移行するシーンがsampleのため"sample"
	}
}
