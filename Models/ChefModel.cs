#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using AgeCalculator;
using AgeCalculator.Extensions;

namespace chefsanddishes.Models;

public class Chef
{
    [Key]
    public int ChefId {get;set;}
    [Required]
    public string FirstName {get;set;}
    [Required]
    public string LastName {get;set;}
    [Required]
    [DataType(DataType.Date)]
    public DateTime Birthday {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    //nav prop
    public List<Dish> AllDishes {get;set;} = new List<Dish>();

    public int ChefAge()
    {
        var birthday = Birthday;
        var age = new Age(birthday, DateTime.Today);
        return age.Years;
    }
}