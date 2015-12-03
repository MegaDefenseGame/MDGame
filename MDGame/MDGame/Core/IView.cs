using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDGame.Core
{
    public interface IView
    {
        void UpdateMap(GameBoard board);
        void UpdateEnemy(GameBoard _board);
        // eiei
    }
}
