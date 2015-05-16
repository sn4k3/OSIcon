using System;
using System.Collections;
using System.Collections.Generic;

namespace OSIcon.Controls
{
    public class RewindManager<T> : IEnumerable<T>
    {
        #region Properties

        /// <summary>
        /// Gets a list with all objects with the past information
        /// </summary>
        public List<T> History { get; private set; }

        /// <summary>
        /// Gets the current index on history
        /// </summary>
        public int CurrentIndex { get; private set; }

        /// <summary>
        /// Gets the current item at current index
        /// </summary>
        public T CurrentItem { get { return CurrentIndex >= 0 ? History[CurrentIndex] : default(T); } }

        /// <summary>
        /// Gets the total objects
        /// </summary>
        public int Count { get { return History.Count; } }

        /// <summary>
        /// Gets if is possible to go previous
        /// </summary>
        public bool CanPrevious { get { return CurrentIndex > 0; } }

        /// <summary>
        /// Gets if is possible to go forward
        /// </summary>
        public bool CanForward { get { return CurrentIndex < History.Count-1; } }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RewindManager()
        {
            History = new List<T>();
            CurrentIndex = -1;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Clear all items in history
        /// </summary>
        public void Clear()
        {
            CurrentIndex = -1;
            History.Clear();
        }

        /// <summary>
        /// Seek a object in history and return the index
        /// </summary>
        /// <param name="obj">Object to find</param>
        /// <returns>Item index, or -1 if not found</returns>
        public int Seek(T obj)
        {
            for (int i = History.Count - 1; i >= 0; i--)
            {
                var item = History[i];
                if (item.Equals(obj))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Go to object
        /// </summary>
        /// <param name="obj">Object to find</param>
        /// <returns>True if object exists, otherwise false.</returns>
        public bool Go(T obj)
        {
            var i = Seek(obj);
            if(i < 0)
                return false;

            CurrentIndex = i;

            return true;
        }

        /// <summary>
        /// Go to object and return his value.
        /// </summary>
        /// <param name="obj">Object to find.</param>
        /// <returns>Object if successfully found, otherwise a default value is returned, eg: null.</returns>
        public T GoAndReturn(T obj)
        {
            return Go(obj) ? CurrentItem : default(T);
        }

        /// <summary>
        /// Go to the previous item in history.
        /// </summary>
        /// <returns>True if can go to the previous item, otherwise false.</returns>
        public bool GoPrevious()
        {
            if (CurrentIndex <= 0)
                return false;

            CurrentIndex--;
            return true;
        }

        /// <summary>
        /// Go to the previous item in history and return his value.
        /// </summary>
        /// <returns>Object if successfully previous item exists, otherwise a default value is returned, eg: null.</returns>
        public T GoPreviousAndReturn()
        {
            return !GoPrevious() ? default(T) : CurrentItem;
        }

        /// <summary>
        /// Go to the forward item in history.
        /// </summary>
        /// <returns>True if can go to the forward item, otherwise false.</returns>
        public bool GoForward()
        {
            if (CurrentIndex >= History.Count-1)
                return false;

            CurrentIndex++;
            return true;
        }

        /// <summary>
        /// Go to the forward item in history and return his value.
        /// </summary>
        /// <returns>Object if successfully forward item exists, otherwise a default value is returned, eg: null.</returns>
        public T GoforwardAndReturn()
        {
            return !GoForward() ? default(T) : CurrentItem;
        }

        /// <summary>
        /// Add a object to this history list
        /// </summary>
        /// <param name="obj">Object to add</param>
        public void Add(T obj)
        {
            if (Count > 0 && obj.Equals(CurrentItem))
                return;
            for (var i = History.Count-1; i > CurrentIndex; i--)
            {
                History.RemoveAt(i);
            }
            History.Add(obj);
            CurrentIndex = History.Count - 1;
        }

        /// <summary>
        /// Add a object to this history list
        /// </summary>
        /// <param name="obj">Object to add</param>
        public void Add(T[] obj)
        {
            if (Count > 0 && obj[0].Equals(CurrentItem))
                return;
            for (var i = History.Count - 1; i > CurrentIndex; i--)
            {
                History.RemoveAt(i);
            }
            History.AddRange(obj);
            CurrentIndex = History.Count - 1;
        }

        #endregion

        #region Implementations
        public IEnumerator<T> GetEnumerator()
        {
            return History.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
