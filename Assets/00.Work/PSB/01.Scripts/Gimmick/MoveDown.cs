using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float moveDistance = 5f;  // 블록이 이동할 거리
    public float moveDuration = 0.5f;  // 애니메이션 지속 시간


    public float minInterval = 1f;
    public float maxInterval = 10f;

    private Vector3 originalPosition;

    private void Start()
    {
        // 원래 위치 저장
        originalPosition = transform.position;

        // 코루틴 시작
        StartCoroutine(AnimateTileBlock());
    }

    private IEnumerator AnimateTileBlock()
    {
        while (true)
        {
            // 랜덤 interval 시간 대기
            float interval = Random.Range(minInterval, maxInterval);

            // 블록을 아래로 이동
            yield return StartCoroutine(MoveTileBlock(Vector3.down * moveDistance, moveDuration));
            yield return new WaitForSeconds(interval);

            // 블록을 원래 위치로 이동
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
