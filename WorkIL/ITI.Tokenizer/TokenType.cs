using System;

namespace ITI.Tokenizer
{
    public enum TokenType
    {
        None,
        Plus,
        Minus,
        Mult,
        Div,
        Number,
        Identifier,
        OpenPar,
        ClosePar,
        OpenSquare,
        CloseSquare,
        OpenBracket,
        CloseBracket,

        Comma,
        Dot,
        SemiColon,
        Colon,
        DoubleColon,
        QuestionMark,

        EndOfInput,
        Error
    }
}
