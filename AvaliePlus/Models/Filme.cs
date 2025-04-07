using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AvaliePlus.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Diretor { get; set; }

        [Required]
        public string Genero { get; set; }

        public int Ano { get; set; }

        public int DuracaoMinutos { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string ImagemUrl { get; set; }

        [Required]
        public string Sinopse { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}
