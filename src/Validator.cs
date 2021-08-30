using System.Text.RegularExpressions;

class Validator {

    public bool ValidateCurrency(string str) {
        return Regex.Match(str, @"^\d+\,\d\d$").Success;
    }

    public bool ValidateType(string str) {
        return str.Equals("Despesa") || str.Equals("Receita");
    }

}