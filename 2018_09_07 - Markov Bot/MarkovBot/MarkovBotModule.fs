module MarkovBotModule
open System
open System.Collections
open System.Linq
open System.Collections.Generic

let getWords (sample:string) =
    sample.Split([|' '; '\r'; '\n'|], StringSplitOptions.RemoveEmptyEntries) |> Array.toList

let rec getBiGrams (words) =
    match words with
    | el1::el2::rest -> (el1,el2)::getBiGrams(el2::rest)
    | _ -> []

let random = System.Random(100)

let pickRandom list =
    let randomNumber = random.Next(List.length list)
    list |> List.skip randomNumber |> List.head

let rec generateFrom' (startWord:string) sample  =
    let x = 
            sample
            |> getWords 
            |> getBiGrams 
            |> List.filter (fun (x, _) -> x = startWord) 
            |> List.map snd
            |> pickRandom
    seq{
        yield startWord
        yield! generateFrom' x sample    
        }

let takeWhileAndOne predicate (s:seq<_>) = 
  /// Iterates over the enumerator, yielding elements and
  /// stops after an element for which the predicate does not hold
  let rec loop (en:IEnumerator<_>) = seq {
    if en.MoveNext() then
      // Always yield the current, stop if predicate does not hold
      yield en.Current
      if predicate en.Current then
        yield! loop en }

  // Get enumerator of the sequence and yield all results
  // (making sure that the enumerator gets disposed)
  seq { use en = s.GetEnumerator()
        yield! loop en }

let generateFrom startWord sample =
    let generatedWord = generateFrom' startWord sample
    generatedWord
    |> takeWhileAndOne (fun x -> not (x.EndsWith '.')) 
    |> String.concat " "