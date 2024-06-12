using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Memory.Model;
using System.Threading;

namespace Memory.View
{
    
    public class MemoryGame : MonoBehaviour
    {
        private MemoryBoard _board;

        [SerializeField] GameObject _boardView;
        [SerializeField] GameObject _tilePrefab;

        private float _timer = 0;
        void Start()
        {
            _board = new MemoryBoard(3, 3);
            int randomIndex = Random.Range(0,_board.Tiles.Count);
            _board.Tiles[randomIndex].PropertyChanged += RandomTileChanged;

            _boardView.GetComponent<MemoryBoardView>()
               .SetUpMemoryBoardView(_board, _tilePrefab);





            foreach (Tile tile in _board.Tiles)
            {
               // Debug.Log(tile.MemoryCardId);
            }
           // GameObject board = Instantiate(_boardView);
          

            //board.transform.position = new Vector3(-_board.Rows*1.5f, 0, -_board.Columns * 1.5f );

            //if (board.TryGetComponent<MemoryBoardView>( out var bV))
            //{
            //    Debug.Log(_board);
            //     bV.SetUpMemoryBoardView(_board,_tilePrefab);
            //}
            //else
            //{
            //    Debug.Log("FAlse");
            //}
            
        }

        private void RandomTileChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
           // Debug.Log(e.ToString());
        }

        // Update is called once per frame
        void Update()
        {
            if (_timer < 2)
            {
                _timer += Time.deltaTime;
            }
            else
            {
                foreach (Tile tile in _board.Tiles)
                {
                    //tile.MemoryCardID++;
                    //Debug.Log(tile.MemoryCardId);
                }
                _timer = 0;
            }
        }
    }
}
