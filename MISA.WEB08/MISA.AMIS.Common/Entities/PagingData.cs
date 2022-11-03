namespace MISA.AMIS.Common
{
    public class PagingData
    {

        public List<Employee> DataEmployees { get; set; }
        public List<Department> DataDepartments { get; set; }
        public List<Position> DataPositions { get; set; }
        public int TotalCount { get; set; }

    }
}