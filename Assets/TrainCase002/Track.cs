using UnityEngine;

public abstract class Track : MonoBehaviour
{
    // 추상 메서드: 하위 클래스에서 구현해야 함
    public abstract void MoveTrain(Train train, float speed);
}