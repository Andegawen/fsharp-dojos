// Learn more about F# at http://fsharp.org

type Coordinate = {X:int;Y:int}
let coords = [{X=25;Y=25};{X=26;Y=26}]

open System

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
