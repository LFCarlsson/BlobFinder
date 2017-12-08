using System;
using System.Collections.Generic;

namespace Disjoint_Set
{
    public class DisjointSetNode<T> where T : IComparable<T>
    {
        T representant; // the smallest value in the set.
        SortedSet<T> set;
        public SortedSet<T> Set { get => set; private set => this.set = value; }
        public T Representant { get => representant; internal set => representant = value; }

        public DisjointSetNode(T value)
        {
            Set = new SortedSet<T>();
            Set.Add(value);
            Representant = value;
        }
        /// <summary>
        /// Check if the set contains a certain value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            return set.Contains(value);
        }
        public DisjointSetNode(SortedSet<T> set)
        {
            Set = set;
            Representant = set.Min;
        }

        public override string ToString()
        {
            string result = string.Join(",", set);
            result = result.Insert(0, "{");
            result += "}";
            return result;
        }
    }
}