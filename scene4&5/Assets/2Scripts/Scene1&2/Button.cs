using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // Ŭ���Ͽ� ���� ��ư
    public Button button;

    // Start() �Լ��� ó�� ����� �� ȣ��˴ϴ�.
    void Start()
    {
        // ��ư�� Ŭ�� �̺�Ʈ�� �Լ� ����
        button.onClick.AddListener(HideButton);
    }

    // ��ư ����� �Լ�
    void HideButton()
    {
        // ��ư ��Ȱ��ȭ
        button.gameObject.SetActive(false);
    }
}
