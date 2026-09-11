using System;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string Input {get; set;} = string.Empty;
    public string Output {get; set;} = string.Empty;

    [BindProperty(SupportsGet = true)]
    public string ConversionType {get; set;} = string.Empty;



    public void OnGet()
    {
        ViewData["ConversionType"] = string.Concat(ConversionType.Select(x => Char.IsUpper(x) ? " " + x
            : x.ToString())).TrimStart(' ');;
        ViewData["Title"] = "Conversions";
        double doubleInput;

        try
        {
            doubleInput = Convert.ToDouble(Input);
        }
        catch (FormatException e)
        {
            ViewData["ErrorMessage"] = "Input must be a valid number.";
            Console.WriteLine(e.Message);
            return;
        }


        switch (ConversionType.ToLower())
        {
            case "milestokilometers":
                UnitOf.Length unit1 = new UnitOf.Length().FromMiles(doubleInput);
                double x1 = unit1.ToKilometers();
                Output = x1.ToString();
                break;
            case "kilometerstomiles":
                UnitOf.Length unit2 = new UnitOf.Length().FromKilometers(doubleInput);
                double x2 = unit2.ToMiles();
                Output = x2.ToString();
                break;
            case "fahrenheittocelsius":
                UnitOf.Temperature unit3 = new UnitOf.Temperature().FromFahrenheit(doubleInput);
                double x3 = unit3.ToCelsius();
                Output = x3.ToString();
                break;
            case "celsiustofahrenheit":
                UnitOf.Temperature unit4 = new UnitOf.Temperature().FromCelsius(doubleInput);
                double x4 = unit4.ToFahrenheit();
                Output = x4.ToString();
                break;
            case "poundstokilograms":
                UnitOf.Mass unit5 = new UnitOf.Mass().FromPounds(doubleInput);
                double x5 = unit5.ToKilograms();
                Output = x5.ToString();
                break;
            case "kilogramstopounds":
                UnitOf.Mass unit6 = new UnitOf.Mass().FromKilograms(doubleInput);
                double x6 = unit6.ToPounds();
                Output =  x6.ToString();
                break;
            case "ouncestopounds":
                UnitOf.Mass unit7 = new UnitOf.Mass().FromOuncesUS(doubleInput);
                double x7 = unit7.ToPounds();
                Output = x7.ToString();
                break;
            case "poundstoounces":
                UnitOf.Mass unit8 = new UnitOf.Mass().FromPounds(doubleInput);
                double x8 = unit8.ToOuncesUS();
                Output = x8.ToString();
                break;
            default:
                ViewData["ErrorMessage"] = "Unknown conversion type.";
                break;
        }
    }
}
