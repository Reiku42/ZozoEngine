using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ZozoEngine
{
    public sealed class World : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField] private Tile _floor;
        [SerializeField] private Tile _wall;
#pragma warning restore CS0649

        private Tilemap _tilemap;
        private Map _map;

        private void Awake()
        {
            _tilemap = GetComponent<Tilemap>();

            var size = new Vector2Int(10, 10);
            _map = new Map(size);
        }

        private void Start()
        {
            var start = new Vector2Int(0, 1);
            var end = new Vector2Int(6, 4);

            foreach (var cell in _map.GetCellsAlongLine(start, end))
            {
                var position = cell.Position;
                ref var actualCell = ref _map.GetCell(position);
                actualCell.IsWalkable = true;
            }

            foreach (var cell in _map.GetAllCells())
            {
                var tile = cell.IsWalkable ? _floor : _wall;
                _tilemap.SetTile((Vector3Int)cell.Position, tile);
            }
        }
    }
}
