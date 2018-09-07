module MarkovBotModule
open System

let generateFrom (startWord:string) (sample:string) (n:int) :string =
    ""

let getWords (sample:string) =
    sample.Split([|' '; '\r'; '\n'|], StringSplitOptions.RemoveEmptyEntries)