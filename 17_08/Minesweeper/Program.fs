// Learn more about F# at http://fsharp.org

type Coordinate = {X:int;Y:int}
let coords = [{X=25;Y=25};{X=26;Y=26}]

let getBlowArea mine =
    seq {
        for x = -1 to 1 do 
            for y = -1 to 1 do
                yield {X = mine.X + x; Y = mine.Y + y}
    }

let transformToHints mines =
    Seq.collect (fun m -> getBlowArea m) mines
    |> Seq.groupBy (fun c -> c)
    |> Seq.filter (fun (c, _) -> not (Seq.contains c mines))
    |> Seq.map (fun (c, list) -> (c, Seq.length list))


open System

[<EntryPoint>]
let main argv =
    Seq.iter (fun x -> printfn "%A"x) (transformToHints coords)

    0 // return an integer exit code
