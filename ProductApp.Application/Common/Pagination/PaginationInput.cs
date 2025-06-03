namespace ProductApp.Application.Common.Pagination
{
    public class PaginationInput
    {
        public int Number { get; set; }
        public int Size { get; set; }

        private PaginationInput(int number, int size)
        {
            Number = number;
            Size = size;
        }

        public static PaginationInput Create(uint? number, uint? size)
        {
            var pageNumber = (int)(number is null or 0 ? 1 : number);
            var pageSize = (int)(size is null or 0 ? 25 : size);

            return new(pageNumber, pageSize);
        }
    }
}
