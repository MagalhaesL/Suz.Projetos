namespace Suz.Projetos.Domain.Entities
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int AutorId { get; set; }
        public Pessoa Autor { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int? SubcategoriaId { get; set; }
        public Subcategoria Subcategoria { get; set; }
    }

}
