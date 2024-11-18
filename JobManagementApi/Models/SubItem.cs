namespace JobManagementApi.Models;

public class SubItem
{
    public string ItemId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; } // e.g., "Pending", "In Progress", "Completed"
}