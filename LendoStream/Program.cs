using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendoStream
{
    class Program
    {
        private static char caracter, caracterAnterior;

        private static string primeiraVogal = "";
        private static string[] vogais = { "a", "A", "e", "E", "i", "I", "o", "O", "u", "U" };

        private static List<String> consoantes = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Por favor, digite uma sequencia de caracteres...");

            string leitura = Console.ReadLine();

            try
            {
                Stream leituraStream = new Stream(leitura);

                while (hasNext(leituraStream) == true)
                {
                    caracter = getNext(leituraStream);

                    //Verifica se o caracter atual e uma vogal, se ele se repete na stream e se o anterior dele e uma consoante
                    if (verificaVogal(caracter.ToString()) && verificaRepeticao(caracter.ToString()) == false && verificaVogal(caracterAnterior.ToString()) == false)
                    {
                        //Caso seja ele o coloca na variavel resposta
                        primeiraVogal = caracter.ToString();
                    }
                    else if (verificaRepeticao(caracter.ToString()) && caracter.ToString() == primeiraVogal)
                    {
                        //Caso ele se repita e seja a vogal resposta a mesma e apagada
                        primeiraVogal = "";
                    }
                    //grava o caracter anterior para efeito de comparacao.
                    caracterAnterior = getNext(leituraStream);
                    //grava o caracter avaliado em uma lista para verificacao.
                    consoantes.Add(caracter.ToString());
                }
                Console.WriteLine("Foi encontrado como resultado a vogal: " + primeiraVogal);

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Verifica casos de repeticao na lista derivada da stream
        /// </summary>
        /// <param name="letra">Letra a ser verificada</param>
        /// <returns></returns>
        public static Boolean verificaRepeticao(string letra)
        {
            foreach (string letras in consoantes)
            {
                if (letras == caracter.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Verifica se o item passado e uma vogal
        /// </summary>
        /// <param name="letra">Letra a ser validada como vogal</param>
        /// <returns></returns>
        public static Boolean verificaVogal(string letra)
        {
            foreach (string vogal in vogais)
            {
                if (letra == vogal)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Retorna o primeiro caracter da stream
        /// </summary>
        /// <param name="input">Classe responsavel pela interface</param>
        /// <returns></returns>
        public static char firstChar(IStream input)
        {
            if (input.hasNext() == true)
            {
                char character = input.getNext();

                return character;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// Verifica se a stream ainda tem itens a serem lidos.
        /// </summary>
        /// <param name="input">Classe responsavel pela interface</param>
        /// <returns></returns>
        public static Boolean hasNext(IStream input)
        {
            return input.hasNext();
        }
        /// <summary>
        /// Pega o proximo item da stream e o retorna como um char
        /// </summary>
        /// <param name="input">Classe responsavel pela interface</param>
        /// <returns></returns>
        public static char getNext(IStream input)
        {
            return input.getNext();
        }
    }
}