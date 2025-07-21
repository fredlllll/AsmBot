grammar asmbotGrammar;

//prog: line* lastLine? EOF;
prog: line+ EOF;

line: lineContent? NEWLINE;
lastLine: lineContent;

lineContent: labelDef | instr;

labelDef: label ':';

instr: IDENT operandList?;

operandList: operand (',' operand)*;

operand : registerOperand | memoryOperand | labelOperand | immediateOperand;

registerOperand : register;
memoryOperand : '[' (register | label) ']';
labelOperand: label;
immediateOperand: immediate;

register: REGISTER;

label: IDENT;

immediate: NUMBER | HEX_NUMBER;

REGISTER: 'ax' | 'ah' | 'al' | 'bx' | 'bh' | 'bl' | 'cx' | 'ch' | 'cl' | 'dx' | 'dh' | 'dl' | 'si' | 'di' | 'sp' | 'bp' | 'ds' | 'ss';
NUMBER: [0-9]+;
HEX_NUMBER: [0-9A-Fa-f]+ ('h'|'H');
IDENT: [a-zA-Z_][a-zA-Z0-9_]*;
NEWLINE: [\r\n]+;
COMMENT: ';' ~[\r\n]* -> skip;
WS: [ \t]+ -> skip;
