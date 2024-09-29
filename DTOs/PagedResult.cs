namespace DigitalConstructal.DTOs
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } // A lista de itens retornados (neste caso, produtos)
        public int TotalRecords { get; set; } // O número total de registros na tabela
        public int PageNumber { get; set; } // O número da página atual
        public int PageSize { get; set; } // O tamanho da página (quantos itens por página)

        // Calcula o número total de páginas
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
    }
}
