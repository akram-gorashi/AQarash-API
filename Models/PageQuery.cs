namespace Al_Delal.Api.Models
{
   public class PageQuery
	{
		const int maxPageSize = 50;
		public int PageNumber { get; set; } = 1;

		private int _pageSize = 16;
		public int PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				_pageSize = (value > maxPageSize) ? maxPageSize : value;
			}
		}
	}
}