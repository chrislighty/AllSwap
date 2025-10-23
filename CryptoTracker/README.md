# CryptoTracker

CryptoTracker is a web application that provides real-time cryptocurrency information and decentralized exchange (DEX) swap simulations. It leverages the CoinGecko API to display the latest market data for top tokens and integrates with Nethereum to provide swap estimates from Uniswap V2.

## Features

*   **Top Token Prices:** View a list of the top 10 cryptocurrencies by market cap, including their current price, market capitalization, 24-hour volume, and price change.
*   **DEX Swap Simulator:** Get an estimated amount for a token swap using the Uniswap V2 router on the Ethereum mainnet.
*   **MetaMask Integration (Upcoming):** Connect your MetaMask wallet to perform live swaps directly from the application.
*   **Price Charts (Upcoming):** Visualize historical price data for various cryptocurrencies.
*   **Portfolio Tracking (Upcoming):** Track your cryptocurrency holdings and swap history.

## Getting Started

### Prerequisites

*   [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
*   An [Infura API Key](https://infura.io/register) for connecting to the Ethereum mainnet.

### Installation

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/your-username/CryptoTracker.git
    cd CryptoTracker
    ```

2.  **Restore dependencies:**
    ```bash
    dotnet restore
    ```

### Configuration

1.  **Infura API Key:**
    Open the `CryptoTracker/appsettings.json` file and replace `"https://mainnet.infura.io/v3/YOUR_INFURA_KEY"` in the `Infura:MainnetUrl` field with your own Infura project URL.

2.  **Database Connection:**
    Open the `CryptoTracker/appsettings.json` file and add a `ConnectionStrings` section with your SQL Server connection string:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CryptoTracker;Trusted_Connection=True;MultipleActiveResultSets=true"
    },
    ```

3.  **Application Settings:**
    The `appsettings.json` file also contains the base URL for the CoinGecko API. No changes are required for this to work.

## Database Migrations

This project uses Entity Framework Core for database management. To create and apply the database migrations, run the following commands from the `CryptoTracker` directory:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Usage

1.  **Run the application:**
    ```bash
    dotnet run
    ```
    The application will be available at `https://localhost:5001` or `http://localhost:5000`.

2.  **Navigate the application:**
    *   **Coins:** The default page, which shows the top 10 tokens.
    *   **DEX:** The DEX swap simulator page. Enter the contract addresses for the tokens you want to swap and the amount to get an estimate.

## Next Steps

The following features are planned for future development:

*   **MetaMask Integration:** Allow users to connect their MetaMask wallet and execute live swaps.
*   **Price Charts:** Add historical price charts for each cryptocurrency using Chart.js.
*   **Portfolio Tracking:** Implement a database to store user portfolios and track their balances.
*   **Testnet Support:** Add support for testing swaps on a testnet like Goerli or Sepolia.
