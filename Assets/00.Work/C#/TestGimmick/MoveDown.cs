using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float moveDistance = 5f;  // ����� �̵��� �Ÿ�
    public float moveDuration = 0.5f;  // �ִϸ��̼� ���� �ð�


    public float minInterval = 1f;
    public float maxInterval = 10f;

    private Vector3 originalPosition;

    private void Start()
    {
        // ���� ��ġ ����
        originalPosition = transform.position;

        // �ڷ�ƾ ����
        StartCoroutine(AnimateTileBlock());
    }

    private IEnumerator AnimateTileBlock()
    {
        while (true)
        {
            // ���� interval �ð� ���
            float interval = Random.Range(minInterval, maxInterval);

            // ����� �Ʒ��� �̵�
            yield return StartCoroutine(MoveTileBlock(Vector3.down * moveDistance, moveDuration));
            yield return new WaitForSeconds(interval);

            // ����� ���� ��ġ�� �̵�
            yield return StartCoroutine(MoveTileBlock(Vector3.up * moveDistance, moveDuration));
            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator MoveTileBlock(Vector3 V3, float overTime)
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + V3;
        float startTime = Time.time;

        while (Time.time < startTime + overTime)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, (Time.time - startTime) / overTime);
            yield return null;
        }
        transform.position = endPosition;
    }
}
