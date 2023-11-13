using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DrawSomthing
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string wordString, checkValidate;
            int nWord;


            Console.WriteLine("Cuantas letras tiene la palabra?  ");
            nWord = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite las letras que le aparecen: ");
            wordString = Console.ReadLine();


            // Se valida la palabra digitada
            checkValidate = ValidateWord(wordString, nWord);


            Console.WriteLine("Generando posibles palabras... Por favor espere.");



            // Se valida la longitud de cadena con el numero de letras 
            if (wordString.Length > nWord)
            {
                throw new Exception("ERROR: No puede exceder el numero de caracteres...");

            }
            else
            {
                List<string> dictionary = Dictionary();
                List<string> combinationsList = GenerarCombinations(checkValidate, dictionary);

                Console.WriteLine($"Las posibles combinaciones para la cadena '{checkValidate}' son: \n");



                foreach (var words in combinationsList)
                {

                    Console.WriteLine(words);

                }
            }





        }

        // Metodo para obtener las palabras del txt en una lista
        public static List<string> Dictionary()
        {
            string path = "Palabras.txt";
            List<string> dictionary = File.ReadAllLines(path).ToList();
            return dictionary;
        }

        // Metodo para inicializar la lista con el array obtenido
        public static List<string> GenerarCombinations(string wordString, List<string> dictionary)
        {
            List<string> combinationsList = new List<string>();

            CombinationsList(wordString.ToCharArray(), 0, combinationsList, dictionary);

            return combinationsList;
        }


        // Metodo para generar las combinaciones posibles
        public static void CombinationsList(char[] letter, int index, List<string> combinationsList, List<string> dictionary)
        {

            /// si es la última posición de la cadena se agrega la combinacion final en la lista
            if (index == letter.Length - 1)
            {

                // cadena en base a un arreglo de tipo char
                string combination = new string(letter);

                if (dictionary.Contains(combination))
                {
                    combinationsList.Add(combination);
                }


            }
            else
            {
                // Convertir la cadena en un arreglo
                for (int i = index; i < letter.Length; i++)
                {
                    // se cambia el caracter actual por el siguiente
                    char temp = letter[index];
                    letter[index] = letter[i];
                    letter[i] = temp;

                    // Recursividad para hallar las demas combinaciones
                    CombinationsList(letter, index + 1, combinationsList, dictionary);

                    // cadena original
                    temp = letter[index];
                    letter[index] = letter[i];
                    letter[i] = temp;
                }
            }
        }

        // Metodo para validar la cadena ingresada
        public static string ValidateWord(string wordString, int nWord)
        {
            // Validamos que el campo de la palabra no venga vacio o sea mayor que 12 
            if (wordString == "" || wordString.Length > 12 || nWord > 12 || nWord == 0)
            {
                Console.WriteLine("La cadena no puede estar vacia o contener mas de 12 letras!");
            }
            else if (wordString.Length > nWord)
            {
                Console.WriteLine($"La cadena excede el numero de caracteres establecido!\n Debe tener {nWord} letras.");
            }
            else
            {
                Console.WriteLine($"La cadena es: {wordString}");
            }

            return wordString;
        }



    }


}
