using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Cielo.Sirius.Foundation;

namespace Cielo.Sirius.Contracts.ConsultarDetalheProdutoMultivanContratadoCliente
{
    [DataContract]
    public class ConsultarDetalheProdutoMultivanContratadoClienteRequest : RequestBase
    {

        //Número do Estabelecimento Comercial
        [DataMember]
        public long CodigoCliente
        { get; set; }

        [DataMember]
        public string CodigoProduto
        { get; set; }
    }

    [DataContract]
    public class ConsultarDetalheProdutoMultivanContratadoClienteResponse : ResponseBase
    {
        [DataMember]
        public List<ConsultarDetalheProdutoMultivanContratadoClienteDTO> DetalhesMultivan
        { get; set; }

    }

    [DataContract]
    public class ConsultarDetalheProdutoMultivanContratadoClienteDTO : DTOBase
    {
        //Nome da Empresa Concorrente
        //Label: Nome da Empresa
        [DataMember]
        public string NomeEmpresa
        { get; set; }

        //Número do Cadastro do Cliente na Empresa
        //Label: Número de Cadastro
        [DataMember]
        public string NumeroCadastroEmpresa
        { get; set; }

        //Label: Início da Vigência
        [DataMember]
        public DateTime? InicioVigencia
        { get; set; }

        //Label: Fim da Vigência
        [DataMember]
        public DateTime? FimVigencia
        { get; set; }

    }
}
