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

    }
}
