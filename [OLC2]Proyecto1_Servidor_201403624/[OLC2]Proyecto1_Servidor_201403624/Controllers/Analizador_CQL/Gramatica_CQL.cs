using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;    
namespace _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_CQL
{
    public class Gramatica_CQL : Grammar
    {
        public Gramatica_CQL() : base(caseSensitive: false)
        {

            #region Expresiones_Regulares

            StringLiteral CADENA = new StringLiteral("cadena", "\"");
            StringLiteral CADENA_ESPECIAL = new StringLiteral("cadena_especial", "\'");

            var ENTERO = new NumberLiteral("entero");
            var DECIMAL = new RegexBasedTerminal("decimal", "[0-9]+'.'[0-9]+");
            IdentifierTerminal IDENTIFICADOR = new IdentifierTerminal("Identificador");

            CommentTerminal comentariosimple = new CommentTerminal("comentariosimple", "//", "\n", "\r\n"); //si viene una nueva linea se termina de reconocer el comentario.
            CommentTerminal comentariomulti = new CommentTerminal("comentariomulti", "/*", "*/");

            #endregion


            #region Terminales
            var ARROBA = ToTerm("@");
            var LOG = ToTerm("log");
            var NULO = ToTerm("null");
            var VERDADERO = ToTerm("true");
            var FALSO = ToTerm("false");
            var CREAR = ToTerm("create");
            var TYPE = ToTerm("type");
            var SI = ToTerm("if");
            var NO = ToTerm("not");
            var EXISTE = ToTerm("exists");
            var ALTERAR = ToTerm("alter");
            var AGREGAR = ToTerm("add");
            var ELIMINAR = ToTerm("delete");
            var DATABASE = ToTerm("database");
            var USAR = ToTerm("use");
            var BORRAR = ToTerm("drop");
            var TABLA = ToTerm("table");
            var CONTADOR = ToTerm("counter");
            var TIPOSTRING = ToTerm("string");
            var TIPOENTERO = ToTerm("int");
            var TIPODOUBLE = ToTerm("double");
            var TIPOTIME = ToTerm("time");
            var TIPODATE = ToTerm("date");
            var TIPOBOOLEAN = ToTerm("boolean");
            var PRIMARY = ToTerm("primary");
            var KEY = ToTerm("key");
            var TRUNCAR = ToTerm("truncate");
            var COMMIT = ToTerm("commit");
            var ROOLBACK = ToTerm("roolback");
            var USUARIO = ToTerm("user");
            var CON = ToTerm("with");
            var PASS = ToTerm("password");
            var PERMITIR = ToTerm("grant");
            var DENEGAR = ToTerm("revoke");
            var ON = ToTerm("on");
            var INSERT = ToTerm("insert");
            var INTO = ToTerm("into");
            var ACTUALIZAR = ToTerm("update");
            var DONDE = ToTerm("where");
            var DESDE = ToTerm("from");
            var CONSULTA = ToTerm("select");
            var IN = ToTerm("in");
            var ASC = ToTerm("asc");
            var DESC = ToTerm("desc");
            var LIMIT = ToTerm("limit");
            var ORDER = ToTerm("order");
            var BY = ToTerm("by");
            var BEGIN = ToTerm("begin");
            var APPLY = ToTerm("apply");
            var BATCH = ToTerm("batch");
            var COUNT = ToTerm("count");
            var MIN = ToTerm("min");
            var MAX = ToTerm("max");
            var AVG = ToTerm("avg");
            var SUM = ToTerm("sum");
            var SET = ToTerm("set");
            var MAP = ToTerm("map");
            var LIST = ToTerm("list");
            var MAS = ToTerm("+");
            var MENOS = ToTerm("-");
            var POTENCIA = ToTerm("**");
            
            var MUL = ToTerm("*");
            var DIV = ToTerm("/");
            var MOD = ToTerm("%");
            var INC = ToTerm("++");
            var DEC = ToTerm("--");
            var IGUAL = ToTerm("=");
            var MASIGUAL = ToTerm("+=");
            var MENOSIGUAL = ToTerm("-=");
            var PORIGUAL = ToTerm("*=");
            var DIVIGUAL = ToTerm("/=");
            var MENOR = ToTerm("<");
            var MAYOR = ToTerm(">");
            var MAYORIGUAL = ToTerm(">=");
            var MENORIGUAL = ToTerm("<=");
            var IGUALIGUAL = ToTerm("==");
            var DIFERENTE = ToTerm("!=");
            var SUMALOGICA = ToTerm("||");
            var MULLOGICA = ToTerm("&&");
            var SUMALOGICAEXCLUSIVA = ToTerm("^");
            var NEGACION = ToTerm("!");
            var PREGUNTA = ToTerm("?");
            var SINO = ToTerm("else");
            var SELECCIONA = ToTerm("switch");
            var CASO = ToTerm("case");
            var DEFECTO = ToTerm("default");
            var MIENTRAS = ToTerm("while");
            var HACER = ToTerm("do");
            var PARA = ToTerm("for");
            var NUEVO = ToTerm("new");
            var GET = ToTerm("get");
            var REMOVE = ToTerm("remove");
            var SIZE = ToTerm("size");
            var CLEAR = ToTerm("clear");
            var CONTAINS = ToTerm("contains");
            var PROCEDURE = ToTerm("procedure");
            var CALL = ToTerm("call");
            var LENGTH = ToTerm("length");
            var TOUPPER = ToTerm("touppercase");
            var TOLOWER = ToTerm("tolowercase");
            var STARTSWITH = ToTerm("startswith");
            var ENDSWITH = ToTerm("endswith");
            var SUBSTRING = ToTerm("substring");
            var GETYEAR = ToTerm("getyear");
            var GETMONTH = ToTerm("getmonth");
            var GETDAY = ToTerm("getday");
            var GETHOUR = ToTerm("gethour");
            var GETMINUTE = ToTerm("getminuts");
            var GETSECOND = ToTerm("getseconds");
            var TODAY = ToTerm("today");
            var NOW = ToTerm("now");
            var BREAK = ToTerm("break");
            var VALUES = ToTerm("values");
            var CONTINUE = ToTerm("break");
            var RETURN = ToTerm("return");
            var CURSOR = ToTerm("cursor");
            var IS = ToTerm("is");
            var EACH = ToTerm("each");
            var OPEN = ToTerm("open");
            var CLOSE = ToTerm("close");
            var THROW = ToTerm("throw");
            var TRY = ToTerm("try");
            var CATCH = ToTerm("catch");
            var MESSAGE = ToTerm("message");
            var COMA = ToTerm(",");
            var PUNTO = ToTerm(".");
            var PUNTOCOMA = ToTerm(";");
            var DOSPUNTOS = ToTerm(":");
            var ABRIRCOR = ToTerm("[");
            var CERRARCOR = ToTerm("]");
            var ABRIRPARENTESIS = ToTerm("(");
            var CERRARPARENTESIS = ToTerm(")");
            var ABRIRPARENTESIS_E = ToTerm("(<");
            var CERRARPARENTESIS_E = ToTerm(">)");
            var ABRIRLLAVE = ToTerm("{");
            var CERRARLLAVE = ToTerm("}");
            var EXCEPCION1 = ToTerm("TypeAlreadyExists");
            var EXCEPCION2 = ToTerm("TypeDontExists");
            var EXCEPCION3 = ToTerm("BDAlreadyExists");
            var EXCEPCION4 = ToTerm("BDDontExists");
            var EXCEPCION5 = ToTerm("UseBDException");
            var EXCEPCION6 = ToTerm("TableAlreadyExists");
            var EXCEPCION7 = ToTerm("TableDontExists");
            var EXCEPCION8 = ToTerm("CounterTypeException");
            var EXCEPCION9 = ToTerm("UserAlreadyExists");
            var EXCEPCION10 = ToTerm("UserDontExists");
            var EXCEPCION11 = ToTerm("ValuesException");
            var EXCEPCION12 = ToTerm("ColumnException");
            var EXCEPCION13 = ToTerm("BatchException");
            var EXCEPCION14 = ToTerm("IndexOutException");
            var EXCEPCION15 = ToTerm("ArithmeticException");
            var EXCEPCION16 = ToTerm("NullPointerException");
            var EXCEPCION17 = ToTerm("NumberReturnsException");
            var EXCEPCION18 = ToTerm("FunctionAlreadyExists");
            var EXCEPCION19 = ToTerm("ProcedureAlreadyExists");
            var EXCEPCION20 = ToTerm("ObjectAlreadyExists");
            RegisterOperators(1, Associativity.Right, IGUAL);
            RegisterOperators(2, Associativity.Right, PREGUNTA, DOSPUNTOS);
            RegisterOperators(3, Associativity.Right, PUNTO);
            RegisterOperators(4, Associativity.Left, SUMALOGICA);
            RegisterOperators(5, Associativity.Left, MULLOGICA);
            RegisterOperators(6, Associativity.Left, SUMALOGICAEXCLUSIVA);
            RegisterOperators(7, Associativity.Left, DIFERENTE, IGUALIGUAL);
            RegisterOperators(8, Associativity.Neutral, MAYORIGUAL, MENORIGUAL, MENOR, MAYOR);
            RegisterOperators(9, Associativity.Left,MAS, MENOS);
            RegisterOperators(10, Associativity.Left, MUL, DIV, MOD);
            RegisterOperators(11, Associativity.Left, POTENCIA);
            RegisterOperators(12, Associativity.Right, NEGACION);
            RegisterOperators(13,Associativity.Neutral,INC,DEC);
            RegisterOperators(14, Associativity.Right,ABRIRPARENTESIS, CERRARPARENTESIS);

            NonGrammarTerminals.Add(comentariosimple);
            NonGrammarTerminals.Add(comentariomulti);
            #endregion

            #region No Terminales
            NonTerminal inicial = new NonTerminal("S");
            NonTerminal instruccion = new NonTerminal("instruccion");
            NonTerminal instrucciones = new NonTerminal("instrucciones");
            NonTerminal sentenciadeclaracion = new NonTerminal("declaracion");
            NonTerminal declaracion_funcion = new NonTerminal("declaracion_funcion");
            NonTerminal declaracion_procedimiento = new NonTerminal("declaracion_procedimiento");
            NonTerminal sentenciaasignacion = new NonTerminal("sentenciaasignacion");
            NonTerminal sentenciaimprimir = new NonTerminal("sentenciaimprimir");
            NonTerminal sentenciadetener = new NonTerminal("sentenciadetener");
            NonTerminal sentenciaretornar = new NonTerminal("sentenciaretornar");
            NonTerminal sentenciacontinuar = new NonTerminal("sentenciacontinuar");
            NonTerminal sentenciasi = new NonTerminal("sentenciaSI");
            NonTerminal sentenciaselecciona = new NonTerminal("sentenciaselecciona");
            NonTerminal sentenciacaso = new NonTerminal("sentenciacaso");
            NonTerminal sentenciamientras = new NonTerminal("sentenciamientras");
            NonTerminal sentenciafor = new NonTerminal("sentenciafor");
            NonTerminal sentenciaforeach = new NonTerminal("sentenciaforeach");
            NonTerminal sentenciahacermientras = new NonTerminal("sentenciahacermientras");
            NonTerminal sentenciacrearbd = new NonTerminal("sentenciacrearbd");
            NonTerminal sentenciausarbd = new NonTerminal("sentenciausarbd");
            NonTerminal sentenciaborrarbd = new NonTerminal("sentenciaborrarbd");
            NonTerminal sentenciaalterartabla = new NonTerminal("sentenciaalterarbd");

            NonTerminal sentenciatruncartabla = new NonTerminal("sentenciatruncartabla");
            NonTerminal sentenciacreartabla = new NonTerminal("sentenciacreartabla");
            NonTerminal sentenciaborrartabla = new NonTerminal("sentenciaborrartabla");
            NonTerminal sentenciacommit = new NonTerminal("sentenciacommit");
            NonTerminal sentenciarollback = new NonTerminal("sentenciarollback");
            NonTerminal sentenciacrearusuario = new NonTerminal("sentenciacrearusuario");
            NonTerminal sentenciapermitir = new NonTerminal("sentenciapermitir");
            NonTerminal sentenciadenegar = new NonTerminal("sentenciadenegar");
            NonTerminal sentenciainsertar = new NonTerminal("sentenciainsertar");
            NonTerminal sentenciaactualizar = new NonTerminal("sentenciaactualizar");
            NonTerminal sentenciaeliminar = new NonTerminal("sentenciaeliminar");
            NonTerminal sentenciaconsulta = new NonTerminal("sentenciaconsulta");
            NonTerminal sentenciabatch = new NonTerminal("sentenciabatch");
            NonTerminal sentenciaagregacion = new NonTerminal("sentenciaagregacion");
            NonTerminal sentenciathrow = new NonTerminal("sentenciathrow");
            NonTerminal sentenciatrycatch = new NonTerminal("sentenciatrycatch");
            NonTerminal tipo = new NonTerminal("tipo");
            NonTerminal sentenciacrearusertype = new NonTerminal("sentenciacrearusertype");
            NonTerminal listavariables = new NonTerminal("listavariables");
            NonTerminal declaracion = new NonTerminal("declaracion");
            NonTerminal expresion = new NonTerminal("expresion");
            NonTerminal listaatributos = new NonTerminal("listaatributos");
            NonTerminal declaracionesusertypes = new NonTerminal("declaracionesusertypes");
            NonTerminal Listavalores = new NonTerminal("Listavalores");
            NonTerminal LISTAINSTRUCCIONES = new NonTerminal("LISTAINSTRUCCIONES");
            NonTerminal Listacasos = new NonTerminal("Listacasos");
            NonTerminal Lista_acceso = new NonTerminal("Lista_acceso");
            NonTerminal Acceso = new NonTerminal("Acceso");
            NonTerminal operacionesunariomenos = new NonTerminal("operacionesunariomenos");
            NonTerminal operacionesunarionegacion = new NonTerminal("operacionesunarionegacion");
            NonTerminal verificacionExiste = new NonTerminal("verificacionExiste");
            NonTerminal lista_declaraciones_tabla = new NonTerminal("lista_declaraciones_tabla");
            NonTerminal declaracion_tabla = new NonTerminal("declaracion_tabla");
            NonTerminal llave_primaria = new NonTerminal("llave_primaria");
            NonTerminal llave_primaria_compuesta = new NonTerminal("llave_primaria_compuesta");
            NonTerminal MODIFICADOR = new NonTerminal("MODIFICADOR");
            NonTerminal TIPOEXCEPCION = new NonTerminal("TIPOEXCEPCION");
            NonTerminal lista_identificadores = new NonTerminal("lista_identificadores");
            NonTerminal sentencia_alterar_user_type = new NonTerminal("sentencia_alterar_user_type");
            NonTerminal sentencia_eliminar_user_type = new NonTerminal("sentencia_eliminar_user_type");
            NonTerminal Lista_parametros = new NonTerminal("Lista_parametros");
            NonTerminal declaracion_parametro = new NonTerminal("declaracion_parametro");
            NonTerminal sentenciacursor = new NonTerminal("sentenciacursor");
            NonTerminal sentenciaabrircursor = new NonTerminal("sentenciabrircursor");
            NonTerminal sentenciacerrarcursor = new NonTerminal("sentenciacerrarcursor");
            NonTerminal Lista_campos = new NonTerminal("Lista_campos");
            NonTerminal campo = new NonTerminal("campo");
            NonTerminal TIPOORDENAMIENTO = new NonTerminal("TIPOORDENAMIENTO");
            NonTerminal TIPOAGREGACION = new NonTerminal("TIPOAGREGACION");
            NonTerminal ASIGNACIONES = new NonTerminal("ASIGNACIONES");
            NonTerminal sentenciawhere = new NonTerminal("sentenciawhere");
            NonTerminal LISTA_SELECCION = new NonTerminal("LISTA_SELECCION");
            NonTerminal llamada = new NonTerminal("llamada");
            NonTerminal OPERACIONPOST = new NonTerminal("OPERACIONPOST");
            NonTerminal instanciaobjeto = new NonTerminal("instanciaobjeto");
            NonTerminal llamada_a_nativas = new NonTerminal("llamada_a_nativas");
            NonTerminal Lista_clave_valor = new NonTerminal("Lista_clave_valor");
            NonTerminal clave_valor = new NonTerminal("clave_valor");
            NonTerminal extras_where = new NonTerminal("extras_where");
            NonTerminal extra = new NonTerminal("extra");
            NonTerminal Tipo_enciclado = new NonTerminal("Tipo_enciclado");
            NonTerminal Asignacion_Multiple = new NonTerminal("Asignacion_Multiple");
            NonTerminal Asignacion_Multiple_Lista = new NonTerminal("Asignacion_Multiple_Lista");
            #endregion

            #region Gramatica
            inicial.Rule = instrucciones;
            LISTAINSTRUCCIONES.Rule = ABRIRLLAVE + instrucciones + CERRARLLAVE
                                     | ABRIRLLAVE + CERRARLLAVE;
            instrucciones.Rule = instrucciones + instruccion
                                | instrucciones + declaracion_funcion
                                | instrucciones + declaracion_procedimiento
                                | declaracion_funcion
                                | declaracion_procedimiento
                                | instruccion;

            tipo.Rule = TIPOBOOLEAN
                        | TIPODATE
                        | TIPODOUBLE
                        | TIPOENTERO
                        | TIPOEXCEPCION
                        | TIPOSTRING
                        | TIPOTIME
                        | IDENTIFICADOR
                        | CONTADOR
                        | MAP
                        | LIST
                        | SET
                        ;
            declaracion_funcion.Rule = tipo + IDENTIFICADOR + ABRIRPARENTESIS + Lista_parametros + CERRARPARENTESIS + LISTAINSTRUCCIONES
                                       | tipo + IDENTIFICADOR + ABRIRPARENTESIS + CERRARPARENTESIS + LISTAINSTRUCCIONES;


            declaracion_procedimiento.Rule = PROCEDURE + IDENTIFICADOR + ABRIRPARENTESIS + Lista_parametros + CERRARPARENTESIS + COMA + ABRIRPARENTESIS + Lista_parametros + CERRARPARENTESIS + LISTAINSTRUCCIONES
                                            | PROCEDURE + IDENTIFICADOR + ABRIRPARENTESIS + CERRARPARENTESIS + COMA + ABRIRPARENTESIS + Lista_parametros + CERRARPARENTESIS + LISTAINSTRUCCIONES
                                            | PROCEDURE + IDENTIFICADOR + ABRIRPARENTESIS + Lista_parametros + CERRARPARENTESIS + COMA + ABRIRPARENTESIS + CERRARPARENTESIS + LISTAINSTRUCCIONES
                                            | PROCEDURE + IDENTIFICADOR + ABRIRPARENTESIS + CERRARPARENTESIS + COMA + ABRIRPARENTESIS + CERRARPARENTESIS + LISTAINSTRUCCIONES;



            Lista_parametros.Rule = MakePlusRule(Lista_parametros , COMA , declaracion_parametro);

            declaracion_parametro.Rule = tipo + ARROBA + IDENTIFICADOR;

            instruccion.Rule = sentenciacrearusertype//
                               | sentencia_eliminar_user_type //
                               | sentencia_alterar_user_type //
                               | sentenciadeclaracion//
                               | sentenciaasignacion + PUNTOCOMA
                               | Asignacion_Multiple_Lista
                               | sentenciaimprimir//
                               | sentenciadetener//
                               | sentenciaretornar//
                               | sentenciacontinuar//
                               | sentenciasi//
                               | sentenciaselecciona//
                               | sentenciafor//
                               | sentenciacursor//
                               | sentenciaabrircursor//
                               | sentenciacerrarcursor//
                               | sentenciaforeach//
                               | sentenciamientras//
                               | sentenciahacermientras//
                               | sentenciacrearbd//
                               | sentenciausarbd//
                               | sentenciaborrarbd//
                               | sentenciacreartabla//
                               | sentenciaalterartabla//
                               | sentenciatruncartabla//
                               | sentenciaborrartabla//
                               | sentenciacommit//
                               | sentenciarollback//
                               | sentenciacrearusuario//
                               | sentenciapermitir//
                               | sentenciadenegar//
                               | sentenciainsertar//
                               | sentenciaactualizar//
                               | sentenciaeliminar//
                               | sentenciaconsulta + PUNTOCOMA//
                               | sentenciaagregacion + PUNTOCOMA//
                               | sentenciabatch//
                               | sentenciathrow//
                               | sentenciatrycatch;//

            sentenciaasignacion.Rule = Lista_acceso + IGUAL + expresion
                                      | Lista_acceso + MASIGUAL + expresion
                                      | Lista_acceso + MENOSIGUAL + expresion
                                      | Lista_acceso + PORIGUAL + expresion
                                      | Lista_acceso + DIVIGUAL + expresion
                                      | Lista_acceso;

            verificacionExiste.Rule = SI + NO + EXISTE
                                    | SI + EXISTE
                                    | Empty;

            sentenciacrearusertype.Rule = CREAR + TYPE + verificacionExiste + IDENTIFICADOR + ABRIRPARENTESIS + listaatributos + CERRARPARENTESIS + PUNTOCOMA
                                         ;

           
            listaatributos.Rule = MakePlusRule(listaatributos ,COMA , declaracionesusertypes)
                                ;

            declaracionesusertypes.Rule = IDENTIFICADOR + Tipo_enciclado
                                          ;

            Tipo_enciclado.Rule = tipo
                                  | tipo + MENOR + Tipo_enciclado + MAYOR
                                  | tipo + MENOR + tipo + COMA + Tipo_enciclado + MAYOR;


            sentencia_alterar_user_type.Rule = ALTERAR + TYPE + IDENTIFICADOR + MODIFICADOR + ABRIRPARENTESIS + lista_identificadores + CERRARPARENTESIS + PUNTOCOMA;

            sentencia_eliminar_user_type.Rule = ELIMINAR + TYPE + IDENTIFICADOR + PUNTOCOMA;


            lista_identificadores.Rule = lista_identificadores + COMA + IDENTIFICADOR
                                       | lista_identificadores + COMA + IDENTIFICADOR + Tipo_enciclado
                                       | IDENTIFICADOR
                                       | IDENTIFICADOR + Tipo_enciclado//////////////////////////////////// falta los map list y set
                                       ;

            sentenciacrearbd.Rule = CREAR + DATABASE + verificacionExiste + IDENTIFICADOR + PUNTOCOMA
                                   | CREAR + DATABASE + IDENTIFICADOR + PUNTOCOMA;

            sentenciausarbd.Rule = USAR + IDENTIFICADOR + PUNTOCOMA;

            sentenciaborrarbd.Rule = BORRAR + DATABASE + IDENTIFICADOR + PUNTOCOMA;

            sentenciabatch.Rule = BEGIN + BATCH+PUNTOCOMA + instrucciones + APPLY + BATCH+PUNTOCOMA ;

            sentenciacreartabla.Rule = CREAR + TABLA + verificacionExiste +IDENTIFICADOR+ ABRIRPARENTESIS + lista_declaraciones_tabla + CERRARPARENTESIS + PUNTOCOMA;


            lista_declaraciones_tabla.Rule = lista_declaraciones_tabla + COMA + declaracion_tabla + llave_primaria
                                            | lista_declaraciones_tabla + COMA + declaracion_tabla
                                            | declaracion_tabla + llave_primaria
                                            | declaracion_tabla
                                            ;

            llave_primaria.Rule = PRIMARY + KEY;
            declaracion_tabla.Rule = IDENTIFICADOR + tipo
                                          | IDENTIFICADOR + LIST + MENOR + tipo + MAYOR
                                          | IDENTIFICADOR + SET + MENOR + tipo + MAYOR
                                          | IDENTIFICADOR + MAP + MENOR + tipo + COMA + tipo + MAYOR
                                          | PRIMARY + KEY + ABRIRPARENTESIS + llave_primaria_compuesta + CERRARPARENTESIS;

            llave_primaria_compuesta.Rule = MakePlusRule(llave_primaria_compuesta , COMA , IDENTIFICADOR)
                                            ;

            sentenciaalterartabla.Rule = ALTERAR + TABLA + IDENTIFICADOR + MODIFICADOR + ABRIRPARENTESIS + lista_identificadores + CERRARPARENTESIS + PUNTOCOMA;

            MODIFICADOR.Rule = AGREGAR | ELIMINAR;

            sentenciaborrartabla.Rule = BORRAR + TABLA + verificacionExiste + IDENTIFICADOR + PUNTOCOMA;

            sentenciatruncartabla.Rule = TRUNCAR + TABLA + IDENTIFICADOR + PUNTOCOMA;

            sentenciacrearusuario.Rule = CREAR + USUARIO + IDENTIFICADOR + CON + PASS + expresion + PUNTOCOMA;

            sentenciapermitir.Rule = PERMITIR + IDENTIFICADOR + ON + IDENTIFICADOR + PUNTOCOMA;

            sentenciadenegar.Rule = DENEGAR + IDENTIFICADOR + ON + IDENTIFICADOR + PUNTOCOMA;

            sentenciacursor.Rule = CURSOR + ARROBA + IDENTIFICADOR + IS + sentenciaconsulta + PUNTOCOMA;

            sentenciaabrircursor.Rule = OPEN + ARROBA + IDENTIFICADOR + PUNTOCOMA;

            sentenciacerrarcursor.Rule = CLOSE + ARROBA + IDENTIFICADOR + PUNTOCOMA;

            sentenciaforeach.Rule = PARA + EACH + ABRIRPARENTESIS + Lista_parametros + CERRARPARENTESIS +IN+ ARROBA + IDENTIFICADOR + LISTAINSTRUCCIONES;

            sentenciainsertar.Rule = INSERT + INTO + IDENTIFICADOR + VALUES + ABRIRPARENTESIS + Listavalores + CERRARPARENTESIS + PUNTOCOMA
                                    | INSERT + INTO + IDENTIFICADOR+ABRIRPARENTESIS+lista_identificadores+CERRARPARENTESIS + VALUES + ABRIRPARENTESIS + Listavalores + CERRARPARENTESIS + PUNTOCOMA;
            sentenciaactualizar.Rule = ACTUALIZAR + IDENTIFICADOR + SET + ASIGNACIONES + sentenciawhere + PUNTOCOMA
                                       | ACTUALIZAR + IDENTIFICADOR + SET + ASIGNACIONES + PUNTOCOMA;
            sentenciaeliminar.Rule = ELIMINAR + DESDE + IDENTIFICADOR + sentenciawhere+PUNTOCOMA
                                    | ELIMINAR + expresion + DESDE + IDENTIFICADOR + sentenciawhere+PUNTOCOMA
                                    | ELIMINAR + DESDE + IDENTIFICADOR+PUNTOCOMA
                                    | ELIMINAR + expresion + DESDE + IDENTIFICADOR+PUNTOCOMA;
            sentenciaconsulta.Rule = CONSULTA + LISTA_SELECCION + DESDE + IDENTIFICADOR + sentenciawhere
                                    | CONSULTA + LISTA_SELECCION + DESDE + IDENTIFICADOR;

            LISTA_SELECCION.Rule = MakePlusRule(LISTA_SELECCION ,COMA , Lista_acceso)
                                 | MUL;

            ASIGNACIONES.Rule = MakePlusRule(ASIGNACIONES, COMA, sentenciaasignacion)
                                ;

            sentenciawhere.Rule = DONDE + expresion
                                | DONDE + expresion + extras_where
                                ;

            extras_where.Rule = MakePlusRule(extras_where, extra);

            extra.Rule = ORDER + BY + Lista_campos
                                | LIMIT + expresion
                                | IN + ABRIRPARENTESIS + Listavalores + CERRARPARENTESIS;

            sentenciaagregacion.Rule = TIPOAGREGACION + ABRIRPARENTESIS_E + sentenciaconsulta +CERRARPARENTESIS_E;
            TIPOAGREGACION.Rule = AVG
                                | COUNT
                                | MIN
                                | MAX
                                | SUM;
            Lista_campos.Rule = MakePlusRule( Lista_campos , COMA , campo)
                               ;

            campo.Rule = IDENTIFICADOR + TIPOORDENAMIENTO
                        | IDENTIFICADOR;
            TIPOORDENAMIENTO.Rule = ASC | DESC;

            sentenciaimprimir.Rule = LOG + ABRIRPARENTESIS + expresion + CERRARPARENTESIS + PUNTOCOMA;

            sentenciasi.Rule = SI + ABRIRPARENTESIS + expresion + CERRARPARENTESIS + LISTAINSTRUCCIONES
                               | SI + ABRIRPARENTESIS + expresion + CERRARPARENTESIS + LISTAINSTRUCCIONES + SINO + sentenciasi
                               | SI + ABRIRPARENTESIS + expresion + CERRARPARENTESIS + LISTAINSTRUCCIONES + SINO + LISTAINSTRUCCIONES;

            sentenciadetener.Rule = BREAK + PUNTOCOMA;

            sentenciaselecciona.Rule = SELECCIONA + ABRIRPARENTESIS + expresion + CERRARPARENTESIS + ABRIRLLAVE + Listacasos + CERRARLLAVE;

            Listacasos.Rule = MakePlusRule (Listacasos,sentenciacaso);
            sentenciacaso.Rule = CASO + expresion + DOSPUNTOS + instrucciones
                            | DEFECTO + DOSPUNTOS + instrucciones
                            ;
            sentenciafor.Rule = PARA + ABRIRPARENTESIS + sentenciadeclaracion + expresion + PUNTOCOMA + expresion + CERRARPARENTESIS + LISTAINSTRUCCIONES;

            sentenciamientras.Rule = MIENTRAS + ABRIRPARENTESIS + expresion + CERRARPARENTESIS + LISTAINSTRUCCIONES;

            sentenciahacermientras.Rule = HACER + LISTAINSTRUCCIONES + MIENTRAS + ABRIRPARENTESIS + expresion + CERRARPARENTESIS + LISTAINSTRUCCIONES;

            sentenciacontinuar.Rule = CONTINUE + PUNTOCOMA;

            sentenciaretornar.Rule = RETURN + Listavalores + PUNTOCOMA;

            sentenciathrow.Rule = THROW + NUEVO + TIPOEXCEPCION + PUNTOCOMA;

            sentenciatrycatch.Rule = TRY + LISTAINSTRUCCIONES + CATCH + ABRIRPARENTESIS + tipo + ARROBA + IDENTIFICADOR + CERRARPARENTESIS + LISTAINSTRUCCIONES;
            TIPOEXCEPCION.Rule = EXCEPCION1
                               | EXCEPCION2
                               | EXCEPCION3
                               | EXCEPCION4
                               | EXCEPCION5
                               | EXCEPCION6
                               | EXCEPCION7
                               | EXCEPCION8
                               | EXCEPCION9
                               | EXCEPCION10
                               | EXCEPCION11
                               | EXCEPCION12
                               | EXCEPCION13
                               | EXCEPCION14
                               | EXCEPCION15
                               | EXCEPCION16
                               | EXCEPCION17
                               | EXCEPCION18
                               | EXCEPCION19
                               | EXCEPCION20
                               ;

            sentenciacommit.Rule = COMMIT + PUNTOCOMA;

            sentenciarollback.Rule = ROOLBACK + PUNTOCOMA;

            Listavalores.Rule = MakePlusRule(Listavalores, COMA, expresion)
                                ;

            sentenciadeclaracion.Rule = tipo + listavariables + PUNTOCOMA;

            listavariables.Rule = MakePlusRule(listavariables, COMA, declaracion)
                                  ;

            declaracion.Rule = ARROBA + IDENTIFICADOR + IGUAL + expresion
                              | ARROBA + IDENTIFICADOR;

            expresion.Rule = expresion + SUMALOGICA + expresion
                           | expresion + SUMALOGICAEXCLUSIVA + expresion
                           | expresion + MULLOGICA + expresion
                           | operacionesunarionegacion
                           | expresion + IGUALIGUAL + expresion
                           | expresion + MAYORIGUAL + expresion
                           | expresion + MENORIGUAL + expresion
                           | expresion + DIFERENTE + expresion
                           | expresion + MAYOR + expresion
                           | expresion + MENOR + expresion
                           | expresion + MOD + expresion
                           | expresion + POTENCIA + expresion
                           | expresion + DIV + expresion
                           | expresion + MUL + expresion
                           | operacionesunariomenos
                           | expresion + MAS + expresion
                           | expresion + MENOS + expresion
                           | ABRIRPARENTESIS + expresion + CERRARPARENTESIS
                           | ABRIRCOR + Listavalores + CERRARCOR
                           | ABRIRLLAVE + Listavalores + CERRARLLAVE//modificacion
                           | ABRIRLLAVE + Lista_clave_valor + CERRARLLAVE
                           | ABRIRCOR + Lista_clave_valor + CERRARCOR
                           | expresion + PREGUNTA + expresion + DOSPUNTOS + expresion
                           | OPERACIONPOST
                           | NULO
                           | CADENA
                           | CADENA_ESPECIAL
                           | VERDADERO
                           | FALSO
                           | DECIMAL
                           | ENTERO
                           | ABRIRPARENTESIS + tipo + CERRARPARENTESIS + expresion
                           | Lista_acceso
                           | NUEVO + instanciaobjeto
                        /////List @hola= new List<List<String>>;
                        //@hola.get(0).insert("hola")
                        //Map @var = new Map<String,Map<String,SET<List<String>>>>;
                        ;
            Lista_clave_valor.Rule = MakePlusRule(Lista_clave_valor, COMA, clave_valor);

            clave_valor.Rule = expresion + DOSPUNTOS + expresion;

            instanciaobjeto.Rule = tipo
                                  | tipo + MENOR + instanciaobjeto + MAYOR
                                  | tipo + MENOR + tipo + COMA + instanciaobjeto + MAYOR;

            OPERACIONPOST.Rule = Lista_acceso + INC
                                | Lista_acceso + DEC
                                ;
            operacionesunariomenos.Rule = MENOS + expresion+ReduceHere();
            operacionesunarionegacion.Rule = NEGACION + expresion;

            llamada.Rule = IDENTIFICADOR + ABRIRPARENTESIS + CERRARPARENTESIS
                           | IDENTIFICADOR + ABRIRPARENTESIS + Listavalores + CERRARPARENTESIS
                           | CALL + IDENTIFICADOR + ABRIRPARENTESIS + CERRARPARENTESIS
                           | CALL + IDENTIFICADOR + ABRIRPARENTESIS + Listavalores + CERRARPARENTESIS
                           | llamada_a_nativas;

            llamada_a_nativas.Rule = LENGTH + ABRIRPARENTESIS + CERRARPARENTESIS
                                   | STARTSWITH + ABRIRPARENTESIS + CERRARPARENTESIS
                                   | TOUPPER + ABRIRPARENTESIS + CERRARPARENTESIS
                                   | TOLOWER + ABRIRPARENTESIS + CERRARPARENTESIS
                                   | ENDSWITH + ABRIRPARENTESIS + CERRARPARENTESIS
                                   | SUBSTRING + ABRIRPARENTESIS + expresion + COMA + expresion + CERRARPARENTESIS
                                   | GETYEAR + ABRIRPARENTESIS + CERRARPARENTESIS
                                   | GETMONTH + ABRIRPARENTESIS + CERRARPARENTESIS
                                   | GETDAY + ABRIRPARENTESIS + CERRARPARENTESIS
                                   | GETHOUR + ABRIRPARENTESIS + CERRARPARENTESIS
                                   | GETMINUTE + ABRIRPARENTESIS + CERRARPARENTESIS
                                   | GETSECOND + ABRIRPARENTESIS + CERRARPARENTESIS
                                   | TODAY + ABRIRPARENTESIS + CERRARPARENTESIS
                                   | NOW + ABRIRPARENTESIS + CERRARPARENTESIS
                                   | INSERT + ABRIRPARENTESIS + expresion + CERRARPARENTESIS
                                   | GET + ABRIRPARENTESIS + expresion + CERRARPARENTESIS
                                   | SET + ABRIRPARENTESIS + expresion + COMA + expresion + CERRARPARENTESIS
                                   | REMOVE + ABRIRPARENTESIS + expresion + CERRARPARENTESIS
                                   | SIZE + ABRIRPARENTESIS + CERRARPARENTESIS
                                   | CLEAR + ABRIRPARENTESIS + CERRARPARENTESIS
                                   | CONTAINS + ABRIRPARENTESIS + expresion + CERRARPARENTESIS
                                   | MESSAGE +ABRIRPARENTESIS+CERRARPARENTESIS
                                   ;
            Asignacion_Multiple_Lista.Rule = Asignacion_Multiple + IGUAL + llamada+PUNTOCOMA;
            Asignacion_Multiple.Rule = MakePlusRule(Asignacion_Multiple,COMA,Lista_acceso);
            Lista_acceso.Rule = MakePlusRule(Lista_acceso, PUNTO, Acceso);

            Acceso.Rule = ARROBA + IDENTIFICADOR
                                | IDENTIFICADOR
                                | IDENTIFICADOR + ABRIRCOR + expresion + CERRARCOR
                                | llamada
                                ;

            #endregion
            #region Preferencias
            this.Root = inicial;
            #endregion

        }
    }
}