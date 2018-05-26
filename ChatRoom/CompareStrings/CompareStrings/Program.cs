using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareStrings
{
    public class Program
    {
        public static List<string> Results = new List<string>();
        public static string Filename = String.Empty; 

        static void Main(string[] args)
        {
            string[] articles = new string[]
            {
                "el"
                ,"un"
                ,"los"
                ,"unos"
                ,"la"
                ,"una"
                ,"las"
                ,"unas"
                ,"a"
                ,"de"
                ,"al"
                ,"del"
                ,"lo"
            };

            string[] arrayOptions1 = new string[]
          { "Solicitud de prestamo"
            ,"Solicitud de préstamo"
            ,"Solicitud de Prestamo"
            ,"Solicitud de Préstamo"
          };

            string[] arrayOptions2 = new string[] 
            {
              "Solicitud de préstamo vehículo"
              ,"Solicitud  de  prestamo  vehiculo"
              ,"Solicitud de  préstamo  vehiculo"
              ,"Solicitud de  prestamo  vehículo"
            };


            string[] arrayOptions3 = new string[]
            {
                "Solicitud prestamo"
            };
            
            Input();

            foreach(var option in arrayOptions1)
            {
                var comparisonResults =  string.Compare(Filename, option, CultureInfo.CurrentCulture, 
                                                                          System.Globalization.CompareOptions.IgnoreNonSpace 
                                                                          | System.Globalization.CompareOptions.IgnoreCase);
                if ( comparisonResults == 0 )
                {
                    Results.Add(option);
                }
            }

            output();

            Input();

            foreach (var option in arrayOptions2)
            {
                var comparisonResults = string.Compare(Filename, option, CultureInfo.CurrentCulture, 
                                                                  System.Globalization.CompareOptions.IgnoreNonSpace 
                                                                | System.Globalization.CompareOptions.IgnoreCase
                                                                | System.Globalization.CompareOptions.IgnoreSymbols);
                if (comparisonResults == 0)
                {
                    Results.Add(option);
                }
            }

            output();

            Input();

            foreach (var option in arrayOptions3)
            {
                var newfilename = String.Empty; 

                foreach(var article in articles)
                {
                    var formattedArticle = String.Format(" {0} ", article);
                    if (Filename.Contains(formattedArticle))
                    {
                        newfilename = Filename.Replace(formattedArticle," ");
                    }

                    var comparisonResults = string.Compare(newfilename, option, CultureInfo.CurrentCulture,
                                                                  System.Globalization.CompareOptions.IgnoreNonSpace
                                                                | System.Globalization.CompareOptions.IgnoreCase
                                                                | System.Globalization.CompareOptions.IgnoreSymbols);
                    if (comparisonResults == 0)
                    {
                        Results.Add(option);
                        newfilename = string.Empty;
                    }

                }   
            }

            output();

            Console.ReadLine();

            void output()
            {
                var count = 1;

                Console.WriteLine("\n*Posible Opciones:\n");

                foreach (var result in Results.ToArray())
                {
                    Console.WriteLine("{0}.{1}", count, result);
                    count++;
                }
                Results.Clear();

            }

            void Input()
            {
                Console.WriteLine("\n*Enter filename:");
                Filename = Console.ReadLine();
            }
        }
    }
}
