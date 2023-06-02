using System.Linq;
using System.Text.RegularExpressions;

namespace ContactRegister.Validations
{
    public static class StringExtensions
    {
        public static bool ContemEspacoEmBranco(this string campos)
            => campos.Split(" ").Any(x => x == string.Empty);

        public static bool ExisteAlgumSimboloOuCaracterEspecial(this string valor)
            => valor.Replace(" ", string.Empty).Any(x => !char.IsLetter(x));

        public static bool TemPeloMenosDoisCaracteresParaCadaPalavra(this string campos)
            => !campos.Split(" ").Where(x => x.Length < 2).Any();

        public static bool IsNumberPhoneValid(this string phonePersonal)
        {
            var expression = "^\\((?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\\) (?:[2-8]|9[1-9])[0-9]{3}\\-[0-9]{4}$";
            return Regex.Match(phonePersonal, expression).Success;
        }
    }
}
