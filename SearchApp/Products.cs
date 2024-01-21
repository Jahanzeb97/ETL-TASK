using Azure.Search.Documents.Indexes;
public partial class Products
{
    [SimpleField(IsKey = true)]
    public string product_id { get; set; }

    [SearchableField()]
    public string product_name { get; set; }  

    [SearchableField()]
    public string description { get; set; }   

    public string image_url { get; set; }
    public string date_added { get; set; }
    public int category_id { get; set; }
    public float price { get; set; }
    
}