using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.ValueObjs.Paginations
{
    public class MetaData
    {
        public int CurrentPage { get; set; } // Trang hiện tại
        public int TotalPage { get; set; } // Tổng số trang
        public int PageSize { get; set; } // Số lượng phần tử trên mỗi trang
        public int TotalCount { get; set; } // Tổng số phần tử
        public bool HasPrevious => CurrentPage > 1; // Có trang trước không
        public bool HasNext => CurrentPage < TotalPage; // Có trang sau không

    }
}
