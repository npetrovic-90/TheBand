using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Helpers
{
	public class BandsResourceParameters
	{
		//filter and search prop
		public string MainGenre { get; set; }
		public string SearchQuery { get; set; }

		///pagination prop
		const int maxPageSize=13;
		public int PageNumber { get; set; } = 1;

		private int _pageSize = 13;

		public int PageSize { get => _pageSize; set=>_pageSize = (value > maxPageSize ) ? maxPageSize : value; }

		//sorting prop
		public string OrderBy { get; set; } = "Name";

		//prop for fields
		public string Fields { get; set; }

	}
}
