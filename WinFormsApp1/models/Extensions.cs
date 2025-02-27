using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace WinFormsApp1.models
{

    
    public static class StringExtensions
    {
        public static string PrimeiraLetraMaiuscula(this string texto)
        {
            if(texto == null)
            {
                return texto;
            }

            return char.ToUpper(texto[0]) + texto.Substring(1);
        }
    }

    public static class ObjectExtensions
    {

        public static void SeuMetodoAqui(this object obj)
        {
            //obj.
        }

        public static string ToJSON(this object obj)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var json = JsonConvert.SerializeObject(obj, serializerSettings);
            return json;
        }

    }

    public static class ClasseTesteExtensions
    {

    }

    public class ClasseTeste
    {
        public string nome { get; set; } = "ejfkjaefjaelfhjkaejfhajkefjkae";


        public void teste()
        {
            nome = "Emanuel";
            nome.ToLower();
            nome.ToUpper();
            nome.PrimeiraLetraMaiuscula();
        }

    }



}
