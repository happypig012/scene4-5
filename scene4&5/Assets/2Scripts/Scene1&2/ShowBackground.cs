using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class SpriteRendererClickHandler : MonoBehaviour
    {
        // ��������Ʈ �迭
        [SerializeField]
        public Sprite[] sprites;

        // ���� ǥ�õǴ� ��������Ʈ�� �ε���
        private int currentIndex = 0;

        // SpriteRenderer ������Ʈ
        private SpriteRenderer spriteRenderer;

        void Start()
        {
            // SpriteRenderer ������Ʈ ��������
            spriteRenderer = GetComponent<SpriteRenderer>();

            // ó���� ù ��° ��������Ʈ ǥ��
            spriteRenderer.sprite = sprites[currentIndex];
        }

        // SpriteRenderer Ŭ�� �̺�Ʈ �ڵ鷯
        void OnMouseDown()
        {
            // ���� ��������Ʈ �ε����� �̵�
            currentIndex++;

            // �ε����� �迭 ������ ����� ó������ ���ư�
            if (currentIndex >= sprites.Length)
            {
                spriteRenderer.gameObject.SetActive(false);
            }

            // ���� ��������Ʈ ǥ��
            spriteRenderer.sprite = sprites[currentIndex];
        }
    }

