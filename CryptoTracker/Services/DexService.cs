using CryptoTracker.Models;
using Nethereum.Web3;
using Nethereum.Util;
using System.Numerics;
using Nethereum.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CryptoTracker.Services
{
    public class DexService : IDexService
    {
        private readonly string UNISWAP_ROUTER_ADDRESS = "0x7a250d5630B4cF539739dF2C5dAcb4c659F2488D"; // Uniswap V2
        private readonly Web3 _web3;

        public DexService(IConfiguration config)
        {
            // Connect to Ethereum (Infura)
            _web3 = new Web3(config["Infura:MainnetUrl"]);
        }

        public async Task<TokenSwap> GetEstimatedSwapAsync(string tokenIn, string tokenOut, decimal amountIn)
        {
            // Convert amount to Wei
            var amountInWei = UnitConversion.Convert.ToWei(amountIn);

            // Router ABI (simplified for getAmountsOut)
            var routerAbi = @"[{'constant':true,'inputs':[{'name':'amountIn','type':'uint256'},{'name':'path','type':'address[]'}],'name':'getAmountsOut','outputs':[{'name':'amounts','type':'uint256[]'}],'payable':false,'stateMutability':'view','type':'function'}]";

            var routerContract = _web3.Eth.GetContract(routerAbi, UNISWAP_ROUTER_ADDRESS);
            var getAmountsOutFunction = routerContract.GetFunction("getAmountsOut");

            var amounts = await getAmountsOutFunction.CallAsync<List<BigInteger>>(amountInWei, new string[] { tokenIn, tokenOut });

            var amountOut = UnitConversion.Convert.FromWei(amounts[1]);

            return new TokenSwap
            {
                TokenIn = tokenIn,
                TokenOut = tokenOut,
                AmountIn = amountIn,
                EstimatedAmountOut = amountOut
            };
        }
    }
}
