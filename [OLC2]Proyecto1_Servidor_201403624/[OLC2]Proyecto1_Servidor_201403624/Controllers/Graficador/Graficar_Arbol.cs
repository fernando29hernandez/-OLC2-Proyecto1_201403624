using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Parsing;
using WINGRAPHVIZLib;
namespace _OLC2_Proyecto1_Servidor_201403624.Controllers.Graficador
{
    public class Graficar_Arbol
    {
        private static int contador;
        private static String arbol;
        public static String obtenerDOT(ParseTreeNode raiz)
        {
            arbol = "digraph G{ node [shape = box];";
            arbol += "nodo0[label=\"" + escapar(raiz.ToString()) + "\"];\n";
            contador = 1;
            recorrerAST("nodo0", raiz);
            arbol += "}";
            return arbol;

        }
        private static void recorrerAST(String padre, ParseTreeNode hijos)
        {
            foreach (ParseTreeNode hijo in hijos.ChildNodes)
            {
                String nombrehijo = "nodo" + contador.ToString();
                arbol += nombrehijo + "[label=\"" + escapar(hijo.ToString()) + "\"];\n";
                arbol += padre + "->" + nombrehijo + ";\n";
                contador++;
                recorrerAST(nombrehijo, hijo);



            }

        }
        private static String escapar(String cadena)
        {
            cadena = cadena.Replace("\\", "\\\\");
            cadena = cadena.Replace("\"", "\\\"");
            cadena = cadena.Replace("\n", "\\n");
            return cadena;
        }

    }
}