using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public enum ProductSortingOptions
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc
    }
    public class ProductSpecificationsParameters
    {
        private const int MAXPAGESIZE = 10;
        private const int DEFAULTPAGESIZE = 5;

        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public ProductSortingOptions? Sort { get; set; }
        public int pageIndex { get; set; } = 1;
        private int _pageSize = DEFAULTPAGESIZE;
        public int pageSize 
        {
            get => _pageSize;
            set => _pageSize = value > MAXPAGESIZE ? MAXPAGESIZE : value;  
        }
    }
}