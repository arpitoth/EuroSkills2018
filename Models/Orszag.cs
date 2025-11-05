using System.ComponentModel.DataAnnotations;

namespace EuroSkillsApi.Models;

public class Orszag
{
    [Key]
    public string Id { get; set; }
    public string OrszagNev { get; set; }
}