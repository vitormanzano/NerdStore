using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler(IProdutoRepository _produtoRepository) : INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        public async Task Handle(ProdutoAbaixoEstoqueEvent notification, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(notification.AggregateId);

            //Enviar email para aquisicão de mais produtos

            //...
        }
    }
}
