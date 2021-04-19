using Nethermind.Abi;
using Nethermind.Core;
using Nethermind.Facade;

namespace Pipeline.Plugins.NftTransactions.Contracts
{
    public class Erc721Metadata : BlockchainBridgeContract
    {
        private IConstantContract Constant { get; }

        public Erc721Metadata(IAbiEncoder abiEncoder, Address contractAddress, IBlockchainBridge blockchainBridge) :
            base(abiEncoder, contractAddress)
        {
            Constant = GetConstant(blockchainBridge);
        }

        public string Name(BlockHeader header) => Constant.Call<string>(header, nameof(Name), Address.Zero);
        public string Symbol(BlockHeader header) => Constant.Call<string>(header, nameof(Symbol), Address.Zero);
    }
}
