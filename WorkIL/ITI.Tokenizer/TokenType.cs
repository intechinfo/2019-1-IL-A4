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
        OpenPar,
        ClosePar,
        SemiColon,
        Colon,
        DoubleColon,
        Comma,
        Dot,
        OpenSquare,
        CloseSquare,
        OpenBracket,
        CloseBracket,

        EndOfInput,
        Error
    }
}
