module Ast

    open System
    open System.Collections.Generic


    type pos = int
    type Symbol = string
   
    type Comment = string

    type Exp = 
        | IntExp of int
        | VarExp of (string * int)
        | DimExp

    type Prog = Prog of Exp list

    let exprToStr expr =
        match expr with
        | IntExp n -> "IntExp: " + n.ToString()
        //| StringExp s -> "StringExp: " + s
        | VarExp (s, l) -> sprintf "VarExp: %s (line=%d)" s l
        | DimExp -> "DimExp"
        
    let progToStr (Prog exprs) = 
        let sExprs = List.map exprToStr exprs
    
        "Prog " + String.Join(", ", sExprs)


