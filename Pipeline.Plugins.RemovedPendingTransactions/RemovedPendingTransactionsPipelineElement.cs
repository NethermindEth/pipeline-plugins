using System;
using Nethermind.Core;
using Nethermind.Pipeline;
using Nethermind.TxPool;

namespace Pipeline.Plugins.RemovedPendingTransactions
{
    public class RemovedPendingTransactionsPipelineElement<TOut> : IPipelineElement<TOut> where TOut : Transaction
    {
        public Action<TOut> Emit { get; set; }

        public RemovedPendingTransactionsPipelineElement(ITxPool txPool)
        {
            txPool.RemovedPending += OnRemovedPending;
        }

        private void OnRemovedPending(object? sender, TxEventArgs args)
        {
            Emit((TOut)args.Transaction);
        }
    }
}
