using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private int apples = 10; // int - ����� �����
    private float speed = 10.5f; // float - ����� � ������� ������ // private - ������ � ���������� ������ ������ �������
    public bool isTouched = false; // bool - ���������� ��� ������ ����� ���� ������ true � false // public - ������ � ������ �������� � ����������

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
