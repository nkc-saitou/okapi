using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpbar : MonoBehaviour {
    Slider _sliderA;
    Slider _sliderB;

    public float minusHP = 0.001f;

    public float _hpA = 1;
    public float _hpB = 1;
    public float Heal=2;
    private float _Heal;
    public float damage = 2;
    int suzuki;
    private float time;

    float flap = 550f;
    float scroll = 10f;
    float direction = 1f;
    int a;
    Rigidbody rbd;                      //gomi

    public Text text_hpa; public Text text_hpb; public Text text_stats;
    float stats;

    void Start()
    {
        _sliderA = GameObject.Find("SliderA").GetComponent<Slider>();
        _sliderB = GameObject.Find("SliderB").GetComponent<Slider>();
        _hpA = _sliderA.maxValue;
        _hpB = _sliderB.maxValue;

        rbd = GetComponent<Rigidbody>();

        suzuki = 0;

    }
     void Update()
    {
        text_hpa.text = _hpA.ToString(); text_hpb.text = _hpB.ToString();
        _sliderA.value = _hpA; _sliderB.value = _hpB;
        if (_hpA >=0)
        {
            _hpA -= minusHP;
            _hpB -= minusHP;
        }
        if (suzuki == 0)
        {
            if (0 > _hpA)
            {
                _hpA = 0;
                suzuki = 1;
                Debug.Log("sigeyamaA");
                text_stats.text = "HP0";
            }
        }
        if (_sliderA.maxValue <= _hpA || _sliderB.maxValue <= _hpB){
            _hpA = _sliderA.maxValue;
            _hpB = _sliderA.maxValue;
        }

        //消してどぞ
        rbd.velocity = new Vector3(scroll * direction, rbd.velocity.y, rbd.velocity.z);
        if (Input.GetKey(KeyCode.D)){
            a = 1;
            direction = 2f;
        }
        else if (Input.GetKey(KeyCode.A)){
            a = 2;
            direction = -2f;
        }
        else{
            direction = 0f;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (_hpA > 0)
        {
            //HP減
            if (other.gameObject.CompareTag("Enemy"))
            {
                _hpA -= damage;
                StartCoroutine("hpdamage");
                text_stats.text = "HP DOWN";
                Debug.Log("sigeyama");
            }

            //HP増
            if (other.gameObject.CompareTag("Heal"))
            {
                    _hpA += Heal;
                    _hpB += Heal;
                    text_stats.text = "HP UP";
                    Debug.Log("kaihuku");
            }
        }
        else
        {
            _hpA = 0; _hpB = 0;
        }
    }

    private IEnumerator hpdamage()
    {
        float a;
            while (true)
        {

            yield return new WaitForSeconds(time);
            a = _hpB - _hpA;
            time = 0.01f;
            _hpB -= 0.05f;
            if (_hpA>=_hpB)
            {
                _hpB = _hpA;
                Debug.Log("コルーチンおわり");
                yield break;
            }
        }
    }
}