using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.ViewModel.Common
{
    public class PagingRequestBase
    {
        public string KeyWord { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public PagingRequestBase()
        {
        }
        public PagingRequestBase(int pageIndex, int pageSize, string keyWord = null)
        {
            KeyWord = keyWord;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
