using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Scripts.Views;
using UnityEngine;
using Zenject;

namespace TicTacToe.Scripts
{
    public class GameplayController : MonoBehaviour
    {
        [Inject] private FieldModel fieldModel;
        [Inject] private GameStateModel stateModel;
        [Inject] private UIView uiView;

        private void Start()
        {
            uiView.ResultOkClicked += RestartGame;
            RestartGame();
        }
        
        private void RestartGame()
        {
            foreach (var cellModel in fieldModel.CellModels)
            {
                cellModel.State = CellState.empty;
                cellModel.Glow = false;
            }

            stateModel.State = GameState.playerTurn;
        }

        public void SelectCell(CellModel _cellModel)
        {
            if (_cellModel.State == CellState.empty)
            {
                if (stateModel.State == GameState.playerTurn)
                {
                    _cellModel.State = CellState.cross;
                    NextTurn();
                    return;
                }
                if (stateModel.State == GameState.enemyTurn)
                {
                    _cellModel.State = CellState.circle;
                    NextTurn();
                    return;
                }
            }
        }

        private void NextTurn()
        {
            var _lines = fieldModel.GetLines();
            foreach (var _line in _lines)
            {
                if (_line.All(_cell => _cell.State == CellState.cross))
                {
                    GlowLine(_line);
                    stateModel.State = GameState.resultWin;
                    return;
                }
                if (_line.All(_cell => _cell.State == CellState.circle))
                {
                    GlowLine(_line);
                    stateModel.State = GameState.resultLose;
                    return;
                }
            }
            if (fieldModel.CellModels.All(_cell => _cell.State != CellState.empty))
            {
                stateModel.State = GameState.resultDraw;
                return;
            }
            if (stateModel.State == GameState.playerTurn)
            {
                stateModel.State = GameState.enemyTurn;
                return;
            }
            if (stateModel.State == GameState.enemyTurn)
            {
                stateModel.State = GameState.playerTurn;
                return;
            }
        }

        private void GlowLine(IEnumerable<CellModel> _line)
        {
            foreach (var _cell in _line)
            {
                _cell.Glow = true;
            }
        }
    }
}