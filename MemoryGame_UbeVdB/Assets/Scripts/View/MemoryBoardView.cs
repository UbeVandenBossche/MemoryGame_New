using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Memory.Model;
using System.ComponentModel;
using System;
namespace Memory.View
{
    public class MemoryBoardView : ViewBaseClass<MemoryBoard>
    {
        GameObject _tilePrefab;
        private List<TileView> _tileViews = new List<TileView>();

        // Start is called before the first frame update

        private void SpawnTiles()
        {
            foreach (Tile tile in Model.Tiles)
            {
                GameObject tileview = Instantiate(_tilePrefab);
                tileview.GetComponent<TileView>().Model = tile;
                tileview.transform.position = new Vector3(tile.Row * 1.5f, 0, tile.Column * 1.5f);
                tileview.transform.SetParent(transform);

            }
            transform.position = new Vector3(-(Model.Rows - 1) * 1.5f / 2, 0, -(Model.Columns - 1) * 1.5f / 2);
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }

        public void SetUpMemoryBoardView(MemoryBoard model, GameObject tilePrefab)
        {
            Model = model;
            _tilePrefab = tilePrefab;

            float xOffset = model.Rows / 2;
            float yOffset = model.Columns / 2;
            float distance = 3f;

            foreach (Tile tile in model.Tiles)
            {
                var tileView = Instantiate(tilePrefab, new Vector3((tile.Row - xOffset) * distance, 0,
                    (tile.Column - yOffset) * distance), Quaternion.identity);
                tileView.transform.SetParent(transform);

                TileView view = tileView.GetComponent<TileView>();

                if (view != null)
                {
                    view.Model = tile;
                }

                _tileViews.Add(view);
            }

            // SpawnTiles();
        }
    }
}
