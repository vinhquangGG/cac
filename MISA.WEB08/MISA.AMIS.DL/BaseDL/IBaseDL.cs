using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.DL
{
    public interface IBaseDL<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bàn ghi</returns>
        /// Created by: PQVINH(29/09/2022)
        public IEnumerable<T> GetAllRecords();
        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>ID bản ghi vừa thêm mới</returns>
        /// Created by: PQVINH(29/09/2022)
        public Guid InsertRecord(T record);
        /// <summary>
        /// Lấy 1 bản ghi
        /// </summary>
        /// <param name="record">Id bản ghi cần lấy</param>
        /// <returns>bản ghi vừa lấy</returns>
        /// Created by: PQVINH(29/09/2022)
        public T GetRecordById(Guid record);
        /// <summary>
        /// Lấy 1 bản ghi
        /// </summary>
        /// <param name="record">Id bản ghi cần lấy</param>
        /// <returns>bản ghi vừa lấy</returns>
        /// Created by: PQVINH(29/09/2022)
        public T UpdateRecord(Guid recordID, T record);
        /// <summary>
        /// Xóa nhân viên theo Id
        /// </summary>
        /// <param name="recordID">Id nhân viên lấy được</param>
        /// <returns></returns>
        /// Created by: PQVINH(29/09/2022)
        public int DeleteRecord(Guid recordID);
        
    }
}
