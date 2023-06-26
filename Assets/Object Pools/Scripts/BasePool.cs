using System;
using System.Collections.Generic;
using UnityEngine;

namespace Object_Pools.Scripts
{
    public abstract class BasePool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private float startCountObjectPool;

        private bool _isCreate;
        private int _currentObjectCount;
        
        private readonly Queue<T> _objectPool = new();
        private readonly Queue<T> _activeObjects = new();
        
        
        private Action<T> _removeFromEvent;
        private Action<T> _addToEvent;

        public bool IsCreate => _isCreate;

        protected void Construct(Action<T> removeFromEvent, Action<T> addToEvent)
        {
            _removeFromEvent = removeFromEvent;
            _addToEvent = addToEvent;
        }
        
        public void CreatePool(T currentObject)
        {
            _isCreate = true;
            
            for (int i = 0; i < startCountObjectPool; i++) AddToPool(currentObject).gameObject.SetActive(false);
        }

        public T TakeFromPool(T currentObject, Vector3 position)
        {
            if (_objectPool.Count == 0) AddToPool(currentObject);
            
            _activeObjects.Enqueue(_objectPool.Dequeue());
            _addToEvent(_activeObjects.Peek());
            _activeObjects.Peek().gameObject.SetActive(true);
            _activeObjects.Peek().transform.position = position;
            
            return _activeObjects.Dequeue();
        }

        protected void ReturnToPool(T currentObject)
        {
            _removeFromEvent(currentObject);
            
            _objectPool.Enqueue(currentObject);
            currentObject.gameObject.SetActive(false);
        }

        private T AddToPool(T currentObject)
        {
            T newObject = Instantiate(currentObject, transform.parent);
            
            _objectPool.Enqueue(newObject);
            return newObject;
        }
    }
}