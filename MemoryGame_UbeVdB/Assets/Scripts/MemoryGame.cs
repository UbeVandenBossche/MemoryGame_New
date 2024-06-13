using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Memory.Model;
using System.Threading;
using TMPro;

namespace Memory.View
{
    
    public class MemoryGame : MonoBehaviour
    {
        private MemoryBoard _board;
        [SerializeField] private int _playerCount = 2;
        [SerializeField] private TextMeshProUGUI _restartText;

        [SerializeField] GameObject _boardView;
        [SerializeField] GameObject _playerPrefab;
        [SerializeField] GameObject _tilePrefab;

        private float _timer = 0;
        void Start()
        {
            _board = new MemoryBoard(3, 3);
            int randomIndex = Random.Range(0,_board.Tiles.Count);
            _board.Tiles[randomIndex].PropertyChanged += RandomTileChanged;

            _boardView.GetComponent<MemoryBoardView>()
               .SetUpMemoryBoardView(_board, _tilePrefab);


            List<Player> players = new List<Player>();

            for (int i = 0; i < _playerCount; i++)
            {
                GameObject player = GameObject.Instantiate(_playerPrefab);
                PlayerView pv = player.GetComponent<PlayerView>();
                pv.Model = new Player();
                pv.Model.Name = $"Player {i + 1}";
                pv.Model.Score = 0;
                pv.Model.IsActive = i == 0;
                pv.Model.ElapsedTime = 0;
                pv.PlayerInfo.rectTransform.position = new Vector3(200, Screen.height / 2 - i * 200, 0);
                players.Add(pv.Model);
            }
            _boardView.GetComponent<MemoryBoardView>().Model.Players = players;

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
