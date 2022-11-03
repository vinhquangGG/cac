using MISA.AMIS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.BL
{
    public class PositionBL : BaseBL<Position>, IPositionBL
    {
        public PositionBL(DL.IBaseDL<Position> baseDL) : base(baseDL)
        {
        }
    }
}
