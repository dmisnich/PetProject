using Character.API;
using UnityEngine;
using UnityEngine.AI;

namespace Character.Impl
{
    public class MouseCharacterMovement : ICharacterInput
    {
        private Transform _transform;
        private NavMeshAgent _agent;
        private bool _isRotation;

        private const float RotationSpeed = 10f;

        public MouseCharacterMovement(Transform transform, NavMeshAgent agent)
        {
            _transform = transform;
            _agent = agent;
        }

        private void Move()
        {
            _agent.SetDestination(_transform.position + _transform.forward);
        }

        private void Rotate()
        {
            float mouseX = Input.GetAxis("Mouse X");
            _transform.Rotate(Vector3.up * mouseX * RotationSpeed);
        }

        public void CharacterInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isRotation = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _isRotation = false;
            }

            if (_isRotation) Rotate();
            
            Move();
        }
    }
}