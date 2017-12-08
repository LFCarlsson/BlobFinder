using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disjoint_Set
{
    public class DisjointSet<T> where T : IComparable<T>
    {

        private List<DisjointSetNode<T>> sets;

        public List<DisjointSetNode<T>> Sets { get => sets; private set => sets = value; }

        public DisjointSet()
        {
            Sets = new List<DisjointSetNode<T>>();
        }

        override public string ToString()
        {
            string result = "";
            for(int i = 0; i < sets.Count(); i++)
            {
                result += sets[i];
                if(i != sets.Count -1)
                    result += "\n";
            }
            return result;
            
        }

        public void AddSet(T value)
        {
            AddSet(new T[] { value });
        }

        public int Count()
        {
            return Sets.Count();
        }

        public void AddSet(T[] values)
        {
            var newSet = new SortedSet<T>();
            foreach(T value in values)
            {
                newSet.Add(value);
            }
            Sets.Add(new DisjointSetNode<T>(newSet));
        }

        public DisjointSetNode<T> Find(T value)
        {
            foreach(var set in Sets)
            {
                if (set.Contains(value)) {
                    return set;
                }
            }
            throw (new KeyNotFoundException("value not in set"));
        }

        public T FindRepresentant (T value)
        {
            return Find(value).Representant;
        }

        public void Merge(T firstVal, T secondVal)
        {
            DisjointSetNode<T> firstSet = Find(firstVal);
            DisjointSetNode<T> secondSet = Find(secondVal);
            int firstCompSecond = firstSet.Representant.CompareTo(secondSet.Representant);
            if (firstCompSecond < 0)
            {
                firstSet.Set.UnionWith(secondSet.Set);
                sets.Remove(secondSet);
            }
            if (firstCompSecond > 0)
            {
                secondSet.Set.UnionWith(firstSet.Set);
                sets.Remove(firstSet);
            }
        }

        private DisjointSetNode<T> GetSetFromRepresentant(T representant)
        {
            foreach(var set in Sets)
            {
                if (set.Representant.Equals(representant))
                {
                    return set;
                }
            }
            return null;
        }
    }
}
