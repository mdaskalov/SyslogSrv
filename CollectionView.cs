#region License
/*
License
---------------------------------

Ionic's IE Cache Viewer is a tool that allows you to view and
manipulate the contents of your Internet Explorer (IE) Cache. 

Written by: Ionic Shade
dpchiesa [AT] hotmail.com 
Copyright (c) 2005  Ionic Shade
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

    * Redistributions of source code must retain the above copyright notice,
      this list of conditions and the following disclaimer.

    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.

    * Neither the name of Ionic Shade nor the names of any
      contributors to this project may be used to endorse or
      promote products derived from this software without
      specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.

*/
#endregion

// 
// I grabbed this from Brendan tompkins
// http://dotnetjunkies.com/WebLog/bsblog/archive/2004/09/02/24116.aspx
//
// I changed a few things: 
//   - support for "Includes" and "NotIncludes" filters in addition to the "Equals" and NotEquals filters
//   - better support sorting and filtering at the same time. Eg, when removing a filter, need to re-sort. 
//   - caching of property descriptors
// 


using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace Helper
{

    [ToolboxItem(true)]
    [DesignTimeVisible(true)]
    [Serializable()]
    public class CollectionView : IBindingList, IComponent, IDisposable
    {
        public event System.ComponentModel.ListChangedEventHandler ListChanged;

        /// <summary>
        /// Creates a new <see cref="CollectionView"/> instance.
        /// </summary>
        /// <param name="list">List.</param>
        public CollectionView(IList list)
        {
            baseList = list;
            if (BaseList is IBindingList)
            {
                supportsBinding = true;
                bindingList = ((IBindingList)BaseList);
                bindingList.ListChanged += new ListChangedEventHandler(SourceChanged);
            }
        }

        /// <summary>
        /// ADDs this instance.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns></returns>
        public int Add(object value)
        {
            return BaseList.Add(value);
        }

        /// <summary>
        /// ADDs the index.
        /// </summary>
        /// <param name="property">Property.</param>
        public void AddIndex(System.ComponentModel.PropertyDescriptor property)
        {
            if (supportsBinding)
            {
                bindingList.AddIndex(property);
            }
        }

        /// <summary>
        /// ADDs the new.
        /// </summary>
        /// <returns></returns>
        public object AddNew()
        {
            if (supportsBinding)
            {
                return bindingList.AddNew();
            }
            return null;
        }

        /// <summary>
        /// Applys the filter.
        /// </summary>
        /// <param name="property">Property.</param>
        /// <param name="compareValue">Compare value.</param>
        public void ApplyFilter(string property, object compareValue)
        {
            this.ApplyFilter(property, compareValue, FilterOperand.Equals);
        }

        /// <summary>
        /// Operand to use when filtering...
        /// </summary>
        public enum FilterOperand
        {
            Equals,
            NotEquals,
            Includes,
            NotIncludes,
        }

        /// <summary>
        /// Applys the filter.
        /// </summary>
        /// <param name="property">Property.</param>
        /// <param name="compareValue">Compare value.</param>
        public void ApplyFilter(string property, object compareValue, FilterOperand operand)
        {
            PropertyDescriptor filterBy = GetPropertyDescriptor(property);

            if (filterBy != null)
            {
                filteredList = new ArrayList();

                foreach (object obj in baseList)
                {
                    Object f = filterBy.GetValue(obj);
                    switch (operand)
                    {
                        case FilterOperand.Equals:
                            if (f.Equals(compareValue)) filteredList.Add(obj);
                            break;

                        case FilterOperand.NotEquals:
                            if (!(f.Equals(compareValue))) filteredList.Add(obj);
                            break;

                        case FilterOperand.Includes:
                            try
                            {
                                string s1 = f.ToString();
                                string s2 = compareValue.ToString();
                                if (s1.LastIndexOf(s2) != -1) filteredList.Add(obj);
                            }
                            catch { }
                            break;

                        case FilterOperand.NotIncludes:
                            try
                            {
                                string s1 = f.ToString();
                                string s2 = compareValue.ToString();
                                if (s1.LastIndexOf(s2) == -1) filteredList.Add(obj);
                            }
                            catch { }
                            break;

                    }
                }

                isFiltered = true;

                // re-apply sort if necessary
                if (isSorted) DoSort();

                if (ListChanged != null)
                {
                    ListChanged(this, new ListChangedEventArgs(ListChangedType.Reset, 0));
                }
            }
        }

        /// <summary>
        /// Applys the sort.
        /// </summary>
        /// <param name="property">Property.</param>
        /// <param name="direction">Direction.</param>
        public void ApplySort(string property, System.ComponentModel.ListSortDirection direction)
        {
            sortBy = GetPropertyDescriptor(property);
            ApplySort(sortBy, direction);
        }

        /// <summary>
        /// Applys the sort.
        /// </summary>
        /// <param name="property">Property.</param>
        /// <param name="direction">Direction.</param>
        public void ApplySort(System.ComponentModel.PropertyDescriptor property, System.ComponentModel.ListSortDirection direction)
        {
            sortBy = property;
            sortDirection = direction;
            DoSort();
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            BaseList.Clear();
            PropertyHash = new Hashtable();
        }

        /// <summary>
        /// Containss this instance.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns></returns>
        public bool Contains(object value)
        {
            return BaseList.Contains(value);
        }

        /// <summary>
        /// Copys the to.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="index">Index.</param>
        public void CopyTo(System.Array array, int index)
        {
            BaseList.CopyTo(array, index);
        }

        /// <summary>
        /// Finds this instance.
        /// </summary>
        /// <param name="property">Property.</param>
        /// <param name="key">Key.</param>
        /// <returns></returns>
        public int Find(System.ComponentModel.PropertyDescriptor property, object key)
        {
            if (supportsBinding)
            {
                return bindingList.Find(property, key);
            }
            else return -1;
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns></returns>
        public System.Collections.IEnumerator GetEnumerator()
        {
            if (IsSorted)
            {
                return new SortedEnumerator(sortedList, sortDirection);
            }
            else
            {
                return BaseList.GetEnumerator();
            }
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns></returns>
        public int IndexOf(object value)
        {
            if (isSorted)
            {
                int index = 0;
                foreach (ListItem item in sortedList)
                {
                    if (item.Item.Equals(value))
                    {
                        return index;
                    }
                    index += 1;
                }
                return -1;
            }
            else
            {
                return BaseList.IndexOf(value);
            }
        }

        /// <summary>
        /// Inserts the value at the given index.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="value">Value.</param>
        public void Insert(int index, object value)
        {
            // this won't work, needs to consider sorting.
            BaseList.Insert(index, value);
        }

        /// <summary>
        /// Removes the given value from the list.
        /// </summary>
        /// <param name="value">Value.</param>
        public void Remove(object value)
        {
            BaseList.Remove(value);
        }

        /// <summary>
        /// Removes the item at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public void RemoveAt(int index)
        {
            int pos = index;

            // Cannot just call BaseList.RemoveAt(pos) - it will not work 
            // if a filter is in place.  The item is removed from the 
            // filtered list, but not from the original list.  When the 
            // filter is cleared (removed), then the item that had been 
            // RemoveAt()'d is back !

            // Instead we get the object at the given position in the list, 
            // then remove that object from the original list.  Then check if 
            // the filter is applied, and if so remove the object in the 
            // filtered list. 

            if (isSorted)
            {
                Object o = GetSortedItem(pos);
                pos = BaseList.IndexOf(o);
                if (pos >= 0)
                {
                    // Console.WriteLine("Removing item (sorted index={0}, base index={1})", index, pos);
                    // WinInet.UrlCacheEntry entry= (WinInet.UrlCacheEntry) o;
                    // Console.WriteLine("item: {0}, {1})", entry.index, entry.SourceUrlName);

                    // remove from the base list
                    baseList.Remove(o);

                    // if filtered, remove from that copy also
                    if (isFiltered) filteredList.RemoveAt(pos); //  filteredList is a partial copy of baseList

                    // and since we are sorted, we need to remove it from that list, too. 
                    // the index depends on the sort order
                    pos = (this.sortDirection == ListSortDirection.Ascending) ? index : sortedList.Count - index - 1;
                    sortedList.RemoveAt(pos);

                }
                // when sort direction is reversed, the sortedList stays the same, 
                // so we have to apply the index from the tail end of the list.  
            }
            else
            {
                Object o = BaseList[pos];
                baseList.Remove(o);
                if (isFiltered) BaseList.RemoveAt(pos);
            }

            // finally, fire the ListChanged events, if any
            if (ListChanged != null)
            {
                ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemDeleted, pos));
            }
        }

        /// <summary>
        /// Removes the filter, fires the ListChanged event.
        /// </summary>
        public void RemoveFilter()
        {
            if (isFiltered)
            {
                filteredList = null;
                isFiltered = false;
                if (isSorted) DoSort();  // any sort that was in place is invalidated when a filter is removed.
                if (ListChanged != null)
                {
                    ListChanged(this, new ListChangedEventArgs(ListChangedType.Reset, 0));
                }
            }
        }

        /// <summary>
        /// Removes the index.
        /// </summary>
        /// <param name="property">Property.</param>
        public void RemoveIndex(System.ComponentModel.PropertyDescriptor property)
        {
            if (supportsBinding)
            {
                bindingList.RemoveIndex(property);
            }
        }

        /// <summary>
        /// Removes the sort.
        /// </summary>
        public void RemoveSort()
        {
            if (isSorted) UndoSort();
        }

        /// <summary>
        /// Gets a value indicating whether [allow edit].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [allow edit]; otherwise, <c>false</c>.
        /// </value>
        public bool AllowEdit
        {
            get
            {
                if (supportsBinding)
                {
                    return bindingList.AllowEdit;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [allow new].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [allow new]; otherwise, <c>false</c>.
        /// </value>
        public bool AllowNew
        {
            get
            {
                if (supportsBinding)
                {
                    return bindingList.AllowNew;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [allow remove].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [allow remove]; otherwise, <c>false</c>.
        /// </value>
        public bool AllowRemove
        {
            get
            {
                if (supportsBinding)
                {
                    return bindingList.AllowRemove;
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// Gets the base list.
        /// </summary>
        /// <value></value>
        public IList BaseList
        {
            get
            {
                return (isFiltered) ? filteredList : baseList;
            }
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value></value>
        public int Count
        {
            get
            {
                return BaseList.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [is fixed size].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [is fixed size]; otherwise, <c>false</c>.
        /// </value>
        public bool IsFixedSize
        {
            get
            {
                return BaseList.IsFixedSize;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [is read only].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [is read only]; otherwise, <c>false</c>.
        /// </value>
        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [is sorted].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [is sorted]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSorted
        {
            get
            {
                return isSorted;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [is synchronized].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [is synchronized]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSynchronized
        {
            get
            {
                return BaseList.IsSynchronized;
            }
        }

        /// <summary>
        /// Gets the sort direction.
        /// </summary>
        /// <value></value>
        public System.ComponentModel.ListSortDirection SortDirection
        {
            get
            {
                return sortDirection;
            }
        }

        /// <summary>
        /// Gets the sort property.
        /// </summary>
        /// <value></value>
        public System.ComponentModel.PropertyDescriptor SortProperty
        {
            get
            {
                return sortBy;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [supports change notification].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [supports change notification]; otherwise, <c>false</c>.
        /// </value>
        public bool SupportsChangeNotification
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [supports searching].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [supports searching]; otherwise, <c>false</c>.
        /// </value>
        public bool SupportsSearching
        {
            get
            {
                if (supportsBinding)
                {
                    return bindingList.SupportsSearching;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [supports sorting].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [supports sorting]; otherwise, <c>false</c>.
        /// </value>
        public bool SupportsSorting
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the sync root.
        /// </summary>
        /// <value></value>
        public object SyncRoot
        {
            get
            {
                return BaseList.SyncRoot;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified index.
        /// </summary>
        /// <value></value>
        public object this[int index]
        {
            get
            {
                if (isSorted)
                {
                    return GetSortedItem(index);
                }
                else
                {
                    return BaseList[index];
                }
            }
            set
            {
                if (isSorted)
                {
                    int pos = BaseList.IndexOf(GetSortedItem(index));
                    BaseList[pos] = value;
                    if (!supportsBinding)
                    {
                        DoSort();
                    }
                }
                else
                {
                    BaseList[index] = value;
                }
            }
        }
        private IList baseList;

        private IBindingList bindingList;
        private ArrayList filteredList;
        private bool isFiltered = false;
        private bool isSorted = false;
        private PropertyDescriptor sortBy;
        private ListSortDirection sortDirection = ListSortDirection.Ascending;
        private ArrayList sortedList = new ArrayList();
        private bool supportsBinding;

        /// <summary>
        /// Does the sort.
        /// </summary>
        private void DoSort()
        {
            sortedList.Clear();
            if (sortBy == null)
            {
                foreach (object obj in BaseList)
                {
                    sortedList.Add(new ListItem(obj, obj));
                }
            }
            else
            {
                foreach (object obj in BaseList)
                {
                    sortedList.Add(new ListItem(sortBy.GetValue(obj), obj));
                }
            }
            sortedList.Sort();
            isSorted = true;
            if (ListChanged != null)
            {
                ListChanged(this, new ListChangedEventArgs(ListChangedType.Reset, 0));
            }
        }

        /// <summary>
        /// Gets the property descriptor.
        /// </summary>
        /// <param name="property">Property.</param>
        /// <returns></returns>
        /// 
        System.Collections.Hashtable PropertyHash = new Hashtable();
        private PropertyDescriptor GetPropertyDescriptor(string property)
        {
            Type itemType = null;
            if (property.Length > 0)
            {

                if (PropertyHash.Count == 0)
                {
                    PropertyDescriptorCollection props = null;
                    Type t = ((object)baseList).GetType();
                    MemberInfo[] defaultMembers = t.GetDefaultMembers();
                    foreach (MemberInfo member in defaultMembers)
                    {
                        if (member.MemberType == MemberTypes.Property)
                        {
                            itemType = ((PropertyInfo)member).GetGetMethod().ReturnType;
                            props = TypeDescriptor.GetProperties(itemType);
                            break;
                        }
                    }

                    // if it is not a strongly-typed collection (eg if arraylist, etc)
                    // then just get the base type of the zeroth elt and assume all elts are the same. 
                    if (props == null || props.Count == 0)
                    {
                        if (baseList.Count > 0)
                        {
                            itemType = baseList[0].GetType();
                            props = TypeDescriptor.GetProperties(itemType);
                        }
                        else
                        {
                            throw new Exception("Can not determine collection item type");
                        }
                    }

                    // if I have a non-null props, then store the properties in the hash
                    if (props != null && props.Count != 0)
                    {
                        foreach (PropertyDescriptor prop in props)
                            PropertyHash[prop.Name] = prop;

                    }
                }
                if (PropertyHash.ContainsKey(property))
                    return (PropertyDescriptor)PropertyHash[property];
            }

            return null;
        }


        /// <summary>
        /// Gets the sorted item.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <returns></returns>
        private object GetSortedItem(int index)
        {
            if (sortDirection == ListSortDirection.Ascending)
            {
                return ((ListItem)sortedList[index]).Item;
            }
            else
            {
                return ((ListItem)sortedList[sortedList.Count - 1 - index]).Item;
            }
        }

        /// <summary>
        /// changes the source. 
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void SourceChanged(object sender, ListChangedEventArgs e)
        {
            if (isSorted)
            {
                if (e.ListChangedType == ListChangedType.ItemAdded)
                {
                    if (sortDirection == ListSortDirection.Ascending)
                    {
                        sortedList.Add(new ListItem(sortBy.GetValue(BaseList[e.NewIndex]), BaseList[e.NewIndex]));
                    }
                    else
                    {
                        sortedList.Insert(0, new ListItem(sortBy.GetValue(BaseList[e.NewIndex]), BaseList[e.NewIndex]));
                    }
                    if (ListChanged != null)
                    {
                        ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemAdded, sortedList.Count - 1));
                    }
                }
                else
                {
                    DoSort();
                }
            }
            else
            {
                if (ListChanged != null)
                {
                    ListChanged(this, e);
                }
            }
        }

        /// <summary>
        /// Undoes the sort.
        /// </summary>
        private void UndoSort()
        {
            sortedList.Clear();
            sortBy = null;
            sortDirection = ListSortDirection.Ascending;
            isSorted = false;
            if (ListChanged != null)
            {
                ListChanged(this, new ListChangedEventArgs(ListChangedType.Reset, 0));
            }
        }

        #region ListItem Inner Class
        private class ListItem : IComparable
        {
            public object Item;
            public object Key;

            public ListItem(object key, object item)
            {
                this.Key = key;
                this.Item = item;
            }

            public int CompareTo(object obj)
            {
                object target = ((ListItem)obj).Key;
                if (Key is IComparable)
                {
                    return ((IComparable)Key).CompareTo(target);
                }
                else
                {
                    if (Key.Equals(target))
                    {
                        return 0;
                    }
                    else
                    {
                        return Key.ToString().CompareTo(target.ToString());
                    }
                }
            }

            public override string ToString()
            {
                return Key.ToString();
            }
        }
        #endregion

        #region SortedEnumerator Inner Class
        private class SortedEnumerator : IEnumerator
        {

            public SortedEnumerator(ArrayList sortIndex, ListSortDirection direction)
            {
                mSortIndex = sortIndex;
                mSortOrder = direction;
                Reset();
            }

            public bool MoveNext()
            {
                if (mSortOrder == ListSortDirection.Ascending)
                {
                    if (index < mSortIndex.Count - 1)
                    {
                        index += 1;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (index > 0)
                    {
                        index -= 1;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public void Reset()
            {
                if (mSortOrder == ListSortDirection.Ascending)
                {
                    index = -1;
                }
                else
                {
                    index = mSortIndex.Count;
                }
            }

            public object Current
            {
                get
                {
                    return ((ListItem)mSortIndex[index]).Item;
                }
            }
            private int index;
            private ArrayList mSortIndex;
            private ListSortDirection mSortOrder;
        }
        #endregion

        #region IComponent Members

        /// <summary>
        /// Get/Set the site where this data is
        /// located.
        /// </summary>
        public ISite Site
        {
            get { return _site; }
            set { _site = value; }
        }
        // Added to implement Site property correctly.
        private ISite _site = null;
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Notify those that care when we dispose.
        /// </summary>
        public event System.EventHandler Disposed;

        /// <summary>
        /// Clean up. Nothing here though.
        /// </summary>
        public void Dispose()
        {
            // Nothing to clean.
            if (Disposed != null)
                Disposed(this, EventArgs.Empty);
        }
        #endregion
    }
}

