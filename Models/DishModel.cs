#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace chefsanddishes.Models;

public class Dish
{
    [Key]
    public int DishId {get;set;}
    [Required]
    [MinLength(2,ErrorMessage ="Name must be at least 2 characters")]
    public string DishName {get;set;}
    [Required(ErrorMessage ="Calories must be above 1")]
    [Range(1, int.MaxValue)]
    public int Calories {get;set;}
    [Required(ErrorMessage ="Tastiness must be at least 1")]
    [Range(1,5)]
    public int Tastiness {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    //foreign Key
    public int ChefId {get;set;}
    //navigation prop
    public Chef? OneChef {get;set;}
}