using System;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Scripts
{
    public class FieldModel
    {
        private CellModel[] cellModels = new CellModel[9];
        public CellModel[] CellModels => cellModels;
        
        public FieldModel()
        {
            for (int i = 0; i < 9; i++)
            {
                cellModels[i] = new CellModel();
            }
        }

        public CellModel GetCellAt(Vector2Int _position)
        {
            if (_position.x < 0 || _position.x > 2 || _position.y < 0 || _position.y > 2)
            {
                throw new Exception("Position out of dimensions");
            }
            return cellModels[_position.y * 3 + _position.x];
        }

        public IEnumerable<IEnumerable<CellModel>> GetLines()
        {
            return new[]
            {
                new[] {cellModels[0], cellModels[1], cellModels[2]},
                new[] {cellModels[3], cellModels[4], cellModels[5]},
                new[] {cellModels[6], cellModels[7], cellModels[8]},
                new[] {cellModels[0], cellModels[3], cellModels[6]},
                new[] {cellModels[1], cellModels[4], cellModels[7]},
                new[] {cellModels[2], cellModels[5], cellModels[8]},
                new[] {cellModels[0], cellModels[4], cellModels[8]},
                new[] {cellModels[2], cellModels[4], cellModels[6]}
            };
        }
    }
}