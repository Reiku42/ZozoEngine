using UnityEngine;
using UnityEngine.Tilemaps;

namespace ZozoEngine
{
    public sealed class World : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField] private int _width;
        [SerializeField] private int _height;
        [SerializeField] private Tile _floor;
        [SerializeField] private Tile _wall;
#pragma warning restore CS0649

        private Tilemap _tilemap;
        private Map _map;

        private void Awake()
        {
            _tilemap = GetComponent<Tilemap>();

            var size = new Vector2Int(_width, _height);
            _map = new Map(size);
        }

        private void Start()
        {
            var start = new Vector2Int(0, 0);
            var end = _map.ClampToBounds(_map.Size);

            foreach (var point in Geometry.GetLine(start, end))
            {
                ref var cell = ref _map[point];
                cell.IsWalkable = true;
            }

            foreach (var cell in _map)
            {
                var tile = cell.IsWalkable ? _floor : _wall;
                _tilemap.SetTile((Vector3Int)cell.Position, tile);
            }
        }
    }
}
