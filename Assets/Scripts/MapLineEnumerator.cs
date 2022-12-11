using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZozoEngine
{
    public struct MapLineEnumerator : IEnumerator<Cell>
    {
        private readonly Map _map;
        private readonly Vector2Int _start;
        private readonly Vector2Int _end;
        private Vector2Int _current;

        public MapLineEnumerator(Map map, Vector2Int start, Vector2Int end)
        {
            _map = map;
            _start = start;
            _end = end;
            _current = Vector2Int.zero;
            Reset();
        }

        public Cell Current => _map.GetCell(_current);

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            _current.x = -1;
            _current.y = 0;
        }

        public void Dispose()
        {
        }
    }
}