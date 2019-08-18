/**
 * Proyecto 1 Compiladores 2 analizador para CQL Lado Cliente 
 * Fernando Antonio Hernandez Gramajo
 * 201403624
 * 
 */

/* Definiciones Léxicas */
%lex

%options case-insensitive

%%

";"					return 'PUNTOCOMA';
"("					return 'PARENTESISIZQUIERDO';
")"					return 'PARENTESISDERECHO';
"["					return 'CORCHETEIZQUIERDO';
"]"					return 'CORCHETEDERECHO';

"+"					return 'MAS';
"-"					return 'MENOS';
"*"					return 'POR';
"/"					return 'DIVIDIDO';
"**"                return 'POTENCIA';
	

/* Espacios en blanco */
\n					{}
\s+											// se ignoran espacios en blanco

/* Comentarios Una y Multilinea*/
"//".*										// comentario simple línea
[/][*][^*]*[*]+([^/*][^*]*[*]+)*[/]			// comentario multiple líneas

/* Cadenas */
\"[^\"]*\"				{ yytext = yytext.substr(1,yyleng-2); return 'CADENA'; }
\'[^\"]*\'				{ yytext = yytext.substr(1,yyleng-2); return 'CADENASIMPLE'; }

/* datos primitivos */
[0-9]+("."[0-9]+)?\b  	return 'DECIMAL';
[0-9]+\b				return 'ENTERO';
"true"                  return 'VERDADERO';
"false"                 return 'FALSO';


"null"                  return 'NULO';
([a-zA-Z])[a-zA-Z0-9_]*	return 'IDENTIFICADOR';

<<EOF>>				return 'EOF';

.					{ console.error('Este es un error léxico: ' + yytext + ', en la linea: ' + yylloc.first_line + ', en la columna: ' + yylloc.first_column); }
/lex



/* Asociación de operadores y precedencia */

%left 'MAS' 'MENOS'
%left 'POR' 'DIVIDIDO'
%left UMENOS

%start ini

%% /* Definición de la gramática */

ini
	: instrucciones EOF{

		return $1;
	}
;

instrucciones
	: instruccion instrucciones{$$ = $1 +'\n'+ $2}
	| instruccion{ $$ = $1;}
	| error { console.error('Este es un error sintáctico: ' + yytext + ', en la linea: ' + this._$.first_line + ', en la columna: ' + this._$.first_column); }
;

instruccion
	: REVALUAR CORIZQ expresion CORDER PTCOMA {
		$$ = 'El valor de la expresión es: ' + $3;
	}
;


expresion
	: MENOS expresion %prec UMENOS	{ $$ = $2 *-1; }
	| expresion MAS expresion		{ $$ = $1 + $3; }
	| expresion MENOS expresion		{ $$ = $1 - $3; }
	| expresion POR expresion		{ $$ = $1 * $3; }
	| expresion DIVIDIDO expresion	{ $$ = $1 / $3; }
	| ENTERO						{ $$ = Number($1); }
	| DECIMAL						{ $$ = Number($1); }
	| PARIZQ expresion PARDER		{ $$ = $2; }
;