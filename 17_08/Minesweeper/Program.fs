// Learn more about F# at http://fsharp.org

type Coordinate = {X:int;Y:int}
type Cell = Mine|Hint of int
let mines = [{X=25;Y=25};{X=26;Y=26}]

let getBlowArea mine =
    seq {
        for x = -1 to 1 do 
            for y = -1 to 1 do
                yield {X = mine.X + x; Y = mine.Y + y}
    }

let transformToHints mines =
    Seq.collect (fun m -> getBlowArea m) mines
    |> Seq.groupBy (fun c -> c)
    |> Seq.map (fun (c, list) -> (c, if Seq.contains c mines then Mine else Hint (Seq.length list)))

let printCoord coord combined =
    match Map.tryFind coord combined with
        | Some Mine -> "*"
        | Some (Hint x)-> x.ToString()
        | None -> "0"

let printBoard mines maxX maxY =
    let combined = Map.ofSeq (transformToHints mines) 
    for x = 0 to maxX - 1 do
        for y = 0 to maxY - 1 do
            printf "%s" (printCoord {X = x;Y = y} combined)
        printfn ""

open System

[<EntryPoint>]
let main argv =
    printBoard mines 30 30
    0 // return an integer exit code
