using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCard : MonoBehaviour
{
    public float xZoomSize = 3.6f;
    public float yZoomSize = 4.8f;

    private Vector3 originalScale;
    private Vector3 offset;
    private Vector3 originalPosition;

    public BoxCollider2D box;

    private bool isDragging = false;

    private void Start()
    {
        originalScale = new Vector3(3.0f, 4.0f, 1.0f);
        //originalPosition = transform.position;
        BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnMouseDown()
    {
        isDragging = true;
        originalPosition = transform.position;
        //originalPosition = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        transform.DOMove(originalPosition, 1.0f).SetEase(Ease.OutExpo);
        // �ж��Ƿ��Ʊ������������������㣬ִ����Ӧ�Ĳ���

        // ������Ӵ���������Ƶ��߼����������Ƿ��Ƴ���ĳ�������

        // �������û�б��������ָ�ԭʼ��С��λ��
        transform.localScale = originalScale;
    }

    private void OnMouseEnter()
    {
        if (!isDragging)
        {
            transform.localScale = new Vector3(xZoomSize, yZoomSize, 1);
            //box.size = new Vector2(1.2f, 1.2f);
        }
    }

    private void OnMouseExit()
    {
        if (!isDragging)
        {
            transform.localScale = originalScale;
            //box.size = new Vector2(1.0f, 1.0f);
        }
    }
}
