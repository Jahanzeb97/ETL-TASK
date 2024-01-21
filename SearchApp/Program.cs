using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;

namespace SearchApp;
class Program
{
    
    private static SearchClient CreateSearchClientForQueries()
    {
        Console.WriteLine("Creating Search Client...");
        string indexName = "azuresql-index";
        string searchServiceEndPoint = "https://janhanzeb-ai-search.search.windows.net";
        string queryApiKey = "juHr7ilfN90t0pqReBP3HauoheumKHIkOFUm7QTDRYAzSeAtx9fh";

        SearchClient searchClient = new SearchClient(new Uri(searchServiceEndPoint), indexName, new AzureKeyCredential(queryApiKey));
        return searchClient;
    }

    private static void WriteDocuments(SearchResults<Products> searchResults)
    {
        List<SearchResult<Products>> results = searchResults.GetResults().ToList();
        if (results.Count() == 0)
        {
            Console.WriteLine("============== No results Found =================");
            return;
        }
        Console.WriteLine("============== Search Results =============\n");
        SearchResult<Products> result = results.First();
        Console.WriteLine("Product Id : " + result.Document.product_id);
        Console.WriteLine("Product Name : " + result.Document.product_name);
        Console.WriteLine("============================================\n");
    }

    private static void RunQueries(SearchClient searchClient)
    {
        while(true)
        {
            SearchOptions options;
            SearchResults<Products> results;

            Console.WriteLine("Enter Search Query (type 'exit' to end) : ");
            string searchString = Console.ReadLine();
            if (searchString == "exit")
                return;

            options = new SearchOptions();
            options.Select.Add("product_id");
            options.Select.Add("product_name");


            results = searchClient.Search<Products>(searchString, options);
            WriteDocuments(results);
        }
    }

    static void Main(string[] args)
    {
        SearchClient searchClient = CreateSearchClientForQueries();
        RunQueries(searchClient);
    }
}
