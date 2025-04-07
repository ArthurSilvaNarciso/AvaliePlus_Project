using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AvaliePlus.Models;

namespace AvaliePlus.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }

        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Comentario { get; set; }

        public int Nota { get; set; }  // Nota de 1 a 5 estrelas

        public DateTime Data { get; set; } = DateTime.Now;

        // 🔗 Relacionamento com Filme
        [ForeignKey("Filme")]
        public int FilmeId { get; set; }

        public Filme Filme { get; set; }
    }
}
