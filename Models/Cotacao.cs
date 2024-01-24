using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SRT.ServiceAPI.Models;

[Table("tsrtcotacao")]
public class Cotacao
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Column("de_remet_nome")]
    public string? RemNome { get; set; }

    [Required]
    [StringLength(14)]
    [Column("de_remet_cpnj_cpf")]
    public string? RemCNPJorCPF { get; set; }

    [Required]
    [StringLength(500)]
    [Column("de_remet_endereco")]
    public string? RemEndereco { get; set; }

    [Required]
    [StringLength(9)]
    [Column("de_remet_cep")]
    public string? RemCEP { get; set; }

    [Required]
    [StringLength(45)]
    [Column("de_remet_bairro")]
    public string? RemBairro { get; set; }

    [Required]
    [StringLength(45)]
    [Column("de_remet_cidade")]
    public string? RemCidade { get; set; }

    [Required]
    [StringLength(2)]
    [Column("de_remet_uf")]
    public string? RemUF { get; set; }

    [Required]
    [StringLength(45)]
    [Column("de_remet_responsavel")]
    public string? RemResponsavel { get; set; }

    [Required]
    [StringLength(20)]
    [Column("de_remet_telefone")]
    public string? RemTelefone { get; set; }

    [Required]
    [StringLength(20)]
    [Column("de_remet_celular")]
    public string? RemCelular { get; set; }



    [Required]
    [StringLength(100)]
    [Column("de_dest_nome")]
    public string? DestNome { get; set; }

    [Required]
    [StringLength(14)]
    [Column("de_dest_cnpj_cpf")]
    public string? DestCNPJorCPF { get; set; }

    [Required]
    [StringLength(500)]
    [Column("de_dest_endereco")]
    public string? DestEndereco { get; set; }

    [Required]
    [StringLength(9)]
    [Column("de_dest_cep")]
    public string? DestCEP { get; set; }

    [Required]
    [StringLength(50)]
    [Column("de_dest_bairro")]
    public string? DestBairro { get; set; }

    [Required]
    [StringLength(50)]
    [Column("de_dest_cidade")]
    public string? DestCidade { get; set; }

    [Required]
    [StringLength(2)]
    [Column("de_dest_uf")]
    public string? DestUF { get; set; }

    [Required]
    [StringLength(50)]
    [Column("de_dest_responsavel")]
    public string? DestResponsavel { get; set; }

    [Required]
    [StringLength(20)]
    [Column("de_dest_telefone")]
    public string? DestTelefone { get; set; }

    [Required]
    [StringLength(20)]
    [Column("de_dest_celular")]
    public string? DestCelular { get; set; }

    [Required]
    [StringLength(20)]
    [Column("de_pagador_frete")]
    public string? PagadorFrete { get; set; }

    [Required]
    [StringLength(50)]
    [Column("de_tpfrete")]
    public string? TipoFrete { get; set; }

    [StringLength(20)]
    [Column("de_num_pedido")]
    public string? NPedido { get; set; }

    [Required]
    [StringLength(20)]
    [Column("de_valor_nf")]
    public string? ValorNF { get; set; }

    [Required]
    [StringLength(2)]
    [Column("de_urgencia")]
    public string? Urgencia { get; set; }

    [Required]
    [Column("dt_coleta")]
    public DateTime DataColeta { get; set; }

    [Required]
    [Column("dt_entrega_lim")]
    public DateTime DataEntrega { get; set; }

    [Required]
    [Column("dt_cad")]
    public DateTime DataRegistro { get; set; }

    [Required]
    [StringLength(20)]
    [Column("de_status")]
    public string? Status { get; set; }

    [Required]
    [StringLength(20)]
    [Column("si_login_cad")]
    public string? Login { get; set; }
}
