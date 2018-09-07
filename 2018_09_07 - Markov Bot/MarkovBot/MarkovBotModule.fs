module MarkovBotModule
open System

let generateFrom (startWord:string) (sample:string) (n:int) :string =
    ""

let getWords (sample:string) =
    sample.Split([|' '; '\r'; '\n'|], StringSplitOptions.RemoveEmptyEntries) |> Array.toList

let rec getBiGrams (words) =
    match words with
    | el1::el2::rest -> (el1,el2)::getBiGrams(el2::rest)
    | el::rest -> []
    | [] -> []