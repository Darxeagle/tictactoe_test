using System;

namespace TicTacToe.Scripts
{
    public class CellModel
    {
        private CellState state = CellState.empty;

        public Action<CellState> StateChanged;
        public Action<bool> GlowChanged;

        public CellState State
        {
            get => state;
            set
            {
                state = value;
                StateChanged?.Invoke(state);
            }
        }

        public bool Glow
        {
            set
            {
                GlowChanged?.Invoke(value);
            }
        }
    }
}