using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private int apples = 10; // int - целое число
    private float speed = 10.5f; // float - число с дробной частью // private - доступ к переменной только внутри скрипта
    public bool isTouched = false; // bool - логический тип данных может быть только true и false // public - доступ в других скриптах и инспекторе

    // Start is called before the first frame update
    void Start()
    {
        apples = 20;
        Debug.Log("hello world" + apples);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isTouched = !isTouched;
            if (isTouched)
            {
                apples++; //++ = +=1
                Debug.Log("privet" + apples);
            }


        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            speed = speed / 2;
            Debug.Log("speed " + speed);
        }
    }
}
