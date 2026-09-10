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



    public void OnGet(string conversionType, string input)
    {
        Input = input;
        ViewData["ConversionType"] = conversionType;
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
            //throw;
        }


        switch (conversionType.ToLower())
        {
            case "milestokilometers":
                UnitOf.Length unit1 = new UnitOf.Length().FromMiles(doubleInput);
                double x1 = unit1.ToKilometers();
                string result1 = x1.ToString();
                Output = result1;
                break;
            case "kilometerstomiles":
                UnitOf.Length unit2 = new UnitOf.Length().FromKilometers(doubleInput);
                double x2 = unit2.ToMiles();
                string result2 = x2.ToString();
                Output = result2;
                break;
            case "fahrenheittocelsius":
                UnitOf.Temperature unit3 = new UnitOf.Temperature().FromFahrenheit(doubleInput);
                double x3 = unit3.ToCelsius();
                string result3 = x3.ToString();
                Output = result3;
                break;
            case "celsiustofahrenheit":
                UnitOf.Temperature unit4 = new UnitOf.Temperature().FromCelsius(doubleInput);
                double x4 = unit4.ToFahrenheit();
                string result4 = x4.ToString();
                Output = result4;
                break;
            case "poundstokilograms":
                UnitOf.Mass unit5 = new UnitOf.Mass().FromPounds(doubleInput);
                double x5 = unit5.ToKilograms();
                string result5 = x5.ToString();
                Output = result5;
                break;
            case "kilogramstopounds":
                UnitOf.Mass unit6 = new UnitOf.Mass().FromKilograms(doubleInput);
                double x6 = unit6.ToPounds();
                string result6 = x6.ToString();
                Output = result6;
                break;
            case "ouncestopounds":
                UnitOf.Mass unit7 = new UnitOf.Mass().FromOuncesUS(doubleInput);
                double x7 = unit7.ToPounds();
                string result7 = x7.ToString();
                Output = result7;
                break;
            case "poundstoounces":
                UnitOf.Mass unit8 = new UnitOf.Mass().FromPounds(doubleInput);
                double x8 = unit8.ToOuncesUS();
                string result8 = x8.ToString();
                Output = result8;
                break;
            default:
                ViewData["ErroMessage"] = "Unknown conversion type.";
                break;
        }
    }
}
