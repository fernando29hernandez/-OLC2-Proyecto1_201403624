using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Irony.Parsing;
using _OLC2_Proyecto1_Servidor_201403624.Controllers.Graficador;
namespace _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_CHISON
{
    public class Sintactico_CHISON
    {
        public void analizar(String cadena)
        {
            Gramatica_CHISON gramatica = new Gramatica_CHISON();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;
            dibujarGrafo(raiz);
        }
        public static void dibujarGrafo(ParseTreeNode raiz)
        {
            String arbol = Graficar_Arbol.obtenerDOT(raiz);
            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(arbol);
            img.Save("C:\\Users\\Fernando\\Documents\\ASTCHISON.png");
        }
    }
}