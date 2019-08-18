using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Parsing;
namespace _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_LUP
{
    public class Gramatica_LUP : Grammar
    {
        public Gramatica_LUP() : base(caseSensitive: true)
        {
            #region Expresiones_Regulares
            CommentTerminal CONTENIDOUSER = new CommentTerminal("CONTENIDOUSER", "[+USER]", "[-USER]");
            CommentTerminal CONTENIDOPASS = new CommentTerminal("CONTENIDOPASS", "[+PASS]", "[-PASS]");
            CommentTerminal CONTENIDODATA = new CommentTerminal("CONTENIDODATA", "[+DATA]", "[-DATA]");

            #endregion
            #region Terminales
            //var USER = ToTerm("user");
            var MAS = ToTerm("+");
            var MENOS = ToTerm("-");
            var QUERY = ToTerm("QUERY");
            var LOGOUT = ToTerm("LOGOUT");
            var LOGIN = ToTerm("LOGIN");
            //var PASS = ToTerm("pass");
            //var DATA = ToTerm("data");
            var STRUCT = ToTerm("STRUCT");
            var ABRIRCOR = ToTerm("[");
            var CERRARCOR = ToTerm("]");

            #endregion
            #region NO_Terminales
            NonTerminal S = new NonTerminal("S");
            NonTerminal ETIQUETALOGIN = new NonTerminal("ETIQUETALOGIN");
            NonTerminal ETIQUETALOGOUT = new NonTerminal("ETIQUETALOGOUT");

            NonTerminal ETIQUETAUSER = new NonTerminal("ETIQUETAUSER");
            NonTerminal ETIQUETAPASS = new NonTerminal("ETIQUETAPASS");
            NonTerminal ETIQUETADATA = new NonTerminal("ETIQUETADATA");
            NonTerminal ETIQUETASTRUCT = new NonTerminal("ETIQUETASTRUCT");
            NonTerminal ETIQUETAQUERY = new NonTerminal("ETIQUETAQUERY");
            NonTerminal ETIQUETA = new NonTerminal("ETIQUETA");
            NonTerminal L_ETIQUETAS = new NonTerminal("L_ETIQUETAS");
            #endregion
            #region Gramatica
            S.Rule = L_ETIQUETAS;

            L_ETIQUETAS.Rule = MakePlusRule(L_ETIQUETAS,ETIQUETA);

            ETIQUETA.Rule =  ETIQUETALOGIN
                            |ETIQUETALOGOUT
                            |ETIQUETASTRUCT
                            |ETIQUETAQUERY;
            ETIQUETALOGIN.Rule = ABRIRCOR + MAS + LOGIN + CERRARCOR + ETIQUETAUSER + ETIQUETAPASS + ABRIRCOR + MENOS + LOGIN + CERRARCOR;
            ETIQUETALOGOUT.Rule = ABRIRCOR + MAS + LOGOUT + CERRARCOR + ETIQUETAUSER + ABRIRCOR + MENOS + LOGOUT + CERRARCOR;
            ETIQUETASTRUCT.Rule = ABRIRCOR + MAS + STRUCT + CERRARCOR + ETIQUETAUSER + ABRIRCOR + MENOS + STRUCT + CERRARCOR;
            ETIQUETAQUERY.Rule = ABRIRCOR + MAS + QUERY + CERRARCOR + ETIQUETAUSER + ETIQUETADATA+ ABRIRCOR + MENOS + QUERY + CERRARCOR;

            ETIQUETAUSER.Rule = CONTENIDOUSER;
            ETIQUETAPASS.Rule = CONTENIDOPASS;
            ETIQUETADATA.Rule = CONTENIDODATA;
            #endregion

            #region Preferencias
            this.Root = S;
            #endregion

        }
    }
}