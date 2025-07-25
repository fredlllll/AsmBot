//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from asmbotGrammar.g4 by ANTLR 4.13.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.2")]
[System.CLSCompliant(false)]
public partial class asmbotGrammarParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, REGISTER=5, NUMBER=6, HEX_NUMBER=7, IDENT=8, 
		NEWLINE=9, COMMENT=10, WS=11;
	public const int
		RULE_prog = 0, RULE_line = 1, RULE_lastLine = 2, RULE_lineContent = 3, 
		RULE_labelDef = 4, RULE_instr = 5, RULE_operandList = 6, RULE_operand = 7, 
		RULE_registerOperand = 8, RULE_memoryOperand = 9, RULE_labelOperand = 10, 
		RULE_immediateOperand = 11, RULE_register = 12, RULE_label = 13, RULE_immediate = 14;
	public static readonly string[] ruleNames = {
		"prog", "line", "lastLine", "lineContent", "labelDef", "instr", "operandList", 
		"operand", "registerOperand", "memoryOperand", "labelOperand", "immediateOperand", 
		"register", "label", "immediate"
	};

	private static readonly string[] _LiteralNames = {
		null, "':'", "','", "'['", "']'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, "REGISTER", "NUMBER", "HEX_NUMBER", "IDENT", 
		"NEWLINE", "COMMENT", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "asmbotGrammar.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static asmbotGrammarParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public asmbotGrammarParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public asmbotGrammarParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class ProgContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode Eof() { return GetToken(asmbotGrammarParser.Eof, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public LineContext[] line() {
			return GetRuleContexts<LineContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public LineContext line(int i) {
			return GetRuleContext<LineContext>(i);
		}
		public ProgContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_prog; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.EnterProg(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.ExitProg(this);
		}
	}

	[RuleVersion(0)]
	public ProgContext prog() {
		ProgContext _localctx = new ProgContext(Context, State);
		EnterRule(_localctx, 0, RULE_prog);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 31;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 30;
				line();
				}
				}
				State = 33;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==IDENT || _la==NEWLINE );
			State = 35;
			Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LineContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE() { return GetToken(asmbotGrammarParser.NEWLINE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public LineContentContext lineContent() {
			return GetRuleContext<LineContentContext>(0);
		}
		public LineContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_line; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.EnterLine(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.ExitLine(this);
		}
	}

	[RuleVersion(0)]
	public LineContext line() {
		LineContext _localctx = new LineContext(Context, State);
		EnterRule(_localctx, 2, RULE_line);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 38;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==IDENT) {
				{
				State = 37;
				lineContent();
				}
			}

			State = 40;
			Match(NEWLINE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LastLineContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public LineContentContext lineContent() {
			return GetRuleContext<LineContentContext>(0);
		}
		public LastLineContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_lastLine; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.EnterLastLine(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.ExitLastLine(this);
		}
	}

	[RuleVersion(0)]
	public LastLineContext lastLine() {
		LastLineContext _localctx = new LastLineContext(Context, State);
		EnterRule(_localctx, 4, RULE_lastLine);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 42;
			lineContent();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LineContentContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public LabelDefContext labelDef() {
			return GetRuleContext<LabelDefContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public InstrContext instr() {
			return GetRuleContext<InstrContext>(0);
		}
		public LineContentContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_lineContent; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.EnterLineContent(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.ExitLineContent(this);
		}
	}

	[RuleVersion(0)]
	public LineContentContext lineContent() {
		LineContentContext _localctx = new LineContentContext(Context, State);
		EnterRule(_localctx, 6, RULE_lineContent);
		try {
			State = 46;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,2,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 44;
				labelDef();
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 45;
				instr();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LabelDefContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public LabelContext label() {
			return GetRuleContext<LabelContext>(0);
		}
		public LabelDefContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_labelDef; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.EnterLabelDef(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.ExitLabelDef(this);
		}
	}

	[RuleVersion(0)]
	public LabelDefContext labelDef() {
		LabelDefContext _localctx = new LabelDefContext(Context, State);
		EnterRule(_localctx, 8, RULE_labelDef);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 48;
			label();
			State = 49;
			Match(T__0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class InstrContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENT() { return GetToken(asmbotGrammarParser.IDENT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public OperandListContext operandList() {
			return GetRuleContext<OperandListContext>(0);
		}
		public InstrContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_instr; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.EnterInstr(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.ExitInstr(this);
		}
	}

	[RuleVersion(0)]
	public InstrContext instr() {
		InstrContext _localctx = new InstrContext(Context, State);
		EnterRule(_localctx, 10, RULE_instr);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 51;
			Match(IDENT);
			State = 53;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 488L) != 0)) {
				{
				State = 52;
				operandList();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class OperandListContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public OperandContext[] operand() {
			return GetRuleContexts<OperandContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public OperandContext operand(int i) {
			return GetRuleContext<OperandContext>(i);
		}
		public OperandListContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_operandList; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.EnterOperandList(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.ExitOperandList(this);
		}
	}

	[RuleVersion(0)]
	public OperandListContext operandList() {
		OperandListContext _localctx = new OperandListContext(Context, State);
		EnterRule(_localctx, 12, RULE_operandList);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 55;
			operand();
			State = 60;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__1) {
				{
				{
				State = 56;
				Match(T__1);
				State = 57;
				operand();
				}
				}
				State = 62;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class OperandContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public RegisterOperandContext registerOperand() {
			return GetRuleContext<RegisterOperandContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public MemoryOperandContext memoryOperand() {
			return GetRuleContext<MemoryOperandContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public LabelOperandContext labelOperand() {
			return GetRuleContext<LabelOperandContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ImmediateOperandContext immediateOperand() {
			return GetRuleContext<ImmediateOperandContext>(0);
		}
		public OperandContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_operand; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.EnterOperand(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.ExitOperand(this);
		}
	}

	[RuleVersion(0)]
	public OperandContext operand() {
		OperandContext _localctx = new OperandContext(Context, State);
		EnterRule(_localctx, 14, RULE_operand);
		try {
			State = 67;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case REGISTER:
				EnterOuterAlt(_localctx, 1);
				{
				State = 63;
				registerOperand();
				}
				break;
			case T__2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 64;
				memoryOperand();
				}
				break;
			case IDENT:
				EnterOuterAlt(_localctx, 3);
				{
				State = 65;
				labelOperand();
				}
				break;
			case NUMBER:
			case HEX_NUMBER:
				EnterOuterAlt(_localctx, 4);
				{
				State = 66;
				immediateOperand();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class RegisterOperandContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public RegisterContext register() {
			return GetRuleContext<RegisterContext>(0);
		}
		public RegisterOperandContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_registerOperand; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.EnterRegisterOperand(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.ExitRegisterOperand(this);
		}
	}

	[RuleVersion(0)]
	public RegisterOperandContext registerOperand() {
		RegisterOperandContext _localctx = new RegisterOperandContext(Context, State);
		EnterRule(_localctx, 16, RULE_registerOperand);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 69;
			register();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class MemoryOperandContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public RegisterContext register() {
			return GetRuleContext<RegisterContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public LabelContext label() {
			return GetRuleContext<LabelContext>(0);
		}
		public MemoryOperandContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_memoryOperand; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.EnterMemoryOperand(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.ExitMemoryOperand(this);
		}
	}

	[RuleVersion(0)]
	public MemoryOperandContext memoryOperand() {
		MemoryOperandContext _localctx = new MemoryOperandContext(Context, State);
		EnterRule(_localctx, 18, RULE_memoryOperand);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 71;
			Match(T__2);
			State = 74;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case REGISTER:
				{
				State = 72;
				register();
				}
				break;
			case IDENT:
				{
				State = 73;
				label();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			State = 76;
			Match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LabelOperandContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public LabelContext label() {
			return GetRuleContext<LabelContext>(0);
		}
		public LabelOperandContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_labelOperand; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.EnterLabelOperand(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.ExitLabelOperand(this);
		}
	}

	[RuleVersion(0)]
	public LabelOperandContext labelOperand() {
		LabelOperandContext _localctx = new LabelOperandContext(Context, State);
		EnterRule(_localctx, 20, RULE_labelOperand);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 78;
			label();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ImmediateOperandContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ImmediateContext immediate() {
			return GetRuleContext<ImmediateContext>(0);
		}
		public ImmediateOperandContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_immediateOperand; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.EnterImmediateOperand(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.ExitImmediateOperand(this);
		}
	}

	[RuleVersion(0)]
	public ImmediateOperandContext immediateOperand() {
		ImmediateOperandContext _localctx = new ImmediateOperandContext(Context, State);
		EnterRule(_localctx, 22, RULE_immediateOperand);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 80;
			immediate();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class RegisterContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode REGISTER() { return GetToken(asmbotGrammarParser.REGISTER, 0); }
		public RegisterContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_register; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.EnterRegister(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.ExitRegister(this);
		}
	}

	[RuleVersion(0)]
	public RegisterContext register() {
		RegisterContext _localctx = new RegisterContext(Context, State);
		EnterRule(_localctx, 24, RULE_register);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 82;
			Match(REGISTER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LabelContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENT() { return GetToken(asmbotGrammarParser.IDENT, 0); }
		public LabelContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_label; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.EnterLabel(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.ExitLabel(this);
		}
	}

	[RuleVersion(0)]
	public LabelContext label() {
		LabelContext _localctx = new LabelContext(Context, State);
		EnterRule(_localctx, 26, RULE_label);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 84;
			Match(IDENT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ImmediateContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NUMBER() { return GetToken(asmbotGrammarParser.NUMBER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode HEX_NUMBER() { return GetToken(asmbotGrammarParser.HEX_NUMBER, 0); }
		public ImmediateContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_immediate; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.EnterImmediate(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IasmbotGrammarListener typedListener = listener as IasmbotGrammarListener;
			if (typedListener != null) typedListener.ExitImmediate(this);
		}
	}

	[RuleVersion(0)]
	public ImmediateContext immediate() {
		ImmediateContext _localctx = new ImmediateContext(Context, State);
		EnterRule(_localctx, 28, RULE_immediate);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 86;
			_la = TokenStream.LA(1);
			if ( !(_la==NUMBER || _la==HEX_NUMBER) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static int[] _serializedATN = {
		4,1,11,89,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,6,2,7,
		7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,7,14,
		1,0,4,0,32,8,0,11,0,12,0,33,1,0,1,0,1,1,3,1,39,8,1,1,1,1,1,1,2,1,2,1,3,
		1,3,3,3,47,8,3,1,4,1,4,1,4,1,5,1,5,3,5,54,8,5,1,6,1,6,1,6,5,6,59,8,6,10,
		6,12,6,62,9,6,1,7,1,7,1,7,1,7,3,7,68,8,7,1,8,1,8,1,9,1,9,1,9,3,9,75,8,
		9,1,9,1,9,1,10,1,10,1,11,1,11,1,12,1,12,1,13,1,13,1,14,1,14,1,14,0,0,15,
		0,2,4,6,8,10,12,14,16,18,20,22,24,26,28,0,1,1,0,6,7,82,0,31,1,0,0,0,2,
		38,1,0,0,0,4,42,1,0,0,0,6,46,1,0,0,0,8,48,1,0,0,0,10,51,1,0,0,0,12,55,
		1,0,0,0,14,67,1,0,0,0,16,69,1,0,0,0,18,71,1,0,0,0,20,78,1,0,0,0,22,80,
		1,0,0,0,24,82,1,0,0,0,26,84,1,0,0,0,28,86,1,0,0,0,30,32,3,2,1,0,31,30,
		1,0,0,0,32,33,1,0,0,0,33,31,1,0,0,0,33,34,1,0,0,0,34,35,1,0,0,0,35,36,
		5,0,0,1,36,1,1,0,0,0,37,39,3,6,3,0,38,37,1,0,0,0,38,39,1,0,0,0,39,40,1,
		0,0,0,40,41,5,9,0,0,41,3,1,0,0,0,42,43,3,6,3,0,43,5,1,0,0,0,44,47,3,8,
		4,0,45,47,3,10,5,0,46,44,1,0,0,0,46,45,1,0,0,0,47,7,1,0,0,0,48,49,3,26,
		13,0,49,50,5,1,0,0,50,9,1,0,0,0,51,53,5,8,0,0,52,54,3,12,6,0,53,52,1,0,
		0,0,53,54,1,0,0,0,54,11,1,0,0,0,55,60,3,14,7,0,56,57,5,2,0,0,57,59,3,14,
		7,0,58,56,1,0,0,0,59,62,1,0,0,0,60,58,1,0,0,0,60,61,1,0,0,0,61,13,1,0,
		0,0,62,60,1,0,0,0,63,68,3,16,8,0,64,68,3,18,9,0,65,68,3,20,10,0,66,68,
		3,22,11,0,67,63,1,0,0,0,67,64,1,0,0,0,67,65,1,0,0,0,67,66,1,0,0,0,68,15,
		1,0,0,0,69,70,3,24,12,0,70,17,1,0,0,0,71,74,5,3,0,0,72,75,3,24,12,0,73,
		75,3,26,13,0,74,72,1,0,0,0,74,73,1,0,0,0,75,76,1,0,0,0,76,77,5,4,0,0,77,
		19,1,0,0,0,78,79,3,26,13,0,79,21,1,0,0,0,80,81,3,28,14,0,81,23,1,0,0,0,
		82,83,5,5,0,0,83,25,1,0,0,0,84,85,5,8,0,0,85,27,1,0,0,0,86,87,7,0,0,0,
		87,29,1,0,0,0,7,33,38,46,53,60,67,74
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
