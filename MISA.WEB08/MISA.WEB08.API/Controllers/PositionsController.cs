using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.BL;
using MISA.AMIS.Common;

namespace MISA.WEB08.API
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PositionsController : BasesController<Position>
    {
        public PositionsController(IBaseBL<Position> baseBL) : base(baseBL)
        {
        }
    }
}
