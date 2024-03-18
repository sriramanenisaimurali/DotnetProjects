using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewsExample.Models
{
    public class ListModel
    {
     public string? ListName { get; set; }

     public List<string> ListItems { get; set; } = new List<string>();

    }
}
