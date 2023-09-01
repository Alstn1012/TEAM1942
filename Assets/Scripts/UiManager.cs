using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject endingCredit;
    public GameObject endingCredit2;

    public float speed = 1f; // �ö󰡴� �ӵ�. Inspector���� ���� ����.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // endingCredit�� ���� ��ġ�� �����ɴϴ�.
        Vector3 currentPos = endingCredit.transform.position;

        // y ��ġ�� ������Ʈ �մϴ�.
        currentPos.y += speed * Time.deltaTime;

        // ������ ��ġ�� endingCredit2�� �ٽ� �����մϴ�.
        endingCredit.transform.position = currentPos;

        Vector3 currentPos1 = endingCredit2.transform.position;

        // y ��ġ�� ������Ʈ �մϴ�.
        currentPos1.y += speed * Time.deltaTime;

        // ������ ��ġ�� endingCredit2�� �ٽ� �����մϴ�.
        endingCredit2.transform.position = currentPos1;
    }
}

