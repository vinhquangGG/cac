using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Common
{
    public class ResultTotal<T>
    {
        //public ResultTotal()
        //{
        //}

        public ResultTotal(int totalPage, int totalRecord, int currentPage, int currentPageRecords, List<T> data)
        {
            TotalPage = totalPage;
            TotalRecord = totalRecord;
            CurrentPage = currentPage;
            CurrentPageRecords = currentPageRecords;
            Data = data;
        }

        public int TotalPage { get; set; }
        public int TotalRecord { get; set; }
        public int CurrentPage { get; set; }
        public int CurrentPageRecords { get; set; }
        public List<T> Data { get; set; }
    }
}
