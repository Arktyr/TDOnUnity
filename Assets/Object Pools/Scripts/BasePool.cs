using System;
using System.Collections.Generic;
using Enemies.Scripts;
using UnityEngine;

namespace Object_Pools.Scripts
{
    public abstract class BasePool<T> : MonoBehaviour
    {
        [SerializeField] private float startCountObjectPool;

        private bool _isCreate;
        private int _currentObjectCount;
        
        private readonly Queue<T> _objectPool = new();
        private readonly Queue<T> _activeObjects = new();

        private Func<T, T> _createEnemy;
        
        private Action<T> _setDisable;
        private Action<T> _setActive;
        private Action<T> _removeFromEvent;
        private Action<T> _addToEvent;
        private Action<T, Vector3> _setTransform;
        
        public bool IsCreate => _isCreate;

        protected void Construct(Func<T, T> createEnemy, Action<T> setDisable, Action<T> setActive,
            Action<T> removeFromEvent, Action<T> addToEvent, Action<T, Vector3> setTransform)
        {
            _createEnemy = createEnemy;
            _setDisable = setDisable;
            _setActive = setActive;
            _removeFromEvent = removeFromEvent;
            _addToEvent = addToEvent;
            _setTransform = setTransform;
        }
        
        public void CreatePool(T currentObject)
        {
            _isCreate = true;
            
            for (int i = 0; i < startCountObjectPool; i++) _setDisable(AddToPool(currentObject));
        }

        public T TakeFromPool(T currentObject, Vector3 position)
        {
            if (_objectPool.Count == 0) AddToPool(currentObject);
            
            _activeObjects.Enqueue(_objectPool.Dequeue());

            _addToEvent(_activeObjects.Peek());
            _setActive(_activeObjects.Peek());
            _setTransform(_activeObjects.Peek(), position);
            
            return _activeObjects.Dequeue();
        }

        protected void ReturnToPool(T currentObject)
        {
            _removeFromEvent(currentObject);
            
            _objectPool.Enqueue(currentObject);
            _setDisable(currentObject);
        }

        private T AddToPool(T currentObject)
        {
            T newObject = _createEnemy(currentObject);
            
            _objectPool.Enqueue(newObject);
            return newObject;
        }
    }
}