using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSmartCityWebAPI.Models
{
    [Table("PRODUTOS")]
    public class Produto
    {
        //Foreing Key
        [Column("IDTIPO")]
        [Display(Name = "Tipo de Produto")]
        public int IdTipoProduto { get; set; }

        //Navigation Property
        public TipoProduto Tipo { get; set; }

        [Key]
        [Column("IDPRODUTO")]
        [HiddenInput]
        public int IdProduto { get; set; }

        [Column("NOMEPRODUTO")]
        [Display(Name = "Nome do Produto")]
        public String NomeProduto { get; set; }

        [Column("CARACTERISTICAS")]
        public String Caracteristicas { get; set; }

        [Column("PRECOMEDIO")]
        [Display(Name = "Preço")]
        public double PrecoMedio { get; set; }

        [Column("LOGOTIPO")]
        public String Logotipo { get; set; }

        [Column("ATIVO")]
        public bool Ativo { get; set; }


    }
}
