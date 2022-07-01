using System;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Scripts
{
    public class GameStateModel
    {
        private GameState state;
        
        public Action<GameState> StateChanged;
        
        public GameState State
        {
            get => state;
            set
            {
                state = value;
                StateChanged?.Invoke(state);
            }
        }
    }
}