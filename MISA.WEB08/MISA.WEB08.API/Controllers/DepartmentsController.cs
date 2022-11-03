using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.BL;
using MISA.AMIS.Common;
using MISA.AMIS.Common.Resources;

namespace MISA.WEB08.API
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : BasesController<Department>
    {
        #region Contructor
        public DepartmentsController(IBaseBL<Department> baseBL) : base(baseBL)
        {
        } 
        #endregion
    }
}
