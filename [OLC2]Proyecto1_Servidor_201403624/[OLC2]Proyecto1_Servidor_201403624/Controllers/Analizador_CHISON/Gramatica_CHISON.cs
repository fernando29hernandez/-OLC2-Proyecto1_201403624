using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;
namespace _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_CHISON
{
    public class Gramatica_CHISON:Grammar

    {
        public Gramatica_CHISON():base(caseSensitive:false)
        {
            #region Expresiones Regulares
           
            CommentTerminal IMPORT = new CommentTerminal("CONTENIDOUSER", "${", "}$");
            StringLiteral CADENA = new StringLiteral("CADENA", "\"");
            CommentTerminal CODIGO = new CommentTerminal("CODIGO", "$", "$");
            //StringLiteral CODIGO = new StringLiteral("CODIGO", "$");
            var ENTERO = new NumberLiteral("ENTERO");
            var DECIMAL = new RegexBasedTerminal("DECIMAL", "[0-9]+'.'[0-9]+");
            StringLiteral CADENA_ESPECIAL = new StringLiteral("cadena_especial", "\'");
            #endregion

            #region terminales
            var DATABASES =ToTerm("\"DATABASES\"");
            var NAME = ToTerm("\"NAME\"");
            var TYPE = ToTerm("\"TYPE\"");
            var DATA = ToTerm("\"DATA\"");
            var CQL_TYPE = ToTerm("\"CQL-TYPE\"");
            var COLUMNS =ToTerm("\"COLUMNS\"");
            var PK =ToTerm("\"PK\"");
            var AS =  ToTerm("\"AS\"");
            var ATTRS =ToTerm("\"ATTRS\"");
            var INSTR = ToTerm("\"INSTR\"");
            var USERS = ToTerm("\"USERS\"");
            var PASSWORD = ToTerm("\"PASSWORD\"");
            var PERMISSIONS = ToTerm("\"PERMISSIONS\"");
            var ABRIRCOR = ToTerm("[");
            var CERRARCOR = ToTerm("]");
            var IGUAL = ToTerm("=");
            var COMA = ToTerm(",");
            var MAYOR = ToTerm(">");
            var MENOR = ToTerm("<");
            var IN = ToTerm("IN");
            var OUT = ToTerm("OUT");
            var TRUE = ToTerm("true");
            var FALSE = ToTerm("false");
            var ABRIRLLAVE = ToTerm("{");
            var CERRRARLLAVE = ToTerm("}");
            var ABRIRPRINCIPAL = ToTerm("$<");
            var CERRARPRINCIPAL = ToTerm(">$");
            var PARAMETERS = ToTerm("\"PARAMETERS\"");
            var NULL = ToTerm("null");

            #endregion

            #region no_terminales
            NonTerminal S = new NonTerminal("S");
            NonTerminal L_TAGS = new NonTerminal("L_TAGS");
            NonTerminal TAG_DATABASES = new NonTerminal("TAG_DATABASES");
            NonTerminal TAG_USUARIOS = new NonTerminal("TAG_USUARIOS");

            NonTerminal Lectura_Archivo_Principal = new NonTerminal("Lectura_Archivo_Principal");
            NonTerminal Lectura_Archivo_Secundario = new NonTerminal("Lectura_Archivo_Secundario");
            NonTerminal TAG = new NonTerminal("TAG");
            NonTerminal OBJETO = new NonTerminal("OBJETO");
            NonTerminal ESTRUCTURA_CUERPO = new NonTerminal("ESTRUCTURA_CUERPO");
            NonTerminal IMPORTARCHISON = new NonTerminal("IMPORTARCHISON");
            NonTerminal ELEMENTOS = new NonTerminal("ELEMENTOS");
            NonTerminal ELEMENTO = new NonTerminal("ELEMENTO");
            NonTerminal EXPRESION = new NonTerminal("EXPRESION");
            NonTerminal LISTA = new NonTerminal("LISTA");
            NonTerminal CUERPO = new NonTerminal("CUERPO");
            #endregion


            #region gramatica 
            S.Rule = L_TAGS;

            L_TAGS.Rule = MakePlusRule(L_TAGS,TAG);

            TAG.Rule =ABRIRPRINCIPAL+ Lectura_Archivo_Principal+CERRARPRINCIPAL
                | Lectura_Archivo_Secundario;

            Lectura_Archivo_Principal.Rule = MakePlusRule(Lectura_Archivo_Principal,COMA,OBJETO);

            Lectura_Archivo_Secundario.Rule = ESTRUCTURA_CUERPO;
            IMPORTARCHISON.Rule = IMPORT;

            OBJETO.Rule = TAG_DATABASES 
                | TAG_USUARIOS;

            TAG_DATABASES.Rule = DATABASES + IGUAL + ABRIRCOR + ESTRUCTURA_CUERPO + CERRARCOR
                            | DATABASES + IGUAL + ABRIRCOR + CERRARCOR
                            | DATABASES + IGUAL + ABRIRCOR + IMPORTARCHISON + CERRARCOR;

            TAG_USUARIOS.Rule = USERS + IGUAL + ABRIRCOR + ESTRUCTURA_CUERPO + CERRARCOR
                          | USERS + IGUAL + ABRIRCOR  + CERRARCOR
                          | USERS + IGUAL + ABRIRCOR +IMPORTARCHISON+ CERRARCOR;

            ESTRUCTURA_CUERPO.Rule = MakePlusRule(ESTRUCTURA_CUERPO, COMA, CUERPO);

            CUERPO.Rule = MENOR + ELEMENTOS + MAYOR;

            ELEMENTOS.Rule = MakePlusRule(ELEMENTOS,COMA,ELEMENTO);

            ELEMENTO.Rule = NAME + IGUAL + EXPRESION
                            | DATA + IGUAL + EXPRESION
                            | COLUMNS + IGUAL + EXPRESION
                            | CQL_TYPE + IGUAL + EXPRESION
                            | TYPE + IGUAL + EXPRESION
                            | PK + IGUAL + EXPRESION
                            | ATTRS + IGUAL + EXPRESION
                            | PARAMETERS + IGUAL + EXPRESION
                            | AS + IGUAL + EXPRESION
                            | INSTR + IGUAL + EXPRESION
                            | PASSWORD + IGUAL + EXPRESION
                            | PERMISSIONS + IGUAL + EXPRESION;

            EXPRESION.Rule = ENTERO
                           | DECIMAL
                           | FALSE
                           | TRUE
                           | CADENA
                           | CADENA_ESPECIAL
                           | ABRIRCOR  + CERRARCOR
                           | ABRIRCOR + ESTRUCTURA_CUERPO + CERRARCOR
                           | ABRIRCOR + LISTA + CERRARCOR
                           | ABRIRCOR + IMPORTARCHISON + CERRARCOR
                           | ESTRUCTURA_CUERPO
                           | CODIGO
                           | IN
                           | OUT
                           | NULL
                           ;

            LISTA.Rule = MakePlusRule(LISTA,COMA,EXPRESION);
            #endregion

            #region preferencias

            this.Root = S; 

            #endregion
        }
    }
}