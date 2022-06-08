// Based on https://github.com/samizzo/TypeSafeObjectPool

using UnityEngine;
using System.Collections.Generic;

namespace PaulMasriStone.Generic
{
    /// <summary>
    /// A type-safe, generic object pool. This object pool requires you to derive a class from it,
    /// and specify the type of object to pool.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [Tooltip("Prefab for this object pool")]
        public T _prefab;

        [Tooltip("Size of this object pool")]
        public IntVariable _size;
        private int Size { get => _size; set => _size.Value = value; }

        [Tooltip("Whether the object pool size can grow or not. If it grows it will permanently change the value of Size.")]
        public BoolVariable _canGrow;
        private bool CanGrow { get => _canGrow; set => _canGrow.Value = value; }

        // The list of free and used objects for tracking.
        private List<T> _freeList;
        private List<T> _usedList;

        public void Awake()
        {
            _freeList = new List<T>(Size);
            _usedList = new List<T>(Size);

            // Instantiate the pooled objects and disable them.
            for (var i = 0; i < Size; i++)
                _freeList.Add(NewObject());
        }

        /// <summary>
        /// Returns an object from the pool. Returns null if there are no more objects free in the pool.
        /// </summary>
        /// <returns>Object of type T from the pool.</returns>
        public T Get()
        {
            var numFree = _freeList.Count;
            if (numFree == 0)
            {
                if (CanGrow)
                {
                    // Create a new object and increment the allowed size
                    var pooledObject = NewObject();
                    Size++;
                    _usedList.Add(pooledObject);
                    return pooledObject;
                }
                else
                    return null;
            }
            else
            {
                // Pull an object from the end of the free list.
                var pooledObject = _freeList[numFree - 1];
                _freeList.RemoveAt(numFree - 1);
                _usedList.Add(pooledObject);
                return pooledObject;
            }
        }

        /// <summary>
        /// Releases an object back to the pool. The object must have been created by this ObjectPool.
        /// </summary>
        /// <param name="pooledObject">Object previously obtained from this ObjectPool</param>
        public void Release(T pooledObject)
        {
            Debug.Assert(_usedList.Contains(pooledObject));

            // Put the pooled object back in the free list.
            _usedList.Remove(pooledObject);
            _freeList.Add(pooledObject);

            // Reparent the pooled object to us, and disable it.
            var pooledObjectTransform = pooledObject.transform;
            pooledObjectTransform.parent = transform;
            pooledObjectTransform.localPosition = Vector3.zero;
            pooledObject.gameObject.SetActive(false);
        }

        private T NewObject()
        {
            var pooledObject = Instantiate(_prefab, transform);
            pooledObject.gameObject.SetActive(false);
            return pooledObject;        
        }
    }
}
