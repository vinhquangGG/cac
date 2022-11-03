using MISA.AMIS.Common;
using MISA.AMIS.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.BL
{
    public class RequestDetailBL : BaseBL<RequestDetail>, IRequestDetailBL
    {
        #region Field
        private IRequestDetailDL _requestDetailDL;
        #endregion
        #region Contructer
        public RequestDetailBL(IRequestDetailDL requestDetailDL) : base(requestDetailDL)
        {
            _requestDetailDL = requestDetailDL;
        }
        #endregion
        #region Methods
        /// <summary>
        /// API lấy tất cả request_detail
        /// </summary>
        /// <param name="idEmployees">List id của nhân viên</param>
        /// <returns>1 nếu thành công</returns>
        public IEnumerable<RequestDetail> GetAllRecordById(Guid id)
        {
            return _requestDetailDL.GetAllRecordById(id);
        }
        /// <summary>
        /// API xóa nhiều request_detail
        /// </summary>
        /// <param name="idEmployees">List id của nhân viên</param>
        /// <returns>1 nếu thành công</returns>
        public int DeleteAllRequestDetailById(List<Guid> idEmployees)
        {
            return _requestDetailDL.DeleteAllRequestDetailById(idEmployees);
        }
        #endregion
    }
}
