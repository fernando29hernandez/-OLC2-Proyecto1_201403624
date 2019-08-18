using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;
namespace _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_LUP.Arbol_LUP
{
    public class Arbol_LUP
    {
        ParseTreeNode Raiz;
        LinkedList<Nodo_LUP> nodos;
        public Arbol_LUP(ParseTreeNode Raiz)
        {
            this.Raiz = Raiz;

        }
        public String  Construir_Arbol()
        {
            String respuesta="";
            nodos = instrucciones(Raiz.ChildNodes.ElementAt(0));
            foreach (Nodo_LUP nodo in nodos)
            {
                respuesta +=nodo.ejecutar().ToString();
            }
            return respuesta;

        }
        public LinkedList<Nodo_LUP> instrucciones(ParseTreeNode actual)
        {
            LinkedList<Nodo_LUP> lista = new LinkedList<Nodo_LUP>();
            foreach (ParseTreeNode ins in actual.ChildNodes)
            {
                lista.AddLast(etiqueta(ins));
            }
            return lista;
        }
        public Nodo_LUP etiqueta(ParseTreeNode actual)
        {
            string tipoetiqueta = actual.ChildNodes.ElementAt(0).ToString().Split(' ')[0].ToLower();
            switch (tipoetiqueta)
            {
                case "etiquetalogin":
                    return etiqueta_login(actual.ChildNodes.ElementAt(0));
                case "etiquetalogout":
                    return etiqueta_logout(actual.ChildNodes.ElementAt(0));
                case "etiquetastruct":
                    return etiqueta_struct(actual.ChildNodes.ElementAt(0));
                case "etiquetaquery":
                    return etiqueta_query(actual.ChildNodes.ElementAt(0));

            }
            return null;
        }

        public Nodo_LUP etiqueta_login(ParseTreeNode actual)
        {
            Nodo_LUP usuario = etiqueta_user(actual.ChildNodes.ElementAt(4));
            Nodo_LUP pass = etiqueta_pass(actual.ChildNodes.ElementAt(5));

            return new ETIQUETA_LOGIN(usuario,pass);
        }
        public Nodo_LUP etiqueta_logout(ParseTreeNode actual)
        {
            Nodo_LUP usuario = etiqueta_user(actual.ChildNodes.ElementAt(4));
            
            return new ETIQUETA_LOGOUT(usuario);
        }

        public Nodo_LUP etiqueta_query(ParseTreeNode actual)
        {
            Nodo_LUP usuario = etiqueta_user(actual.ChildNodes.ElementAt(4));
            Nodo_LUP data = etiqueta_data(actual.ChildNodes.ElementAt(5));

            return new ETIQUETA_QUERY(usuario, data);
        }


        public Nodo_LUP etiqueta_struct(ParseTreeNode actual)
        {
            Nodo_LUP usuario = etiqueta_user(actual.ChildNodes.ElementAt(4));
            
            return new ETIQUETA_STRUCT(usuario);
        }

        public Nodo_LUP etiqueta_user(ParseTreeNode actual)
        {
            String usuario = actual.ChildNodes.ElementAt(0).ToString();
            return new ETIQUETA_USER(usuario);

        }
        public Nodo_LUP etiqueta_pass(ParseTreeNode actual)
        {
            String usuario = actual.ChildNodes.ElementAt(0).ToString();
            return new ETIQUETA_PASS(usuario);

        }
        public Nodo_LUP etiqueta_data(ParseTreeNode actual)
        {
            String data = actual.ChildNodes.ElementAt(0).ToString();
            return new ETIQUETA_DATA(data);

        }
    }
}