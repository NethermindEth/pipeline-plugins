using System;
using Nethermind.Core;
using Nethermind.Pipeline;
using Nethermind.TxPool;

namespace Pipeline.Plugins.NftTransactions
{
    public class Erc721TransactionsPipelineElement<TOut> : IPipelineElement<TOut> where TOut : Transaction
    {
        public Action<TOut> Emit { get; set; }

        public Erc721TransactionsPipelineElement(ITxPool txPool)
        {
            txPool.NewPending += OnNewPending;
        }

        private void OnNewPending(object? sender, TxEventArgs args)
        {
            Emit((TOut)args.Transaction);
        }
    }
}
