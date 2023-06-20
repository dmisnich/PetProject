using Character.API;
using UnityEngine;
using UnityEngine.AI;

namespace Character.Impl
{
    public class TouchCharacterMovement : ICharacterInput
    {
        private Transform _transform;
        private NavMeshAgent _agent;
        private Vector2 _touchStartPosition;

        private const float AngleCoefficient = 0.2f;

        public TouchCharacterMovement(Transform transform, NavMeshAgent agent)
        {
            _transform = transform;
            _agent = agent;
        }
        
        private void Move()
        {
            _agent.SetDestination(_transform.position + _transform.forward);
        }

        private void Rotate(float angle)
        {
            Quaternion rotation = Quaternion.Euler(0f, angle, 0f);
            _transform.rotation *= rotation;
        }
        
        public void CharacterInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    _touchStartPosition = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 touchDelta = touch.position - _touchStartPosition;
                    float rotationAngle = touchDelta.x * AngleCoefficient;

                    Rotate(rotationAngle);
                }
            }
            
            Move();
        }
    }
}