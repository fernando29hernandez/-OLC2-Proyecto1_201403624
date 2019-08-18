using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Parsing;
using _OLC2_Proyecto1_Servidor_201403624.Controllers.Graficador;
namespace _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_LUP
{
    public class Sintactico_LUP
    {
        public String analizar(String cadena)
        {
            Gramatica_LUP gramatica = new Gramatica_LUP();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;
            Arbol_LUP.Arbol_LUP arbol_lup = new Arbol_LUP.Arbol_LUP(raiz);
            String respuesta = arbol_lup.Construir_Arbol();

            return respuesta;
            //dibujarGrafo(raiz);
        }
        public static void dibujarGrafo(ParseTreeNode raiz)
        {
            String arbol = Graficar_Arbol.obtenerDOT(raiz);
            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(arbol);
            img.Save("C:\\Users\\Fernando\\Documents\\ASTLUP.png");
        }
    }
}