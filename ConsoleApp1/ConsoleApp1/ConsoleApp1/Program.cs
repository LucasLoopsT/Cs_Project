using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader arquivoTxt;
            string path = "C:/Users/Lucas/Desktop/IFSP/ConsoleApp1/ConsoleApp1/";
            arquivoTxt = new StreamReader(path+"teste.txt");

            //conteudoHtml armazenará toda a converção do arquivo Txt para o Html
            string conteudoHtml = "";

            //caracter irá identificar cada caracter do arquivo Txt
            string caracter;

            //linha irá ler cada linha do arquivo Txt
            string linha = "";

            //lendo se tornará true após um caracter especial for identificado, servindo para alertar quando o caracter deverá ser guardado na váriavel conteudoHtml
            bool lendo = false;


            //lerá linha por linha até não ter mais
            while((linha = arquivoTxt.ReadLine()) != null)
            {
                //Quantidade de caracteres na linha
                int tam = linha.Length;

                //repetição para identificar os caracteres do arquivoTxt
                for(int i = 0; i < tam; i++)
                {   
                    //Substring é uma Função para pegar uma parte da string. O Primeiro parâmetro é a posição. O Segundo a quantidade que ele pega 
                    caracter = linha.Substring(i, 1);
                    
                    //Ler os casos de caracter especial
                    switch (caracter)
                    {
                        //Título H1
                        case "@":
                            conteudoHtml += "<h1 style=\"position: absolute; left:" + (i * 10) + "px\">";
                            lendo = true;
                            break;
                        case "*":
                            conteudoHtml += "</h1>";
                            lendo = false;
                            break;

                        //Texto P
                        case "\'":
                            conteudoHtml += "<p style=\"position: absolute; left:" + (i * 10) + "px\">";
                            lendo = true;
                            break;
                        case "\"":
                            conteudoHtml += "</p>";
                            lendo = false;
                            break;

                        //Break
                        case ";":
                            conteudoHtml+= "<br>";
                            break;

                        //Label
                        case "#":
                            conteudoHtml+= "<label style=\"position: absolute; left:" + (i * 10) + "px\">";
                            lendo= true;
                            break;
                        case "$":
                            conteudoHtml+= "</label>";
                            lendo= false;
                            break;

                        //Input Type Text
                        case "|":
                            conteudoHtml+= "<input type=\"text\" style=\"position: absolute; left:" + (i * 10) + "px\"></input>";
                            break;

                        //Input Type="CheckBox"
                        case "(":
                            conteudoHtml+= "<input type=\"checkbox\" style=\"position: absolute; left:" + (i * 10) + "px\"></input>";
                            break;

                        //Input Type="Radio"
                        case "+":
                            conteudoHtml+= "<input type=\"radio\" style=\"position: absolute; left:" + (i * 10) + "px\"></input>";
                            break;

                        //ComboBox
                        case "[":
                            conteudoHtml+= "<select style=\"position: absolute; left:" + (i * 10) + "px\">";
                            break;
                        case "]":
                            conteudoHtml+= "</select>";
                            break;
                        //Option - ComboBox
                        case ",":
                            conteudoHtml+= "<option>";
                            lendo = true;
                            break;
                        case ".":
                            conteudoHtml+= "</option>";
                            lendo = false;
                            break;

                        //Button
                        case "<":
                            conteudoHtml+= "<button style=\"position: absolute; left:" + (i * 10) + "px\">";
                            lendo = true;
                            break;
                        case ">":
                            conteudoHtml+= "</button>";
                            lendo = false;
                            break;

                        //Default - Ler o caracter
                        default:
                            if (lendo == true) {
                                conteudoHtml += caracter;
                            }
                            break;
                    }

                }

            } 
            
            StreamWriter arquivo;
            arquivo = new StreamWriter(path+"index.html");
            arquivo.WriteLine("<!DOCTYPE html><html><head><meta charset=\"UTF-8\"<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"> " +
                "<title>Document</title></head><body>" + conteudoHtml + "</body></html>");
            
            arquivo.Close();
            arquivoTxt.Close();

        }
    }
}
