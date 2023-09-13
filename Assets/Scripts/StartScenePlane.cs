using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScenePlane : MonoBehaviour
{
    float rightMax = 15.0f; //�·� �̵������� (x)�ִ밪

    float leftMax = -10.0f; //��� �̵������� (x)�ִ밪

    float currentPosition; //���� ��ġ(x) ����

    float direction = 8.0f; //�̵��ӵ�+����

    void Start()
    {
        currentPosition = transform.position.x;
    }

    void Update()

    {

        currentPosition += Time.deltaTime * direction;

        if (currentPosition >= rightMax)

        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            direction *= -1;

            currentPosition = rightMax;

        }

        //���� ��ġ(x)�� ��� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�

        //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� ��� �̵������� (x)�ִ밪���� ����

        else if (currentPosition <= leftMax)

        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            direction *= -1;

            currentPosition = leftMax;

        }

        //���� ��ġ(x)�� �·� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�

        //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� �·� �̵������� (x)�ִ밪���� ����

        transform.position = new Vector3(currentPosition, 0, 0);

        //"Stone"�� ��ġ�� ���� ������ġ�� ó��

    }
}
