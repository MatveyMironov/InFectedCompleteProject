using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProceduralLevelSystem
{
    internal class LevelGrid
    {
        private readonly Dictionary<Vector2Int, LevelFragment> _placement;

        public LevelGrid()
        {
            _placement = new();
        }

        public Vector2Int[] OccupiedPositions { get { return _placement.Keys.ToArray(); } }
        public LevelFragment[] PlacedFragments { get { return _placement.Values.ToArray(); } }

        public bool TryPlaceFragmentAtPosition(LevelFragment fragment, Vector2Int position)
        {
            if (_placement.ContainsKey(position))
            {
                return false;
            }

            _placement.Add(position, fragment);

            return true;
        }

        public bool TryRemoveFragmentAtPosition(Vector2Int position)
        {
            if (_placement.ContainsKey(position))
            {
                _placement.Remove(position);

                return true;
            }

            return false;
        }

        public bool TryGetFragmentAtPosition(Vector2Int position, out LevelFragment fragment)
        {
            fragment = null;

            if (_placement.ContainsKey(position))
            {
                fragment = _placement[position];

                return true;
            }

            return false;
        }
    }
}