﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoAbaixoEstoqueEvent : DomainEvent
    {
        public int QuantidadeRestante { get; private set; }

        public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidadeRestante) : base(aggregateId) 
        {
            QuantidadeRestante = quantidadeRestante;
        }
    }
}
